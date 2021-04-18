using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Serilog_Seq_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        //DI
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public void Index()
        {
            string adSoyad = "Eren Yılmaz";
            var complexType = new {Name = "Eren", Lastname = "Yılmaz", Age = 23, Gender = "Man"};

            _logger.LogInformation("Home Index Triggered.");
            _logger.LogInformation("{adSoyad} Kullanıcısı Sisteme Giriş Yaptı.", adSoyad);
            _logger.LogInformation("{@complexType} Sisteme Giriş Yaptı", complexType);  //COMPLEX TYPE'LAR SERIALIZE EDİLİR.

        }




    }
}
