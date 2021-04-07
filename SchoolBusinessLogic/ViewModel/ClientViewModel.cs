using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.ViewModel
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Имя")]
        public string ClientName { get; set; }

        [DataMember]
        [DisplayName("Фамилия")]
        public string ClientSurname { get; set; }

        [DataMember]
        [DisplayName("Отчество")]
        public string ClientPatronymic { get; set; }

        [DataMember]
        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }

        [DataMember]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
