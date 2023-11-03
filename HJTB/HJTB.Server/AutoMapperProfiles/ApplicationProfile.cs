using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Applications;

namespace HJTB.Server.AutoMapperProfiles
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Models.Application, CreateViewModel>();
            CreateMap<CreateViewModel, Models.Application>();
        }

    }
}
