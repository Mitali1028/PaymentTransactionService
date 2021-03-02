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

        public List<UserPaymentTransaction> GetPaymentByUserId(int userId)
        {
          return (from e in _dbContext.UserPaymentTransactions
                select new UserPaymentTransaction
                {
                    AmountBalance = e.AmountBalance,
                    Transactions =  _dbContext.PaymentTransactions.Where(p =>
                        p.UserPaymentTransactionId == e.Id).OrderByDescending(a => a.PaymentDate).ToList(),
                }).ToList();
        }
    }
}
