using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EtkinlikGorevlileriManager : IEtkinlikGorevlileriService
    {
        IEtkinlikGorevlileriDal _etkinlikGorevlileriDal;
        public EtkinlikGorevlileriManager(IEtkinlikGorevlileriDal etkinlikGorevlileriDal)
        {
            _etkinlikGorevlileriDal = etkinlikGorevlileriDal;
        }
        public IDataResult<int> Add(EtkinlikGorevlileri entity)
        {
            var result = _etkinlikGorevlileriDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikGorevlileriAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikGorevlileriAddBasarisiz);
        }

        public IDataResult<int> Delete(EtkinlikGorevlileri entity)
        {
            var result = _etkinlikGorevlileriDal.DeleteAsync(entity.Id);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikGorevlileriAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikGorevlileriAddBasarisiz);
        }

        public IDataResult<List<EtkinlikGorevlileri>> GetAll()
        {
            var result = _etkinlikGorevlileriDal.GetAllAsync();
            if (result.IsCompleted && result.Result != null && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikGorevlileri>>(result.Result);
            }
            return new ErrorDataResult<List<EtkinlikGorevlileri>>(result.Result);
        }

        public IDataResult<EtkinlikGorevlileri> GetById(int id)
        {
            var result = _etkinlikGorevlileriDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<EtkinlikGorevlileri>(result.Result);
            }
            return new ErrorDataResult<EtkinlikGorevlileri>(result.Result);
        }

        public IDataResult<int> Update(EtkinlikGorevlileri entity)
        {
            var result = _etkinlikGorevlileriDal.UpdateAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikGorevlileriUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikGorevlileriUpdateBasarisiz);
        }
    }
}
