using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiplomApp5.Models;
using DiplomApp5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomApp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentUserController : Controller
    {
        private readonly ApplicationContext _context;

        public CurrentUserController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.CurrentUser.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public CurrentUser Get(int id)
        {
            return _context.CurrentUser.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("session/{sessionId?}")]
        public CurrentUser GetBySessionId(string sessionId)
        {
            var currentUser = _context.CurrentUser.FirstOrDefault(x => x.SessionId == sessionId);

            if (currentUser != null)
                return currentUser;

            return new CurrentUser() { RankId = 0/*3*/ };
        }

        [HttpPost]
        public int Add(CurrentUser currentUser)
        {
            //currentUser.Id = 1;
            _context.CurrentUser.Add(currentUser);
            _context.SaveChanges();
            return currentUser.Id;
        }

        [HttpPut]
        public void Update(CurrentUser currentUser)
        {
            if (_context.Users.Where<User>(x => x.Login == currentUser.Login && x.Password == currentUser.Password) != null)
            {
                if (_context.CurrentUser.Count<CurrentUser>() != 0)
                    _context.CurrentUser.Update(currentUser);
                else
                    Add(currentUser);
            }
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            CurrentUser currentUser = Get(id);
            _context.CurrentUser.Remove(currentUser);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
