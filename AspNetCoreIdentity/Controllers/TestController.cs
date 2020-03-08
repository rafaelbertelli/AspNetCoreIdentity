using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        //private readonly ILogger _logger;

        //public TestController(ILogger logger)
        //{
        //    _logger = logger;
        //}

        [AllowAnonymous]
        public IActionResult Index()
        {
            //_logger.Trace("Hello world from AspNetCore!");
            try
            {
                throw new Exception("Vou pegar o erro mesmo sem estar no _logger");
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }
    }
}