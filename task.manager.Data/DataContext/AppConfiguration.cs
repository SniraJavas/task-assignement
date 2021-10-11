using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;



namespace task.manager.data.DataContext
{
     public class AppConfiguration
    {
        public string sqlConnectionString { set; get; }
        public AppConfiguration() {
            var configBUilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBUilder.AddJsonFile(path, false);
            var root = configBUilder.Build();
            var appSetting = root.GetSection("ConnectionStrings: DefaultConnection");

            sqlConnectionString = appSetting.Value;
            Console.WriteLine("connection str ", sqlConnectionString);
        }
       
    }
}
