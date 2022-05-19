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
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;
        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public async Task<IDataResult<int>> Add(Personel entity)
        {
            var result = await _personelDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.PersonelAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.PersonelAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(Personel entity)
        {
            var result = await _personelDal.DeleteAsync(entity.Id);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.PersonelDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.PersonelDeleteBasarisiz);
        }

        public async Task<IDataResult<List<Personel>>> GetAll()
        {
            var result = await _personelDal.GetAllAsync();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Personel>>(result);
            }
            return new ErrorDataResult<List<Personel>>(result);
        }

        public async Task<IDataResult<Personel>> GetById(int id)
        {
            var result = await _personelDal.GetByIdAsync(id);
            if (result != null)
            {
                return new SuccessDataResult<Personel>(result);
            }
            return new ErrorDataResult<Personel>(result);
        }

        public async Task<IDataResult<int>> Update(Personel entity)
        {
            var result = await _personelDal.UpdateAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.PersonelUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.PersonelUpdateBasarisiz);
        }
    }
}
