using LibLogica.Interfaces;

namespace LibLogica.Services
{
    public class MiService : IMiService
    {
        public void Saluda(string nombre)
        {
            Console.Write($"Hola, {nombre}");
        }
    }
}
