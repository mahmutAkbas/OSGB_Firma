using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Business.Utilities.ValidationRules
{
    public static class ValidationTool
    {
        public static string Validate(IValidator validator,object entity)
        {
          
            var context=new ValidationContext<object>(entity);
            var result=validator.Validate(context);
            string message = "";
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    message += error + "\n";
                }
            }
            return message;
        }
    }
}
