using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using opg_201910_interview.Models;

namespace opg_201910_interview.Controllers
{
    public class JsonFormatController : Controller
    {
        private IOptions<ClientSettings> settings;
        public JsonFormatController(IOptions<ClientSettings> _settings)
        {
            settings = _settings;
        }

        public string Index()
        {
            foreach (var client in settings.Value.Clients)
            {
                var dir = new DirectoryInfo(client.FileDirectoryPath);
                var files = dir.GetFiles("*.xml");
                var fileNames = files.Select(i => i.Name).ToList();
                var sorted = Helpers.Methods.CustomStringOrdering(fileNames, client.ClientOrder);
                client.Files = sorted;
            }

            var result = settings.Value.Clients.Select(i => new {
                ClientID = i.ClientId,
                Files = i.Files
            }).ToList();

            var json = JsonConvert.SerializeObject(result);
            return json;
        }
    }
}