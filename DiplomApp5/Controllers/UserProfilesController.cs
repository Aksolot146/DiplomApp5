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
    public class UserProfilesController : Controller
    {
        private readonly ApplicationContext _context;

        public UserProfilesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.UserProfiles.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public UserProfile Get(int id)
        {
            return _context.UserProfiles.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            UserProfile userProfile = Get(id);
            _context.UserProfiles.Remove(userProfile);
            //_context.Users.Remove(_context.Users.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

        [HttpPost]
        public int Add(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            //userProfile.UserId = user.Id;
            //userProfile.RankId = 3;
            //userProfile.DeptId = 1;
            _context.SaveChanges();
            return userProfile.Id;
        }

        [HttpPut]
        public void Update(UserProfile userProfile)
        {
            _context.UserProfiles.Update(userProfile);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
