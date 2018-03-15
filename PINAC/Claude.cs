using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PINAC
{
    class Claude
    {
        private const string soapEnv = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                      <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                                            <soap:Body>
                                                  {0}
                                            </soap:Body>
                                      </soap:Envelope> ";

        // WebService appel au WebClient
        private static Task<string> CallWebClient(string request)
        {
            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "text/xml; charset=utf-8";
            client.Encoding = System.Text.Encoding.UTF8;
            Task<string> getStringTask = client.UploadStringTaskAsync("http://46.105.1.31/Claude/ClaudeService.asmx", "POST", request);

            return getStringTask;
        }

        // WebService aboutClaude
        //public static Task<string> aboutClaude()
        //{
        //    string soapRequest = string.Format(soapEnv, "<aboutClaude />");
        //    return CallWebClient(soapRequest);
        //}

        // WebService userLogin
        public static Task<string> userLogin(string login, string password)
        {
            string fonction = string.Format(@"<userLogin>
                                                <login>{0}</login>
                                                <password>{1}</password>
                                            </userLogin>", login, password);

            string soapRequest = string.Format(soapEnv, fonction);
            return CallWebClient(soapRequest);
        }

        public static Task<string> getPatients(string criteria)
        {
            string fonction = string.Format(@"<patients>
      <criteria>{0}</criteria>
    </patients>", criteria);
            string soapRequest = string.Format(soapEnv,  fonction);
            return CallWebClient(soapRequest);
        }
    }
}