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
    public class RequestVendorsController : Controller
    {
        private readonly ApplicationContext _context;

        public RequestVendorsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.RequestVendors.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public RequestVendor Get(int id)
        {
            return _context.RequestVendors.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            RequestVendor requestVendor = Get(id);
            _context.RequestVendors.Remove(requestVendor);
            _context.SaveChanges();
        }

        [HttpPost]
        public int Add(RequestVendor requestVendor)
        {
            _context.RequestVendors.Add(requestVendor);
            _context.SaveChanges();
            return requestVendor.Id;
        }

        [HttpPut]
        public void Update(RequestVendor requestVendor)
        {
            _context.RequestVendors.Update(requestVendor);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
