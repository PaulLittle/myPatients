/*
    Author:         Paul Little
    Student No:     S00156762
    Description:    FA2 Patient Blood Types
    Date:           05-11-2015
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace myPatients
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string DEFAULT_BLOOD_FILENAME = "noType";

        Random rnd = new Random(System.Environment.TickCount);

        ObservableCollection<Patient> group = new ObservableCollection<Patient>();
        ObservableCollection<Patient> filteredGroup = new ObservableCollection<Patient>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // make a group of patients
            PopulateGroup();
            PopulateListbox();
        }
        
        private void PopulateGroup()
        {
            group = new ObservableCollection<Patient>()
            {
                // Can this be done in a loop or generated randomly?
                new Patient {Name = "John Smith", Blood = BloodGroup.A },
                new Patient {Name = "Vivion Kinsella", Blood = BloodGroup.B },
                new Patient {Name = "Una L'Estrange", Blood = BloodGroup.AB },
                new Patient {Name = "Colm Davey", Blood = BloodGroup.AB },
                new Patient {Name = "Paul Powell", Blood = BloodGroup.A },
                new Patient {Name = "Aine Mitchell", Blood = BloodGroup.AB },
                new Patient {Name = "Fergal Keane", Blood = BloodGroup.B },
                new Patient {Name = "Fran Regan", Blood = BloodGroup.AB },
                new Patient {Name = "Padraig Harte", Blood = BloodGroup.AB },
                new Patient {Name = "Neil Gannon", Blood = BloodGroup.A },
                new Patient {Name = "Drew Lang" },
                new Patient()
            };
        }

        private void PopulateListbox()
        {
            FilterByBloodGroup('Z');
            lbxPatients.ItemsSource = filteredGroup;
        }

        //private void lbxPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Notice2.Text = (lbxPatients.SelectedIndex >= 0) ? (lbxPatients.SelectedItem as Patient).Name : "Nothing Selected";
        //}

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button.Content == null) return;
            char filterBlood = Char.Parse(button.Content.ToString());
            FilterByBloodGroup(filterBlood);
        }

        private void FilterByBloodGroup(char blood)
        {
            filteredGroup.Clear();            

            foreach (var patient in group)
            {
                if (patient.Blood == BloodGroup.A && blood == 'A')
                {
                    filteredGroup.Add(patient);
                    Notice1.Text = "BLOOD TYPE A";
                    //upDateBloodImage(Convert.ToString(blood));
                }
                else if (patient.Blood == BloodGroup.AB && blood == 'Y')
                {
                    filteredGroup.Add(patient);
                    Notice1.Text = "BLOOD TYPE AB";
                    //upDateBloodImage(Convert.ToString(blood));
                }
                else if (patient.Blood == BloodGroup.B && blood == 'B')
                {
                    filteredGroup.Add(patient);
                    Notice1.Text = "BLOOD TYPE B";
                    //upDateBloodImage(Convert.ToString(blood));
                }
                else if (blood == 'Z')
                {
                    filteredGroup.Add(patient);
                    Notice1.Text = "ALL BLOOD TYPES";
                    //upDateBloodImage();
                }
            }
        }

        //private void upDateBloodImage(string filename="")
        //{
        //    if (String.IsNullOrEmpty(filename)) filename = DEFAULT_BLOOD_FILENAME;
        //    BitmapImage bm = new BitmapImage();
        //    bm.BeginInit();
        //    var path = "pack://application:,,,/myPatients;component/Images" + filename + ".jpg";
        //    bm.UriSource = new Uri(path);
        //    imgBlood.Source = bm;
        //    bm.EndInit();
        //}
    }  // end class
}  // end ns
