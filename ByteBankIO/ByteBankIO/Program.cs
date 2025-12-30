using ByteBankIO;
using System.Text;

partial class Program // ele pode lidar com a classe program em outros arquivo, de uma forma unica, mas separada em diversos arquivos
{
    static void Main(string[] args)
    {
        var enderecoArquiv = "contas.txt";

        using (var fluxoArquivo = new FileStream(enderecoArquiv, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoArquivo);//StreamReader é uma classe intermediária que fará a manipulação e leitura dos bytes do FileStream
           // var linha = leitor.ReadLine();
            //var texto = leitor.ReadToEnd();
            //Console.WriteLine(texto);
            //var numero = leitor.Read(); //primeiro byte do arquivo
            //Console.WriteLine(numero);

            while (!leitor.EndOfStream)//enquanto não for o final do arquivo, fazendo linha por linha
            {
                var linha = leitor.ReadLine();
                Console.WriteLine(linha);
            }
        }
        Console.ReadLine();
   
    }

}