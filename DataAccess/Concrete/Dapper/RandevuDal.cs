using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace DataAccess.Concrete.Dapper
{
    public class RandevuDal : IRandevuDal
    {
        public async Task<int> AddAsync(Randevu entity)
        {
            string query = "INSERT INTO public.randevu (yurutucufirmaid, randevutarihi, onay)VALUES (@yurutucufirmaid, @randevutarihi, @onay);";
            using (var connection=new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result=await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.randevu WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =await connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<Randevu>> GetAllAsync()
        {
            string query = "SELECT * FROM public.randevu";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Randevu>(query);
                return result.AsList();
            }
        }

        public async Task<Randevu> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM public.randevu WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Randevu>(query, id);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Randevu entity)
        {
            string query = "UPDATE public.randevu SET  yurutucufirmaid =@yurutucufirmaid, randevutarihi =@randevutarihi , onay =@onay  WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
