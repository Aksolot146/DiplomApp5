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
    public class RequestModelsController : Controller
    {
        private readonly ApplicationContext _context;

        public RequestModelsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.RequestModels.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public RequestModel Get(int id)
        {
            return _context.RequestModels.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            RequestModel requestModel = Get(id);
            _context.RequestModels.Remove(requestModel);
            _context.SaveChanges();
        }

        [HttpPost]
        public int Add(RequestModel requestModel)
        {
            _context.RequestModels.Add(requestModel);
            _context.SaveChanges();
            return requestModel.Id;
        }

        [HttpPut]
        public void Update(RequestModel requestModel)
        {
            _context.RequestModels.Update(requestModel);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
