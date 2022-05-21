using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikGorevleriDal : IEtkinlikGorevleriDal
    {
        public int Add(EtkinlikGorevleri entity)
        {
            string query = "INSERT INTO etkinlik_gorevleri (etkinlikziyaretid, islemid, aciklama, tarih) VALUES(@etkinlikziyaretid, @islemid, @aciklama, @tarih); ";
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

        public  EtkinlikGorevleri GetById(int id)
        {
            string query = "SELECT * FROM public.etkinlik_gorevleri WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<EtkinlikGorevleri>(query,new { id=id});
                return result;
            }
        }

        public List<EtkinlikGorevDto> GetEtkinlikGorevDtos(string islemAdi)
        {
            string query = "SELECT i.adi,e.tarih FROM public.etkinlik_gorevleri e INNER JOIN public.islemler i ON e.islemid = i.id WHERE i.adi LIKE CONCAT('%',@adi,'%')";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<EtkinlikGorevDto>(query,new { adi=islemAdi});
                return result.AsList();
            }
        }

        public int Update(EtkinlikGorevleri entity)
        {
            string query = "UPDATE public.etkinlik_gorevleri SET etkinlikziyaretid =@etkinlikziyaretid, islemid =@islemid , aciklama =@aciklama, tarih =@tarih WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }
    }
}
