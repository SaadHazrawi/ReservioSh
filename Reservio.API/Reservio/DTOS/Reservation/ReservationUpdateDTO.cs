﻿using Reservio.Core;
using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Reservation
{
    public class ReservationUpdateDTO
    {
        public int ClinicId { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 15 characters.")]
        public string FirstName { get; set; } = null!;

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 15 characters.")]
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime Date { get; set; } = DateTimeLocal.GetDate();
        public GenderPaintet Gender { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string PhoneNumber { get; set; } = null!;

        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")]
        public string IPAddress { get; set; } = null!;
        public string Region { get; set; } = string.Empty;
    }
}
