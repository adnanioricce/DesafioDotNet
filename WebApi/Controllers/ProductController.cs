using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _dataContext.Set<Product>().ToArrayAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _dataContext.FindAsync<Product>(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<Product> Post([FromBody] Product value)
        {
            _dataContext.Add(value);
            await _dataContext.SaveChangesAsync();
            return value;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Product value)
        {
            var entity = await _dataContext.FindAsync<Product>(id);
            if (entity is null)
                return;            
            
            entity.Name = value.Name;
            entity.Brand = value.Brand;
            entity.Price = value.Price;
                        
            await _dataContext.SaveChangesAsync();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var entity = await _dataContext.FindAsync<Product>(id);
            if (entity is null)
                return;
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
