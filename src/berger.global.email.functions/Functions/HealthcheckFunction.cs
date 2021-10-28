using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace berger.global.functions.Functions
{
    public class HealthcheckFunction
    {
        #region Functions
        [Function("v1.0/healthcheck")]
        public dynamic Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1.0/healthcheck")] HttpRequestData request, FunctionContext context)
        {
            return new
            {
                Status = "Ok",
                Version = "1.0",
                Release = "1.0",
                Description = "Email Api",
                Time = DateTime.UtcNow
            };
        }
        #endregion
    }
}