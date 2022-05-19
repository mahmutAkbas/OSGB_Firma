using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikGorevliileriDal : IEtkinlikGorevlileriDal
    {
        public async Task<int> AddAsync(EtkinlikGorevlileri entity)
        {
            string query = "INSERT INTO public.etkinlik_gorevlileri(personelid, yetki,etkinlikziyaretid)VALUES (@personelid, @yetki,@etkinlikziyaretid);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.etkinlik_gorevlileri WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<EtkinlikGorevlileri>> GetAllAsync()
        {
            string query = "SELECT * FROM public.etkinlik_gorevlileri; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<EtkinlikGorevlileri>(query);
                return result.AsList();
            }
        }

        public async Task<EtkinlikGorevlileri> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM public.etkinlik_gorevlileri WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<EtkinlikGorevlileri>(query, id);
                return result;
            }
        }

        public async Task<int> UpdateAsync(EtkinlikGorevlileri entity)
        {
            string query = "UPDATE public.etkinlik_gorevlileri SET personelid =@personelid, yetki =@yetki, etkinlikziyaretid =@etkinlikziyaretid WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
