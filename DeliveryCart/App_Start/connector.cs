using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DeliveryCart.App_Start
{
    public  static class connector
    {
        public const string NameSpace = "wepapi"; // service bus name  

        public const string QueName = "webapi"; // queue name  

        public const string key = "W13I4bOrxz80MTD3wIgBXeVvwb7hkFOlpurrfAbldp4=";

        public static Microsoft.ServiceBus.Messaging.QueueClient OrdersQueueClient;

        public static NamespaceManager CreateNamespaceManager()
        {
            var uri = ServiceBusEnvironment.CreateServiceUri(
                "sb", NameSpace, String.Empty);

            var tP = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                "RootManageSharedAccessKey", key);

            return new NamespaceManager(uri, tP);
        }

        public static void Initialize()
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Http;

            var namespaceManager = CreateNamespaceManager();

            var messagingFactory = MessagingFactory.Create
                 (namespaceManager.Address, namespaceManager.Settings.TokenProvider);

            OrdersQueueClient = messagingFactory.CreateQueueClient(QueName);
        }
    }





}