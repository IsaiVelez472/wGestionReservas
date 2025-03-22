using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace wfGestionReservas
{
    internal class GestorReservas
    {
        private static GestorReservas _instancia;
        private List<Reserva> reservas;

        private GestorReservas()
        {
            reservas = new List<Reserva>();
        }

        public static GestorReservas Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GestorReservas();
                }
                return _instancia;
            }
        }

        public List<Reserva> ObtenerReservas()
        {
            return new List<Reserva>(reservas); // Retorna una copia para evitar modificaciones externas
        }

        public void AgregarReserva(Reserva reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");
            }

            // Validar si la habitación ya está reservada en esas fechas
            bool existeReserva = reservas.Any(r => r.NumeroHabitacion == reserva.NumeroHabitacion && r.FechaReserva.Date == reserva.FechaReserva.Date);
            if (existeReserva)
            {
                MessageBox.Show("El nombre no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            reservas.Add(reserva);
        }

        public bool ActualizarReserva(int numeroHabitacion, Reserva nuevaReserva)
        {
            var reservaExistente = reservas.FirstOrDefault(r => r.NumeroHabitacion == numeroHabitacion);
            if (reservaExistente != null && nuevaReserva != null)
            {
                // Actualizar los datos de la reserva
                reservaExistente.NombreCliente = nuevaReserva.NombreCliente;
                reservaExistente.FechaReserva = nuevaReserva.FechaReserva;
                reservaExistente.DuracionEstadia = nuevaReserva.DuracionEstadia;
                return true;
            }
            return false; // Retorna false si la reserva no se encontró
        }
    }
}