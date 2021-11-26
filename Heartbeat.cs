using System;
using System.IO;
using System.Timers;

namespace DiscordSettingsGistSync
{
    internal class Heartbeat
    {
        private readonly Timer _timer;

        internal Heartbeat()
        {
            _timer = new Timer(Config.TimerDuration) { AutoReset = true };
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(Config.HeartbeatLog, lines);
        }

        internal void Start() =>
            _timer.Start();

        internal void Stop() =>
            _timer.Stop();
    }
}
