using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PaymentTransactionService.Repositories;

namespace PaymentTransactionService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;

        public PaymentTransactionController(IPaymentTransactionRepository paymentTransactionRepository)
        {
            _paymentTransactionRepository = paymentTransactionRepository;
        }
      
        // GET: api/PaymentTransaction/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var payments = _paymentTransactionRepository.GetUserPaymentTransactionsById(id);
            if(payments == null) return Content("User not found");
            return new OkObjectResult(payments);
        }
    }
}
