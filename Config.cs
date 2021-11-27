using System.IO;

namespace DiscordSettingsGistSync
{
    internal static class Config
    {
        /// <summary>
        /// 4 Hours
        /// </summary>
        internal static long TimerDuration = 4L * 3600000L;
        internal static string HeartbeatLog = Path.Combine(Path.GetTempPath(), "dsgs_heartbeat.log");
        internal static string ServiceName = "DiscordSettingsGistSync";
        internal static string ServiceDisplayName = "Discord Settings to GitHub Gist synchronizer service";
        public static string ServiceDescription = "Synchs your discord settings with your GitHub Gists so you can access them anytime";

        public static string LocalStorageLocation;
    }
}
