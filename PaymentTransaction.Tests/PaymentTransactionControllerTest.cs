using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using PaymentTransactionService.Controllers;
using PaymentTransactionService.Data;
using PaymentTransactionService.DBContext;
using PaymentTransactionService.Repositories;
using Xunit;


namespace PaymentTransactionService.Tests
{
    public class PaymentTransactionControllerTest
    {
        private readonly Mock<IPaymentTransactionRepository> _mockPaymentTransactionRepository;
        private readonly PaymentTransactionController _controller;

        public PaymentTransactionControllerTest()
        {
            _mockPaymentTransactionRepository = new Mock<IPaymentTransactionRepository>();
            _controller = new PaymentTransactionController(_mockPaymentTransactionRepository.Object);
        }
        
        [Fact]
        public void GetReturnsContentWithUserNotFound()
        {
            _mockPaymentTransactionRepository.Setup(repo => repo.GetPaymentByUserId(2)).Returns((User) null);                                                          

            var result = _controller.Get(2);

            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("User not found", contentResult.Content);

        }

        [Fact]
        public void GetReturnsMatchingUserDetails()
        {
            _mockPaymentTransactionRepository.Setup(repo => repo.GetPaymentByUserId(1)).Returns(GetTestSessions().FirstOrDefault(s => s.Id == 1));
           
            var result = _controller.Get(1);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<User>(viewResult.Value);
        }

        private List<User> GetTestSessions()
        {
            var sessions = new List<User>
            {
                new User() {
                    Id = 1, 
                    AmountBalance = 30000, 
                    Transactions = new List<PaymentTransaction>
                    {
                        new PaymentTransaction()
                        {
                            Id = 1,
                            Amount = 1500,
                            PaymentDate = new DateTime(2021, 01, 11),
                            UserPaymentTransactionId = 1
                        },

                        new PaymentTransaction()
                        {
                        Id = 2,
                        Amount = 23.34,
                        PaymentDate = new DateTime(2021, 01, 12),
                        UserPaymentTransactionId = 1

                        }
                    }
            },
                new User()
                {
                    Id = 2,
                    AmountBalance = 12000
                }
            };

            return sessions;
        }
    }
}
