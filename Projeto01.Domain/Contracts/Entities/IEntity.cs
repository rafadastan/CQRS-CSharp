using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Contracts.Entities
{
    public interface IEntity
    {
        ValidationResult Validate { get; }
    }
}
