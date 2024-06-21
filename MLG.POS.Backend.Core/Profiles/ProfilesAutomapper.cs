using AutoMapper;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Core.Profiles
{
    public class ProfilesAutomapper : Profile
    {
        public ProfilesAutomapper()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(c => c.Id_Client, o => o.MapFrom(s => s.Id_Client))
                .ForMember(c => c.Nam_Name, o => o.MapFrom(s => s.Nam_Name))
                .ForMember(c => c.Nam_Surname, o => o.MapFrom(s => s.Nam_Surname))
                .ForMember(c => c.Des_Address, o => o.MapFrom(s => s.Des_Address))
                .ForMember(c => c.Des_Email, o => o.MapFrom(s => s.Des_Email))
                .ForMember(c => c.Des_Password, o => o.MapFrom(s => s.Des_Password));
        }
    }
}
