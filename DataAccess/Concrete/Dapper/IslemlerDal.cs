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
        public  int Add(Islemler entity)
        {
            string query = "INSERT INTO public.islemler(adi, tip)VALUES (@adi, @tip);";
            using (var connection=new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result= connection.Execute(query,entity);
                return result;
            }
        }

        public  int Delete(int id)
        {
            string query = "DELETE FROM public.islemler WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, new { id=id});
                return result;
            }
        }

        public  List<Islemler> GetAll()
        {
            string query = "SELECT * FROM public.islemler;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Islemler>(query);
                return result.AsList();
            }
        }
        public List<Islemler> GetAllFilter(string islemAdi)
        {
            string query = "SELECT * FROM public.islemler WHERE adi LIKE CONCAT('%',@adi,'%');";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Islemler>(query, new { adi=islemAdi});
                return result.AsList();
            }
        }

        public  Islemler GetById(int id)
        {
            string query = "SELECT * FROM public.islemler WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.QueryFirst<Islemler>(query, id);
                return result;
            }
        }

        public  int Update(Islemler entity)
        {
            string query = "UPDATE public.islemler SET  adi=@adi, tip=@tip WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }
    }
}
