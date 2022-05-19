using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class PersonelDal : IPersonelDal
    {
        public async Task<int> AddAsync(Personel entity)
        {
            string query = "INSERT INTO public.personel (adi, soyadi, telefon, kayittarihi, silinmedurumu, silinmetarihi, unvanid) VALUES (@adi, @soyadi, @telefon, @kayittarihi, @silinmedurumu, @silinmetarihi, @unvanid);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.personel WHERE id=@id ;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<Personel>> GetAllAsync()
        {
            string query = "SELECT * FROM public.personel WHERE id=@id ;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Personel>(query);
                return result.AsList();
            }
        }

        public async Task<Personel> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM public.personel WHERE id=@id ;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Personel>(query, id);
                return result;
            }
        }

        public Task<int> UpdateAsync(Personel entity)
        {
            string query = "UPDATE public.personel SET  adi=@adi, soyadi=@soyadi, telefon=@telefon, kayittarihi=@kayittarihi, silinmedurumu=@silinmedurumu, silinmetarihi=@silinmetarihi, unvanid=@unvanid WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
