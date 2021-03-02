using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaymentTransactionService.Repositories;

namespace PaymentTransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;

        public PaymentTransactionController(IPaymentTransactionRepository paymentTransactionRepository)
        {
            _paymentTransactionRepository = paymentTransactionRepository;
        }
        // GET: api/PaymentTransaction
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PaymentTransaction/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var payments = _paymentTransactionRepository.GetPaymentByUserId(id);
            return new OkObjectResult(payments);
        }

        // POST: api/PaymentTransaction
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PaymentTransaction/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
