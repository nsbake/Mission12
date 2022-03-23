﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mission12.Models;

namespace Mission12.Models
{
    public class Tour
    {
        //* unsure atm if this will be needed with reqs
        [Key]
        [BindNever]
        public int Id { get; set; }

        public Tour (Appointment appointment)
        {
            Appointment = appointment;
        }

        [Required]
        public Appointment Appointment { get; set; }

        [Required(ErrorMessage ="Please provide a group name")]
        public string Name { get; set; }

        [Required]
        [Range(1,15,ErrorMessage ="Groups must be 1-15 in size")]
        public int Size { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }
    }
}
