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
    public class UserRanksController : Controller
    {
        private readonly ApplicationContext _context;

        public UserRanksController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.UserRanks.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public UserRank Get(int id)
        {
            return _context.UserRanks.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public int Add(UserRank userRank)
        {
            _context.UserRanks.Add(userRank);
            _context.SaveChanges();
            return userRank.Id;
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            UserRank userRank = Get(id);
            _context.UserRanks.Remove(userRank);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
