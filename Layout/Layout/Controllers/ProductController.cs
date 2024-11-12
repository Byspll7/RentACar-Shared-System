using AutoMapper;
using Layout.Helpers;
using Layout.Models;
using Layout.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Layout.Controllers
{
    public class ProductController : Controller
    {

        private AppDBContext _context;

        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;

        public AppDBContext Context { get => _context; set => _context = value; }

        public ProductRepository ProductRepository => _productRepository;

        public ProductController(AppDBContext context, IHelper helper, IMapper mapper)
        {

            _productRepository = new ProductRepository();

            _context = context;
            _mapper = mapper;
        }





        public IActionResult Index()
        {
            

            var products = _context.TblProduct.ToList();

           
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Remove(int id)
        {
            var product = _context.TblProduct.Find(id);
            _context.TblProduct.Remove(product);
            _context.SaveChanges(); 
            return RedirectToAction("Index");


        }


        [HttpGet]   
        public IActionResult Add()
        {
            //Select Duration
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 month",1 },
                { "3 month",3 },
                { "6 month",6 },
                { "12 month",12 }
            };


            //SelectList
            ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new(){Data="Blue",Value="Blue",},
                  new(){Data="Red",Value="Red"},
                    new(){Data="Gray",Value="Gray" },
                      new(){Data="Green",Value="Greem"},
                        new(){Data="Black",Value="Black"},
                          new(){Data="White",Value="White"}
                

            }, "Value", "Data");
            
            return View();
             
        }

        [HttpPost]
        public  IActionResult Add(ProductViewModel newProduct)
        {
            //Checkout Validation
            if (ModelState.IsValid)
            {
                _context.TblProduct.Add(_mapper.Map<Product>(newProduct));
                _context.SaveChanges();
                TempData["status"] = "Product has been added succesfully";

                return RedirectToAction("Index");
            }
            else
            {
                //Select Duration
                ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 month",1 },
                { "3 month",3 },
                { "6 month",6 },
                { "12 month",12 }
            };


                //SelectList
                ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new(){Data="Blue",Value="Blue",},
                  new(){Data="Red",Value="Red"},
                    new(){Data="Gray",Value="Gray" },
                      new(){Data="Green",Value="Greem"},
                        new(){Data="Black",Value="Black"},
                          new(){Data="White",Value="White"}


            }, "Value", "Data");

                return View();
            }
            
        }
           
        

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.TblProduct.Find(id);

            ViewBag.ExpireValue= product.Expire;
            //Select Duration
            ViewBag.Expire = new Dictionary<string,int>()
            {
                { "1 month",1 },
                 { "3 month",3 },
                  { "6 month",6 },
                   { "12 month",12 }
            };


            //SelectList
            ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new(){Data="Blue",Value="Blue",},
                  new(){Data="Red",Value="Red"},
                    new(){Data="Gray",Value="Gray" },
                      new(){Data="Green",Value="Greem"},
                        new(){Data="Black",Value="Black"},
                          new(){Data="White",Value="White"}


            }, "Value", "Data",product.Color);

            TempData["status"] = "Product has been update succesfully";

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            
            if(ModelState.IsValid)
            {
                ViewBag.ExpireValue = updateProduct.Expire;
                //Select Duration
                ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 month",1 },
                 { "3 month",3 },
                  { "6 month",6 },
                   { "12 month",12 }
            };


                //SelectList
                ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new(){Data="Blue",Value="Blue",},
                  new(){Data="Red",Value="Red"},
                    new(){Data="Gray",Value="Gray" },
                      new(){Data="Green",Value="Greem"},
                        new(){Data="Black",Value="Black"},
                          new(){Data="White",Value="White"}


            }, "Value", "Data",updateProduct.Color);



                return RedirectToAction("Index=++");
            }
            _context.TblProduct.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();
            TempData["status"] = "Product has been succefully updated";
            return RedirectToAction("Index");
        }
    }
}
