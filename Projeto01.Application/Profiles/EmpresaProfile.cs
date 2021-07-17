using AutoMapper;
using Projeto01.Application.Commands.Empresas;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            #region Commands To Entities

            CreateMap<EmpresaCreateCommand, Empresa>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    //dest.NomeFantasia = src.NomeFantasia;
                    //dest.RazaoSocial = src.RazaoSocial;
                    //dest.Cnpj = src.Cnpj;
                });

            CreateMap<EmpresaUpdateCommand, Empresa>();
            CreateMap<EmpresaDeleteCommand, Empresa>();

            #endregion

            #region Entities to Models

            CreateMap<Empresa, EmpresaModel>();

            #endregion
        }
    }
}
