using System.Globalization;

namespace Data;
public interface ILogService 
{ 
    void saveMessage(string message);
}
public class LogService : ILogService
{
    public void saveMessage(string message)
    {
        var path = @$"{Directory.GetParent(AppContext.BaseDirectory).FullName}\LogErrores.txt";
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture)}]::{message}");
        }
    }
}
