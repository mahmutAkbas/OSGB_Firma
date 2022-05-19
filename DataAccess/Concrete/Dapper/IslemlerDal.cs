using DataAccess.Abstract;
using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace DataAccess.Concrete.Dapper
{
    public class IslemlerDal : IIslemlerDal
    {
        public async Task<int> AddAsync(Islemler entity)
        {
            string query = "INSERT INTO public.islemler(adi, tip)VALUES (@adi, @tip);";
            using (var connection=new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result=await connection.ExecuteAsync(query,entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.islemler WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =await connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<Islemler>> GetAllAsync()
        {
            string query = "SELECT * FROM public.islemler;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =await connection.QueryAsync<Islemler>(query);
                return result.AsList();
            }
        }

        public async Task<Islemler> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM public.islemler WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =await connection.QueryFirstAsync<Islemler>(query, id);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Islemler entity)
        {
            string query = "UPDATE public.islemler SET  adi=@adi, tip=@tip WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
