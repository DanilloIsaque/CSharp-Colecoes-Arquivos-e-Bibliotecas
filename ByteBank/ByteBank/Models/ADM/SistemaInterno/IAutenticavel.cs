using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Models.ADM.SistemaInterno
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);
    }
}