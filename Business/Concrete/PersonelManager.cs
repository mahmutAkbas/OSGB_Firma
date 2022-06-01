using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using Business.Utilities.ValidationRules;
using Business.Utilities.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;
        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IResult Add(Personel entity)
        {
            var resultValidate = ValidationTool.Validate(new PersonelValidator(), entity);
            if (resultValidate.Length > 0)
            {
                return new ErrorResult(resultValidate);
            }
            entity.KayitTarihi = System.DateTime.Now;
            entity.SilinmeDurumu = false;
            var result = _personelDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult(ResponseMessages.PersonelAddBasarili);
            }
            return new ErrorResult(ResponseMessages.PersonelAddBasarisiz);
        }

        public IResult Delete(Personel entity)
        {
            var result = _personelDal.Delete(entity.Id);
            if (result > 0)
            {
                return new SuccessResult(ResponseMessages.PersonelDeleteBasarili);
            }
            return new ErrorResult(ResponseMessages.PersonelDeleteBasarisiz);
        }

        public IDataResult<List<Personel>> GetAll()
        {
            var result = _personelDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<Personel>>(result);
            }
            return new ErrorDataResult<List<Personel>>(result);
        }

        public IDataResult<List<PersonelDto>> GetAllFilter(string personelAdi, bool silinmeDurumu)
        {
            var result = _personelDal.GetAllFilter(personelAdi, silinmeDurumu);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<PersonelDto>>(result);
            }
            return new ErrorDataResult<List<PersonelDto>>(result);
        }


        public IDataResult<List<PersonelDto>> GetAllPersonelDto(bool silinmeDurumu)
        {
            var result = _personelDal.GetAllPersonelDto(silinmeDurumu);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<PersonelDto>>(result);
            }
            return new ErrorDataResult<List<PersonelDto>>(result);
        }

        public IDataResult<Personel> GetById(int id)
        {
            var result = _personelDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<Personel>(result);
            }
            return new ErrorDataResult<Personel>(result);
        }

        public IResult Update(Personel entity)
        {
     
            var result = _personelDal.Update(entity);
            if (result > 0)
            {
                return new SuccessResult(ResponseMessages.PersonelUpdateBasarili);
            }
            return new ErrorResult(ResponseMessages.PersonelUpdateBasarisiz);
        }
    }
}
