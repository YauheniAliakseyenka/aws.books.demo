using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AWS.Books.WebAPI.Demo.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        private IConfiguration Configuration;

        public TestController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("env")]
        public string Index()
        {
            return Configuration["Environment"];
        }
    }
}