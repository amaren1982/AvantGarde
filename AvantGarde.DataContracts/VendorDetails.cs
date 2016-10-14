using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
   public  class VendorDetails
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string OrganizationName
        { get; set; }

        [DataMember]
        public int SubCategoryId
        { get; set; }

        [DataMember]
        public int EstYear
        { get; set; }

        [DataMember]
        public string Address
        { get; set; }


        [DataMember]
        public string Email
        { get; set; }

        [DataMember]
        public string Phone
        { get; set; }

        [DataMember]
        public string ContactPerson
        { get; set; }

        [DataMember]
        public string Mobile
        { get; set; }


        [DataMember]
        public int VendorType
        { get; set; }

        [DataMember]
        public string Description
        { get; set; }

    }
}
