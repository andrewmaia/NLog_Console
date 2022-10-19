using Microsoft.Extensions.Logging;

namespace NLog_Console
{
    public interface IServico1
    {
        void Log();
    }

    public class Servico1 : IServico1
    {
        ILogger<Servico1> _logger;
        public Servico1(ILogger<Servico1> logger)
        {
            _logger = logger;
        }


        public void Log()
        {
            _logger.Log(LogLevel.Error, "Ocorreu um erro!");
        }
    }
}
