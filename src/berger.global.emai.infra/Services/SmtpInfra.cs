using System.IO;
using System.Reflection;
using brg.emai.infra.Interfaces;

namespace brg.emai.infra.Services
{
    public class SmtpInfra : ISmtpInfra
    {
        public string Get()
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(basePath, "smtp.json");

            string json = new StreamReader(path).ReadToEnd();

            return json;
        }
    }
}
