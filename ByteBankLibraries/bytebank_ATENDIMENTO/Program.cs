using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;
using GeradorChavePix;
//Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
//new ByteBankAtendimento().AtendimentoCliente();

/*o nível de visibilidade internal torna 
o elemento visível somente na própria biblioteca que o declarou, DLL ou executável que o contém.*/
//EAutenticaoUtil autenticador = new AutenticaoUtil();

//apos adicionar nas dependencias do projeto bytebank_ATENDIMENTO a referencia ao projeto GeradorChavePix
//é possivel acessar a classe GeradorChavePix que é interna ao projeto bytebank
Console.WriteLine(GeradorPix.GetChavePix());

var lista = GeradorPix.GetChavesPix(12);

foreach (var chave in lista)
{
    Console.WriteLine(chave);
}
