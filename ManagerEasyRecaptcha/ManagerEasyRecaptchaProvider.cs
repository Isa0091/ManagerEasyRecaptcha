using ManagerEasyRecaptcha.Abstract;
using ManagerEasyRecaptcha.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyRecaptcha
{
    public class ManagerEasyRecaptchaProvider : IManagerEasyRecaptchaProvider
    {
        private readonly ManagerEasyRecaptchaConfiguration _managerEasyRecaptchaConfiguration;
        private readonly HttpClient _client;

        public ManagerEasyRecaptchaProvider(
            HttpClient client,
            ManagerEasyRecaptchaConfiguration managerEasyRecaptchaConfiguration)
        {
            _client = client;
            _managerEasyRecaptchaConfiguration = managerEasyRecaptchaConfiguration;
        }

        public bool Validate(string gRecaptchaResponse)
        {
            return ReCaptchaPassed(gRecaptchaResponse);
        }

        public string GetPublicKey()
        {
            return _managerEasyRecaptchaConfiguration.PublicKey;
        }

        private bool ReCaptchaPassed(string gRecaptchaResponse)
        {
            var result = _client.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_managerEasyRecaptchaConfiguration.Secret}&response={gRecaptchaResponse}").Result;
            if (result.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            string JSONres = result.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);
            if (JSONdata.success != "true")
            {
                return false;
            }

            return true;
        }
    }
}
