﻿using GoodRead.Domain.Entities.Users;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Service.DTOs.Accounts
{
    public class AccountRegisterDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(50), MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public static implicit operator User(AccountRegisterDto dto)
        {
            return new User()
            {
                Email = dto.Email,
            };
        }
    }
}
