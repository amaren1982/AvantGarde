using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class News
    {
        private int _iNewsId = 0;
        private bool _isActive = false;
        private string _strContent = string.Empty;
        private string _strLink = string.Empty;

        [DataMember]
        public int NewsId
        {
            get { return _iNewsId; }
            set { _iNewsId = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get;
            set;
        }

        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        [DataMember]
        public string Content
        {
            get { return _strContent; }
            set { _strContent = value; }
        }

        [DataMember]
        public string Link
        {
            get { return _strLink; }
            set { _strLink = value; }
        }
    }
}
