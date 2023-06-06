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
    public class RequestChatController : Controller
    {
        private readonly ApplicationContext _context;

        public RequestChatController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.RequestChat.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public RequestChat Get(int id)
        {
            return _context.RequestChat.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public int Add(RequestChat requestChat)
        {
            _context.RequestChat.Add(requestChat);
            _context.SaveChanges();
            return requestChat.Id;
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            RequestChat requestChat = Get(id);
            _context.RequestChat.Remove(requestChat);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(RequestChat requestChat)
        {
            _context.RequestChat.Update(requestChat);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
