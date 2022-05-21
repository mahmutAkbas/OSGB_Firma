using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using Npgsql;
using System;
using System.Collections.Generic;
namespace DataAccess.Concrete.Dapper
{
    public class RandevuDal : IRandevuDal
    {
        public int Add(Randevu entity)
        {
            string query = "INSERT INTO public.randevu (yurutucufirmaid, randevutarihi,aciklama, onay)VALUES (@yurutucufirmaid, @randevutarihi,@aciklama, @onay);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM public.randevu WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, new {id=id } );
                return result;
            }
        }

        public List<Randevu> GetAll()
        {
            string query = "SELECT * FROM public.randevu";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Randevu>(query);
                return result.AsList();
            }
        }

        public List<Randevu> GetAllByDate(DateTime tarih, int userId)
        {
            string query = "SELECT id, yurutucufirmaid, randevutarihi, onay, aciklama FROM public.randevu WHERE randevutarihi=@randevutarihi AND yurutucufirmaid = @yurutucufirmaid ORDER BY randevutarihi DESC;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Randevu>(query, new { randevutarihi = tarih, yurutucufirmaid = userId });
                return result.AsList();
            }
        }

        public List<Randevu> GetAllById(int userId)
        {
            string query = "SELECT id, yurutucufirmaid, randevutarihi, onay, aciklama FROM public.randevu WHERE  yurutucufirmaid = @yurutucufirmaid;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Randevu>(query, new {  yurutucufirmaid = userId });
                return result.AsList();
            }
        }

        public Randevu GetById(int id)
        {
            string query = "SELECT * FROM public.randevu WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.QueryFirst<Randevu>(query, new {id=id});
                return result;
            }
        }

        public List<RandevuDto> GetlRandevuDtoAll(bool randevuOnay)
        {
            string query = "SELECT r.id, y.adi,r.yurutucufirmaid, randevutarihi, onay, aciklama FROM public.randevu r INNER JOIN public.yurutucu_firma y ON r.yurutucufirmaid = y.id WHERE r.onay=@onay ORDER BY r.randevutarihi DESC";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<RandevuDto>(query, new { onay = randevuOnay });
                return result.AsList();
            }
        }

        public List<RandevuDto> GetlRandevuDtoFilter(DateTime randevuTarih, string firmaAdi, bool randevuOnay)
        {
            string query = "SELECT r.id,r.yurutucufirmaid, y.adi, randevutarihi, onay, aciklama FROM public.randevu r INNER JOIN public.yurutucu_firma y ON r.yurutucufirmaid = y.id WHERE (r.randevutarihi=@tarih OR y.adi LIKE CONCAT('%',@adi,'%')) AND r.onay=@onay ORDER BY r.randevutarihi DESC";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<RandevuDto>(query, new { tarih=randevuTarih,adi=firmaAdi,onay=randevuOnay });
                return result.AsList();
            }
        }

        public int Update(Randevu entity)
        {
            string query = "UPDATE public.randevu SET  yurutucufirmaid =@yurutucufirmaid, randevutarihi =@randevutarihi ,aciklama=@aciklama, onay =@onay  WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }
    }
}
