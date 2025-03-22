using System;
using wfGestionReservas;

namespace wfGestionReservas
{
    public class ReservaFactory
    {
        public static Reserva CrearReserva(string tipo, string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracionEstadia, double tarifaPorNoche)
        {
            if (tipo == "Estandar")
            {
                return new HabitacionEstandar(nombreCliente, numeroHabitacion, fechaReserva, duracionEstadia, tarifaPorNoche);
            }
            else if (tipo == "VIP")
            {
                return new HabitacionVIP(nombreCliente, numeroHabitacion, fechaReserva, duracionEstadia, tarifaPorNoche);
            }
            else
            {
                throw new ArgumentException("Tipo de reserva no valido");
            }
        }
    }
}