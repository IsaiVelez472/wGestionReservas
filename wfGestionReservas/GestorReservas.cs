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
            // Retorna una copia para evitar modificaciones externas
            return new List<Reserva>(reservas);
        }

        public void AgregarReserva(Reserva reserva)
        {
            if (reserva == null)
            {
                MessageBox.Show("La reserva no puede ser nula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcular el rango de fechas de la nueva reserva
            DateTime fechaInicioNueva = reserva.FechaReserva;
            DateTime fechaFinNueva = reserva.FechaReserva.AddDays(reserva.DuracionEstadia - 1);

            // Verificar si hay una superposición de fechas con otra reserva existente
            bool existeReserva = reservas.Any(r =>
                r.NumeroHabitacion == reserva.NumeroHabitacion &&
                RangoFechasSeSuperpone(r.FechaReserva, r.FechaReserva.AddDays(r.DuracionEstadia - 1), fechaInicioNueva, fechaFinNueva)
            );

            if (existeReserva)
            {
                MessageBox.Show("Esta habitación ya tiene una reserva para alguno de estos días, revisas la fecha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            reservas.Add(reserva);
            MessageBox.Show("Reserva agregada correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool ActualizarReserva(Guid id, string nuevoNombre, int nuevaHabitacion, DateTime nuevaFecha, int nuevaDuracion)
        {
            Reserva reserva = reservas.FirstOrDefault(r => r.Id == id);
            if (reserva == null)
            {
                MessageBox.Show("No se encontró la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            DateTime fechaInicioNueva = nuevaFecha;
            DateTime fechaFinNueva = nuevaFecha.AddDays(nuevaDuracion - 1);

            // Verificar si la nueva reserva se superpone con otra, excluyendo la misma reserva
            bool existeSuperposicion = reservas.Any(r =>
                r.Id != id &&
                r.NumeroHabitacion == nuevaHabitacion &&
                RangoFechasSeSuperpone(r.FechaReserva, r.FechaReserva.AddDays(r.DuracionEstadia - 1), fechaInicioNueva, fechaFinNueva)
            );

            if (existeSuperposicion)
            {
                MessageBox.Show("No se puede actualizar la reserva porque hay una superposición de fechas con otra reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            reserva.NombreCliente = nuevoNombre;
            reserva.NumeroHabitacion = nuevaHabitacion;
            reserva.FechaReserva = nuevaFecha;
            reserva.DuracionEstadia = nuevaDuracion;
            MessageBox.Show("Reserva actualizaca correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public bool EliminarReserva(Guid id)
        {
            Reserva reserva = reservas.FirstOrDefault(r => r.Id == id);
            if (reserva == null)
            {
                MessageBox.Show("No se encontró la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            reservas.Remove(reserva);
            MessageBox.Show("Reserva eliminada correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool RangoFechasSeSuperpone(DateTime inicio1, DateTime fin1, DateTime inicio2, DateTime fin2)
        {
            return inicio1 <= fin2 && inicio2 <= fin1;
        }
    }
}