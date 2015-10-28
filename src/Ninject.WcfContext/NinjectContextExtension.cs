using Ninject.CoreContext;

namespace Ninject.WcfContext
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
            return context;
        }
    }
}
