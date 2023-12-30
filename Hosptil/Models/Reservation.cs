﻿using System.ComponentModel.DataAnnotations;

namespace Hosptil.Models;
public class Reservation
{
    public int ReservationId { get; set; }
    public int PatientId { get; set; }
    public int ClinicId { get; set; }
    public string IPAddress { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime BookFor { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Clinic Clinic { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}

