using System;
using System.Text;
using ESB_ConnectionPoints.PluginsInterfaces;

namespace ESBservice
{
    //  [ServiceBehavior(Namespace = "http://purchases.erpi.crystals.ru", Name = "Set10PurchasesService")]
    public class set10Service : Set10Purchases
    {
         IServiceLocator _soapLocator = SOAPserver.end_addr;
         IMessageHandler _messageHandler = SOAPserver.handler;
         ILogger _logger;
         IMessageFactory _messageFactory = SOAPserver.end_addr.GetMessageFactory();
         string _classId = SOAPserver._classId;
         string _type = SOAPserver._type;

        public void processPurchases(processPurchases request)
        {
            _logger = SOAPserver.end_addr.GetLogger(GetType());
            if (!_messageHandler.HandleMessage(tryCreateMessage(request, _type, _classId)))
            {
                _logger.Info("Обработчик занят делаем паузу 2 секунды");
                SOAPserver._ct.WaitHandle.WaitOne(TimeSpan.FromSeconds(2));
            }      
        }

        public Message tryCreateMessage(processPurchases body, string type , string classId)
        {
            _logger.Error(Encoding.UTF8.GetString(body.Body.purchases));
            try
            {
                
                if (body.Body.purchases != null)
                {
                    Message newMessage = _messageFactory.CreateMessage(type);
                    newMessage.Body = body.Body.purchases;
                    newMessage.ClassId = classId;
                    return newMessage;
                }
                _logger.Warning(Encoding.UTF8.GetString(body.Body.purchases) + " пустое тело сообщений");
                return null;
            }
            catch(Exception ex)
            {
                _logger.Error("Не удалось создать сообщение : ( " + ex.Message + " )");
                return null;
            }
        }

        //public Task processPurchasesAsync(processPurchases request)
        //{
        //    return null;
        //}
    }
}
