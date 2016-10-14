using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class CurrentOpenings
    {
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Company
        {
            get;
            set;
        }

        [DataMember]
        public string Position
        {
            get;
            set;
        }

        [DataMember]
        public string Qualification
        {
            get;
            set;
        }

        [DataMember]
        public string Skillset
        {
            get;
            set;
        }

        [DataMember]
        public string Email
        {
            get;
            set;
        }

        [DataMember]
        public string OpenTillDate
        {
            get;
            set;
        }

        [DataMember]
        public bool IsActive
        {
            get;
            set;
        }

        [DataMember]
        public DateTime CreatedDate 
        {
            get;
            set;
        }


        [DataMember]
        public DateTime ModifiedDate
        {
            get;
            set;
        }
    }
}
