using Application1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {

        private ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _appDbContext;


        public Product2Controller(ILogger<WeatherForecastController> logger, AppDbContext appDbContext)
        {
            this._logger = logger;
            this._appDbContext = appDbContext;
        }


        [HttpGet]
        public List<Product> Add(Product product)
        {
            _appDbContext.Add(product);
            _appDbContext.SaveChanges();


            var list = from a in _appDbContext.Products
                       orderby a.ID
                       select a;

            return list.ToList();
        }
    }
}
