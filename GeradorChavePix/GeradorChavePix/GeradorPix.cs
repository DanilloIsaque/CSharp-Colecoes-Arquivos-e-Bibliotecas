using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorChavePix
{
    public static class GeradorPix // static pq só vai gerar chave pix
    {
        public static string GerarChavePixAleatoria()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 32);
        }
        public static string GetChavePix()
        {
            return Guid.NewGuid().ToString();
        }

        public static List<string> GetChavesPix(int numeroChaves)
        {
            if (numeroChaves <= 0)
            {
                throw new ArgumentException("O número de chaves deve ser maior que zero.");
            }
            else
            {
                var chavesPix = new List<string>();
                for (int i = 0; i < numeroChaves; i++)
                {
                    chavesPix.Add(Guid.NewGuid().ToString());
                }

                return chavesPix;
            }
        }
    }
}
