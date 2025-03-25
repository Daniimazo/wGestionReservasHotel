using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionReservasHotel
{
    public class HabitacionVIP : Reserva
    {
        public decimal TarifaBase { get; set; }
        public const decimal Descuento = 0.20m;

        public HabitacionVIP(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracion, decimal tarifaBase)
            : base(nombreCliente, numeroHabitacion, fechaReserva, duracion)
        {
            if (tarifaBase <= 0)
                throw new ArgumentException("La tarifa base no puede ser menor o igual a cero.");

            TarifaBase = tarifaBase;
        }

        public override decimal CalcularCostoTotal()
        {
            decimal total = TarifaBase * DuracionEstadia;
            return DuracionEstadia > 5 ? total * (1 - Descuento) : total;
        }
    }

}
