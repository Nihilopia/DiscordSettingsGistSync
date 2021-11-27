using System;

using Topshelf;

namespace DiscordSettingsGistSync
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                TopshelfExitCode topshelfExitCode = HostFactory.Run(config =>
                 {
                     config.Service<Heartbeat>(service =>
                     {
                         service.ConstructUsing(heartbeat => new());
                         service.WhenStarted(heartbeat => heartbeat.Start());
                         service.WhenStopped(heartbeat => heartbeat.Stop());
                     });

                     config.RunAsLocalService();
                     config.SetServiceName(Config.ServiceName);
                     config.SetDisplayName(Config.ServiceDisplayName);
                     config.SetDescription(Config.ServiceDescription);
                 });

                int exitCode = (int)Convert.ChangeType(topshelfExitCode, topshelfExitCode.GetTypeCode());
                Environment.ExitCode = exitCode;
            }
        }
    }
}
