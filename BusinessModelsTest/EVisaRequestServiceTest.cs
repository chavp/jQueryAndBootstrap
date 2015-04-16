using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace eVisa.BusinessModels.Test
{
    [TestClass]
    public class EVisaRequestServiceTest
    {
        string _requestUT = "GRC00100000000000000000041";
        [TestMethod]
        public void TestNotifyVerified()
        {
            var serviceUT = new EVisaRequestServiceReference.EVisaRequestServiceClient();

            var opResult = serviceUT.NotifyVerified(_requestUT);
        }

        [TestMethod]
        public void TestNotifyReEdit()
        {
            var serviceUT = new EVisaRequestServiceReference.EVisaRequestServiceClient();

            var opResult = serviceUT.NotifyReEdit(_requestUT, "TestNotifyReEdit");
        }

        [TestMethod]
        public void TestNotifyAppointment()
        {
            var serviceUT = new EVisaRequestServiceReference.EVisaRequestServiceClient();

            var opResult = serviceUT.NotifyAppointment(_requestUT, DateTime.UtcNow.AddDays(3), "TestNotifyReEdit");
        }

        [TestMethod]
        public void TestNotifyApproved()
        {
            var serviceUT = new EVisaRequestServiceReference.EVisaRequestServiceClient();

            var opResult = serviceUT.NotifyApproved(_requestUT);
        }

        [TestMethod]
        public void TestNotifyDisapproved()
        {
            var serviceUT = new EVisaRequestServiceReference.EVisaRequestServiceClient();

            var opResult = serviceUT.NotifyDisapproved(_requestUT, "TestNotifyReEdit");
        }
    }
}
