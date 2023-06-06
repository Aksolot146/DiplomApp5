using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiplomApp5.Models;
using DiplomApp5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DiplomApp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCustomers = await _context.Users.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("{login}/{password}")]
        public User Get(string login, string password)
        {
            var user = _context.Users
                .Include(x => x.Profile).ThenInclude(x => x.Department)
                .Include(x => x.Profile).ThenInclude(x => x.UserRank)
                .FirstOrDefault(x => x.Login == login);

            if (user != null && VerifyPassword(password, user.Password))
                return user;

            return new User();
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            User user = Get(id);
            _context.Users.Remove(user);
            //_context.UserProfiles.Remove(_context.UserProfiles.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

        [HttpPost]
        public int Add(User user)
        {
            user.RegDate = DateTime.Now;
            user.AuthDate = DateTime.Now;
            user.Password = HashPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            /*UserProfile userProfile = new UserProfile()
            {
                UserId = user.Id,
                //DeptId = 1,
                //RankId = 3,
                //Nickname = "default"
            };

            _context.UserProfiles.Add(userProfile);
            _context.SaveChanges();*/
            return user.Id;
        }

        [HttpPut]
        public void Update(User user) {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            byte[] hashBytes = Convert.FromBase64String(passwordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}