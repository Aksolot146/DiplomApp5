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
    public class RequestStatsController : Controller
    {
        private readonly ApplicationContext _context;
        public RequestStatsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.RequestStats.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public RequestStat Get(int id)
        {
            return _context.RequestStats.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public int Add(RequestStat requestStat)
        {
            //currentUser.Id = 1;
            _context.RequestStats.Add(requestStat);
            _context.SaveChanges();
            return requestStat.Id;
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            RequestStat requestStat = Get(id);
            _context.RequestStats.Remove(requestStat);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Remove()
        {
            _context.Database.ExecuteSqlRaw("delete from requeststats");
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
