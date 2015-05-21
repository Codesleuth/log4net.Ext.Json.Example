using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using log4net.Config;

namespace log4net_json
{
    public static class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main()
        {
            XmlConfigurator.Configure();

            _log.Info(new { Body = "Hello!" });
            _log.Error(new { ErrorMessage = "Something went wrong!" });
            _log.Debug(new { Key = "Hey", Value = "You?" });

            try
            {
                throw new Exception("Something went REALLY wrong!");
            }
            catch (Exception ex)
            {
                _log.Error(new { Problem = "Exception" }, ex);
            }

            var dictionary = new Dictionary<string, string>()
            {
                {"Pigs", "Pink"},
                {"Simpsons", "Yellow"}
            };

            _log.Info(dictionary);
        }
    }
}
