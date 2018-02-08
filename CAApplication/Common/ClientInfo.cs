using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class ClientInfo
    {
        //public ClientInfo()
        //{
        //    PANNumber = string.Empty;
        //    Name = string.Empty;
        //    FatherOrHusbandName = string.Empty;
        //    MobileNumber = string.Empty;
        //    EmailId = string.Empty;
        //    Address = string.Empty;
        //    DateOfBirth = string.Empty;
        //    AuditorId = 0;
        //    ClientInputDataList = new List<ClientInputData>();
        //}

        public string PANNumber { get; set; }

        public string Name { get; set; }

        public string FatherOrHusbandName { get; set; }

        public string MobileNumber { get; set; }

        public string EmailId { get; set; }

        public string Address { get; set; }

        public string DateOfBirth { get; set; }

        public int AuditorId { get; set; }

        public List<ClientInputData> ClientInputDataList { get; set; }
    }
}
