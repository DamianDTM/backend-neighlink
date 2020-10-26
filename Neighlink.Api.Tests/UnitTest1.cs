using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neighlink.Repository;
using Neighlink.Entity;
using Neighlink.Repository.implementation;
using Neighlink.Repository.Context;
using TechTalk.SpecFlow.CommonModels;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Neighlink.Api.Tests
{
   
    [TestClass]
    public class UnitTest1
    {
        ApplicationDbContext context;
        IOptions<PrivateSettings> settings;

        [TestMethod]
        public void HU07()
        {
            User usuario = new User();
            UserRepository rep = new UserRepository(context, settings);
            usuario = rep.Authenticate("correo@gmail.com", "21312");
            Assert.AreEqual(rep.Authenticate("correo@gmail.com", "21312"),usuario);
        }

        [TestMethod]
        public void HU08()
        {
            Payment pago = new Payment();

            PaymentRepository rep = new PaymentRepository(context);
            pago.BillId = 1;
            IEnumerable<Payment> expected;
            expected = rep.GetPaymentsByBill(pago.BillId);

            Assert.AreEqual(rep.GetPaymentsByBill(1), expected);

        }
       
       [TestMethod]
        public void HU09()
        {
            PaymentCategory PayC = new PaymentCategory();
            PaymentCategoryRepository rep = new PaymentCategoryRepository(context);
            PayC.CondominiumId = 1;
            IEnumerable<PaymentCategory> expected;
            expected = rep.GetBuildingsByCondominium(PayC.CondominiumId);
            Assert.AreEqual(rep.GetBuildingsByCondominium(1), expected);
        }


        [TestMethod]
        public void HU10()
        {


            Payment pagoR = new Payment();
            PaymentRepository rep = new PaymentRepository(context);
            pagoR.UserId = 1;
            IEnumerable<Payment> expected;
            expected = rep.GetPaymentsByUser(pagoR.UserId);
            Assert.AreEqual(rep.GetPaymentsByUser(1), expected);

        }
    }
}
