using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using Npgsql;
using System.Collections.Generic;

namespace DataAccess.Concrete.Dapper
{
    public class PersonelDal : IPersonelDal
    {
        public int Add(Personel entity)
        {
            string query = "INSERT INTO public.personel (adi, soyadi, telefon, kayittarihi, silinmedurumu, silinmetarihi, unvanid) VALUES (@adi, @soyadi, @telefon, @kayittarihi, @silinmedurumu, @silinmetarihi, @unvanid);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM public.personel WHERE id=@id ;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, id);
                return result;
            }
        }

        public List<Personel> GetAll()
        {
            string query = "SELECT * FROM public.personel ;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Personel>(query);
                return result.AsList();
            }
        }

        public List<PersonelDto> GetAllFilter(string personelAdi, bool silinmeDurumu)
        {
            string query = "SELECT p.*,u.unvanadi FROM public.personel p INNER JOIN public.unvan u ON p.unvanid = u.id  WHERE adi LIKE CONCAT('%',@adi,'%') AND p.silinmedurumu=@silinmedurumu;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<PersonelDto>(query, new { adi = personelAdi, silinmedurumu = silinmeDurumu });
                return result.AsList();
            }
        }

        public Personel GetById(int id)
        {
            string query = "SELECT * FROM public.personel WHERE id=@id ;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.QueryFirst<Personel>(query, id);
                return result;
            }
        }

        public List<PersonelDto> GetAllPersonelDto(bool silinenDurumu)
        {
            string query = "SELECT p.*,u.unvanadi FROM public.personel p INNER JOIN public.unvan u ON p.unvanid = u.id WHERE p.silinmedurumu=@silinmedurumu;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<PersonelDto>(query, new { silinmedurumu = silinenDurumu });
                return result.AsList();
            }
        }

        public int Update(Personel entity)
        {
            string query = "UPDATE public.personel SET  adi=@adi, soyadi=@soyadi, telefon=@telefon, kayittarihi=@kayittarihi, silinmedurumu=@silinmedurumu, silinmetarihi=@silinmetarihi, unvanid=@unvanid WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }
    }
}
