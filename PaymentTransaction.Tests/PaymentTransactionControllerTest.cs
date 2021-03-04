using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
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
        private HttpClient _client;
        private PaymentTransactionContext _dbContext;
        private IConfiguration _configuration;

        public PaymentTransactionControllerTest()
        {
            // some configuration for http end point testing.. 
           // _configuration = new ConfigurationBuilder()
           //     .AddJsonFile("appsettings.json")
           //     .AddEnvironmentVariables()
           //     .Build();
           // var webHostBuilder = new WebHostBuilder()
           //     .UseConfiguration(_configuration)
           //     .UseStartup<Startup>()
           //     .ConfigureTestServices(config =>
           //         {
           //             config.AddScoped(a => _mockPaymentTransactionRepository.Object);
           //         }
           //     );

           // var testServer = new TestServer(webHostBuilder);
           // _client = testServer.CreateClient();
           // _client.DefaultRequestHeaders.Add("X-Authorization", "ABCD");

           // var serviceProvider = testServer.Host.Services;

           // _dbContext = serviceProvider.GetService<PaymentTransactionContext>();
           //_dbContext.Database.Migrate();


            _mockPaymentTransactionRepository = new Mock<IPaymentTransactionRepository>();
            _controller = new PaymentTransactionController(_mockPaymentTransactionRepository.Object);
        }
        
        [Fact]
        public void GetReturnsContentWithUserNotFound()
        {
            _mockPaymentTransactionRepository.Setup(repo => repo.GetUserPaymentTransactionsById(2)).Returns((User) null);                                                          

            var result = _controller.Get(2);

            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("User not found", contentResult.Content);

        }

        [Fact]
        public void GetReturnsMatchingUserDetails()
        {
            _mockPaymentTransactionRepository.Setup(repo => repo.GetUserPaymentTransactionsById(1)).Returns(GetTestSessions().FirstOrDefault(s => s.Id == 1));
           
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
                            UserId = 1
                        },

                        new PaymentTransaction()
                        {
                        Id = 2,
                        Amount = 23.34,
                        PaymentDate = new DateTime(2021, 01, 12),
                        UserId = 1

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
