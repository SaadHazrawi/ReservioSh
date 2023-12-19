﻿using Hosptil.Models;
using System.ComponentModel.DataAnnotations;

namespace Hosptil.DTOS.Doctor
{
    public class DoctorWithoutSubstitueDTO
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Specialist { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
