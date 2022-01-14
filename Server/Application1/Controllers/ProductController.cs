using Application1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Application1.Controllers
{
    public class ProductController : Controller
    {
        /*
         * IOrderedQueryable<Product> Index()
         {
             return list2;
         }
        */


        private readonly ILogger<ProductController> logger;
        private ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _appDbContext;

        
        public ProductController(ILogger<WeatherForecastController> logger, AppDbContext appDbContext)
        {
            this._logger = logger;
            this._appDbContext = appDbContext;
        }



        //public List<Product> Index()
        //{ 
        //    var productList = Get();
        //    return productList ;
        //}




        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        

        Product product1=new Product();

        [HttpPost]
        public ActionResult Index(string CatId, string ProNam, string ProDes, int ProPri, int ProSto)
        {
            product1.CategoryId = Convert.ToInt32(CatId);
            product1.ProductName = ProNam;
            product1.ProductDescription = ProDes;
            product1.ProductPrice = ProPri;
            product1.ProductStock = ProSto;
            Add(product1);

            return Content($"Registration Successful \nCategoryId:  { CatId} \nProduct Name:  {ProNam} " +
                $"\nProduct Description: {ProDes} \nProduct Price: {ProPri} \nProduct Stock: {ProSto} ");
            
        }

        [HttpGet]       
        public List<Product> Get()
        {
            // Query expression
            // Tüm kayıtları ID sıralı biçimde listelenecek
            var list = from a in _appDbContext.Products
                        orderby a.ID
                        select a;           

            return list.ToList();
        }

        [HttpPost]
        public List<Product> GetById([FromBody]Product product)
        {
            //Query expression
            //İstenen Id de bulunan kayıt listelenecek

            var list = from a in _appDbContext.Products
                        where a.ID == product.ID
                        select a;

            return list.ToList();
        }

        [HttpPost]
        public List<Product> GetFilterByName([FromBody]Filter filter)
        {
            var list = from a in _appDbContext.Products
                       where a.ProductName.Contains(filter.ProductName)
                       select a;

            return list.ToList();
        }

        [HttpPost]
        public List<Product> GetFilter([FromBody]Filter filter)
        {
            var list = from a in _appDbContext.Products
                       select a;
            if (filter.CategoryId.ToString()!=null)
            {
                list = from a in list
                       where a.CategoryId == filter.CategoryId
                       select a;
            }

            // if (filter.ProductName != null)

            if (filter.ProductName != "")
            {
                list = from a in list
                       where a.ProductName.Contains(filter.ProductName)
                       select a;
            }
            if (filter.ProductMinPrice != null)
            {
                list = from a in list
                       where a.ProductPrice >= filter.ProductMinPrice
                       select a;
            }
            if ( filter.ProductMaxPrice != null)
            {
                list = from a in list
                       where a.ProductPrice <= filter.ProductMaxPrice
                       select a;
            }
            if (filter.ProductMinStock != null)
            {
                list = from a in list
                       where a.ProductStock > filter.ProductMinStock
                       select a;

            }          
            return list.ToList();
        }

        [HttpPost]
        public List<Product> Add([FromBody]Product product)
        {
            _appDbContext.Add(product);
            _appDbContext.SaveChanges();


            var list = from a in _appDbContext.Products
                       orderby a.ID
                       select a;

            return list.ToList();


            //Bilgileri verilen kayıt veritabanına eklencek ve ardından tüm kayıtlar ID sıralı biçimde listelenecek
            //    /Add?CatID=&Name=&Description=&Price=&Stock=

            //Product product = new Product();
            //product.CategoryId = CatId;
            //product.ProductName = Name;
            //product.ProductDescription = Description;
            //product.ProductPrice = Price;
            //product.ProductStock = Stock;

        }

        [HttpPost]
        public List<Product> Delete([FromBody]Product product)
        {
            //Lambda Expressions
            //İstenen Id de bulunan kayıt silinecek ve ardından tüm kayıtlar ID sıralı biçimde listelenecek

            var delete = _appDbContext.Products.Where(x => x.ID == product.ID).FirstOrDefault();
            _appDbContext.Remove(delete);
            _appDbContext.SaveChanges();

            //var list = _appDbContext.Products
            //    .Where(a => a.ID == Id)
            //    .OrderBy(a => a.ID)
            //    .Select (a => a.ProductName );

            //Query expression
            var list = from a in _appDbContext.Products
                       orderby a.ID
                       select a;          

            return list.ToList();

        }

        [HttpPost]
        public List<Product> Update([FromBody]Product product)
        {            
            //İstenen Id de bulunan kaydın ismi verilen isim ile güncellenecek
            //ve ardından tüm kayıtlar ID sıralı biçimde listelenecek
            // Lambda Expressions
            var update = _appDbContext.Products.Where(x => x.ID == product.ID).FirstOrDefault();
            update.ProductName = product.ProductName;
            update.ProductDescription = product.ProductDescription;
            update.ProductPrice = product.ProductPrice;
            update.ProductStock = product.ProductStock;
            _appDbContext.SaveChanges();

            //Query expression
            var list = from a in _appDbContext.Products
                       orderby a.ID
                       select a;                                  
            
            return list.ToList();
        }

    }

}
