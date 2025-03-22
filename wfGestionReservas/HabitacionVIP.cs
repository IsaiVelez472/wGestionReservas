using System;

namespace wfGestionReservas
{
    internal class HabitacionVIP : Reserva
    {
        public double TarifaPorNoche { get; set; }
        public double DescuentoVIP { get; set; } = 0.20;
        public HabitacionVIP(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracionEstadia, double tarifaPorNoche)
            : base(nombreCliente, numeroHabitacion, fechaReserva, duracionEstadia)
        {
            if (tarifaPorNoche <= 0)
            {
                throw new ArgumentException("La tarifa por noche debe ser mayor a cero.");
            }
            TarifaPorNoche = tarifaPorNoche;
        }
        public override double CalcularCostoTotal()
        {
            double costoTotal = DuracionEstadia * TarifaPorNoche;

            if (DuracionEstadia > 5)
            {
                double descuento = costoTotal * DescuentoVIP;
                return costoTotal - descuento;
            }

            return costoTotal;
        }

    }
}
