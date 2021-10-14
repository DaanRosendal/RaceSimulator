using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Controller;
using Model;

namespace WPF.StatsWindows
{
    public partial class RaceStatsWindow : Window
    {
        private Dictionary<IParticipant, long> _finishedParticipants = new();
        private Track _previousTrack = Data.CurrentRace.Track;
        
        public RaceStatsWindow()
        {
            InitializeComponent();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                UpdateStats();

                if (_previousTrack != Data.CurrentRace.Track)
                {
                    _finishedParticipants.Clear();
                    ListBoxDriverTimes.Items.Clear();
                }

                _previousTrack = Data.CurrentRace.Track;
            };
        }

        private void UpdateStats()
        {
            Title = $"Race statistics | Elapsed time: {Data.CurrentRace.GetElapsedTime()} seconds";
            ListBoxStandings.Items.Clear();
            ListBoxDriverTimes.Items.Clear();
            
            var count = 1;
            foreach (var participant in Data.CurrentRace.Participants.OrderByDescending(p => p.PassedSections))
            {
                var item = new ListBoxItem();
                item.Content = $"{count++}. {participant.Name}: {participant.DrivenLaps}/{Race.Laps}";
                ListBoxStandings.Items.Add(item);
            }

            foreach (var participant in Data.CurrentRace.Participants.Where(p => p.DrivenLaps == Race.Laps))
            {
                if (!_finishedParticipants.TryGetValue(participant, out var pa))
                {
                    _finishedParticipants.Add(participant, participant.Timer.ElapsedMilliseconds);
                }
            }

            count = 1;
            foreach (var finishedParticipant in _finishedParticipants)
            {
                var p = finishedParticipant.Key;
                var time = (Convert.ToDecimal(finishedParticipant.Value) / (1024.0m * 1024.0m)) * 1000;
                time = Math.Round(time, 3);
                var stringTime = Convert.ToString(time).Replace(",", ".");
                var item = new ListBoxItem();
                item.Content = $"{count++}. {p.Name}: {stringTime} ";
                ListBoxDriverTimes.Items.Add(item);
            }
        }
    }
}
