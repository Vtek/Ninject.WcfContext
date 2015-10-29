using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.WcfContext
{
    public sealed class NinjectServiceHost : ServiceHost
    {
        private IKernel _kernel;

        public NinjectServiceHost(Type serviceType, Uri[] baseAddresses, IKernel kernel)
            :base(serviceType, baseAddresses)
        {
            _kernel = kernel;
        }

        protected override void OnOpening()
        {
            if (Description.Behaviors.Find<NinjectServiceBehavior>() == null)
            {
                Description.Behaviors.Add(new NinjectServiceBehavior(_kernel));
            }
            base.OnOpening();
        }
    }
}
