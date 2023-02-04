using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StcWebApi.Data;
using StcWebApi.Models;
using StcWebApi.Models.Cutomer;

namespace StcWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CustomerController : ControllerBase
    {
        private readonly StcDbContext _context;
        public CustomerController(StcDbContext context)
        {
            _context= context;
        }
        [HttpGet("")]
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.customers. ToListAsync();  
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer),statusCode:200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID (int id)
        {
            var data= await _context.customers.FindAsync(id);
            return data==null ? NotFound() : Ok(data);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<string> Create (Customer customer)
        { 
             await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return "success";
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update (int id, Customer customer)
        {
            if (id != customer.Id) return NotFound();
            _context.Entry(customer).State = EntityState.Modified;
            await  _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DeleteItem = await _context.customers.FindAsync(id);
            if (DeleteItem == null) return NotFound();
            _context.customers.Remove(DeleteItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
