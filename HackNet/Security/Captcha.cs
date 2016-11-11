﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace HackNet.Security
{
    public class Captcha
    {
        [JsonProperty("success")]
        private string _Success;
        public string Success
        {
            get
            {
                return _Success;
            }
            set
            {
                _Success = value;
            }
        }

        [JsonProperty("error-codes")]
        private List<string> _ErrorCodes;
        public List<string> ErrorCodes
        {
            get
            {
                return _ErrorCodes;
            }
            set
            {
                _ErrorCodes = value;
            }
        }

        public static bool Validate(string EncodedResponse)
        {
            WebClient wc = new WebClient();
            var googleReply = wc.DownloadString(
                                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                                "6LdUsQsUAAAAAJx-BwDeWZreLPAPA6otMupIyTsr",
                                EncodedResponse
                                ));
            var captchaResponse = JsonConvert.DeserializeObject<Captcha>(googleReply);
            System.Diagnostics.Debug.WriteLine(captchaResponse.Success);
            return captchaResponse.Success.Contains("true");
        }
    }
}