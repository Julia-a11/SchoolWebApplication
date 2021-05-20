using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        [DataMember]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
