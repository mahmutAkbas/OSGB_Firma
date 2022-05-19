using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EtkinlikZiyaretManager : IEtkinlikZiyaretService
    {
        IEtkinlikZiyaretDal _etkinlikZiyaretDal;
        public EtkinlikZiyaretManager(IEtkinlikZiyaretDal etkinlikZiyaretDal)
        {
            _etkinlikZiyaretDal = etkinlikZiyaretDal;
        }
        public IDataResult<int> Add(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikZiyaretiAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikZiyaretiAddBasarisiz);
        }

        public IDataResult<int> Delete(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikZiyaretiDeleteBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikZiyaretiDeleteBasarisiz);
        }

        public IDataResult<List<EtkinlikZiyaret>> GetAll()
        {
            var result = _etkinlikZiyaretDal.GetAllAsync();
            if (result.IsCompleted && result.Result != null && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikZiyaret>>(result.Result);
            }
            return new ErrorDataResult<List<EtkinlikZiyaret>>(result.Result);
        }

        public IDataResult<EtkinlikZiyaret> GetById(int id)
        {
            var result = _etkinlikZiyaretDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<EtkinlikZiyaret>(result.Result);
            }
            return new ErrorDataResult<EtkinlikZiyaret>(result.Result);
        }

        public IDataResult<int> Update(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.UpdateAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikZiyaretiUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikZiyaretiUpdateBasarisiz);
        }
    }
}
