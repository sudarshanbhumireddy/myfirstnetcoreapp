using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
    [AllowAnonymous]
    public class ValidEmailDomainAttribute:ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
          string[] val= value.ToString().Split('@');
           return val[1].ToUpper() == _allowedDomain.ToUpper();
        }
    }
}
