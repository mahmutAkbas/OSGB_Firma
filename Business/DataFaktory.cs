using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Dapper;

namespace Business
{
    public class DataFaktory
    {
        public DataFaktory()
        {
            Unvans = new UnvanManager(new UnvanDal());
        }

        public IUnvanService Unvans { get; set; }
    }
}
