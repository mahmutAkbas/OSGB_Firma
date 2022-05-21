using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RandevuManager : IRandevuService
    {
        IRandevuDal _randevuDal;
        public RandevuManager(IRandevuDal randevuDal)
        {
            _randevuDal = randevuDal;
        }

        public IResult Add(Randevu entity)
        {
            var result =  _randevuDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.RandevuAddBasarili);
            }
            return new ErrorResult( ResponseMessages.RandevuAddBasarisiz);
        }

        public IResult Delete(Randevu entity)
        {
            var result =  _randevuDal.Delete(entity.Id);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.RandevuDeleteBasarili);
            }
            return new ErrorResult( ResponseMessages.RandevuDeleteBasarisiz);
        }

        public IDataResult<List<Randevu>> GetAll()
        {
            var result =  _randevuDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Randevu>>(result);
            }
            return new ErrorDataResult<List<Randevu>>(result);
        }

        public IDataResult<List<Randevu>> GetAllByDate(System.DateTime tarih, int userId)
        {
            var result = _randevuDal.GetAllByDate(tarih,userId);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Randevu>>(result);
            }
            return new ErrorDataResult<List<Randevu>>(result);
        }

        public IDataResult<List<Randevu>> GetAllById(int userId)
        {
            var result = _randevuDal.GetAllById(userId);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Randevu>>(result);
            }
            return new ErrorDataResult<List<Randevu>>(result);
        }


        public IDataResult<Randevu> GetById(int id)
        {
            var result =  _randevuDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<Randevu>(result);
            }
            return new ErrorDataResult<Randevu>(result);
        }

        public IDataResult<List<RandevuDto>> GetRandevuDtoAllByOnay(bool randevuOnay)
        {
            var result = _randevuDal.GetlRandevuDtoAll(randevuOnay);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<RandevuDto>>(result);
            }
            return new ErrorDataResult<List<RandevuDto>>(result);
        }

        public IDataResult<List<RandevuDto>> GetRandevuDtoAllFilter(System.DateTime randevuTarih, string firmaAdi, bool randevuOnay)
        {
            var result = _randevuDal.GetlRandevuDtoFilter(randevuTarih,firmaAdi,randevuOnay);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<RandevuDto>>(result);
            }
            return new ErrorDataResult<List<RandevuDto>>(result);
        }

        public IResult Update(Randevu entity)
        {
            if (GetIsTrueByOnay(entity.Id).Success)
            {
                var result = _randevuDal.Update(entity);
                if (result > 0)
                {
                    return new SuccessResult(ResponseMessages.RandevuUpdateBasarili);
                }
                return new ErrorResult(ResponseMessages.RandevuUpdateBasarisiz);
            }
            return new ErrorResult();
           
        }
        private IResult GetIsTrueByOnay(int id)
        {
            var result = GetById(id);
            if (result.Success && result.Data.Onay) { 
                    return new ErrorResult("Onaylanan randevuyu değiştiremezsiniz");
            }
            return new SuccessResult();
        }
    }
}
