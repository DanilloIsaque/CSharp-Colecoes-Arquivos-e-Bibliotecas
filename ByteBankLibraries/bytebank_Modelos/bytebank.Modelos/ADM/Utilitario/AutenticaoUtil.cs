using System;
using System.Collections.Generic;
using System.Text;

namespace bytebank_Modelos.bytebank.Modelos.ADM.Utilitario
{
    internal class AutenticaoUtil
    {
        public bool ValidarSenha(string senha, string senhaTentativa)
        {
            return senha.Equals(senhaTentativa);
        }
    }
}
