using ElectricityBillingSystem.Controllers;
using ElectricityBillingSystem.DTO;
using ElectricityBillingSystem.Entities;
using ElectricityBillingSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBSTest
{
    public class CustomerControllerTests
    {
        private Mock<ICustomerRepository> mockCustomerRepo;
        private Mock<IBillRepository> mockBillRepo;
        private Mock<IPaymentRepository> mockPaymentRepo;

        public CustomerControllerTests()
        {
            mockCustomerRepo = new Mock<ICustomerRepository>();
            mockBillRepo = new Mock<IBillRepository>();
            mockPaymentRepo = new Mock<IPaymentRepository>();
        }

        [Test]
        public void GetAllBillsCustomerTest()
        {
            //Arrange
            var bills = new List<Bill> {
  new Bill(){ BillId = 1, CustomerName = "Akash",CustomerType = "Household",
PaymentStatus = "Due",Units =50,
CustomerId=1,ElectricityBoardId =1
},
new Bill(){ BillId = 1, CustomerName = "Akash",CustomerType = "Household",
PaymentStatus = "Due",Units =50,
CustomerId=1,ElectricityBoardId =1
}
};
            var billDTO = new List<BillDTO>() { };
            mockBillRepo.Setup(x => x.GetAllBillsCustomer(1)).Returns(bills);
            var controller = new CustomerController(mockCustomerRepo.Object, mockBillRepo.Object, mockPaymentRepo.Object);

            //Act
            IActionResult result = controller.GetAllBillsCustomer(1);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
