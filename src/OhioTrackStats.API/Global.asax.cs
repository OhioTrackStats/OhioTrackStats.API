using System;
using System.Web;
using ServiceStack.Logging;
using ServiceStack.Logging.Elmah;
using ServiceStack.MiniProfiler;

namespace OhioTrackStats.API
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var logFactory = new ConsoleLogFactory();
            LogManager.LogFactory = new ElmahLogFactory(logFactory, this);
            new AppHost().Init();
        }

        protected void Application_BeginRequest(object src, EventArgs e)
        {
            if (Request.IsLocal)
            {
                Profiler.Start();
            }
        }

        protected void Application_EndRequest(object src, EventArgs e)
        {
            Profiler.Stop();
        }
    }
}