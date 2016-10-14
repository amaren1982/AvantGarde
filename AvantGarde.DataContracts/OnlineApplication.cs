using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class OnlineApplication
    {
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }

        [DataMember]
        public string MiddleName
        {
            get;
            set;
        }

        [DataMember]
        public string LastName
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
        public string Qualification
        {
            get;
            set;
        }

        [DataMember]
        public string Discipline
        {
            get;
            set;
        }

        [DataMember]
        public string LandlineNumber
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
        public string Email
        {
            get;
            set;
        }

        [DataMember]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        [DataMember]
        public string CurrentEmployer
        {
            get;
            set;
        }

        [DataMember]
        public string Experience
        {
            get;
            set;
        }

        [DataMember]
        public string CurrentCTC
        {
            get;
            set;
        }

        [DataMember]
        public string ExpectedCTC
        {
            get;
            set;
        }

        [DataMember]
        public string Resume
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
    }
}
