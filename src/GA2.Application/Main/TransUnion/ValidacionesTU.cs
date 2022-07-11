using GA2.Application.Dto;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using TransUnionService;

namespace GA2.Application.Main.TU
{
    public class ValidacionesTU
    {

        public readonly string serviceUrl = "https://www.transuniondecisioncentreuat.com.mx/TU.IDS.ExternalServices_mex_latam/SolutionExecution/ExternalSolutionExecution.svc";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public ValidacionesTU()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding =
                new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport)
                {
                    OpenTimeout = TimeSpan.MaxValue,
                    CloseTimeout = TimeSpan.MaxValue,
                    ReceiveTimeout = TimeSpan.MaxValue,
                    SendTimeout = TimeSpan.MaxValue
                };
        }

        public async Task<ExternalSolutionExecutionClient> GetInstanceAsync()
        {
            return await Task.Run(() => new ExternalSolutionExecutionClient(basicHttpBinding, endpointAddress));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="rawRequest"></param>
        /// <param name="rawResponse"></param>
        /// <returns></returns>
        public DCResponse ConsumirTU(DCRequest request, out string rawRequest, out string rawResponse)
        {
            try
            {
                if (request.Fields.Any())
                {
                    foreach (var item in request.Fields.Field)
                    {
                        if (item.Key == "PrimaryApplicant")
                        {
                            item.Text = XmlTextEncoder.Encode(item.Text);
                        }
                    }
                }

                string requestFinal = request.Serialize<DCRequest>().Replace("&amp;", "&").Replace(":q1", "").Replace("q1:", "");

                var tu = this.GetInstanceAsync().GetAwaiter().GetResult();
                var estado = tu.State;
                var response = tu.ExecuteXMLString(requestFinal);

                DCResponse responseFinal = Serialization.DeserializeDC(response);
                rawRequest = requestFinal;
                rawResponse = response;

                return responseFinal;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public DCResponse ConsumirTUAqm(DCRequest request, out string rawRequest, out string rawResponse)
        {
            try
            {
                if (request.Fields.Any())
                {
                    foreach (var item in request.Fields.Field)
                    {
                        if (item.Key == "PrimaryApplicant")
                        {
                            item.Text = XmlTextEncoder.Encode(item.Text);
                        }
                        else if (item.Key == "ApplicationData")
                        {
                            item.Text = XmlTextEncoder.Encode(item.Text);
                        }
                    }
                }

                string requestFinal = request.Serialize<DCRequest>();

                requestFinal = requestFinal.Replace("<DCRequest>", "<DCRequest xmlns = \"http://transunion.com/dc/extsvc\" >").Replace("amp;", "");
                requestFinal = request.Serialize<DCRequest>().Replace("&amp;", "&").Replace(":q1", "").Replace("q1:", "");

                var tu = this.GetInstanceAsync().GetAwaiter().GetResult();
                var estado = tu.State;
                var response = tu.ExecuteXMLString(requestFinal);

                DCResponse responseFinal = Serialization.DeserializeDC(response);

                rawRequest = requestFinal;
                rawResponse = response;

                return responseFinal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
