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
        public  int Add(Randevu entity)
        {
            string query = "INSERT INTO public.randevu (yurutucufirmaid, randevutarihi, onay)VALUES (@yurutucufirmaid, @randevutarihi, @onay);";
            using (var connection=new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result= connection.Execute(query, entity);
                return result;
            }
        }

        public  int Delete(int id)
        {
            string query = "DELETE FROM public.randevu WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, id);
                return result;
            }
        }

        public  List<Randevu> GetAll()
        {
            string query = "SELECT * FROM public.randevu";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<Randevu>(query);
                return result.AsList();
            }
        }

        public List<Randevu> GetAllFilter(Randevu entity)
        {
            throw new NotImplementedException();
        }

        public  Randevu GetById(int id)
        {
            string query = "SELECT * FROM public.randevu WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<Randevu>(query, id);
                return result;
            }
        }

        public  int Update(Randevu entity)
        {
            string query = "UPDATE public.randevu SET  yurutucufirmaid =@yurutucufirmaid, randevutarihi =@randevutarihi , onay =@onay  WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }
    }
}
