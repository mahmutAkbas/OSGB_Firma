using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EtkinlikGorevleriManager : IEtkinlikGorevleriService
    {
        IEtkinlikGorevleriDal _etkinlikGorevleriDal;
        public EtkinlikGorevleriManager(IEtkinlikGorevleriDal etkinlikGorevleriDal)
        {
            _etkinlikGorevleriDal = etkinlikGorevleriDal;
        }

        public IDataResult<int> Add(EtkinlikGorevleri entity)
        {
            var result = _etkinlikGorevleriDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikGoreviAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikGoreviAddBasarisiz);
        }

        public IDataResult<int> Delete(EtkinlikGorevleri entity)
        {
            var result = _etkinlikGorevleriDal.DeleteAsync(entity.Id);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikGoreviDeleteBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikGoreviDeleteBasarisiz);
        }

        public IDataResult<List<EtkinlikGorevleri>> GetAll()
        {
            var result = _etkinlikGorevleriDal.GetAllAsync();
            if (result.IsCompleted && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikGorevleri>>(result.Result);
            }
            return new ErrorDataResult<List<EtkinlikGorevleri>>(result.Result);
        }

        public IDataResult<EtkinlikGorevleri> GetById(int id)
        {
            var result = _etkinlikGorevleriDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<EtkinlikGorevleri>(result.Result);
            }
            return new ErrorDataResult<EtkinlikGorevleri>(result.Result);
        }

        public IDataResult<int> Update(EtkinlikGorevleri entity)
        {
            var result = _etkinlikGorevleriDal.UpdateAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.EtkinlikGoreviUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.EtkinlikGoreviUpdateBasarisiz);

        }
    }
}
