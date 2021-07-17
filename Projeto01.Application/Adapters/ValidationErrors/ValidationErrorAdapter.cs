using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Adapters.ValidationErrors
{
    public class ValidationErrorAdapter
    {
        public static List<ValidationErrorModel> Parse(IEnumerable<ValidationFailure> errors)
        {
            return errors.Select(
                er => new { er.PropertyName, Errors = er.ErrorMessage })
                .GroupBy(g => g.PropertyName).ToList()
                .Select(
                    s => new ValidationErrorModel
                    {
                        Name = s.Key,
                        Errors = s.Select(m => m.Errors).ToList()
                    }
                )
                .ToList();
        }
    }
}
