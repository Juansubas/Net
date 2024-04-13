namespace LibLogica.Interfaces
{
    public interface IMiService
    {
        void Saluda(string nombre);

        void Suma(double num1, double num2);

        void Resta(double num1, double num2);
        void Multiplicacion(double num1, double num2);
        void Division(double num1, double num2);
        void LeerAmbiente();
    }
}
