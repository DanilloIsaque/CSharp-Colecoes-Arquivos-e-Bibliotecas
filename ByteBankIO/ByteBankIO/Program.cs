using ByteBankIO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var enderecoArquiv = "contas.txt";
 
        var fluxoArquivo = new FileStream(enderecoArquiv, FileMode.Open);
        var buffer = new byte[1024];
        var numeroBytesLidos = -1;


        while(numeroBytesLidos != 0)
        {
            numeroBytesLidos = fluxoArquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer);
        }
       // fluxoArquivo.Read(buffer, 0, 1024); // stream vai gravar da posicao 0 atéa 1024
    //Devoluções:
    // O numero total de bytes lidos do buffer. Isso poderá ser menor que o numero solicitado, se não estiver
    //disponivel nom momento, ou zero, se o final do fluxo for atingido
        
        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer);
        Console.Write(texto);
        /*
        foreach(var MeuByte in buffer)
        {
            Console.Write(MeuByte);
            Console.Write(" ");
        }*/
    }
}