﻿using System;

namespace TestJobForUralsib.Domain.Models
{
    public class CustomerExtraInformation
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? Birthdate { get; set; }

        public CustomerExtraInformation(string phone, string email = null, DateTime? birthdate = null)
            : this()
        {
            if (string.IsNullOrEmpty(phone))
                throw new ArgumentNullException(nameof(phone));

            Email = email;
            Birthdate = birthdate;
        }

        private CustomerExtraInformation()
        {
        }
    }
}