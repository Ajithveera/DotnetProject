using CrudWebApi.Database;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        private readonly EmployeeDBContext EmployeeDBContext;

        public EmployeeController (EmployeeDBContext employeeDBContext)
        {
            this.EmployeeDBContext = employeeDBContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var Employees= await EmployeeDBContext.Employees.ToListAsync();
            return Ok(Employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody]Employee Emp)
        {
            Emp.id = new Guid();
            await EmployeeDBContext.Employees.AddAsync(Emp);
            await EmployeeDBContext.SaveChangesAsync();
            return Ok(Emp);
        }

      

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,[FromBody] Employee Emp)
        {
            var Employee=await EmployeeDBContext.Employees.FirstOrDefaultAsync(a=>a.id==id);

            if (Employee != null)
            { 
                Employee.Name = Emp.Name;
                Employee.MobileNo = Emp.MobileNo;
                Employee.EmailId = Emp.EmailId;
                await EmployeeDBContext.SaveChangesAsync();
                return Ok(Emp);
            }
            else
            {
                return NotFound("Employee not found");
            }
        }
   
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await EmployeeDBContext.Employees.FirstOrDefaultAsync(e => e.id == id);

            if (employee != null)
            {
                EmployeeDBContext.Employees.Remove(employee);
                await EmployeeDBContext.SaveChangesAsync();
                return Ok(employee);
            }
            else
            {
                return NotFound("Employee not found");
            }
        }
    }
}
