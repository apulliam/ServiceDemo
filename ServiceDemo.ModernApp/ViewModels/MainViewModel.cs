using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Collections.ObjectModel;
using ServiceDemo.ModernApp.Common;
using ServiceDemo.ModernApp.Views;
using ServiceDemo.ServiceContract;
using ServiceDemo.ServiceContract.Model;
using ServiceDemo.ModernApp.Service;

namespace ServiceDemo.ModernApp.ViewModels
{
    public class MainViewModel: ViewModelBase, IDemoEventService, System.IDisposable
    {
        public RelayCommand CallServiceCommand { get; private set; }

        private bool waitingForEvent;
        private string eventParam;
        private string serviceResult;
        private string serviceParam = "Test";
        private int serviceWait = 1000;
        private int eventWait = 5000;
        private DemoEventServiceClient demoEventServiceClient;


        public bool WaitingForEvent
        {
            get
            {
                return waitingForEvent;
            }
            set
            {
                waitingForEvent = value;
            }
        }

        public string ServiceParam
        {
            get
            {
                return serviceParam;
            }
            set
            {
                serviceParam = value;
                RaisePropertyChanged("ServiceParam");
            }
        }

        public int EventWait
        {
            get
            {
                return eventWait;
            }
            set
            {
                eventWait = value;
                RaisePropertyChanged("EventWait");
            }
        }

        public int ServiceWait
        {
            get
            {
                return serviceWait;
            }
            set
            {
                serviceWait = value;
                RaisePropertyChanged("ServiceWait");
            }
        }

        public string ServiceResult
        {
            get
            {
                return serviceResult;
            }
            set
            {
                serviceResult = value;
                RaisePropertyChanged("ServiceResult");
            }
        }


        public string EventParam
        {
            get
            {
                return eventParam;
            }
            set
            {
                eventParam = value;
                RaisePropertyChanged("EventParam");
            }
        }


        public MainViewModel()
        {
            demoEventServiceClient = new DemoEventServiceClient(this);
            CallServiceCommand = new RelayCommand(async () => await CallService());
        }

        async public Task Initialize()
        {
            await demoEventServiceClient.Start();
        }

        async private Task CallService()
        {
            var serviceClient = new DemoServiceClient();
            WaitingForEvent = true;
            ServiceResult = await serviceClient.DemoMethod(ServiceParam, ServiceWait, EventWait);
           
        }


        async public Task DemoEvent(EventState eventState)
        {
            var coreWindowDispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
            await coreWindowDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                EventParam = eventState.Property1;
                WaitingForEvent = false;
            }).AsTask();
            
        }

        public void Dispose()
        {
            demoEventServiceClient.Stop();
        }
    }
}
