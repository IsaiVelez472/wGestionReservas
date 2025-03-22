using System;
using System.Windows.Forms;

namespace wfGestionReservas
{
    public class ReservaFactory
    {
        public static Reserva CrearReserva(string tipo, string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracionEstadia, double tarifaPorNoche)
        {
            try
            {
                switch (tipo)
                {
                    case "Estandar":
                        return new HabitacionEstandar(nombreCliente, numeroHabitacion, fechaReserva, duracionEstadia, tarifaPorNoche);

                    case "VIP":
                        return new HabitacionVIP(nombreCliente, numeroHabitacion, fechaReserva, duracionEstadia, tarifaPorNoche);

                    default:
                        throw new ArgumentException("Tipo de reserva no válido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}