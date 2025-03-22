using System;

namespace wfGestionReservas
{
    internal class HabitacionEstandar : Reserva
    {
        public double TarifaPorNoche { get; set; }

        public HabitacionEstandar(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracionEstadia, double tarifaPorNoche)
            : base(nombreCliente, numeroHabitacion, fechaReserva, duracionEstadia)
        {
            if (TarifaPorNoche <= 0) throw new ArgumentException("La tarifa por noche debe ser mayor a cero.");
            
            TarifaPorNoche = tarifaPorNoche;
        }

        public override double CalcularCostoTotal()
        {
            return TarifaPorNoche * DuracionEstadia;
        }
    }
}
