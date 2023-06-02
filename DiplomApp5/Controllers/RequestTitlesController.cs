using DiplomApp5.Models;
using DiplomApp5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomApp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTitlesController : Controller
    {
        private readonly ApplicationContext _context;

        public RequestTitlesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.RequestTitles.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public RequestTitle Get(int id)
        {
            return _context.RequestTitles.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            RequestTitle requestTitle = Get(id);
            _context.RequestTitles.Remove(requestTitle);
            _context.SaveChanges();
        }

        [HttpPost]
        public int Add(RequestTitle requestTitle)
        {
            _context.RequestTitles.Add(requestTitle);
            _context.SaveChanges();
            return requestTitle.Id;
        }

        [HttpPut]
        public void Update(RequestTitle requestTitle)
        {
            _context.RequestTitles.Update(requestTitle);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
