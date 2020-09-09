using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESB.ConnectionPoints.WebService;
using ESB.ConnectionPoints.WebService.SOAP;

namespace ESBservice
{
    public class test : ESB.ConnectionPoints.WebService.SOAP.IIngoingStringService
    {
        public StringMessage ExecuteRequest(StringMessage requestMessage, int timeoutSec)
        {
            return null;
        }

        public bool SendMessage(StringMessage message)
        {
            return false;
        }

        public int SendMessageBatch(StringMessageCollection messages)
        {
            return 0;
        }
    }
}

