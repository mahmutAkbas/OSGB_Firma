using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using Npgsql;
using System.Collections.Generic;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikZiyaretDal : IEtkinlikZiyaretDal
    {
        public int Add(EtkinlikZiyaret entity)
        {
            string query = "INSERT INTO public.etkinlik_ziyaret(randevuid, aylikucret)VALUES (@randevuid, @aylikucret);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);

                return result;
            }
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM public.etkinlik_ziyaret WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, id);
                return result;
            }
        }

        public List<EtkinlikZiyaret> GetAll()
        {
            string query = "SELECT * FROM public.etkinlik_ziyaret;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<EtkinlikZiyaret>(query);
                return result.AsList();
            }
        }

        public EtkinlikZiyaret GetById(int id)
        {
            string query = "SELECT * FROM public.etkinlik_ziyaret WHERE id=@id";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.QueryFirst<EtkinlikZiyaret>(query, new { id = id });
                return result;
            }
        }

        public int GetByZiyaretId(int id)
        {

            string query = "SELECT * FROM public.etkinlik_ziyaret WHERE randevuid=@id ORDER BY id DESC  LIMIT 1";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.QueryFirst<EtkinlikZiyaret>(query, new { id = id });
                return result.Id;
            }
        }

        public List<EtkinlikZiyaretDto> GetEtkinlikZiyaretDto()
        {
            string query = "SELECT e.id,r.randevutarihi,y.adi,e.aylikucret FROM public.etkinlik_ziyaret e INNER JOIN public.randevu r ON e.randevuid = r.id INNER JOIN public.yurutucu_firma y ON r.yurutucufirmaid = y.id";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<EtkinlikZiyaretDto>(query);
                return result.AsList();
            }
        }
        public List<EtkinlikZiyaretDto> GetEtkinlikZiyaretByFirmaAdi(string firmaAdi)
        {
            string query = "SELECT e.id,r.randevutarihi,y.adi,e.aylikucret FROM public.etkinlik_ziyaret e INNER JOIN public.randevu r ON e.randevuid = r.id INNER JOIN public.yurutucu_firma y ON r.yurutucufirmaid = y.id WHERE adi LIKE CONCAT('%',@adi,'%')";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<EtkinlikZiyaretDto>(query,new { adi=firmaAdi });
                return result.AsList();
            }
        }
        public int Update(EtkinlikZiyaret entity)
        {
            string query = "UPDATE public.etkinlik_ziyaret SET randevuid=@randevuid, aylikucret=@aylikucret WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }
    }
}
