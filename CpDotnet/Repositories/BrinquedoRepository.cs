using CpDotnet.Interfaces;
using CpDotnet.Models;
using Oracle.ManagedDataAccess.Client;

namespace CpDotnet.Repositories
{
    public class BrinquedoRepository : IBrinquedoRepository
    {
        private readonly string _connectionString;

        public BrinquedoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Brinquedo>> GetAllAsync()
        {
            var brinquedos = new List<Brinquedo>();

            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OracleCommand("SELECT * FROM TDS_TB_Brinquedos", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            brinquedos.Add(new Brinquedo
                            {
                                Id_brinquedo = reader.GetInt32(0),
                                Nome_brinquedo = reader.GetString(1),
                                Tipo_brinquedo = reader.GetString(2),
                                Classificacao = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Tamanho = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Preco = reader.GetDecimal(5)
                            });
                        }
                    }
                }
            }

            return brinquedos;
        }

        public async Task<Brinquedo> GetByIdAsync(int id)
        {
            Brinquedo brinquedo = null;

            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OracleCommand("SELECT * FROM TDS_TB_Brinquedos WHERE Id_brinquedo = :Id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Id", id));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            brinquedo = new Brinquedo
                            {
                                Id_brinquedo = reader.GetInt32(0),
                                Nome_brinquedo = reader.GetString(1),
                                Tipo_brinquedo = reader.GetString(2),
                                Classificacao = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Tamanho = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Preco = reader.GetDecimal(5)
                            };
                        }
                    }
                }
            }

            return brinquedo;
        }

        public async Task AddAsync(Brinquedo brinquedo)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OracleCommand(
                    "INSERT INTO TDS_TB_Brinquedos (Nome_brinquedo, Tipo_brinquedo, Classificacao, Tamanho, Preco) " +
                    "VALUES (:Nome, :Tipo, :Classificacao, :Tamanho, :Preco)", connection))
                {
                    command.Parameters.Add(new OracleParameter("Nome", brinquedo.Nome_brinquedo));
                    command.Parameters.Add(new OracleParameter("Tipo", brinquedo.Tipo_brinquedo));
                    command.Parameters.Add(new OracleParameter("Classificacao", brinquedo.Classificacao ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("Tamanho", brinquedo.Tamanho ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("Preco", brinquedo.Preco));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Brinquedo brinquedo)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OracleCommand(
                    "UPDATE TDS_TB_Brinquedos SET Nome_brinquedo = :Nome, Tipo_brinquedo = :Tipo, Classificacao = :Classificacao, " +
                    "Tamanho = :Tamanho, Preco = :Preco WHERE Id_brinquedo = :Id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Nome", brinquedo.Nome_brinquedo));
                    command.Parameters.Add(new OracleParameter("Tipo", brinquedo.Tipo_brinquedo));
                    command.Parameters.Add(new OracleParameter("Classificacao", brinquedo.Classificacao ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("Tamanho", brinquedo.Tamanho ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("Preco", brinquedo.Preco));
                    command.Parameters.Add(new OracleParameter("Id", brinquedo.Id_brinquedo));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OracleCommand("DELETE FROM TDS_TB_Brinquedos WHERE Id_brinquedo = :Id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Id", id));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
