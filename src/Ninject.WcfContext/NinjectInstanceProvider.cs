using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.WcfContext
{
    /// <summary>
    /// Ninject Instance Provider
    /// </summary>
    public sealed class NinjectInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// Service type
        /// </summary>
        public Type ServiceType { set; get; }

        /// <summary>
        /// Ninject Kernel
        /// </summary>
        private IKernel _kernel;

        /// <summary>
        /// Create a new instance of NinjectInstanceProvider
        /// </summary>
        /// <param name="_kernel">Ninject kernel instance</param>
        public NinjectInstanceProvider(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Get service instance
        /// </summary>
        /// <param name="instanceContext">Instance context</param>
        /// <param name="message">Message</param>
        /// <returns></returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return _kernel.GetService(ServiceType);
        }

        /// <summary>
        /// Get instance
        /// </summary>
        /// <param name="instanceContext">Instance contextes</param>
        /// <returns>Service instance</returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Release the instance
        /// </summary>
        /// <param name="instanceContext">Instance context</param>
        /// <param name="instance">Instance</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            _kernel.Release(instance);
        }
    }
}
