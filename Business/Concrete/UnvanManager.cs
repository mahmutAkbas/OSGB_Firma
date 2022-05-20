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

        public IResult Add(Unvan entity)
        {
            var result =  _unvanDal.Add(entity);

            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.UnvanAddBasarili);
            }
            return new ErrorResult( ResponseMessages.UnvanAddBasarisiz);
        }

        public IResult Delete(Unvan entity)
        {
            var result =  _unvanDal.Delete(entity.Id);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.UnvanDeleteBasarili);
            }
            return new ErrorResult( ResponseMessages.UnvanDeleteBasarisiz);
        }

        public IDataResult<List<Unvan>> GetAll()
        {
            var result =  _unvanDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Unvan>>(result);
            }
            return new ErrorDataResult<List<Unvan>>();
        }

        public IDataResult<List<Unvan>> GetAllFilter(string unvanAdi)
        {
            var result =  _unvanDal.GetAllFilter(new Unvan() { UnvanAdi=unvanAdi });
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Unvan>>(result);
            }
            return new ErrorDataResult<List<Unvan>>();
        }

        public IDataResult<Unvan> GetById(int id)
        {
            var result =  _unvanDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<Unvan>(result);
            }
            return new ErrorDataResult<Unvan>();
        }

        public IResult Update(Unvan entity)
        {
            var result =  _unvanDal.Update(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.UnvanUpdateBasarili);
            }
            return new ErrorResult( ResponseMessages.UnvanUpdateBasarisiz);
        }
    }
}
