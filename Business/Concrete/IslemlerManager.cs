using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class IslemlerManager : IIslemlerService
    {
        IIslemlerDal _islemlerDal;
        public IslemlerManager(IIslemlerDal islemlerDal)
        {
            _islemlerDal = islemlerDal;
        }

        public IDataResult<int> Add(Islemler entity)
        {
            var result = _islemlerDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.IslemlerAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.IslemlerAddBasarisiz);
        }

        public IDataResult<int> Delete(Islemler entity)
        {
            var result = _islemlerDal.DeleteAsync(entity.Id);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.IslemlerDeleteBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.IslemlerDeleteBasarisiz);
        }

        public IDataResult<List<Islemler>> GetAll()
        {
            var result = _islemlerDal.GetAllAsync();
            if (result.IsCompleted && result.Result != null && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<Islemler>>(result.Result);
            }
            return new ErrorDataResult<List<Islemler>>(result.Result);
        }

        public IDataResult<Islemler> GetById(int id)
        {
            var result = _islemlerDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<Islemler>(result.Result);
            }
            return new ErrorDataResult<Islemler>(result.Result);
        }

        public IDataResult<int> Update(Islemler entity)
        {
            var result = _islemlerDal.UpdateAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.IslemlerUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.IslemlerUpdateBasarisiz);
        }
    }
}
