﻿using System.ComponentModel.DataAnnotations;

namespace ElmaaredApp.BLL.Dtos
{
    public class EditProfileModel
	{
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountKind { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
