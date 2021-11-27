using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            OnTimerElapsed(this, (ElapsedEventArgs)EventArgs.Empty);
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
