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
    public class IslemlerManager : IIslemlerService
    {
        IIslemlerDal _islemlerDal;
        public IslemlerManager(IIslemlerDal islemlerDal)
        {
            _islemlerDal = islemlerDal;
        }

        public async Task<IDataResult<int>> Add(Islemler entity)
        {
            var result = await _islemlerDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.IslemlerAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.IslemlerAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(Islemler entity)
        {
            var result = await _islemlerDal.DeleteAsync(entity.Id);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.IslemlerDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.IslemlerDeleteBasarisiz);
        }

        public async Task<IDataResult<List<Islemler>>> GetAll()
        {
            var result = await _islemlerDal.GetAllAsync();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Islemler>>(result);
            }
            return new ErrorDataResult<List<Islemler>>(result);
        }

        public async Task<IDataResult<Islemler>> GetById(int id)
        {
            var result = await _islemlerDal.GetByIdAsync(id);
            if (result != null)
            {
                return new SuccessDataResult<Islemler>(result);
            }
            return new ErrorDataResult<Islemler>(result);
        }

        public async Task<IDataResult<int>> Update(Islemler entity)
        {
            var result = await _islemlerDal.UpdateAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.IslemlerUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.IslemlerUpdateBasarisiz);
        }
    }
}
