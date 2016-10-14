using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{

    [DataContract]
    public class Testimonial
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public int SectionId
        { get; set; }

        [DataMember]
        public string DisplayName
        { get; set; }

        [DataMember]
        public bool IsActive
        { get; set; }

        [DataMember]
        public DateTime CreatedDate
        { get; set; }

        [DataMember]
        public DateTime ModifiedDate
        { get; set; }

        [DataMember]
        public string DownloadPath
        { get; set; }

        [DataMember]
        public string SectionName
        { get; set; }
    }

    [DataContract]
    public class TestimonialAttachments
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public int DownloadId
        { get; set; }

        [DataMember]
        public string DownloadPath
        { get; set; }

        [DataMember]
        public DateTime CreatedDate
        { get; set; }
    }
}
