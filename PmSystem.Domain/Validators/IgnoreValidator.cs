using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmSystem.Domain.Validators
{
    public class IgnoreValidator : AbstractValidator<object>
    {
        public IgnoreValidator()
        {
            
        }
    }
}
