using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using opg_201910_interview.Helpers;

namespace UnitTestProject
{
    [TestClass]
    public class MethodTest
    {
        private List<string> data = new List<string>() { "blaze-2019-03-20", "blaze-2018-03-03", "discus-2015-12-21", "waghor-2012-05-23", "shovel-2000-01-01", "eclair_20180908" };
        private string order = "shovel, waghor, blaze, discus";

        [TestMethod]
        public void TestCustomStringOrdering()
        {
            try
            {
                var result = Methods.CustomStringOrdering(data, order);
                Console.WriteLine(result.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFormatInput()
        {
            try
            {
                var result = Methods.FormatInput(data);
                Console.WriteLine(result.ToString());
            }
            catch(Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestConvertStringToDateTime()
        {
            try
            {
                var input = "2020-06-16";
                var result = Methods.ConvertStringToDateTime(input);
                Console.WriteLine(result.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
