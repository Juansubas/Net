using LibLogica.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LibLogica.Services

{
    public class MiService : IMiService
    {
        private readonly IConfiguration _configuration;
        public MiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Division(double num1, double num2)
        {
            try 
            {
                if (num2 == 0) throw new Exception("El numero 2 no puede ser 0");
                Console.Write($"El resultado de la Division es , {num1 / num2}\n");
            } catch (Exception ex) 
            {
                Console.WriteLine($"Se generado un error al tratar de hacer la division {ex.Message}");
            }
        }

        public void LeerAmbiente()
        {
            Console.WriteLine(_configuration["Ambiente"]);
        }

        public void Multiplicacion(double num1, double num2)
        {
            Console.Write($"El resultado de la Multiplicacion es , {num1 * num2}\n");
        }

        public void Resta(double num1, double num2)
        {
            Console.Write($"El resultado de la Resta es , {num1 - num2}\n");
        }

        public void Saluda(string nombre)
        {
            Console.Write($"Hola, {nombre} \n");
        }

        public void Suma(double num1, double num2)
        {
            Console.Write($"El resultado de la Suma es , {num1 + num2} \n");
        }
    }
}
