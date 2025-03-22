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
            try
            {
                return new List<Reserva>(reservas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Reserva>();
            }
        }

        public void AgregarReserva(Reserva reserva)
        {
            try
            {
                if (reserva == null)
                {
                    MessageBox.Show("La reserva no puede ser nula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime fechaInicioNueva = reserva.FechaReserva;
                DateTime fechaFinNueva = reserva.FechaReserva.AddDays(reserva.DuracionEstadia - 1);

                bool existeReserva = reservas.Any(r =>
                    r.NumeroHabitacion == reserva.NumeroHabitacion &&
                    RangoFechasSeSuperpone(r.FechaReserva, r.FechaReserva.AddDays(r.DuracionEstadia - 1), fechaInicioNueva, fechaFinNueva)
                );

                if (existeReserva)
                {
                    MessageBox.Show("Esta habitación ya tiene una reserva para alguno de estos días, revisa la fecha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reservas.Add(reserva);
                MessageBox.Show("Reserva agregada correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ActualizarReserva(Guid id, string nuevoNombre, int nuevaHabitacion, DateTime nuevaFecha, int nuevaDuracion)
        {
            try
            {
                Reserva reserva = reservas.FirstOrDefault(r => r.Id == id);
                if (reserva == null)
                {
                    MessageBox.Show("No se encontró la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                DateTime fechaInicioNueva = nuevaFecha;
                DateTime fechaFinNueva = nuevaFecha.AddDays(nuevaDuracion - 1);

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
                MessageBox.Show("Reserva actualizada correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarReserva(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool RangoFechasSeSuperpone(DateTime inicio1, DateTime fin1, DateTime inicio2, DateTime fin2)
        {
            try
            {
                return inicio1 <= fin2 && inicio2 <= fin1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar superposición de fechas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
