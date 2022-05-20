using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class UnvanDal : IUnvanDal
    {
        public  int Add(Unvan entity)
        {
            var query = "INSERT INTO unvan (unvanadi) VALUES (@UnvanAdi);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }

        public  int Delete(int id)
        {
            string query = "DELETE FROM public.unvan WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, new { id = id });
                return result;
            }
        }

        public  List<Unvan> GetAll()
        {
            string query = "SELECT id, unvanadi FROM public.unvan;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<Unvan>(query);
                return result.AsList();
            }
        }

        public  List<Unvan> GetAllFilter(Unvan entity)
        {
            string query = "SELECT * FROM public.unvan WHERE unvanadi LIKE CONCAT('%',@UnvanAdi,'%');";
            string filter = $"'%{entity.UnvanAdi}%'";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<Unvan>(query, new { UnvanAdi=entity.UnvanAdi });
                return result.AsList();
            }
        }

        public  Unvan GetById(int id)
        {
            string query = "SELECT * FROM public.unvan WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<Unvan>(query, id);
                return result;
            }
        }

        public  int Update(Unvan entity)
        {
            string query = "UPDATE public.unvan SET unvanadi = @UnvanAdi WHERE id = @id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }
    }
}
