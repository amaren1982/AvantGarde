using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AvantGarde.DataContracts
{
    [DataContract]
    public class EmailTemplate
    {
        private int _iTemplateId = 0;
        private string _strTemplateName = string.Empty;
        private string _strTemplateContent = string.Empty;
        private string _strEmailSubject = string.Empty;
        private string _strSendEmailTo = string.Empty;
        private int _iModifiedById = 0;
        private DateTime _dtModifieddate = DateTime.Now;

        [DataMember]
        public int TemplateId
        {
            get { return _iTemplateId; }
            set { _iTemplateId = value; }
        }

        [DataMember]
        public string TemplateName
        {
            get { return _strTemplateName; }
            set { _strTemplateName = value; }
        }

        [DataMember]
        public string TemplateContent
        {
            get { return _strTemplateContent; }
            set { _strTemplateContent = value; }
        }

        [DataMember]
        public string EmailSubject
        {
            get { return _strEmailSubject; }
            set { _strEmailSubject = value; }
        }

        [DataMember]
        public string SendEmailTo
        {
            get { return _strSendEmailTo; }
            set { _strSendEmailTo = value; }
        }

        [DataMember]
        public int ModifiedById
        {
            get { return _iModifiedById; }
            set { _iModifiedById = value; }
        }

        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _dtModifieddate; }
            set { _dtModifieddate = value; }
        }
    }
}
