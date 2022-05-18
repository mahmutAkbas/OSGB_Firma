using DataAccess.Abstract;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Entities.Concrete.Data;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikGorevleriDal : IEtkinlikGorevleri
    {
        public Task<int> AddAsync(EtkinlikGorevleri entity)
        {
            string query = "INSERT INTO EtkinlikGorevleri (Id, EtkinlikId, IslemId, Aciklama, Tarih) VALUES(@Id, @EtkinlikId, @IslemId, @Aciklama, @Tarih); ";
            using (var connection=new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            string query = "";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<EtkinlikGorevleri>> GetAllAsync()
        {
            string query = "";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<EtkinlikGorevleri>(query);
                return result.AsList();
            }
        }

        public async Task<EtkinlikGorevleri> GetByIdAsync(int id)
        {
            string query = "";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<EtkinlikGorevleri>(query);
                return (EtkinlikGorevleri)result;
            }
        }

        public Task<int> UpdateAsync(EtkinlikGorevleri entity)
        {
            string query = "";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
