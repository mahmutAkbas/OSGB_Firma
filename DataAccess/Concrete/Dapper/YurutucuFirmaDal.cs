using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class YurutucuFirmaDal : IYurutucuFirmaDal
    {
        public  int Add(YurutucuFirma entity)
        {
            string query = "INSERT INTO public.yurutucu_firma(adi, kayittarihi) VALUES( @adi, @kayittarihi); ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }

        public  int Delete(int id)
        {
            string query = "DELETE FROM public.yurutucu_firma WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, id);
                return result;
            }
        }

        public  List<YurutucuFirma> GetAll()
        {
            string query = "SELECT * FROM public.yurutucu_firma  ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<YurutucuFirma>(query);
                return result.AsList();
            }
        }

        public List<YurutucuFirma> GetAllFilter(YurutucuFirma entity)
        {
            throw new System.NotImplementedException();
        }

        public List<YurutucuFirma> GetAllFilter(string adi)
        {
            string query = "SELECT * FROM public.yurutucu_firma WHERE adi LIKE CONCAT('%',@adi,'%');";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<YurutucuFirma>(query, new { adi=adi});
                return result.AsList();
            }
        }

        public  YurutucuFirma GetById(int id)
        {
            string query = "SELECT * FROM public.yurutucu_firma WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<YurutucuFirma>(query, id);
                return result;
            }
        }

        public  int Update(YurutucuFirma entity)
        {
            string query = "UPDATE public.yurutucu_firma SET  adi =@adi, kayittarihi =@kayittarihi     WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }
    }
}
