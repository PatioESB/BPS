using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using ESB_ConnectionPoints.PluginsInterfaces;

namespace ESBservice
{


    public  class SOAPserver : IStandartIngoingConnectionPoint
    {
        /// <summary>
        /// Логгер.
        /// </summary>
        public  readonly ILogger _logger;
        /// <summary>
        /// Фабрика сообщений.
        /// </summary>
        public  readonly IMessageFactory _messageFactory;
        /// <summary>
        /// Порт сервиса
        /// </summary>
        public readonly string _port;
        /// <summary>
        /// префикс адресса.
        /// </summary>
        public readonly string _prefixAddress;
        /// <summary>
        /// класс входящих сообщений
        /// </summary>
        //public readonly string _classId;
        /// <summary>
        /// тип входящего сообщения.
        /// </summary>
        //public readonly string _type;
        /// <summary>
        /// Свойство класс сообщения.
        /// </summary>
        public static string _classId { get; private set; }
        ///<summary>
        ///Свойство типа сообщения.
        /// </summary>
        public static string _type { get; private set; }
        /// <summary>
        /// Сервис локатор
        /// </summary>
        public static IServiceLocator end_addr { get; private set; }
        /// <summary>
        /// Обработчик сообщения.
        /// </summary>
        public static IMessageHandler handler { get; private set; }
        /// <summary>
        /// Токен свободного потока.
        /// </summary>
        public static CancellationToken _ct { get; private set; }
        /// <summary>
        /// Константа
        /// </summary>
        private TimeSpan _readInterval = TimeSpan.FromSeconds(1);

        public SOAPserver(IServiceLocator serviceLocator ,  string port , 
            string prefixAddress , string classId , string type)
        {

            if (string.IsNullOrEmpty(classId))
            {
                _logger.Info(string.Format("Не задан класс сообщения <{0}>", classId));
            }

            if (string.IsNullOrEmpty(type))
            {
                _logger.Info(string.Format("Не задан type сообщения <{0}>", type));
            }

            _logger = serviceLocator.GetLogger(GetType());
            _messageFactory = serviceLocator.GetMessageFactory();
            end_addr = serviceLocator;
            _prefixAddress = prefixAddress;
            _port = port;
            _classId = classId;
            _type = type;
        }

        public  void Run(IMessageHandler messageHandler, CancellationToken ct)
        {
            _ct = ct;
            handler = messageHandler;
            while (!ct.IsCancellationRequested)
            {
                continue;
            }
        }

        public void Initialize()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri baseAddress = new Uri("http://"+ System.Net.Dns.GetHostName() + ":" + _port + "/adapters/" + _prefixAddress);
            var svc = new ServiceHost(typeof(set10Service), baseAddress);
            svc.AddServiceEndpoint(typeof(Set10Purchases), binding, baseAddress);
            svc.Open();
            _logger.Debug("SOAP сервис запущен , адрес " + svc.BaseAddresses[0].AbsoluteUri);
        }

        public void Cleanup()
        {
        }

        public void Dispose()
        {
        }
    }
}
