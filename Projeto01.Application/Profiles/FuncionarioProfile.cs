using AutoMapper;
using Projeto01.Application.Commands.Funcionarios;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            #region Commands To Entities

            CreateMap<FuncionarioCreateCommand, Funcionario>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                });

            CreateMap<FuncionarioUpdateCommand, Funcionario>();
            CreateMap<FuncionarioDeleteCommand, Funcionario>();

            #endregion

            #region Entities to Models

            CreateMap<Funcionario, FuncionarioModel>();

            #endregion
        }
    }
}
