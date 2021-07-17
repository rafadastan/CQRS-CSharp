using FluentValidation;
using Projeto01.Domain.Entities;
using Projeto01.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Validations
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Id do funcionário é obrigatório.");

            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Nome do funcionário é obrigatório")
                .Length(6, 150).WithMessage("Nome deve ter de 6 a 150 caracteres.");

            RuleFor(f => f.Cpf)
                .NotEmpty().WithMessage("CPF do funcionário é obrigatório")
                .Length(11).WithMessage("CPF deve ter de 11 caracteres.")
                .Must(CpfValidation.IsValid).WithMessage("CPF inválido.");

            RuleFor(f => f.Matricula)
                .NotEmpty().WithMessage("Matrícula do funcionário é obrigatório")
                .Length(6).WithMessage("Matrícula deve ter de 6 caracteres.");

            RuleFor(f => f.DataAdmissao)
                .NotEmpty().WithMessage("Data de Admissão do funcionário é obrigatório");

            RuleFor(f => f.EmpresaId)
                .NotEmpty().WithMessage("Id da empresa é obrigatório");
        }
    }
}
