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
    public class EtkinlikGorevlileriManager : IEtkinlikGorevlileriService
    {
        IEtkinlikGorevlileriDal _etkinlikGorevlileriDal;
        public EtkinlikGorevlileriManager(IEtkinlikGorevlileriDal etkinlikGorevlileriDal)
        {
            _etkinlikGorevlileriDal = etkinlikGorevlileriDal;
        }
        public async Task<IDataResult<int>> Add(EtkinlikGorevlileri entity)
        {
            var result = await _etkinlikGorevlileriDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikGorevlileriAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikGorevlileriAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(EtkinlikGorevlileri entity)
        {
            var result = await _etkinlikGorevlileriDal.DeleteAsync(entity.Id);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikGorevlileriAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikGorevlileriAddBasarisiz);
        }

        public async Task<IDataResult<List<EtkinlikGorevlileri>>> GetAll()
        {
            var result = await _etkinlikGorevlileriDal.GetAllAsync();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikGorevlileri>>(result);
            }
            return new ErrorDataResult<List<EtkinlikGorevlileri>>(result);
        }

        public async Task<IDataResult<EtkinlikGorevlileri>> GetById(int id)
        {
            var result = await _etkinlikGorevlileriDal.GetByIdAsync(id);
            if (result != null)
            {
                return new SuccessDataResult<EtkinlikGorevlileri>(result);
            }
            return new ErrorDataResult<EtkinlikGorevlileri>(result);
        }

        public async Task<IDataResult<int>> Update(EtkinlikGorevlileri entity)
        {
            var result = await _etkinlikGorevlileriDal.UpdateAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikGorevlileriUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikGorevlileriUpdateBasarisiz);
        }
    }
}
