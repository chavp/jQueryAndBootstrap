using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eVisa.BusinessModels.Test
{
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Cfg;
    using FluentNHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using FluentNHibernate.Cfg.Db;
    using NHibernate.Connection;
    using NHibernate.Driver;

    using Oracle.ManagedDataAccess; // ODP.NET Oracle managed provider
    using Oracle.ManagedDataAccess.Client;
    using Cwn.eVisa.BusinessModels; 

    [TestClass]
    public class DBTest
    {
        ISessionFactory _sessionFactory = null;

        [TestInitialize]
        public void Setup()
        {
            _sessionFactory = DBHelper.CreateOracleSessionFactory();
        }

        [TestMethod]
        public void TestQueryDB()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var visaTypeList = (from x in session.Query<VisaType>()
                              select x).ToList();
            }
        }

        [TestMethod]
        public void InitializeRootMember()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                // Member *******************************************************
                var root = new Member("__ROOT@eVisa.com")
                {
                };

                root.Profile.FirstName = "F_TEST";
                root.Profile.LastName = "L_TEST";

                session.Save(root);
                session.Save(root.Profile);

                var person = (from r in session.Query<Role>()
                              where r.Name == "PERSON"
                              select r).Single();

                var memberRole = new MemberRole(root, person);
                session.Save(memberRole);

                tran.Commit();
            }
        }

        [TestMethod]
        public void InitializeMasterDB()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                // intit EApplicationVisaType *******************************************************
                var draft = new EApplicationVisaStatus("DRAFT", "Draft");
                var reEdit = new EApplicationVisaStatus("RE-EDIT", "Re-edit");
                var pending = new EApplicationVisaStatus("PENDING", "Pending...");
                var verifying = new EApplicationVisaStatus("VERIFYING", "Verifying...");
                var appointment = new EApplicationVisaStatus("APPOINTMENT", "Appointment");
                var approved = new EApplicationVisaStatus("APPROVED", "Approved");
                var disapproved = new EApplicationVisaStatus("DISAPPROVED", "Disapproved");
                session.Save(draft);
                session.Save(reEdit);
                session.Save(pending);
                session.Save(appointment);
                session.Save(approved);
                session.Save(disapproved);

                // Member Role *******************************************************
                var person = new Role("PERSON");
                var agent = new Role("AGENT");
                session.Save(person);
                session.Save(agent);

                // Receive EVISA App Request *******************************************************
                var recieveEntryType = new AccountingEntryType("RECEIVE_EVISA_APP_REQ")
                {
                    Description = "Entry for Receive E-Visa Application Request"
                };

                session.Save(recieveEntryType);

                // Currency *******************************************************
                // THB
                var usa = new Currency("USD")
                {
                    Description = "United States dollar"
                };

                var thailand = new Currency("THB")
                {
                    Description = "Thai baht"
                };

                var chinese = new Currency("CNY")
                {
                    Description = "Chinese yuan"
                };

                session.Save(usa);
                session.Save(thailand);
                session.Save(chinese);

                tran.Commit();
            }
        }

        [TestMethod]
        public void InitializeEApplicationVisaStatus()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var draft = new EApplicationVisaStatus("DRAFT", "Draft");
                var pending = new EApplicationVisaStatus("PENDING", "Pending...");
                var verifying = new EApplicationVisaStatus("VERIFYING", "Verifying...");
                var reEdit = new EApplicationVisaStatus("RE-EDIT", "Re-edit");
                var appointment = new EApplicationVisaStatus("APPOINTMENT", "Appointment");
                var approved = new EApplicationVisaStatus("APPROVED", "Approved");
                var disapproved = new EApplicationVisaStatus("DISAPPROVED", "Disapproved");

                session.Save(draft);
                session.Save(pending);
                session.Save(verifying);
                session.Save(reEdit);
                session.Save(appointment);
                session.Save(approved);
                session.Save(disapproved);

                tran.Commit();
            }
        }

        [TestMethod]
        public void InitializeEntryType()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                // Receive EVISA App Request *******************************************************
                var recieveEntryType = new AccountingEntryType("RECEIVE_EVISA_APP_REQ")
                {
                    Description = "Entry for Receive E-Visa Application Request"
                };

                session.Save(recieveEntryType);

                tran.Commit();
            }
        }

        [TestMethod]
        public void TestMaritalMap()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var results = (from x in session.Query<Marital>()
                                    select x).ToList();

                Assert.AreNotEqual(0, results.Count);
            }
        }

        [TestMethod]
        public void InitMarital()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var single = new Marital("Single")
                {
                    NameTH = "โสด",
                };

                var married = new Marital("Married")
                {
                    NameTH = "แต่งงาน",
                };

                var divorce = new Marital("Divorce")
                {
                    NameTH = "หย่าร้าง",
                };

                var separate = new Marital("Separate")
                {
                    NameTH = "แยกกันอยู่",
                };

                session.Save(single);
                session.Save(married);
                session.Save(divorce);
                session.Save(separate);

                tran.Commit();
            }
        }

        [TestMethod]
        public void InitPurposeOfVisit()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var tourism = new PurposeOfVisit("Tourism")
                {
                    NameTH = "การท่องเที่ยว"
                };

                var transit = new PurposeOfVisit("Transit")
                {
                    NameTH = "ผ่านทาง"
                };

                var business = new PurposeOfVisit("Business")
                {
                    NameTH = "ธุรกิจ"
                };

                var diplomatic_Official = new PurposeOfVisit("Diplomatic/Official")
                {
                    NameTH = "Diplomatic/Official"
                };

                var other = new PurposeOfVisit("Other")
                {
                    NameTH = "อื่นๆ"
                };

                session.Save(tourism);
                session.Save(transit);
                session.Save(business);
                session.Save(diplomatic_Official);
                session.Save(other);

                tran.Commit();
            }
        }

        [TestMethod]
        public void InitTravelling()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var flight = new Travelling("Flight")
                {
                    NameTH = "เครื่องบิน"
                };

                var bus = new Travelling("Bus")
                {
                    NameTH = "รถบัส"
                };

                var car = new Travelling("Car")
                {
                    NameTH = "รถยนต์"
                };

                var ship = new Travelling("Ship")
                {
                    NameTH = "เรือ"
                };

                var motocycle = new Travelling("Motocycle")
                {
                    NameTH = "รถจักรยานยนต์"
                };

                session.Save(flight);
                session.Save(bus);
                session.Save(car);
                session.Save(ship);
                session.Save(motocycle);

                tran.Commit();
            }
        }

        [TestMethod]
        public void InitGender()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var male = new Gender("Male")
                {
                    NameTH = "ชาย"
                };

                var female = new Gender("Female")
                {
                    NameTH = "หญิง"
                };

                session.Save(male);
                session.Save(female);

                tran.Commit();
            }
        }

        [TestMethod]
        public void TestCountry()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var results = (from x in session.Query<Country>()
                               select x).ToList();

                Assert.AreNotEqual(0, results.Count);
            }
        }

        [TestMethod]
        public void TestNation()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var results = (from x in session.Query<Nation>()
                               select x).ToList();

                Assert.AreNotEqual(0, results.Count);
            }
        }

        [TestMethod]
        public void InitAppVisaType()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var touristVisa = (from x in session.Query<VisaType>()
                                   where x.ID == 8
                                   select x).Single();

                var transitVisa = (from x in session.Query<VisaType>()
                                   where x.ID == 9
                                   select x).Single();

                var appTouristVisa = new AppVisaType
                {
                    Name = "Tourist Visa",
                    NameTH = "นักท่องเที่ยว",
                    VisaType = touristVisa
                };

                var appTransitVisa = new AppVisaType
                {
                    Name = "Transit Visa",
                    NameTH = "คนเดินทางผ่าน",
                    VisaType = transitVisa
                };

                session.Save(appTouristVisa);
                session.Save(appTransitVisa);

                tran.Commit();
            }
        }
    }
}
