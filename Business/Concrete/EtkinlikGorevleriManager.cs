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
    public class EtkinlikGorevleriManager : IEtkinlikGorevleriService
    {
        IEtkinlikGorevleriDal _etkinlikGorevleriDal;
        public EtkinlikGorevleriManager(IEtkinlikGorevleriDal etkinlikGorevleriDal)
        {
            _etkinlikGorevleriDal = etkinlikGorevleriDal;
        }

        public async Task<IDataResult<int>> Add(EtkinlikGorevleri entity)
        {
            var result = await _etkinlikGorevleriDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikGoreviAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikGoreviAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(EtkinlikGorevleri entity)
        {
            var result = await _etkinlikGorevleriDal.DeleteAsync(entity.Id);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikGoreviDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikGoreviDeleteBasarisiz);
        }

        public async Task<IDataResult<List<EtkinlikGorevleri>>> GetAll()
        {
            var result = await _etkinlikGorevleriDal.GetAllAsync();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikGorevleri>>(result);
            }
            return new ErrorDataResult<List<EtkinlikGorevleri>>(result);
        }

        public async Task<IDataResult<EtkinlikGorevleri>> GetById(int id)
        {
            var result = await _etkinlikGorevleriDal.GetByIdAsync(id);
            if (result != null)
            {
                return new SuccessDataResult<EtkinlikGorevleri>(result);
            }
            return new ErrorDataResult<EtkinlikGorevleri>(result);
        }

        public async Task<IDataResult<int>> Update(EtkinlikGorevleri entity)
        {
            var result = await _etkinlikGorevleriDal.UpdateAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikGoreviUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikGoreviUpdateBasarisiz);

        }
    }
}
