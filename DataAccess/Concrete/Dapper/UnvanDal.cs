using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class UnvanDal : IUnvanDal
    {
        public async Task<int> AddAsync(Unvan entity)
        {
            string query = "INSERT INTO Unvan(UnvanAdi) VALUES (@UnvanAdi);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.unvan WHERE unvan_id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<Unvan>> GetAllAsync()
        {
            string query = "SELECT unvan_id, unvan_adi FROM public.unvan;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Unvan>(query);
                return result.AsList();
            }
        }

        public async Task<Unvan> GetByIdAsync(int id)
        {
            string query = "SELECT unvan_id, unvan_adi FROM public.unvan WHERE unvan_id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Unvan>(query, id);
                return (Unvan)result;
            }
        }

        public async Task<int> UpdateAsync(Unvan entity)
        {
            string query = "UPDATE public.unvan SET unvan_adi = @unvan_adi WHERE unvan_id = @unvan_id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
