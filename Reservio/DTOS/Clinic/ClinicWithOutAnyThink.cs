﻿using Reservio.Models;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Clinic
{
    public class ClinicCreationDTO
    {
        public string Name { get; set; }
        public Guid CountPaitentAccepte { get; set; }

    }
}
