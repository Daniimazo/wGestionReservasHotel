using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionReservasHotel
{
    public class GestorReservas
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
                    _instancia = new GestorReservas();
                return _instancia;
            }
        }

        public void AgregarReserva(Reserva reserva)
        {
            if (reservas.Any(r => r.NumeroHabitacion == reserva.NumeroHabitacion && r.FechaReserva == reserva.FechaReserva))
                throw new InvalidOperationException("Ya existe una reserva para esta habitación en la fecha seleccionada.");

            reservas.Add(reserva);
        }

        public List<Reserva> ObtenerReservas()
        {
            return reservas;
        }

        public void EliminarReserva(int numeroHabitacion, DateTime fecha)
        {
            var reserva = reservas.FirstOrDefault(r => r.NumeroHabitacion == numeroHabitacion && r.FechaReserva == fecha);
            if (reserva != null)
                reservas.Remove(reserva);
            else
                throw new KeyNotFoundException("Reserva no encontrada.");
        }
    }

}
