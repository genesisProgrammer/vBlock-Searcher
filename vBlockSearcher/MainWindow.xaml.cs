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
using System.IO;
using System.Data;

namespace vBlockSearcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox inputBox = (TextBox)sender;
            inputBox.Text = string.Empty;
            inputBox.GotFocus -= inputBox_GotFocus;
        }

        //https://www.youtube.com/watch?v=3YBTVn1a4oM for reading from csv
        void readCSV()
        {
            string path = @"C:\Users\achapman\Desktop\vBlock.csv";
            StreamReader SR = new StreamReader(path);
            DataTable dt = new DataTable();

            int rows = 0; // placeholder to initiate column headers on first read

            string[] columnNames = null;
            string[] streamValuesArray = null;

            while (!SR.EndOfStream)
            {
                string streamInput = SR.ReadLine().Trim(); 

                if(streamInput.Length > 0) 
                {
                    streamValuesArray = streamInput.Split(',');
                    if (rows == 0) //creates headers for columns
                    {
                        rows = 1; //turns off flag for column headers
                        columnNames = streamValuesArray; 
                        foreach(string headers in columnNames)
                        {
                            DataColumn DC = new DataColumn(headers, typeof(string));
                            DC.DefaultValue = string.Empty;
                            dt.Columns.Add(DC);
                        }
                    }
                    else
                    {
                        DataRow DR = dt.NewRow();

                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            DR[columnNames[i]] = streamValuesArray[i] == null ? string.Empty : streamValuesArray[i];
                            //DR[columnNames[i]] = (streamValuesArray[i] == null ? string.Empty : streamValuesArray[i];)
                            //Think of the ternary operator in these paranthesis. If sva[i] = null, then DR[columnNames[i] = string.empty 
                            //ELSE DR[columnNames[i] = sva[i] 
                   

                        }
                    }
                }
                
            }
        }
    }

}
