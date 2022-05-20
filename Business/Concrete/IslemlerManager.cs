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

        public IResult Add(Islemler entity)
        {
            var result =  _islemlerDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.IslemlerAddBasarili);
            }
            return new ErrorResult( ResponseMessages.IslemlerAddBasarisiz);
        }

        public IResult Delete(Islemler entity)
        {
            var result =  _islemlerDal.Delete(entity.Id);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.IslemlerDeleteBasarili);
            }
            return new ErrorResult( ResponseMessages.IslemlerDeleteBasarisiz);
        }

        public IDataResult<List<Islemler>> GetAll()
        {
            var result =  _islemlerDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Islemler>>(result);
            }
            return new ErrorDataResult<List<Islemler>>(result);
        }

        public IDataResult<List<Islemler>> GetAllFilter(Islemler entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Islemler> GetById(int id)
        {
            var result =  _islemlerDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<Islemler>(result);
            }
            return new ErrorDataResult<Islemler>(result);
        }

        public IResult Update(Islemler entity)
        {
            var result =  _islemlerDal.Update(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.IslemlerUpdateBasarili);
            }
            return new ErrorResult( ResponseMessages.IslemlerUpdateBasarisiz);
        }
    }
}
