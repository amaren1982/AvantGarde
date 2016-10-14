using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
     [DataContract]
    public class MainCategory
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

    }

    [DataContract]
    public class Category
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }


        [DataMember]
        public string Code
        { get; set; }


        [DataMember]
        public int MainCategoryId
        { get; set; }
    }

    [DataContract]
    public class SubCategory
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }


        [DataMember]
        public string Code
        { get; set; }


        [DataMember]
        public int CategoryId
        { get; set; }
    }

    [DataContract]
    public class SelectionCriteria
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string Description
        { get; set; }


        [DataMember]
        public int SubCategoryId
        { get; set; }
    }
}
