using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vBlockSearcher
{
    class vBlockData
    {
        public vBlockData()
        {
        }

        public string machineName { get; set; }
        public string vBlock { get; set; }
        public Uri URL { get; set; }
        public string folder { get; set; }
        public string subFolder { get; set; }
        private static string path = @"C:\Users\achapman\Desktop\vBlock.csv";

       
        public static string Path
        {
            get { return path; }
            set { path = value; }
        }


    }
}
