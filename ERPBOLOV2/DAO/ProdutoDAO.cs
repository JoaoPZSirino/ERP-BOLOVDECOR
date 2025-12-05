using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPBOLOV2.DAO
{
    public class ProdutoDAO
    {
        private string stringConexao = "Server=localhost;Database=db_bolodecoracao;Uid=root;Pwd=123;";

        public int AdicionarProduto(Produto produto)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "INSERT INTO produto (Codigo, Modelo, Cor, Altura, Topo, Base, ValorLocacao) VALUES (@Codigo, @Modelo, @Cor, @Altura, @Topo, @Base, @ValorLocacao)";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Codigo", produto.Codigo ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Modelo", (int)produto.Modelo);
                    comando.Parameters.AddWithValue("@Cor", produto.Cor ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Altura", produto.Altura);
                    comando.Parameters.AddWithValue("@Topo", produto.Topo);
                    comando.Parameters.AddWithValue("@Base", produto.Base);
                    comando.Parameters.AddWithValue("@ValorLocacao", produto.ValorLocacao);

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

        public List<Produto> ObterTodosProdutos()
        {
            var produtos = new List<Produto>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Codigo, Modelo, Cor, Altura, Topo, Base, ValorLocacao FROM produto";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var produto = new Produto
                            {
                                Id = reader.GetInt32("Id"),
                                Codigo = reader["Codigo"]?.ToString(),
                                Modelo = (TipoModelo)reader.GetInt32("Modelo"),
                                Cor = reader["Cor"]?.ToString(),
                                Altura = reader.GetDecimal("Altura"),
                                Topo = reader.GetDecimal("Topo"),
                                Base = reader.GetDecimal("Base"),
                                ValorLocacao = reader.GetDecimal("ValorLocacao")
                            };
                            produtos.Add(produto);
                        }
                    }
                }
            }
            return produtos;
        }

    }


}
