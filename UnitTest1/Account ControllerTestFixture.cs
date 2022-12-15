using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTest1
{
    public class Account_ControllerTestFixture
    {
        [Test,
            TestCase("abcd1234",false),
            TestCase("ifr@uni-corvinus",false),
            TestCase("irf.uni-corvunis.hu",false),
            TestCase("ifr@uni-corvinus.hu",true)
            ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test,
            TestCase("abcdABCD", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("Abc1234", false),
            TestCase("Abcd1234", true)
            ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult2 = accountController.ValidatePassword(password);
            Assert.AreEqual(expectedResult, actualResult2);
        }
    }
}
