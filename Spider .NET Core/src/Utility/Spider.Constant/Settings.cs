using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Spider.Constant
{
    public class Settings
    {
        private static Settings settings;
        private IConfigurationRoot configuration;

        private Settings()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            configuration = builder.Build();
        }

        public static Settings Values()
        {
            if (settings == null)
            {
                settings = new Settings();
            }
            return settings;
        }

        public string DatabaseConnectionString
        {
            get
            {
                return configuration.GetConnectionString("DefaultConnection");
            }
        }

        //Alvays add this inside on own properties. To beter protection of critical data.
        public bool IsDebugEnabled
        {
            //TODO:
            get
            {
                return true;
            }
        }

        public bool IsShowDevelopersExtraInfoOnMessagesCall
        {
            //TODO:           
            get
            {
                return this.IsDebugEnabled && true;
            }
        }



    }
}
