using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikZiyaretDal : IEtkinlikZiyaretDal
    {
        public  int Add(EtkinlikZiyaret entity)
        {
            string query = "INSERT INTO public.etkinlik_ziyaret(randevuid, aylikucret)VALUES (@randevuid, @aylikucret);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }

        public  int Delete(int id)
        {
            string query = "DELETE FROM public.etkinlik_ziyaret WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, id);
                return result;
            }
        }

        public  List<EtkinlikZiyaret> GetAll()
        {
            string query = "SELECT * FROM public.etkinlik_ziyaret;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<EtkinlikZiyaret>(query);
                return result.AsList();
            }
        }

        public List<EtkinlikZiyaret> GetAllFilter(EtkinlikZiyaret entity)
        {
            throw new System.NotImplementedException();
        }

        public  EtkinlikZiyaret GetById(int id)
        {
            string query = "INSERT INTO public.etkinlik_ziyaret(randevuid, aylikucret)VALUES (@randevuid, @aylikucret);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<EtkinlikZiyaret>(query, id);
                return result;
            }
        }

        public  int Update(EtkinlikZiyaret entity)
        {
            string query = "UPDATE public.etkinlik_ziyaret SET randevuid=@randevuid, aylikucret=@aylikucret WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }
    }
}
