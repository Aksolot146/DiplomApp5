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
    public class DepartmentsController : Controller
    {
        DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            /*try
            {
                var listCustomers = await _context.Departments.ToListAsync();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/
            return _departmentService.GetDepartments();
        }

        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return _departmentService.GetDepartment(id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            _departmentService.RemoveDepartment(id);
        }

        [HttpPost]
        public int Add(Department department) {
            _departmentService.AddDepartment(department);
            return department.Id;
        }

        [HttpPut]
        public void Update(Department department)
        {
            _departmentService.UpdateDepartment(department);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
