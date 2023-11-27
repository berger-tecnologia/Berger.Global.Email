using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Email
{
    public class TemplateService : ITemplateService
    {
        public string Process(string template, List<KeyValuePair<string, string>> data)
        {
            foreach (var pair in data)
            {
                template = template.Replace(pair.Key, pair.Value);
            }

            return template;
        }
    }
}