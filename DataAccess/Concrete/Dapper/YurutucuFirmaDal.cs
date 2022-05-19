using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class YurutucuFirmaDal : IYurutucuFirmaDal
    {
        public async Task<int> AddAsync(YurutucuFirma entity)
        {
            string query = "INSERT INTO public.yurutucu_firma(adi, kayittarihi) VALUES( ?, ?); ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.yurutucu_firma WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<YurutucuFirma>> GetAllAsync()
        {
            string query = "SELECT * FROM public.yurutucu_firma  ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<YurutucuFirma>(query);
                return result.AsList();
            }
        }

        public async Task<YurutucuFirma> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM public.yurutucu_firma WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<YurutucuFirma>(query, id);
                return result;
            }
        }

        public async Task<int> UpdateAsync(YurutucuFirma entity)
        {
            string query = "UPDATE public.yurutucu_firma SET  adi =@adi, kayittarihi =@kayittarihi     WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
