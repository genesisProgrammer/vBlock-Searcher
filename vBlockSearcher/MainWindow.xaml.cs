using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;



namespace vBlockSearcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// filtering logic: http://dotnetpattern.com/filter-listview-wpf
    /// </summary>

    public partial class MainWindow : INotifyPropertyChanged
    {

       // private string filterText; 
       // private CollectionViewSource machineCollection;
        public event PropertyChangedEventHandler PropertyChanged;
        


        public MainWindow() 
        {
            InitializeComponent();

            ObservableCollection<vBlockData> vBlockDataCollection = new ObservableCollection<vBlockData>();

#region
            //add to view model in constructor for vBlockDataCollection??--
            StreamReader SR = new StreamReader(getFilePath());
            string[] streamValuesArray = null;

            while (!SR.EndOfStream)
            {
                string streamInput = SR.ReadLine().Trim();

                if (streamInput.Length > 0)
                {
                    streamValuesArray = streamInput.Split(',');

                    vBlockDataCollection.Add(new vBlockData
                    {
                        machineName = streamValuesArray[0],
                        vBlock = streamValuesArray[1],
                        URL = new Uri(streamValuesArray[2]),
                        folder = streamValuesArray[3],
                        subFolder = streamValuesArray[4]
                    });
                }
            }
            SR.Close();
            SR.Dispose();
#endregion
            csvGrid.ItemsSource = vBlockDataCollection;

            //machineCollection = new CollectionViewSource();
            //machineCollection.Source = vBlockDataCollection;
            //machineCollection.Filter += machineCollection_Filter;

           
            

        }

        public ICollectionView SourceCollection
        {
            get
            {
                return CollectionViewSource.GetDefaultView()
            }
        }

        public string getFilePath()
        {
            return vBlockData.Path;
        }


        //public string FilterText
        //{
        //    get
        //    {
        //        return filterText;
        //    }
        //    set
        //    {
        //        filterText = value;
        //        this.machineCollection.View.Refresh();
        //        RaisePropertyChanged("FilterText");
        //    }
        //}

        //void machineCollection_Filter(object sender, FilterEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(FilterText))
        //    {
        //        e.Accepted = true;
        //        return;
        //    }

        //    vBlockData vMachine = e.Item as vBlockData;
        //    if (vMachine.machineName.ToUpper().Contains(FilterText.ToUpper()))
        //    {
        //        e.Accepted = true;
        //    }
        //    else
        //    {
        //        e.Accepted = false;
        //    }
        //}


        //public void RaisePropertyChanged(string propertyName)
        //{
        //    if (this.PropertyChanged != null)
        //    {
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

    }
    
    
}
