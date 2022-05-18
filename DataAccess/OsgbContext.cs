
namespace DataAccess
{

    public class OsgbContext
    {
        public static readonly string ConnectionString;
        static OsgbContext()
        {
            ConnectionString = "Server=127.0.0.1;Port=5432;Database=OSGB_Firma;User Id=postgres;Password=1;";
        }
    }
}
