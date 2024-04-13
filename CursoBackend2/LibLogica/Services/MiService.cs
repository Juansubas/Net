using LibLogica.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibLogica.Services
{
    public class MiService : IMiService
    {
        public void Division(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.Write($"No se puede dividir por cero, cambie su valor de {num2}");
            }
            else
            {
                Console.Write($"El resultado de la Division es , {num1/num2}");
            }
        }

        public void Multiplicacion(double num1, double num2)
        {
            Console.Write($"El resultado de la Multiplicacion es , {num1 * num2}");
        }

        public void Resta(double num1, double num2)
        {
            Console.Write($"El resultado de la Resta es , {num1 - num2}");
        }

        public void Saluda(string nombre)
        {
            Console.Write($"Hola, {nombre}");
        }

        public void Suma(double num1, double num2)
        {
            Console.Write($"El resultado de la Suma es , {num1 - num2}");
        }
    }
}
