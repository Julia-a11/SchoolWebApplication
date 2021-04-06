using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.BindingModel
{
    [DataContract]
    public class ClientBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public string ClientSurname { get; set; }

        [DataMember]
        public string ClientPatronymic { get; set; }

        [DataMember]
        public DateTime DateBirth { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
