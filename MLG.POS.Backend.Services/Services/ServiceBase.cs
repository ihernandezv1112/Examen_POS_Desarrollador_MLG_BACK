using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace MLG.POS.Backend.Services.Services
{
    public abstract class ServiceBase
    {
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _configuration;

        protected ServiceBase(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
    }
}
