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
    public class UnvanManager : IUnvanService
    {
        private IUnvanDal _unvanDal;
        public UnvanManager(IUnvanDal unvanDal)
        {
            _unvanDal = unvanDal;
        }

        public async Task<IDataResult<int>> Add(Unvan entity)
        {
            var result = await _unvanDal.AddAsync(entity);

            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.UnvanAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.UnvanAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(Unvan entity)
        {
            var result = await _unvanDal.DeleteAsync(entity.Id);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.UnvanDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.UnvanDeleteBasarisiz);
        }

        public async Task<IDataResult<List<Unvan>>> GetAll()
        {
            var result = await _unvanDal.GetAllAsync();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Unvan>>(result);
            }
            return new ErrorDataResult<List<Unvan>>();
        }

        public async Task<IDataResult<Unvan>> GetById(int id)
        {
            var result = await _unvanDal.GetByIdAsync(id);
            if (result != null)
            {
                return new SuccessDataResult<Unvan>(result);
            }
            return new ErrorDataResult<Unvan>();
        }

        public async Task<IDataResult<int>> Update(Unvan entity)
        {
            var result = await _unvanDal.UpdateAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.UnvanUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.UnvanUpdateBasarisiz);
        }
    }
}
