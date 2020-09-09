using ESB_ConnectionPoints.PluginsInterfaces;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;
using System;

namespace ESBservice
{
    /// <summary>
    /// Фабрика для создания входящей точки подключения.
    /// </summary>
    public sealed class IngoingConnectionPointFactory
        : IIngoingConnectionPointFactory
    {
        public const string PORT            = @"Порт";
        public const string PREFIX_ADDRESS  = @"Префикс базового адресса";
        public const string CLASS_ID        = @"Класс входящего сообщения";
        public const string TYPE            = @"Тип входящего сообщения";

        public IIngoingConnectionPoint Create(Dictionary<string, string> parameters,
            IServiceLocator serviceLocator)
        {
            if (!parameters.ContainsKey(PORT))
            {
                throw new ArgumentException(string.Format("Не задан порт <{0}>"),
                    PORT);
            }
            if (!parameters.ContainsKey(PREFIX_ADDRESS))
            {
                throw new ArgumentException(string.Format("Не задан префикс <{0}>"),
                    PREFIX_ADDRESS);
            }

            string port             = parameters[PORT];
            string prefixAddress    = parameters[PREFIX_ADDRESS];
            string classId          = parameters[CLASS_ID];
            string type             = parameters[TYPE];

            return new SOAPserver(serviceLocator ,  port ,
                prefixAddress , classId , type);
        }
    }
}