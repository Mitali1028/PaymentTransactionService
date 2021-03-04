using PaymentTransactionService.Data;

namespace PaymentTransactionService.Repositories
{
    public interface IPaymentTransactionRepository
    {
        User GetUserPaymentTransactionsById(int userId);
    }
}