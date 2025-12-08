using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPBOLOV2.DAO
{
    public class AssessorDAO
    {
        private string stringConexao = "Server=localhost;Database=db_bolodecoracao;Uid=root;Pwd=123;";

        // Adiciona um novo assessor ao banco
        public int AdicionarAssessor(Assessor assessor)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "INSERT INTO assessor (Nome, Endereco, Celular) VALUES (@Nome, @Endereco, @Celular)";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", assessor.Nome ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Endereco", assessor.Endereco ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Celular", assessor.Celular ?? (object)DBNull.Value);

                    comando.ExecuteNonQuery();

                    using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conexao))
                    {
                        var result = cmdId.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                            return newId;
                    }
                }
                return 0;
            }
        }

        // Retorna todos os assessores do banco
        public List<Assessor> ObterTodosAssessores()
        {
            var assessores = new List<Assessor>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Endereco, Celular FROM assessor";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var assessor = new Assessor
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader["Nome"]?.ToString(),
                                Endereco = reader["Endereco"]?.ToString(),
                                Celular = reader["Celular"]?.ToString()
                            };
                            assessores.Add(assessor);
                        }
                    }
                }
            }
            return assessores;
        }

        // Obtem assessores por nome
        public List<Assessor> ObterAssessoresPorNome(string nome)
        {
            var assessores = new List<Assessor>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Endereco, Celular FROM assessor WHERE Nome LIKE @Nome";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var assessor = new Assessor
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader["Nome"]?.ToString(),
                                Endereco = reader["Endereco"]?.ToString(),
                                Celular = reader["Celular"]?.ToString()
                            };
                            assessores.Add(assessor);
                        }
                    }
                }
            }
            return assessores;
        }
    }
}
