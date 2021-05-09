using AutoMapper;
using Service.DB;
using Service.Models;
using Service.ServiceInterface;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_Book.Models;
using Service.ModelsInterface;

namespace WebApp_Book.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBooksService _booksService;
        private readonly IAuthorsService _authorsService;
        private readonly IMapper _mapper;      
        public BooksController(IBooksService booksService,IAuthorsService authorsService,IMapper mapper)
        {
            _booksService = booksService;
            _authorsService = authorsService;
            _mapper = mapper;
        }
        
        // GET: Books        
        public async Task<ActionResult> Index()
        {
            IEnumerable<IBooks> lista = new List<IBooks>();
            lista = await  _booksService.GetBooksAsync();
            return View(_mapper.Map<List<IBooks>,List<BooksView>>(lista.ToList()));
        }

        // GET: Books/Create
        public async Task<ActionResult> Create()
        {
            var dropdown = await _authorsService.GetAuthorsAsync();
            SelectList list = new SelectList(dropdown, "Id", "Name");
            ViewBag.VehicleNames = list;
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<ActionResult> Create(BooksView newBook)
        {
            try
            {
                var done =  _booksService.Edit(_mapper.Map<BooksView,IBooks>(newBook));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                var dropdown = await _authorsService.GetAuthorsAsync();
                SelectList list = new SelectList(dropdown, "Id", "Name");
                ViewBag.VehicleNames = list;
                var book = await _booksService.GetOneBookAsync(id);
                return View(_mapper.Map<BooksView>(book));
            }
            catch
            {
                return View();
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(BooksView book)
        {
            try
            {
                await _booksService.Update(_mapper.Map<IBooks>(book));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if(id == null)
                {
                    ViewBag.Message = "ID can't be empty!";
                }
                else
                {
                    await _booksService.Delete(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
