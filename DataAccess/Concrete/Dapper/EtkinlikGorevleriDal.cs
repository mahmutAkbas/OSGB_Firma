using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikGorevleriDal : IEtkinlikGorevleriDal
    {
        public int Add(EtkinlikGorevleri entity)
        {
            string query = "INSERT INTO etkinlik_gorevleri (etkinlikid, islemid, aciklama, tarih) VALUES(@etkinlikid, @islemid, @aciklama, @tarih); ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM public.etkinlik_gorevleri WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, id);
                return result;
            }
        }

        public  List<EtkinlikGorevleri> GetAll()
        {
            string query = "SELECT * FROM public.etkinlik_gorevleri";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<EtkinlikGorevleri>(query);
                return result.AsList();
            }
        }

        public List<EtkinlikGorevleri> GetAllFilter(EtkinlikGorevleri entity)
        {
            throw new System.NotImplementedException();
        }

        public  EtkinlikGorevleri GetById(int id)
        {
            string query = "SELECT * FROM public.etkinlik_gorevleri WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<EtkinlikGorevleri>(query,id);
                return result;
            }
        }

        public int Update(EtkinlikGorevleri entity)
        {
            string query = "UPDATE public.etkinlik_gorevleri SET etkinlikid =@etkinlikid, islemid =@islemid , aciklama =@aciklama, tarih =@tarih WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }
    }
}
