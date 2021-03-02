using System.Collections.Generic;
using PaymentTransactionService.Data;

namespace PaymentTransactionService.Repositories
{
    public interface IPaymentTransactionRepository
    {
        List<UserPaymentTransaction> GetPaymentByUserId(int userId);
    }
}