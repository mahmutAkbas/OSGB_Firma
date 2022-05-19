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
    public class RandevuManager : IRandevuService
    {
        IRandevuDal _randevuDal;
        public RandevuManager(IRandevuDal randevuDal)
        {
            _randevuDal = randevuDal;
        }

        public async Task<IDataResult<int>> Add(Randevu entity)
        {
            var result = await _randevuDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.RandevuAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.RandevuAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(Randevu entity)
        {
            var result = await _randevuDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.RandevuDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.RandevuDeleteBasarisiz);
        }

        public async Task<IDataResult<List<Randevu>>> GetAll()
        {
            var result = await _randevuDal.GetAllAsync();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Randevu>>(result);
            }
            return new ErrorDataResult<List<Randevu>>(result);
        }

        public async Task<IDataResult<Randevu>> GetById(int id)
        {
            var result = await _randevuDal.GetByIdAsync(id);
            if (result != null)
            {
                return new SuccessDataResult<Randevu>(result);
            }
            return new ErrorDataResult<Randevu>(result);
        }

        public async Task<IDataResult<int>> Update(Randevu entity)
        {
            var result = await _randevuDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.RandevuUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.RandevuUpdateBasarisiz);
        }
    }
}
