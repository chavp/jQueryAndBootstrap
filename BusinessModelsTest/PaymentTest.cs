using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eVisa.BusinessModels.Test
{
    using NHibernate;
    using NHibernate.Linq;
    using Cwn.eVisa.BusinessModels;
    using System.Collections.Generic;
    using System.Globalization;

    [TestClass]
    public class PaymentTest
    {
        ISessionFactory _sessionFactory = null;

        [TestInitialize]
        public void Setup()
        {
            _sessionFactory = DBHelper.CreateOracleSessionFactory();
        }

        string _branchUnitCode = "BRA001";
        [TestMethod]
        public void when_root_request_one_eAvisaApply()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                // Given
                var name = "__ROOT@eVisa.com";

                var root = (from m in session.Query<Member>()
                            where m.Username == name
                            select m).Single();

                var receiveEntryType = (from x in session.Query<AccountingEntryType>()
                            where x.Name == "RECEIVE_EVISA_APP_REQ"
                            select x).Single();

                var receiveAcc = new Account(root, receiveEntryType);
                session.Save(receiveAcc);

                var thBath = (from m in session.Query<Currency>()
                              where m.Code == "THB"
                              select m).Single();

                var approved = (from m in session.Query<EApplicationVisaStatus>()
                                where m.Name == "APPROVED"
                            select m).Single();

                var tr60 = (from m in session.Query<VisaType>()
                                where m.Code == "0008"
                                select m).Single();

                var requestCode = GenRequestCode(_branchUnitCode, DateTime.Now, 1);
                //var eApplicationVisa = new EApplicationVisa(root, approved, tr60);
                //session.Save(eApplicationVisa);

                //var newEntry = new AccountingEntry(receiveAcc, 10, 350, thBath);
                //session.Save(receiveAcc);
                //receiveAcc.AccountingEntries.Add(newEntry);

                //// Receipt
                //decimal receivedAmountUSD = 10;
                //var receipt = new Receipt(DateTime.UtcNow, root, receivedAmountUSD);
                //session.Save(receipt);

                //var newReqEntry = new EApplicationVisaRequestAccountingEntry(newEntry, eApplicationVisa, receipt);
                //session.Save(newReqEntry);

                tran.Commit();
            }
        }

        [TestMethod]
        public void when_root_request_two_eAvisaApply()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                // Given
                var name = "__ROOT@eVisa.com";

                var root = (from m in session.Query<Member>()
                            where m.Username == name
                            select m).Single();

                var receiveEntryType = (from x in session.Query<AccountingEntryType>()
                                        where x.Name == "RECEIVE_EVISA_APP_REQ"
                                        select x).Single();

                var receiveAcc = (from x in session.Query<Account>()
                                  where x.Owner == root
                                  && x.EntryType == receiveEntryType
                                  select x).Single();

                //session.Save(receiveAcc);

                var currency = (from m in session.Query<Currency>()
                              where m.Code == "CNY"
                              select m).Single();

                var approved = (from m in session.Query<EApplicationVisaStatus>()
                                where m.Name == "APPROVED"
                                select m).Single();

                var tr60 = (from m in session.Query<VisaType>()
                            where m.Code == "0008"
                            select m).Single();

                //var eApplicationVisa1 = new EApplicationVisa(root, GenRequestCode(_branchUnitCode, DateTime.Now, 2), approved, tr60);
                //session.Save(eApplicationVisa1);

                //var eApplicationVisa2 = new EApplicationVisa(root, GenRequestCode(_branchUnitCode, DateTime.Now, 3), approved, tr60);
                //session.Save(eApplicationVisa2);

                //var newEntry1 = new AccountingEntry(receiveAcc, 10, 60, currency);
                //receiveAcc.AccountingEntries.Add(newEntry1);

                //var newEntry2 = new AccountingEntry(receiveAcc, 10, 60, currency);
                //receiveAcc.AccountingEntries.Add(newEntry2);

                //// Receipt
                //decimal receivedAmountUSD = newEntry1.AmountUSD + newEntry2.AmountUSD;
                //var receipt = new Receipt(DateTime.Now, root, receivedAmountUSD);
                //session.Save(receipt);

                //var newReqEntry1 = new EApplicationVisaRequestAccountingEntry(newEntry1, eApplicationVisa1, receipt);
                //session.Save(newReqEntry1);

                //var newReqEntry2 = new EApplicationVisaRequestAccountingEntry(newEntry2, eApplicationVisa2, receipt);
                //session.Save(newReqEntry2);

                //session.Update(receiveAcc);

                tran.Commit();
            }
        }

        [TestMethod]
        public void check_root_receive_balance()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var name = "__ROOT@eVisa.com";

                var root = (from m in session.Query<Member>()
                            where m.Username == name
                            select m).Single();

                var receiveEntryType = (from x in session.Query<AccountingEntryType>()
                                        where x.Name == "RECEIVE_EVISA_APP_REQ"
                                        select x).Single();

                var receiveAcc = (from x in session.Query<Account>()
                                  where x.Owner == root
                                  && x.EntryType == receiveEntryType
                                  select x).Single();

                var receiveBalance = receiveAcc.AccountingEntries.Sum(e => e.AmountUSD);

                Console.WriteLine("receiveBalance {0}", receiveBalance);
            }
        }

        public string GenRequestCode(string brCode, DateTime requestDate, long sequence)
        {
            CultureInfo forParseDate = new CultureInfo("en-US");
            return string.Format("{0}{1}{2}",
                brCode, requestDate.ToUniversalTime().ToString("yyyyMMdd", forParseDate), sequence.ToString("0000000"));
        }

        [TestCleanup]
        public void Teardown()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                //var receiveEntryType = (from x in session.Query<AccountingEntryType>()
                //                        where x.Name == "RECEIVE_EVISA_APP_REQ"
                //                        select x).Single();

                //var allAccount = (from x in session.Query<Account>()
                //                  where x.EntryType == receiveEntryType
                //                  select x).ToList();

                //foreach (var item in allAccount)
                //{
                //    session.Delete(item);
                //}
                //tran.Commit();
            }
        }

        [TestMethod]
        public void TestConvertBase()
        {
            long id = long.MaxValue;

            string code = IntToString(id,
            new char[] { '0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'}, 13);


        }

        public string IntToString(long value, char[] baseChars, int padding)
        {
            string result = string.Empty;
            int targetBase = baseChars.Length;

            do
            {
                result = baseChars[value % targetBase] + result;
                value = value / targetBase;
            }
            while (value > 0);

            while (result.Length < padding)
            {
                result = "0" + result;
            }

            return result;
        }
    }
}
