using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Goodies.Util
{


    public class Autenticacao
    {
        public static string TOKEN = "1dh4d6hf621dg29f9d";
        public static string FALHA_AUTENTICACAO = "Falha na Autenticacao - O token informado é inválido";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;

        }
        public void Autenticar()
        {
            try
            {
                string tokenRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();
                if (String.Equals(TOKEN, tokenRecebido))
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(FALHA_AUTENTICACAO);
            }
        }
    }
}
