using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikZiyaretDal : IEtkinlikZiyaretDal
    {
        public async Task<int> AddAsync(EtkinlikZiyaret entity)
        {
            string query = "INSERT INTO public.etkinlik_ziyaret(randevuid, aylikucret)VALUES (@randevuid, @aylikucret);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.etkinlik_ziyaret WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<EtkinlikZiyaret>> GetAllAsync()
        {
            string query = "SELECT * FROM public.etkinlik_ziyaret;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<EtkinlikZiyaret>(query);
                return result.AsList();
            }
        }

        public async Task<EtkinlikZiyaret> GetByIdAsync(int id)
        {
            string query = "INSERT INTO public.etkinlik_ziyaret(randevuid, aylikucret)VALUES (@randevuid, @aylikucret);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<EtkinlikZiyaret>(query, id);
                return result;
            }
        }

        public async Task<int> UpdateAsync(EtkinlikZiyaret entity)
        {
            string query = "UPDATE public.etkinlik_ziyaret SET randevuid=@randevuid, aylikucret=@aylikucret WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
