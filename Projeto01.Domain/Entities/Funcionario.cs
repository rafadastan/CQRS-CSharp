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
    public class Funcionario : IEntity
    {
        #region Properties

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Guid EmpresaId { get; set; }

        #endregion

        #region Navigations

        public Empresa Empresa { get; set; }

        #endregion

        #region Validations

        public ValidationResult Validate
            => new FuncionarioValidation().Validate(this);

        #endregion

    }
}
