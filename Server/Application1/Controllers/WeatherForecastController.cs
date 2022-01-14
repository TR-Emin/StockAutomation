using Application1.Models;
using Application1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };




        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _appDbContext;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _appDbContext = dbContext;
        }

        [HttpGet]
        public void ProductGet()
        {

            //ProductController productController = new ProductController(_logger,_appDbContext);
            //productController.Get();
            


            //    // Query expression
            //    var list2 = from a in _appDbContext.Products
            //                where a.ProductPrice > 4200
            //                orderby a.ProductPrice
            //                select a;

            //    return list2;

            //    foreach (var item in list2)
            //    {
            //        Console.WriteLine(item.ProductName+"  "+item.ProductPrice);

            //    }


            //    // Lambda expression
            //    var list = _appDbContext.Products
            //        .Where(n => n.CategoryId == 1)
            //        .OrderBy(n => n);
            //    //Select(n => n.ProductName);


            //    var query = from i in list
            //                select new {i.ID, i.CategoryId, i.ProductName, i.ProductDescription, i.ProductPrice, i.ProductStock };


            //    //foreach (var item in list)
            //    //{
            //    //    Console.WriteLine(item.ID+"  "+item.ProductName+" "+item.ProductPrice+"   "+item.ProductDescription);
            //    //}






        }


    }
}
