using ByteBankIO;
using System.Text;

partial class Program // ele pode lidar com a classe program em outros arquivo, de uma forma unica, mas separada em diversos arquivos
{
    static void Main(string[] args)
    {
        //var enderecoArquiv = "contas.txt";

        //using (var fluxoArquivo = new FileStream(enderecoArquiv, FileMode.Open))
        //{
        //    var leitor = new StreamReader(fluxoArquivo);//StreamReader é uma classe intermediária que fará a manipulação e leitura dos bytes do FileStream
        //   // var linha = leitor.ReadLine();
        //    //var texto = leitor.ReadToEnd();
        //    //Console.WriteLine(texto);
        //    //var numero = leitor.Read(); //primeiro byte do arquivo
        //    //Console.WriteLine(numero);

        //    while (!leitor.EndOfStream)//enquanto não for o final do arquivo, fazendo linha por linha
        //    {
        //        var linha = leitor.ReadLine();
        //        var contaCorrente = ConverterStringParaContaCorrente(linha);
        //        var msg = $"Titular: {contaCorrente.Titular.Nome}, Agência: {contaCorrente.Agencia}, Conta: {contaCorrente.Numero}, Saldo: {contaCorrente.Saldo}";
        //        Console.WriteLine(msg);
        //    }
        //}

        //CriarArquivo();
        //CriarArquivoComWriter();
        //TesteEscrita();
        //CriarArquivoComBinario();
        //LeituraBinaria();
        StreamConsole();
        Console.ReadLine();
   
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',');
        var agencia = int.Parse(campos[0]);
        var numero = int.Parse(campos[1]);
        var saldo = double.Parse(campos[2].Replace('.',','));
        var titular = new Cliente();
        titular.Nome = campos[3];
        var resultado = new ContaCorrente(agencia, numero);
        resultado.Depositar(saldo);
        resultado.Titular = titular;

        return resultado;
    }

    static void CriarArquivo()
    {
        var enderecoArquiv = "contasExportadas.csv";
        using (var fluxoArquivo = new FileStream(enderecoArquiv, FileMode.Create))
        {
            var contaComoString = "456,789456-1,1000.50,Pedro Silva";
            var encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes(contaComoString); //converte a string em bytes
            fluxoArquivo.Write(bytes, 0, bytes.Length); //escreve os bytes no arquivo
            Console.WriteLine($"Arquivo criado com sucesso em {(Path.GetFullPath("contasExportadas.csv"))}");
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadasWriter.csv";
        using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)) //CreateNew só cria se não existir um igual
        using(var escritor = new StreamWriter(fluxoArquivo))
        {
            escritor.Write("456,789456-1,43000.50,Carlos Santos");
            Console.WriteLine($"Arquivo criado com sucesso em {(Path.GetFullPath("contasExportadasWriter.csv"))}");
        }
    }

    static void TesteEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";
        using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)) //CreateNew só cria se não existir um igual
        using (var escritor = new StreamWriter(fluxoArquivo))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush();
                Console.WriteLine($"Linha {i} foi escrita no arquivo. Pressione enter... "); // nao estava gravando no arquivo por conta da latencia no hd, demora um pouco mais
                // nos outros casos, e utilizado a memoria ram
                //o flush vai despejar o buffer para o stream, fazendo diretamente
                Console.ReadLine();

            }
        }
    }

    static void CriarArquivoComBinario()
    {
        var caminhoNovoArquivo = "testeBinario.txt";
        using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)) //CreateNew só cria se não existir um igual
        using (var escritor = new BinaryWriter(fluxoArquivo))
        {
            // ao inves de armazenar um texto puro, vai armazenar um binario oara os valores numericos. o valor inteiro ou double ali pode ser muito grande 
            escritor.Write(456);
            escritor.Write(789456);
            escritor.Write(100310.50);
            escritor.Write("Danillo");
        }
    }

    static void LeituraBinaria()
    {
        var caminhoNovoArquivo = "testeBinario.txt";
        using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Open)) //CreateNew só cria se não existir um igual
        using (var leitor = new BinaryReader(fluxoArquivo))
        {
            //ler o arquivo binario
            var agencia = leitor.ReadInt32();
            var numero = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"Agência: {agencia}, Conta: {numero}, Saldo: {saldo}, Titular: {titular}");
        }
    }

    static void StreamConsole()
    {
        using (var fluxoEntrada = Console.OpenStandardInput()) // fluxo de entrada padrao do console
        using(var fluxoSaida = new FileStream("console.txt", FileMode.Create))
        {
           var buffer = new byte[1024];

            while (true)
            {
                var numeroBytesLidos = fluxoEntrada.Read(buffer, 0, 1024);

                fluxoSaida.Write(buffer, 0, numeroBytesLidos); 
                fluxoSaida.Flush();
                Console.WriteLine($"Bytes lidos: {numeroBytesLidos}");
            }
        }
    }
}