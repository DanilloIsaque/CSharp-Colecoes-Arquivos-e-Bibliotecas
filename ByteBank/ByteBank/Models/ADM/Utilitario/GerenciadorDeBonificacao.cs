using ByteBank.Models.ADM.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Models.ADM.Utilitario
{
    public class GerenciadorDeBonificacao
    {
        private double _totalBonificacao;

        public void Registrar(Funcionario funcionario)
        {
            _totalBonificacao += funcionario.getBonificacao();
        }

        public double GetTotalBonificacao()
        {
            return _totalBonificacao;
        }

    }
}