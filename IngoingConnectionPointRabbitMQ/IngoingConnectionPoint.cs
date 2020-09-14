using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESB_ConnectionPoints.PluginsInterfaces;

namespace IngoingConnectionPointRabbitMQ
{
    class IngoingConnectionPoint : IStandartIngoingConnectionPoint
    {
        public readonly ILogger _logger;
        public readonly IMessageFactory _messageFactory;
        public readonly string _port;
        public readonly string _prefixAddress;

        public IngoingConnectionPoint(IServiceLocator serviceLocator , string port
            , string prefixAddress, string name_queue)
        {
            if(string.IsNullOrEmpty(name_queue))
            {
                _logger.Error("Задайте имя очереди");
            }
            _logger = serviceLocator.GetLogger(GetType());
            _messageFactory = serviceLocator.GetMessageFactory();
            _port = port;
            _prefixAddress = prefixAddress;
        }
        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Run(IMessageHandler messageHandler, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
