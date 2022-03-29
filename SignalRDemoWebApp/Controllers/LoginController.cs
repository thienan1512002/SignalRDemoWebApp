using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SignalRDemoWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemoWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignalRDemoContext _context;

        public LoginController(SignalRDemoContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetData()
        {
            var data = await _context.Notyfs.ToListAsync();
            return Json(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(string username , string content)
        {
            Notyf notyf = new Notyf();
            notyf.Content = content;
            notyf.Username = username;
            notyf.TimeCreate = DateTime.Now.ToString();
            _context.Notyfs.Add(notyf);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       
    }
}
