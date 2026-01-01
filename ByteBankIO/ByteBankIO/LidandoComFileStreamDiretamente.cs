using ByteBankIO;
using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {
        var enderecoArquiv = "contas.txt";
        using (var fluxoArquivo = new FileStream(enderecoArquiv, FileMode.Open)) // nao precisa do metodo close no fim 
        {
            var buffer = new byte[1024];
            var numeroBytesLidos = -1;

            while (numeroBytesLidos != 0)
            {
                numeroBytesLidos = fluxoArquivo.Read(buffer, 0, 1024);
                Console.WriteLine($"Bytes lidos: {numeroBytesLidos}");
                EscreverBuffer(buffer, numeroBytesLidos);
            }
            // fluxoArquivo.Read(buffer, 0, 1024); // stream vai gravar da posicao 0 atéa 1024
            //Devoluções:
            // O numero total de bytes lidos do buffer. Isso poderá ser menor que o numero solicitado, se não estiver
            //disponivel nom momento, ou zero, se o final do fluxo for atingido
            fluxoArquivo.Close(); // arquivo finalizado
            Console.ReadLine();
        }

    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer, 0, bytesLidos);
        Console.Write(texto);
        /*
        foreach(var MeuByte in buffer)
        {
            Console.Write(MeuByte);
            Console.Write(" ");
        }*/
    }
}