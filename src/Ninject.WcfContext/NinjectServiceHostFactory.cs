using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Ninject.WcfContext
{
    public sealed class NinjectServiceHostFactory : ServiceHostFactory
    {
        internal static IKernel Kernel { get; set; }

        public NinjectServiceHostFactory()
        {
            
        }
        /// <summary>
        /// Crée une instance de ServiceHost
        /// </summary>
        /// <param name="serviceType">Type du service</param>
        /// <param name="baseAddresses"></param>
        /// <returns></returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new NinjectServiceHost(serviceType, baseAddresses, Kernel);
        }
    }
}
