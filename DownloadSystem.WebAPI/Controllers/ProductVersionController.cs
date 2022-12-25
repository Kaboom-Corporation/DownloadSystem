
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
    public class ProductVersionController : ControllerBase
    {
        private readonly IMapper Mapper;
        private readonly DBContext Context;

        public ProductVersionController(IMapper mapper, DBContext context)
        {
            Mapper = mapper;
            Context = context;
        }

        // GET: api/<ProductVersionController>
        [HttpGet]
        public async Task<ActionResult<List<ProductVersionViewModel>>> GetAll()
        {
            var ProductVersions = Context.ProductVersions.ToList();
            return Ok(ProductVersions.Select(x => Mapper.Map<ProductVersionViewModel>(x)).ToList());
        }

        // GET api/<ProductVersionController>/5
        [HttpGet]
        public async Task<ActionResult<ProductVersionViewModel>> GetByID(Guid id)
        {
            var ProductVersion = await Context.ProductVersions.FindAsync(id);

            if (ProductVersion == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ProductVersionViewModel>(ProductVersion));
        }

        [HttpGet]
        public async Task<ActionResult> GetVersionFileById(Guid id)
        {
            var ProductVersion = await Context.ProductVersions.FindAsync(id);

            if (ProductVersion == null)
            {
                return NotFound();
            }

            return File(ProductVersion.FileByteArray, ProductVersion.FileContentType, ProductVersion.FileFullName);
        }

        [HttpGet]
        public async Task<ActionResult> GetLastVersionFile(Guid productId)
        {
            var ProductVersion = Context.ProductVersions.Where(x => x.ProductID == productId)
                .OrderByDescending(x => x.DateTimeLoad).LastOrDefault();

            if (ProductVersion == null)
            {
                return NotFound();
            }

            return File(ProductVersion.FileByteArray, ProductVersion.FileContentType, ProductVersion.FileFullName);
        }

        // POST api/<ProductVersionController>
        
        [HttpPost]
        public async Task<ActionResult<ProductVersionViewModel>> Create([FromForm] ProductVersionEditModel ProductVersion, [FromForm] IFormFile file)
        {
            var entity = Mapper.Map<ProductVersionEntity>(ProductVersion);

            entity.FileFullName = file.FileName;
            entity.FileContentType = file.ContentType;
            entity.FileByteArray = ReadFully(file.OpenReadStream());

            Context.ProductVersions.Add(entity);
            await Context.SaveChangesAsync();

            return await GetByID(entity.ID);
        }

        // PUT api/<ProductVersionController>/5
        [HttpPut]
        public async Task<ActionResult<ProductVersionViewModel>> Edit(Guid id, [FromBody] ProductVersionEditModel ProductVersion)
        {
            var entity = Mapper.Map<ProductVersionEntity>(ProductVersion);
            entity.ID = id;
            Context.ProductVersions.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return await GetByID(entity.ID);
        }

        // DELETE api/<ProductVersionController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ProductVersion = await Context.ProductVersions.FindAsync(id);

            if (ProductVersion == null)
            {
                return NotFound();
            }

            Context.ProductVersions.Remove(ProductVersion);
            await Context.SaveChangesAsync();

            return NoContent();
        }

        private byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
