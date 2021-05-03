using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codeFirsto.Models;
using codeFirsto.Repositories.Interfaces;
using codeFirsto.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace codeFirsto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration Configuration;
        IBookRepository _bookrepo;
        IPublisherRepository _publrepo;
        ITokenServices _services;
        IUserRepository _userRepository;

        public WeatherForecastController(
         ILogger<WeatherForecastController> logger,
         IBookRepository bookrepo,
         IPublisherRepository publrepo,
         IConfiguration configuration,
         IUserRepository userRepository,
         ITokenServices services)
        {
            _logger = logger;
            _bookrepo = bookrepo;
            _publrepo = publrepo;
            Configuration = configuration;
            _services = services;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("{id}/{oto}")]
        public async Task<List<Publisher>> GetAction(int id, string oto, [FromQuery(Name = "ele")] string ele)
        {
            Console.WriteLine(oto);
            Console.WriteLine(ele);
            Console.WriteLine(Configuration.GetValue<String>("SystemConfig:Nome"));
            return await _publrepo.getAll(id);
        }

        [HttpGet]
        [Route("autehnticated")]
        [Authorize()]
        public async Task<List<Publisher>> Geto()
        {
            return await _publrepo.getAll(1);
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
        {
            var _user = await _userRepository.GetUser(user.UserName, user.Password);
            var token = _services.GenerateToken(_user);
            return new
            {
                user = user,
                token = token
            };
        }
    }
}