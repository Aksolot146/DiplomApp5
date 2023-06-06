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
    public class RequestStatusesController : Controller
    {
        private readonly ApplicationContext _context;

        public RequestStatusesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.RequestStatuses.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public RequestStatus Get(int id)
        {
            return _context.RequestStatuses.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public int Add(RequestStatus requestStatus)
        {
            _context.RequestStatuses.Add(requestStatus);
            _context.SaveChanges();
            return requestStatus.Id;
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            RequestStatus requestStatus = Get(id);
            _context.RequestStatuses.Remove(requestStatus);
            _context.SaveChanges();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
