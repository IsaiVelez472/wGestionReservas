using System;

namespace wfGestionReservas
{
    public abstract class Reserva
    {
        public Guid Id { get; }
        public string NombreCliente { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public int DuracionEstadia { get; set; }

        public Reserva(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracionEstadia)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(nombreCliente))
            {
                throw new ArgumentException("El nombre del cliente no puede estar vacio.");
            }
            if (numeroHabitacion <= 0)
            {
                throw new ArgumentException("El número de habitación es inválido.");
            }
            if (fechaReserva == DateTime.MinValue)
            {
                throw new ArgumentException("La fecha de reserva no puede estar vacía o inválida.");
            }
            if (duracionEstadia <= 0)
            {
                throw new ArgumentException("La duración de la estadia debe ser mayor a cero.");
            }

            NombreCliente = nombreCliente;
            NumeroHabitacion = numeroHabitacion;
            FechaReserva = fechaReserva;
            DuracionEstadia = duracionEstadia;
        }

        public abstract double CalcularCostoTotal();
    }
}
