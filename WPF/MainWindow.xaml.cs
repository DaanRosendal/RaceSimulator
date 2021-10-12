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


            // while (Data.CurrentRace.Track != null)
            // {
            //     for (; ; )
            //     {
            //         System.Threading.Thread.Sleep(100);
            //         Visualizer.HideParticipants(Data.CurrentRace.Track);
            //         Visualizer.DrawTrack(Data.CurrentRace.Track);
            //         Visualizer.MoveParticipants(Data.CurrentRace.Track);
            //         Visualizer.RenderParticipants(Data.CurrentRace.Track);
            //         Data.CurrentRace.CheckIfParticipantsOnFinish();
            //         Data.CurrentRace.RandomizeEquipment(10);
            //         
            //         if (!Data.CurrentRace.ParticipantsOnTrack())
            //         {
            //             Console.Clear();
            //             Data.NextRace();
            //             Console.SetCursorPosition(0,0);
            //             break;
            //         }
            //     }
            // }
            //
            // Console.Clear();
        }
    }
}