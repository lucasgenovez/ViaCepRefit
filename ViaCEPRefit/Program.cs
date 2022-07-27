using Refit;
using System;
using System.Threading.Tasks;

namespace ViaCEPRefit
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu CEP: ");
                string cepInformado = Console.ReadLine().ToString().Replace("-", "");
                Console.WriteLine($"CEP Informado: {cepInformado}");

                Console.WriteLine("Consultando Informações do CEP...");

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine($"\nLogradouro: {address.Logradouro}\nBairro: {address.Bairro}\nCidade: {address.Localidade}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na consulta de CEP {ex.Message}");
            }
        }
    }
}
