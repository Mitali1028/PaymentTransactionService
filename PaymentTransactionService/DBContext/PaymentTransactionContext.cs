using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentTransactionService.Data;

namespace PaymentTransactionService.DBContext
{
    public class PaymentTransactionContext : DbContext
    {
        public PaymentTransactionContext(DbContextOptions<PaymentTransactionContext> options) : base(options)
        {
        }

        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<User> UserPaymentTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(b => b.Transactions)
                .WithOne(x => x.User).HasForeignKey(x => x.UserPaymentTransactionId);
          

            modelBuilder.Entity<PaymentTransaction>().HasData(
                        new PaymentTransaction
                        {
                            Id = 1,
                            Amount = 1500,
                            UserPaymentTransactionId = 1,
                            PaymentDate = new DateTime(2021, 1, 2)
                        },
                        new PaymentTransaction
                        {
                            Id = 2,
                            Amount = 1700.50,
                            PaymentDate = new DateTime(2021, 1, 25),
                            UserPaymentTransactionId = 1
                        });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                AmountBalance = 30000

            });

           
        }
    }
}
