using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    // Singleton class
    public class GlobalData
    {
        private GlobalData()
        {
 
        }

        private static GlobalData _instance = null;

        public static GlobalData Instance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalData();
                }

                return _instance;
            }
        }

        public string PanNumber { get; set; }
    }
}
