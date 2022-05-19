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
            var result =await _unvanDal.DeleteAsync(entity.Id);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.UnvanDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.UnvanDeleteBasarisiz);
        }

        public IDataResult<List<Unvan>> GetAll()
        {
            var result = _unvanDal.GetAllAsync();
            if (result.IsCompleted && result.Result != null && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<Unvan>>(result.Result);
            }
            return new ErrorDataResult<List<Unvan>>();
        }

        public IDataResult<Unvan> GetById(int id)
        {
            var result = _unvanDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<Unvan>(result.Result);
            }
            return new ErrorDataResult<Unvan>();
        }

        public IDataResult<int> Update(Unvan entity)
        {
            var result = _unvanDal.UpdateAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.UnvanUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.UnvanUpdateBasarisiz);
        }
    }
}
