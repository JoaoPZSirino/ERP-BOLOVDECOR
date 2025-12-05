using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPBOLOV2.DAO
{
    public class LocalDAO
    {
        private string stringConexao = "Server=localhost;Database=db_bolodecoracao;Uid=root;Pwd=123;";

        // Obter todos os locais
        public List<Local> ObterTodosLocais()
        {
            var locais = new List<Local>();
            using (MySql.Data.MySqlClient.MySqlConnection conexao = new MySql.Data.MySqlClient.MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Endereco, Celular FROM local";
                using (MySql.Data.MySqlClient.MySqlCommand comando = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                {
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var local = new Local
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                Endereco = reader.GetString("Endereco"),
                                Celular = reader.GetString("Celular")
                            };
                            locais.Add(local);
                        }
                    }
                }
            }
            return locais;
        }

        // Adicionar um novo local
        public int AdicionarLocal(Local local)
        {
            using (MySql.Data.MySqlClient.MySqlConnection conexao = new MySql.Data.MySqlClient.MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "INSERT INTO local " +
                    "(Nome, Endereco, Celular) " +
                    "VALUES " +
                    "( @Nome, @Endereco, @Celular)";
                using (MySql.Data.MySqlClient.MySqlCommand comando = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", local.Nome ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Endereco", local.Endereco ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Celular", local.Celular ?? (object)DBNull.Value);
                    comando.ExecuteNonQuery();
                    // obtém id gerado
                    using (var cmdId = new MySql.Data.MySqlClient.MySqlCommand("SELECT LAST_INSERT_ID();", conexao))
                    {
                        var result = cmdId.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                            return newId;
                    }
                }
                return 0; // falha ao obter id
            }
        }

        // filtrar por nome do local
        public List<Local> FiltrarLocaisPorNome(string nome)
        {
            var locais = new List<Local>();
            using (MySql.Data.MySqlClient.MySqlConnection conexao = new MySql.Data.MySqlClient.MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Endereco, Celular FROM local WHERE Nome LIKE @Nome";
                using (MySql.Data.MySqlClient.MySqlCommand comando = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var local = new Local
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                Endereco = reader.GetString("Endereco"),
                                Celular = reader.GetString("Celular")
                            };
                            locais.Add(local);
                        }
                    }
                }
            }
            return locais;
        }
    }
}
