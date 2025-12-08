using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ERPBOLOV2.DAO
{
    public class DecoradorDAO
    {
        private string stringConexao = "Server=localhost;Database=db_bolodecoracao;Uid=root;Pwd=123;";

        public int AdicionarDecorador(Decorador decorador)
        {
            // Adiciona um novo cliente ao banco
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "INSERT INTO decorador " +
                    "(Nome, Endereco, Celular) " +
                    "VALUES " +
                    "( @Nome, @Endereco, @Celular)";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", decorador.Nome ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Endereco", decorador.Endereco ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Celular", decorador.Celular ?? (object)DBNull.Value);

                    comando.ExecuteNonQuery();

                    // obtém id gerado
                    using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conexao))
                    {
                        var result = cmdId.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                            return newId;
                    }
                }
                return 0; // falha ao obter id
            }

        }

        // Obtem todos os decoradores
        public List<Decorador> ObterTodosDecoradores()
        {
            var decoradores = new List<Decorador>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Endereco, Celular FROM decorador";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var decorador = new Decorador
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader["Nome"]?.ToString(),
                                Endereco = reader["Endereco"]?.ToString(),
                                Celular = reader["Celular"]?.ToString()
                            };
                            decoradores.Add(decorador);
                        }
                    }
                }
            }
            return decoradores;
        }

        //Obtem decoradores por nome
        public List<Decorador> ObterDecoradoresPorNome(string nome)
        {
            var decoradores = new List<Decorador>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Endereco, Celular FROM decorador WHERE Nome LIKE @Nome";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var decorador = new Decorador
                            {
                                Id = reader.GetInt32("id"),
                                Nome = reader["Nome"]?.ToString(),
                                Endereco = reader["Endereco"]?.ToString(),
                                Celular = reader["Celular"]?.ToString()
                            };
                            decoradores.Add(decorador);
                        }
                    }
                }
            }
            return decoradores;
        }

    }
}
