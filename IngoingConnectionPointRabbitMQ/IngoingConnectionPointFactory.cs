using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESB_ConnectionPoints.PluginsInterfaces;

namespace IngoingConnectionPointRabbitMQ
{
    class IngoingConnectionPointFactory : IIngoingConnectionPointFactory
    {
        public const string NAME_QUEUE = @"Наименование очереди";
        public const string PORT = @"Порт сервиса";
        public const string PREFIX_ADDRESS = @"Префикс базового адресса";
        
        public IIngoingConnectionPoint Create(Dictionary<string, string> parameters, IServiceLocator serviceLocator)
        {
            if(!parameters.ContainsKey(PORT))
            {
                throw new ArgumentException(string.Format("Не задан порт {0}", PORT));
            }
            if(!parameters.ContainsKey(PREFIX_ADDRESS))
            {
                throw new ArgumentException(string.Format("Не задан префикс адреса {0}", PREFIX_ADDRESS));
            }

            string port = parameters[PORT];
            string prefixAddress = parameters[PREFIX_ADDRESS];
            string name_queue = parameters[NAME_QUEUE];

            return new IngoingConnectionPoint(serviceLocator, port, prefixAddress, name_queue);
        }
    }
}
