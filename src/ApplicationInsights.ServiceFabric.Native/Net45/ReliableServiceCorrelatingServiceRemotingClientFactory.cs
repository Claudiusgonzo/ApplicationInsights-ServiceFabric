﻿namespace Microsoft.ApplicationInsights.ServiceFabric.Remoting.Activities
{
    using Microsoft.ServiceFabric.Services.Client;
    using Microsoft.ServiceFabric.Services.Communication.Client;
    using Microsoft.ServiceFabric.Services.Remoting;
    using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
    using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Client;
    using System.Collections.Generic;

    /// <summary>
    /// Remoting client factory for constructing clients that can call actor services. Clients created by this factory pass correlation ids and relevant information
    /// to the callee so diagnostic traces can be tagged with the relevant ids. This factory wraps and use <see cref="FabricTransportServiceRemotingClientFactory"/> for most of the
    /// underying functionality. <see cref="ReliableServiceCorrelatingServiceRemotingClientFactory"/> calls <see cref="FabricTransportServiceRemotingClientFactory"/> to create an inner client, which
    /// handles the main call transport and will be wrapped by a <see cref="CorrelatingServiceRemotingClient"/> object.
    /// </summary>
    public class ReliableServiceCorrelatingServiceRemotingClientFactory : CorrelatingServiceRemotingClientFactory
    {
        /// <summary>
        /// Initializes the <see cref="ReliableServiceCorrelatingServiceRemotingClientFactory"/> object. Most parameters are pass straight to the underying FabricTransport.
        /// </summary>
        /// <param name="fabricTransportRemotingSettings">The settings for the fabric transport. If the settings are not provided or null,
        /// default settings with no security.</param>
        /// <param name="callbackClient">The callback client that receives the callbacks from the service.</param>
        /// <param name="servicePartitionResolver">Service partition resolver to resolve the service endpoints. If not specified,
        /// a default service partition resolver returned by Microsoft.ServiceFabric.Services.Client.ServicePartitionResolver.GetDefault
        /// is used. </param>
        /// <param name="exceptionHandlers">Exception handlers to handle the exceptions encountered in communicating with
        /// the actor.</param>
        /// <param name="traceId">Id to use in diagnostics traces from this component.</param>
        public ReliableServiceCorrelatingServiceRemotingClientFactory(
            FabricTransportRemotingSettings fabricTransportRemotingSettings = null,
            IServiceRemotingCallbackClient callbackClient = null,
            IServicePartitionResolver servicePartitionResolver = null,
            IEnumerable<IExceptionHandler> exceptionHandlers = null,
            string traceId = null)
        : base(new FabricTransportServiceRemotingClientFactory(fabricTransportRemotingSettings, callbackClient, servicePartitionResolver, exceptionHandlers, traceId)) { }
    }
}
