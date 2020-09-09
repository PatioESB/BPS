using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ESBservice
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://purchases.erpi.crystals.ru", ConfigurationName = "Verme.Set10Purchases")]
    public interface Set10Purchases
    {

        // CODEGEN: Контракт генерации сообщений с именем version из пространства имен  не отмечен как обнуляемый http://purchases.erpi.crystals.ru/inputAction
        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "")]
        void processPurchases(processPurchases request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class processPurchases
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "processPurchases", Namespace = "http://purchases.erpi.crystals.ru", Order = 0)]
        public processPurchasesBody Body;

        public processPurchases()
        {
        }

        public processPurchases(processPurchasesBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "")]
    public partial class processPurchasesBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public byte[] purchases;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string version;

        public processPurchasesBody()
        {
        }

        public processPurchasesBody(byte[] purchases, string version)
        {
            this.purchases = purchases;
            this.version = version;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Set10PurchasesChannel : Set10Purchases, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Set10PurchasesClient : System.ServiceModel.ClientBase<Set10Purchases>, Set10Purchases
    {

        public Set10PurchasesClient()
        {
        }

        public Set10PurchasesClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public Set10PurchasesClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public Set10PurchasesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public Set10PurchasesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Set10Purchases.processPurchases(processPurchases request)
        {
            base.Channel.processPurchases(request);
        }

        public void processPurchases(byte[] purchases, string version)
        {
            processPurchases inValue = new processPurchases();
            inValue.Body = new processPurchasesBody();
            inValue.Body.purchases = purchases;
            inValue.Body.version = version;
            ((Set10Purchases)(this)).processPurchases(inValue);
        }
    }
}
