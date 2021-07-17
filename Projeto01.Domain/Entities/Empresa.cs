using FluentValidation.Results;
using Projeto01.Domain.Contracts.Entities;
using Projeto01.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Entities
{
    public class Empresa : IEntity
    {
        #region Properties

        public Guid Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

        #endregion

        #region Navigations

        public ICollection<Funcionario> Funcionarios { get; set; }

        #endregion

        #region Validations

        public ValidationResult Validate 
            => new EmpresaValidation().Validate(this);

        #endregion
    }
}
