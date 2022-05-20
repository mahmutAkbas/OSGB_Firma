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

        public IResult Add(Randevu entity)
        {
            var result =  _randevuDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.RandevuAddBasarili);
            }
            return new ErrorResult( ResponseMessages.RandevuAddBasarisiz);
        }

        public IResult Delete(Randevu entity)
        {
            var result =  _randevuDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.RandevuDeleteBasarili);
            }
            return new ErrorResult( ResponseMessages.RandevuDeleteBasarisiz);
        }

        public IDataResult<List<Randevu>> GetAll()
        {
            var result =  _randevuDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Randevu>>(result);
            }
            return new ErrorDataResult<List<Randevu>>(result);
        }

        public IDataResult<List<Randevu>> GetAllFilter(Randevu entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Randevu> GetById(int id)
        {
            var result =  _randevuDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<Randevu>(result);
            }
            return new ErrorDataResult<Randevu>(result);
        }

        public IResult Update(Randevu entity)
        {
            var result =  _randevuDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.RandevuUpdateBasarili);
            }
            return new ErrorResult( ResponseMessages.RandevuUpdateBasarisiz);
        }
    }
}
