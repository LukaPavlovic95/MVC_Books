using AutoMapper;
using Service.ModelsInterface;
using Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_Book.Models;

namespace WebApp_Book.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IMapper _mapper;
        public AccountController(ILoginService loginService, IRegisterService registerService, IMapper mapper)
        {
            _loginService = loginService;
            _registerService = registerService;
            _mapper = mapper;
        }

        // GET: Login
        public async Task<ActionResult> Index()
        {
            IEnumerable<IRegister> lista = new List<IRegister>();
            lista = await _registerService.GetUsers();
            return View(_mapper.Map<List<IRegister>, List<RegisterView>>(lista.ToList()));
        }
        public async Task<ActionResult> Register()
        {
            var model = new RegisterView(); 
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterView reg)
        {
            if (ModelState.IsValid)
            {
                if (_registerService.Register(_mapper.Map<IRegister>(reg)).Result)
                {
                    RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Error", "User already exists!");
                    return View();
                }                
            }            
            return View();
        }
        public async Task<ActionResult> Login()
        {
            var model = new LoginView();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginView login)
        {
            if (ModelState.IsValid)
            {                
                var loginChk = _loginService.Login(_mapper.Map<ILogin>(login));
                if (loginChk.Result == login.Email)
                {
                    Session["Email"] = login.Email;
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email and Password is Not Matching");
                    return View();
                }
            }
            return View();
        }
        public async Task<ActionResult> Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login","Account");
        }
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    ViewBag.Message = "ID can't be empty!";
                }
                else
                {
                    await _registerService.Delete(id);
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