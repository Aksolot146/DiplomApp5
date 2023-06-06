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
    public class RequestsController : Controller
    {
        RequestService _requestService;

        public RequestsController(RequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public IEnumerable<Request> Get()
        {
            /*try
            {
                var listCustomers = await _context.Requests.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/
            return _requestService.GetRequests();
        }

        [HttpGet("{id}")]
        public Request Get(int id)
        {
            return _requestService.GetRequest(id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            _requestService.DeleteRequest(id);
        }

        [HttpPut]
        public void Update(Request request)
        {
            _requestService.UpdateRequest(request);
        }

        [HttpPost]
        public int Add(Request request)
        {
            _requestService.AddRequest(request);
            return request.Id;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
