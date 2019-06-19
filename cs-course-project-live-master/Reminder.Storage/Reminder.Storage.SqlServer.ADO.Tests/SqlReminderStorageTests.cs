using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    [TestClass]
    public class SqlReminderStorageTests
    {
        private const string _connectionString =
             @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ReminderTest;Integrated Security=true;";

        [TestInitialize]
        public void TestInitialize()
        {
            var dbInit = new SqlReminderStorageInit(_connectionString);
            dbInit.InitializeDatabase();
        }

        [TestMethod]
        public void Method_Add_Returns_Not_Empty_Guid()
        {
            var storage = new SqlReminderStorage(_connectionString);

            Guid actual = storage.Add(new ReminderItemRestricted
            {
                ContactId = "TestContactId",
                Date = DateTimeOffset.Now.AddHours(1),
                Message = "Test Message",
                Status = Core.ReminderItemStatus.Awaiting
            });

            Assert.AreNotEqual(Guid.Empty, actual);
        }

        [TestMethod]
        public void Method_Get_By_Id_Method_Returns_Just_Added_Item()
        {
            var storage = new SqlReminderStorage(_connectionString);

            DateTimeOffset expectedDate = DateTimeOffset.Now;
            string expectedContactId = "TEST_CONTACT_ID";
            string expectedMessage = "TEST_MESSAGE_TEXT";
            ReminderItemStatus expectedStatus = ReminderItemStatus.Failed;

            Guid id = storage.Add(new ReminderItemRestricted
            {
                ContactId = expectedContactId,
                Date = expectedDate,
                Message = expectedMessage,
                Status = expectedStatus
            });

            Assert.AreNotSame(Guid.Empty, id);

            var actualItem = storage.Get(id);

            Assert.IsNotNull(actualItem);
            Assert.AreEqual(id, actualItem.Id);
            Assert.AreEqual(expectedContactId, actualItem.ContactId);
            Assert.AreEqual(expectedDate, actualItem.Date);
            Assert.AreEqual(expectedMessage, actualItem.Message);
            Assert.AreEqual(expectedStatus, actualItem.Status);
        }

        [TestMethod]
        public void Method_Get_By_Id_Method_Returns_Null_If_Not_Found()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(Guid.Empty);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Method_Get_By_Status_0_Valid_Number_Of_Items()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(ReminderItemStatus.Awaiting);

            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public void Method_Get_By_Status_1_Valid_Number_Of_Items()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(ReminderItemStatus.Ready);

            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void Method_Get_By_Status_2_Valid_Number_Of_Items()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(ReminderItemStatus.Sent);

            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public void Method_Get_By_Status_3_Valid_Number_Of_Items()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(ReminderItemStatus.Failed);

            Assert.AreEqual(3, actual.Count);
        }

        [TestMethod]
        public void Property_Count_Returns_8_For_Initial_Data_Set()
        {
            var storage = new SqlReminderStorage(_connectionString);

            int actual = storage.Count;
            Assert.AreEqual(8, actual);
        }

        [TestMethod]
        public void Remove_Method_Returns_False_When_Item_Not_Found()
        {
        var storage = new SqlReminderStorage(_connectionString);

        bool actual = storage.Remove(Guid.Empty);
        Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Remove_Method_Returns_True_When_Item_Found()
        {
            var storage = new SqlReminderStorage(_connectionString);

            bool actual = storage.Remove(new Guid("00000000 - 0000 - 0000 - 0000 - 111111111111"));
            Assert.IsTrue(actual);
        }
    }
}
