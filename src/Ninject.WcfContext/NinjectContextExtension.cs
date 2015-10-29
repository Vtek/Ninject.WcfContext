using Ninject.CoreContext;
using Ninject.WcfContext;

namespace Ninject.CoreContext
{
    /// <summary>
    /// Ninject Context extension
    /// </summary>
    public static class NinjectContextExtension
    {
        /// <summary>
        /// Use WCF
        /// </summary>
        public static NinjectContext UseWcf(this NinjectContext context)
        {
            context.Use(kernel => 
            {
                NinjectServiceHostFactory.Kernel = kernel;
            });
            return context;
        }
    }
}
