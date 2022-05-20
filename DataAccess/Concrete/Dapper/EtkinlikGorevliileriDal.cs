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
        public  int Add(EtkinlikGorevlileri entity)
        {
            string query = "INSERT INTO public.etkinlik_gorevlileri(personelid, yetki,etkinlikziyaretid)VALUES (@personelid, @yetki,@etkinlikziyaretid);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }

        public  int Delete(int id)
        {
            string query = "DELETE FROM public.etkinlik_gorevlileri WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, id);
                return result;
            }
        }

        public  List<EtkinlikGorevlileri> GetAll()
        {
            string query = "SELECT * FROM public.etkinlik_gorevlileri; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<EtkinlikGorevlileri>(query);
                return result.AsList();
            }
        }

        public List<EtkinlikGorevlileri> GetAllFilter(EtkinlikGorevlileri entity)
        {
            throw new System.NotImplementedException();
        }

        public  EtkinlikGorevlileri GetById(int id)
        {
            string query = "SELECT * FROM public.etkinlik_gorevlileri WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<EtkinlikGorevlileri>(query, id);
                return result;
            }
        }

        public  int Update(EtkinlikGorevlileri entity)
        {
            string query = "UPDATE public.etkinlik_gorevlileri SET personelid =@personelid, yetki =@yetki, etkinlikziyaretid =@etkinlikziyaretid WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }
    }
}
