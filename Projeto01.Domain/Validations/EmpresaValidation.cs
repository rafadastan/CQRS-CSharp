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
    public class EmpresaValidation : AbstractValidator<Empresa>
    {
        //ctor + 2x[tab] -> método construtor
        public EmpresaValidation()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Id da empresa é obrigatório.");

            RuleFor(e => e.NomeFantasia)
                .NotEmpty().WithMessage("Nome Fantasia é obrigatório.")
                .Length(6, 150).WithMessage("Nome Fantasia deve ter de 6 a 150 caracteres.");

            RuleFor(e => e.RazaoSocial)
                .NotEmpty().WithMessage("Razão Social é obrigatório.")
                .Length(6, 150).WithMessage("Razão Social deve ter de 6 a 150 caracteres.");

            RuleFor(e => e.Cnpj)
                .NotEmpty().WithMessage("CNPJ é obrigatório.")
                .Length(20).WithMessage("CNPJ deve ter 20 caracteres.")
                .Must(CnpjValidation.IsValid).WithMessage("CNPJ inválido.");
        }
    }
}
