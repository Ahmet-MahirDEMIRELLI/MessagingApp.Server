﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Application.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string X25519PublicKey { get; set; }
        [Required]
        public string Ed25519PublicKey { get; set; }
    }
}
