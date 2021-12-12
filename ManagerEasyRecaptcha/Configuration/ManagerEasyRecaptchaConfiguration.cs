using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyRecaptcha.Configuration
{
    public class ManagerEasyRecaptchaConfiguration
    {
        /// <summary>
        /// Valor secreto brindado por google
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Valor publico brindado por google
        /// </summary>
        public string PublicKey { get; set; }
    }
}
