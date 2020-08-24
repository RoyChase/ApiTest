using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Context _ctx;
        public CustomerController(Context ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult<IQueryable<Customer>> Get()
        {
            var data =_ctx.GetTable<Customer>().LoadWith(c => c.Emails);

            //var spam = data.ToList();

            return Ok(data);
        }
    }
}
