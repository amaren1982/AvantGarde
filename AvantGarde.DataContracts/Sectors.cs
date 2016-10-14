using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class SectorsData
    {
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public string SectorName { get; set; }
        [DataMember]
        public string ParentSectorName { get; set; }
        [DataMember]
        public int ParentSectorID { get; set; }
        
    }

    [DataContract]
    public class ParentSectors
    {
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public string ParentSectorName { get; set; }
        
    }

    [DataContract]
    public class SectorAttachments
    {
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public int SectorID { set; get; }
        [DataMember]
        public string SectorName { get; set; }
        [DataMember]
        public string Caption { get; set; }
        [DataMember]
        public string SectorAttachment { get; set; }
        [DataMember]
        public int ParentSectorID { get; set; }

    }
}
