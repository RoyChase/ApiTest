using System;
using System.Linq;
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
        public IQueryable<Customer> Get()
        {
            var data =_ctx.GetTable<Customer>();

            var mapped1 = data.Select(c => new CustomerModel
            {
                Emails = c.Emails.Select(m => m.Email),
            });

            try
            {
                var works = mapped1.Select(m => new { m.Emails }).ToList();

                var fails = mapped1.Select(m => m.Emails).ToList();
            }
            catch (Exception)
            {
                

            }

            return data;
        }
    }
}
