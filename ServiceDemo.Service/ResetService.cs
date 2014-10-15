using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Samples.Server.Repository;
using Microsoft.Samples.Service;
using Microsoft.Samples.Service.Model;
using Microsoft.Samples.Logging;

namespace Microsoft.Samples.Server.Service
{
    public class ResetService : IServerResetService
    {
        private IConfigCache _configRepository = null;
        private IImageRepository _playRepository = null;
        private IResetBroadcastService _resetBroadcastService = null;
        private readonly ILogger _logger = null;

        public ResetService(IConfigCache configRepository, IPlayRepository playRepository, IResetBroadcastService resetBroadcastService, ILogger logger)
        {
            _configRepository = configRepository;
            _playRepository = playRepository;
            _resetBroadcastService = resetBroadcastService;
            _logger = logger;
        }

        public void Reset()
        {
            _logger.LogTrace(EventID.MethodEntry, "Entered ResetService:Reset Method");

            _resetBroadcastService.Reset();
            _configRepository.DeleteConfig();
            _playRepository.Clear();

            _logger.LogTrace(EventID.MethodExit, "Exited ResetService:Reset Method");
        }
    }
}


 var hubContext = GlobalHost.ConnectionManager.GetHubContext<ConfigHub>();
 	        hubContext.Clients.All.UpdateConfig(clientConfig);