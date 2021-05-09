using AutoMapper;
using Service.ModelsInterface;
using Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_Book.Models;

namespace WebApp_Book.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _authorsService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorsService authorsService, IMapper mapper)
        {
            _authorsService = authorsService;
            _mapper = mapper;
        }

        // GET: Authors
        public async Task<ActionResult> Index()
        {
            IEnumerable<IAuthors> lista = new List<IAuthors>();
            lista = await _authorsService.GetAuthorsAsync();
            return View(_mapper.Map<List<IAuthors>, List<AuthorsView>>(lista.ToList()));
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public async Task<ActionResult> Create(AuthorsView newAthor)
        {
            try
            {
                var done = _authorsService.Edit(_mapper.Map<AuthorsView, IAuthors>(newAthor));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            {
                //if (id == null)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                //IAuthors author = _authorsService.GetAuthorsAsync()     
                //.Include(i => i.OfficeAssignment)
                //.Where(i => i.ID == id)
                //.Single();
                //if (instructor == null)
                //{
                //    return HttpNotFound();
                //}
                return View();
            }
        }

        // POST: Authors/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(AuthorsView author)
        {   
            try
            {
                var done = _authorsService.Update(_mapper.Map<IAuthors>(author));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    ViewBag.Message = "ID can't be empty!";
                }
                else
                {
                    //await _authorsService.Delete(id));
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
