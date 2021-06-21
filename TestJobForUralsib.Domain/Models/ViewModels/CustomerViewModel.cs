using System;
using System.ComponentModel.DataAnnotations;

namespace TestJobForUralsib.Domain.Models.ViewModels
{
    public class CustomerViewModel
    {
        [UIHint("Hidden")]
        public int ID;

        [Display(Name = "Имя")]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name;

        [Display(Name = "Фамилия")]
        [MinLength(1)]
        [MaxLength(20)]
        public string Surname;

        [Display(Name = "Отчество")]
        [MinLength(1)]
        [MaxLength(20)]
        public string Patronymic;

        [Display(Name = "Адрес электронной почты")]
        [EmailAddress]
        public string Email;

        [Display(Name = "Номер мобильного телефона")]
        [Phone]
        public string Phone;

        [Display(Name = "Дата рождения")]
        public DateTime? Birthdate;
    }
}
