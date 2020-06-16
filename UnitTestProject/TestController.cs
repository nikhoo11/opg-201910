using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opg_201910_interview.Controllers;
using opg_201910_interview.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class TestController
    {
        private Client testClient = new Client() { ClientId = 1001, FileDirectoryPath = "../../../../opg-201910Base-master/UploadFiles/ClientA", 
                                                ClientOrder = "shovel, waghor, blaze, discus" };
        IOptions<ClientSettings> settings;

        [TestMethod]
        public void TestJsonFormatController()
        {
            try
            {
                List<Client> clients = new List<Client>();
                clients.Add(testClient);
                settings = Options.Create<ClientSettings>(new ClientSettings() { Clients = clients });

                var ctrl = new JsonFormatController(settings);
                var result = ctrl.Index();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
