using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class SectionMaster
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

    }
}
