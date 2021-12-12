using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyRecaptcha.Abstract
{
    /// <summary>
    /// Maneja la definicion de los metodos 
    /// </summary>
    public interface IManagerEasyRecaptchaProvider
    {
        /// <summary>
        /// Valida el response enviado desde el form
        /// En la accion debe consultarse Request.Form["g-recaptcha-response"]) y eso debe enviarse a este metodo
        /// </summary>
        /// <param name="gRecaptchaResponse"></param>
        /// <returns></returns>
        bool Validate(string gRecaptchaResponse);

        /// <summary>
        /// Obtiene la llave publica configurada
        /// </summary>
        /// <returns></returns>
        string GetPublicKey();
    }
}
