using System.Collections.Generic;
using PaymentTransactionService.Data;

namespace PaymentTransactionService.Repositories
{
    public interface IPaymentTransactionRepository
    {
        User GetPaymentByUserId(int userId);
    }
}