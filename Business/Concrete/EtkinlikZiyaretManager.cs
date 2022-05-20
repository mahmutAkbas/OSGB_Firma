using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EtkinlikZiyaretManager : IEtkinlikZiyaretService
    {
        IEtkinlikZiyaretDal _etkinlikZiyaretDal;
        public EtkinlikZiyaretManager(IEtkinlikZiyaretDal etkinlikZiyaretDal)
        {
            _etkinlikZiyaretDal = etkinlikZiyaretDal;
        }
        public IResult Add(EtkinlikZiyaret entity)
        {
            var result =  _etkinlikZiyaretDal.Add(entity);
            if (result> 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikZiyaretiAddBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikZiyaretiAddBasarisiz);
        }

        public IResult Delete(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikZiyaretiDeleteBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikZiyaretiDeleteBasarisiz);
        }

        public IDataResult<List<EtkinlikZiyaret>> GetAll()
        {
            var result = _etkinlikZiyaretDal.GetAll();
            if ( result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikZiyaret>>(result);
            }
            return new ErrorDataResult<List<EtkinlikZiyaret>>(result);
        }

        public IDataResult<List<EtkinlikZiyaret>> GetAllFilter(EtkinlikZiyaret entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<EtkinlikZiyaret> GetById(int id)
        {
            var result = _etkinlikZiyaretDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<EtkinlikZiyaret>(result);
            }
            return new ErrorDataResult<EtkinlikZiyaret>(result);
        }

        public IResult Update(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.Update(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikZiyaretiUpdateBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikZiyaretiUpdateBasarisiz);
        }
    }
}
