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

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            StartCompetition();
            
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                RenderTrack();
                
                if (!Data.CurrentRace.ParticipantsOnTrack())
                {
                    EndRace();
                }
            };

            void RenderTrack()
            {
                BitmapImages.ClearCache();
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.MoveParticipants(Data.CurrentRace.Track);
                Visualizer.RenderParticipants(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
                Data.CurrentRace.CheckIfParticipantsOnFinish();
                Data.CurrentRace.RandomizeEquipment(10);
            }

            void StartCompetition()
            {
                InitializeComponent();
                Data.Initialize();
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.DrawParticipantsInStartPosition(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
            }

            void EndRace()
            {
                Data.NextRace();
                Visualizer.ResetXY();
                BitmapImages.ClearCache();
                Data.NextRace();
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.DrawParticipantsInStartPosition(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
            }
        }
    }
}