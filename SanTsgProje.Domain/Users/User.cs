﻿using System;

namespace SanTsgProje.Domain.Users
{
    public class User
    {
        // User Informations
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfSign { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

    }
}
