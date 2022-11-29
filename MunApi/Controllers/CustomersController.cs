using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunApi.Contexts;
using MunApi.Models;
using MunApi.Models.Entities;
using MunApi.Services;
using System.Net;
using System.Numerics;

namespace MunApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerServices _customerServices;

        public CustomersController(CustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerServices.Create(model);
                return new OkResult();
            }
                return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return new OkObjectResult(await _customerServices.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _customerServices.Get(id);
            if(result != null)
                return new OkObjectResult(result);

            return new NotFoundResult();
        }
    }
}
