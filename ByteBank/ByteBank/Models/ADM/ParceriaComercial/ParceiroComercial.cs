using ByteBank.Models.ADM.SistemaInterno;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Models.ADM.ParceriaComercial
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}