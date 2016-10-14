using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class Feedback
    {
        private int _iFeedbackId = 0;
        private string _strFeedbackType = string.Empty;
        private string _strUserName = string.Empty;
        private string _strUserOrgName = string.Empty;
        private string _strUserAddress = string.Empty;
        private string _strUserEmail = string.Empty;
        private string _strUserMobile = string.Empty;
        private string _strProposalNumber = string.Empty;
        private string _strSubject = string.Empty;
        private string _strDescription = string.Empty;
        private DateTime _dtFeedbackDate;

        [DataMember]
        public int FeedbackId
        {
            get { return _iFeedbackId; }
            set { _iFeedbackId = value; }
        }

        [DataMember]
        public string FeedbackType
        {
            get { return _strFeedbackType; }
            set { _strFeedbackType = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return _strUserName; }
            set { _strUserName = value; }
        }

        [DataMember]
        public string UserOrgName
        {
            get { return _strUserOrgName; }
            set { _strUserOrgName = value; }
        }

        [DataMember]
        public string UserAddress
        {
            get { return _strUserAddress; }
            set { _strUserAddress = value; }
        }

        [DataMember]
        public string UserEmail
        {
            get { return _strUserEmail; }
            set { _strUserEmail = value; }
        }

        [DataMember]
        public string UserMobile
        {
            get { return _strUserMobile; }
            set { _strUserMobile = value; }
        }

        [DataMember]
        public string ProposalNumber
        {
            get { return _strProposalNumber; }
            set { _strProposalNumber = value; }
        }

        [DataMember]
        public string Subject
        {
            get { return _strSubject; }
            set { _strSubject = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _strDescription; }
            set { _strDescription = value; }
        }

        [DataMember]
        public DateTime FeedbackDate
        {
            get { return _dtFeedbackDate; }
            set { _dtFeedbackDate = value; }
        }
    }
}
