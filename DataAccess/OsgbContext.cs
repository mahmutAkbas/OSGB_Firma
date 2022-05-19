
namespace DataAccess
{

    public class OsgbContext
    {
        public static readonly string ConnectionString;
        static OsgbContext()
        {
            ConnectionString = "Host=localhost;Port=5432;Database=OSGB_Firma;User Id=postgres;Password=1;";
        }
    }
}
