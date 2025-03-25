using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionReservasHotel
{
    public class CreadorReservas
    {
        public static Reserva CrearReserva(string tipo, string nombre, int numHabitacion, DateTime fecha, int duracion, decimal tarifa)
        {
            if (tipo == "Estandar")
            {
                return new HabitacionEstandar(nombre, numHabitacion, fecha, duracion, tarifa);
            }
            else if (tipo == "VIP")
            {
                return new HabitacionVIP(nombre, numHabitacion, fecha, duracion, tarifa);
            }
            else
            {
                throw new Exception("Tipo de reserva no válido.");
            }
        }
    }

}
