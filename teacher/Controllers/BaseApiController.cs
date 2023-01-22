using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teacher.Services.Interfaces;

namespace teacher.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IServiceManager _serviceManager;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;

        public BaseApiController(IServiceManager serviceManager, ILoggerManager logger, IMapper mapper)
        {
            _serviceManager= serviceManager;
            _logger= logger;
            _mapper= mapper;
        }
    }
}
