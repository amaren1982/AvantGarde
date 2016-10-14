using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class CustomerConnect
    {
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public int Type
        {
            get;
            set;
        }

        [DataMember]
        public string OrgName
        {
            get;
            set;
        }

        [DataMember]
        public string Address
        {
            get;
            set;
        }

        [DataMember]
        public string EmailId
        {
            get;
            set;
        }

        [DataMember]
        public string Mobile
        {
            get;
            set;
        }

        [DataMember]
        public string ProposalNo
        {
            get;
            set;
        }

        [DataMember]
        public string Subject
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

        [DataMember]
        public int CreatedBy
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
