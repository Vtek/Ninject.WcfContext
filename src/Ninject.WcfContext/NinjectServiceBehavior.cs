using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.WcfContext
{
    /// <summary>
    /// Ninject service behavior
    /// </summary>
    public sealed class NinjectServiceBehavior : IServiceBehavior
    {
        /// <summary>
        /// Ninject instance provider
        /// </summary>
        public NinjectInstanceProvider InstanceProvider { get; set; }

        /// <summary>
        /// reate a new instance of NinjectServiceBehavior
        /// </summary>
        /// <param name="_kernel">Ninject Kernel</param>
        public NinjectServiceBehavior(IKernel _kernel)
        {
            InstanceProvider = new NinjectInstanceProvider(_kernel);
        }

        /// <summary>
        /// Add binding parameters
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        /// <param name="endpoints"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            //don't do nothing here
        }

        /// <summary>
        /// Apply dispatcher
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            //for all dispatch use NinjectInstanceProvider
            foreach (var ed in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>().SelectMany(cd => cd.Endpoints))
            {
                InstanceProvider.ServiceType = serviceDescription.ServiceType;
                ed.DispatchRuntime.InstanceProvider = InstanceProvider;
            }
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            //don't do nothing here
        }
    }
}
