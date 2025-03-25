using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionReservasHotel
{
    public class HabitacionEstandar : Reserva
    {
        public decimal TarifaFija { get; set; }

        public HabitacionEstandar(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracion, decimal tarifa)
            : base(nombreCliente, numeroHabitacion, fechaReserva, duracion)
        {
            if (tarifa <= 0)
                throw new ArgumentException("La tarifa no puede ser menor o igual a cero.");

            TarifaFija = tarifa;
        }

        public override decimal CalcularCostoTotal()
        {
            return TarifaFija * DuracionEstadia;
        }
    }

}
