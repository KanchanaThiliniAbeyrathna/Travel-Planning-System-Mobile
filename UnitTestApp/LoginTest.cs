using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyAppTrial;

namespace UnitTestApp
{
    [TestClass]
    public class LoginTest
    {
        LoginPage testlogin = new LoginPage();

        [TestMethod]
        public void Test1()
        {
            Assert.Equals(4, 3);
            //equal button click
        }

        [TestMethod]
        public async void TestLoginMethod()
        {
            string loginParams = "email=malshathilini10.13@cse.mrt.ac.lk&password=7777";
            string responseBody = await testlogin.checkLogin(loginParams);
            string expected = "ERROR LOGIN";
            Assert.Equals(expected, responseBody);
        }

        [TestMethod]
        public async void ErrorTestLoginMethod()
        {
            string loginParams = "email=kanchanatabeyrathna@gmail.com&password=1111";
            string responseBody = await testlogin.checkLogin(loginParams);
            string expected = "ERROR LOGIN";
            Assert.AreNotSame(expected, responseBody);
        }


    }
}
