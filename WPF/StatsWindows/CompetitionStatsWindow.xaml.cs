using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for CompetitionStatsWindow.xaml
    /// </summary>
    public partial class CompetitionStatsWindow : Window
    {
        private List<Track> _tracks = new();
        
        public CompetitionStatsWindow()
        {
            InitializeComponent();
            UpdateStats();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                UpdateStats();
            };
        }

        // private void UpdateStats()
        // {
        //     ElapsedTimeLabel.Content = $"Elapsed time: {Data.Competition.GetElapsedTime()}";
        //     ListBoxStandingsPerRace.Items
        // }
        
        private void UpdateStats()
        {
            ElapsedTimeLabel.Content = $"Elapsed time: {Data.Competition.GetElapsedTime()} seconds";
            ListViewTracks.Items.Clear();

            if (!_tracks.Contains(Data.CurrentRace.Track))
            {
                _tracks.Add(Data.CurrentRace.Track);
            }
            
            var view = new GridView();
            view.Columns.Add(new GridViewColumn { Header = "Tracks", DisplayMemberBinding = new Binding("Track") });
            ListViewTracks.View = view;
            
            var count = 0;
            foreach (var track in _tracks)
            {
                var trackName = $"{track.Name}";
                
                ListViewTracks.Items.Add(new { Track = trackName });
            }
        }
    }
}
