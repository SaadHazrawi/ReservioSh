﻿namespace Reservio.DTOS.Reservation;
public class ReservationStatus
{
    public string Status { get; set; } = string.Empty;
    public string StoppingTo { get; set; } = string.Empty;
    public bool Stopping { get; set; } = false;
}
