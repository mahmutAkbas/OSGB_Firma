using Entities.Concrete.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.ValidationRules.FluentValidation
{
    public class PersonelValidator:AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(p => p.Adi).MinimumLength(3);
            RuleFor(p => p.Adi).NotEmpty();

            RuleFor(p => p.Soyadi).MinimumLength(3);
            RuleFor(p => p.Soyadi).NotEmpty();

            RuleFor(p => p.Telefon).MinimumLength(3);

            RuleFor(p => p.Telefon).NotEmpty();

            RuleFor(p => p.UnvanId).NotNull();
        }
    }
}
