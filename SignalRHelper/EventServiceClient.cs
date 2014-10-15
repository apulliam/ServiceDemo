using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRHelper
{
    public abstract class EventServiceClient<IClient>
    {
        private IHubProxy _hubProxy = null;
        private HubConnection _hubConnection = null;

        protected IClient InnerClient
        {
            get;
            private set;
        }


        public string ServerAddress
        {
            get;
            set;
        }

        public string HubName
        {
            get;
            private set;
        }

        protected HubConnection HubConnection
        {
            get
            {
                if (_hubConnection == null)
                {
                    _hubConnection = new HubConnection(ServerAddress);
                }
                return _hubConnection;
            }
        }

        protected IHubProxy HubProxy
        {
            get
            {
                if (_hubProxy == null)
                {
                    _hubProxy = HubConnection.CreateHubProxy(HubName);
                }
                return _hubProxy;
            }
        }

        public EventServiceClient(IClient client, string hubName)
        {
            InnerClient = client;
            HubName = hubName;
        }

        public EventServiceClient(IClient client, string hubName, string serverAddress)
            : this(client, hubName)
        {
            ServerAddress = serverAddress;
        }


        async public virtual Task Start()
        {
            await HubConnection.Start();
        }

        public virtual void Stop()
        {
            HubConnection.Stop();
        }
    }
}
