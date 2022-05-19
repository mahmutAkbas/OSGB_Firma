using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RandevuManager : IRandevuService
    {
        IRandevuDal _randevuDal;
        public RandevuManager(IRandevuDal randevuDal)
        {
            _randevuDal = randevuDal;
        }
        public IDataResult<int> Add(Randevu entity)
        {
            var result = _randevuDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.RandevuAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.RandevuAddBasarisiz);
        }

        public IDataResult<int> Delete(Randevu entity)
        {
            var result = _randevuDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.RandevuDeleteBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.RandevuDeleteBasarisiz);
        }

        public IDataResult<List<Randevu>> GetAll()
        {
            var result = _randevuDal.GetAllAsync();
            if (result.IsCompleted && result.Result != null && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<Randevu>>(result.Result);
            }
            return new ErrorDataResult<List<Randevu>>(result.Result);
        }

        public IDataResult<Randevu> GetById(int id)
        {
            var result = _randevuDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<Randevu>(result.Result);
            }
            return new ErrorDataResult<Randevu>(result.Result);
        }

        public IDataResult<int> Update(Randevu entity)
        {
            var result = _randevuDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.RandevuUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.RandevuUpdateBasarisiz);
        }
    }
}
