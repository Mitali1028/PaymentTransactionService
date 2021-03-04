using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentTransactionService.Data;
using PaymentTransactionService.DBContext;

namespace PaymentTransactionService.Repositories
{
    public class PaymentTransactionRepository : IPaymentTransactionRepository
    {
        private readonly PaymentTransactionContext _dbContext;

        public PaymentTransactionRepository(PaymentTransactionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserPaymentTransactionsById(int userId)
        {
          return (from e in _dbContext.UserPaymentTransactions where e.Id == userId
                select new User
                {
                    AmountBalance = e.AmountBalance,
                    Transactions =  _dbContext.PaymentTransactions.Where(p =>
                        p.UserId == e.Id).OrderByDescending(a => a.PaymentDate).ToList(),
                }).FirstOrDefault();
        }
    }
}
