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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Data.Initialize();
            
            Visualizer.DrawTrack(Data.CurrentRace.Track);
            Visualizer.DrawParticipantsInStartPosition(Data.CurrentRace.Track);
            BaseImage.Source = Visualizer.GetTrack();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.MoveParticipants(Data.CurrentRace.Track);
                Visualizer.RenderParticipants(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
                Data.CurrentRace.CheckIfParticipantsOnFinish();
                Data.CurrentRace.RandomizeEquipment(10);
            };
            
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.MoveParticipants(Data.CurrentRace.Track);
                Visualizer.RenderParticipants(Data.CurrentRace.Track);
                BaseImage.Source = Visualizer.GetTrack();
                Data.CurrentRace.CheckIfParticipantsOnFinish();
                Data.CurrentRace.RandomizeEquipment(10);
            };
            
            // while (Data.CurrentRace.Track != null)
            // {
            //     for (; ; )
            //     {
            //         //  timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            //         // timer.Start();
            //         // timer.Tick += (sender, args) =>
            //         // {
            //         //     timer.Stop();
            //         //     Visualizer.DrawTrack(Data.CurrentRace.Track);
            //         //     Visualizer.MoveParticipants(Data.CurrentRace.Track);
            //         //     Visualizer.RenderParticipants(Data.CurrentRace.Track);
            //         //     BaseImage.Source = Visualizer.GetTrack();
            //         //     Data.CurrentRace.CheckIfParticipantsOnFinish();
            //         //     Data.CurrentRace.RandomizeEquipment(10);
            //         // };
            //         
            //         // System.Threading.Thread.Sleep(100);
            //         // Visualizer.HideParticipants(Data.CurrentRace.Track);
            //         
            //         // if (!Data.CurrentRace.ParticipantsOnTrack())
            //         // {
            //         //     BitmapImages.ClearCache();
            //         //     Data.NextRace();
            //         //     Visualizer.ResetXY();
            //         //     break;
            //         // }
            //     }
            // }
            
        }
    }
}