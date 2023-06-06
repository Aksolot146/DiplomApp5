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
    public class RequestPartNumbersController : Controller
    {
        private readonly ApplicationContext _context;

        public RequestPartNumbersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.RequestPartNumbers.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public RequestPartNumber Get(int id)
        {
            return _context.RequestPartNumbers.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            RequestPartNumber requestPartNumber = Get(id);
            _context.RequestPartNumbers.Remove(requestPartNumber);
            _context.SaveChanges();
        }

        [HttpPost]
        public int Add(RequestPartNumber requestPartNumber)
        {
            requestPartNumber.RegDate = DateTime.Now;
            _context.RequestPartNumbers.Add(requestPartNumber);
            _context.SaveChanges();
            return requestPartNumber.Id;
        }

        [HttpPut]
        public void Update(RequestPartNumber requestPartNumber)
        {
            _context.RequestPartNumbers.Update(requestPartNumber);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
