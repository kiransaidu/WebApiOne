using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiOne.Models;

namespace WebApiOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeessController : ControllerBase
    {
        static List<Employee> list = new List<Employee>()
        {
            new Employee{ Id=1,FName="Sam",LName="Dicosta",Salary=98000.90},
             new Employee{ Id=2,FName="surya",LName="Vendra",Salary=88000.90},
              new Employee{ Id=3,FName="Krishna",LName="Varma",Salary=78000.90},
        };
        [HttpGet]
        public IEnumerable<Employee>Get()
        {
            return list;
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
            Employee emp = list.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(emp);
                return NoContent();
            }
        }
        [HttpPost]
        public ActionResult<Employee>Post(Employee newEmp)
        {
            list.Add(newEmp);
            return CreatedAtAction(nameof(Get), newEmp);
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id,Employee upEmp)
        {
            Employee extemp = list.SingleOrDefault(x => x.Id == id);
            if (extemp == null)
            {
                return NotFound();
            }
            else
            {
               
                return NoContent();
            }
        }
        
    }
}
