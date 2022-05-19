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
    public class EtkinlikZiyaretManager : IEtkinlikZiyaretService
    {
        IEtkinlikZiyaretDal _etkinlikZiyaretDal;
        public EtkinlikZiyaretManager(IEtkinlikZiyaretDal etkinlikZiyaretDal)
        {
            _etkinlikZiyaretDal = etkinlikZiyaretDal;
        }
        public async Task<IDataResult<int>> Add(EtkinlikZiyaret entity)
        {
            var result = await _etkinlikZiyaretDal.AddAsync(entity);
            if (result> 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikZiyaretiAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikZiyaretiAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(EtkinlikZiyaret entity)
        {
            var result =await _etkinlikZiyaretDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikZiyaretiDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikZiyaretiDeleteBasarisiz);
        }

        public async Task<IDataResult<List<EtkinlikZiyaret>>> GetAll()
        {
            var result =await _etkinlikZiyaretDal.GetAllAsync();
            if ( result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikZiyaret>>(result);
            }
            return new ErrorDataResult<List<EtkinlikZiyaret>>(result);
        }

        public async Task<IDataResult<EtkinlikZiyaret>> GetById(int id)
        {
            var result =await _etkinlikZiyaretDal.GetByIdAsync(id);
            if (result != null)
            {
                return new SuccessDataResult<EtkinlikZiyaret>(result);
            }
            return new ErrorDataResult<EtkinlikZiyaret>(result);
        }

        public async Task<IDataResult<int>> Update(EtkinlikZiyaret entity)
        {
            var result =await _etkinlikZiyaretDal.UpdateAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.EtkinlikZiyaretiUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.EtkinlikZiyaretiUpdateBasarisiz);
        }
    }
}
