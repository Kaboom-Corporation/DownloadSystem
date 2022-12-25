using AutoMapper;
using DownloadSystem.Shared.EditModels;
using DownloadSystem.Shared.ViewModels;
using DownloadSystem.WebAPI.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DownloadSystem.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper Mapper;
        private readonly DBContext Context;

        public ProductController(IMapper mapper, DBContext context)
        {
            Mapper = mapper;
            Context = context;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductViewModel>>> GetAll()
        {
            var products = Context.Products.ToList();
            return Ok(products.Select(x => Mapper.Map<ProductViewModel>(x)).ToList());
        }

        // GET api/<ProductController>/5
        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetByID(Guid id)
        {
            var product = await Context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ProductViewModel>(product));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Create([FromBody] ProductEditModel product)
        {
            var entity = Mapper.Map<ProductEntity>(product);
            Context.Products.Add(entity);
            await Context.SaveChangesAsync();

            return await GetByID(entity.ID);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<ActionResult<ProductViewModel>> Edit(Guid id, [FromBody] ProductEditModel product)
        {
            var entity = Mapper.Map<ProductEntity>(product);
            entity.ID = id;
            Context.Products.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return await GetByID(entity.ID);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await Context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            Context.Products.Remove(product);
            await Context.SaveChangesAsync();

            return NoContent();
        }
    }
}
