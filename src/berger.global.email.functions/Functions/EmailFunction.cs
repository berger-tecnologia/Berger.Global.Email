using System.IO;
using Newtonsoft.Json;
using berger.global.application.Interfaces;
using berger.global.application.ViewModels;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Threading.Tasks;

namespace berger.global.functions.Functions
{
    public class EmailFunction
    {
        #region Properties
        private readonly IEmailApplication _application;
        #endregion

        #region Constructors
        public EmailFunction(IEmailApplication application)
        {
            _application = application;
        }
        #endregion

        #region Functions
        [Function("v1.0/email")]
        public async Task<dynamic> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1.0/email")] HttpRequestData request, FunctionContext context)
        {
            var json = new StreamReader(request.Body).ReadToEnd();

            var email = JsonConvert.DeserializeObject<EmailViewModel>(json);

            var answer = await _application.Send(email);

            return answer;
        }
        #endregion
    }
}