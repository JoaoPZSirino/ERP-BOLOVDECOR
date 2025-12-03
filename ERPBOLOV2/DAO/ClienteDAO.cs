using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // Biblioteca do MySQL

namespace ERPBOLOV2
{
    public class ClienteDAO
    {
        private string stringConexao = "Server=localhost;Database=db_bolodecoracao;Uid=root;Pwd=123;";

        public int AdicionarCliente(Cliente cliente)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "INSERT INTO cliente " +
                    "(Nome, Nacionalidade, EstadoCivil, Profissao, Endereco, Cep, CidadeEstado, RG, CPF, Email, Celular) " +
                    "VALUES " +
                    "(@Nome, @Nacionalidade, @EstadoCivil, @Profissao, @Endereco, @Cep, @CidadeEstado, @RG, @CPF, @Email, @Celular)";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", cliente.Nome ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Endereco", cliente.Endereco ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@EstadoCivil", cliente.EstadoCivil ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Cep", cliente.CEP ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@CidadeEstado", cliente.CidadeEstado ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@CPF", cliente.CPF ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Email", cliente.Email ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Nacionalidade", cliente.Nacionalidade ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Profissao", cliente.Profissao ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@RG", cliente.RG ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Celular", cliente.Celular ?? (object)DBNull.Value);

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

        // Atualiza os dados do cliente
        public bool AtualizarCliente(Cliente cliente)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "UPDATE cliente SET " +
                    "Nome = @Nome, " +
                    "Nacionalidade = @Nacionalidade, " +
                    "EstadoCivil = @EstadoCivil, " +
                    "Profissao = @Profissao, " +
                    "Endereco = @Endereco, " +
                    "Cep = @Cep, " +
                    "CidadeEstado = @CidadeEstado, " +
                    "RG = @RG, " +
                    "CPF = @CPF, " +
                    "Email = @Email " +
                    "Celular = @Celular " +
                    "WHERE Id = @Id";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", cliente.Nome ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Endereco", cliente.Endereco ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@EstadoCivil", cliente.EstadoCivil ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Cep", cliente.CEP ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@CidadeEstado", cliente.CidadeEstado ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@CPF", cliente.CPF ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Email", cliente.Email ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Nacionalidade", cliente.Nacionalidade ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Profissao", cliente.Profissao ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@RG", cliente.RG ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Celular", cliente.Celular ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Id", cliente.Id);
                    int linhasAfetadas = comando.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
            }
        }

        // Exclui um cliente pelo Id
        public bool ExcluirCliente(int clienteId)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "DELETE FROM cliente WHERE Id = @Id";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", clienteId);
                    int linhasAfetadas = comando.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
            }
        }


        // Retorna todos os clientes do banco
        public List<Cliente> ObterTodosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Nacionalidade, EstadoCivil, Profissao, Endereco, Cep, CidadeEstado, RG, CPF, Email, Celular FROM cliente";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    using (MySqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Id = leitor.GetInt32("Id"),
                                Nome = leitor["Nome"] as string,
                                Nacionalidade = leitor["Nacionalidade"] as string,
                                EstadoCivil = leitor["EstadoCivil"] as string,
                                Profissao = leitor["Profissao"] as string,
                                Endereco = leitor["Endereco"] as string,
                                CEP = leitor["Cep"] as string,
                                CidadeEstado = leitor["CidadeEstado"] as string,
                                RG = leitor["RG"] as string,
                                CPF = leitor["CPF"] as string,
                                Email = leitor["Email"] as string,
                                Celular = leitor["Celular"] as string
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
            }
            return clientes;
        }

        // filtro por nome (retorna todos se filtro for vazio)
        public List<Cliente> ObterClientesPorNome(string nomeFiltro)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (MySqlConnection conexao = new MySqlConnection(stringConexao))
            {
                conexao.Open();
                string sql = "SELECT Id, Nome, Nacionalidade, EstadoCivil, Profissao, Endereco, Cep, CidadeEstado, RG, CPF, Email, Celular FROM cliente ";
                if (!string.IsNullOrEmpty(nomeFiltro))
                {
                    sql += "WHERE Nome LIKE @NomeFiltro ";
                }
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    if (!string.IsNullOrEmpty(nomeFiltro))
                    {
                        comando.Parameters.AddWithValue("@NomeFiltro", "%" + nomeFiltro + "%");
                    }
                    using (MySqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Id = leitor.GetInt32("Id"),
                                Nome = leitor["Nome"] as string,
                                Nacionalidade = leitor["Nacionalidade"] as string,
                                EstadoCivil = leitor["EstadoCivil"] as string,
                                Profissao = leitor["Profissao"] as string,
                                Endereco = leitor["Endereco"] as string,
                                CEP = leitor["Cep"] as string,
                                CidadeEstado = leitor["CidadeEstado"] as string,
                                RG = leitor["RG"] as string,
                                CPF = leitor["CPF"] as string,
                                Email = leitor["Email"] as string,
                                Celular = leitor["Celular"] as string
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
            }
            return clientes;
        }
    }
}
