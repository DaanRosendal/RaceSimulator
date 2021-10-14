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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Controller;
using Model;
using WPF.StatsWindows;

namespace WPF
{
    public partial class MainWindow : Window
    {
        private Window _competitionStatsWindow;
        private Window _raceStatsWindow;

        public MainWindow()
        {
            StartCompetition();
            
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                if (!Data.CurrentRace.ParticipantsOnTrack())
                {
                    EndRace();
                    
                    
                }


                RenderTrack();
            };

            void StartCompetition()
            {
                InitializeComponent();
                Data.Initialize();
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.DrawParticipantsInStartPosition(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
                TrackName.Content = Data.CurrentRace.Track.Name;
            }
            
            void RenderTrack()
            {
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.MoveParticipants(Data.CurrentRace.Track);
                Visualizer.RenderParticipants(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
                Data.CurrentRace.CheckIfParticipantsOnFinish();
                Data.CurrentRace.RandomizeEquipment(10);
            }

            void EndRace()
            {
                Data.NextRace();
                
                if (Data.Competition.Finished)
                {
                    Data.Competition.EndCompetition();
                    
                    System.Windows.Application.Current.Shutdown();
                }
                
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.DrawParticipantsInStartPosition(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
                TrackName.Content = Data.CurrentRace.Track.Name;
            }
        }

        private void MenuItem_Click_Close_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_Show_Competition_Stats(object sender, RoutedEventArgs e)
        {
            _competitionStatsWindow = new CompetitionStatsWindow();
            _competitionStatsWindow.Show();
        }

        private void MenuItem_Click_Show_Race_Stats(object sender, RoutedEventArgs e)
        {
            _raceStatsWindow = new RaceStatsWindow();
            _raceStatsWindow.Show();
        }
    }
}