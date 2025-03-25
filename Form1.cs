using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionReservasHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cbTipoHabitacion.SelectedItem.ToString();
                string nombre = txtNombreCliente.Text;
                int numHabitacion = int.Parse(txtNumeroHabitacion.Text);
                DateTime fecha = dtpFechaReserva.Value;
                int duracion = int.Parse(txtDuracion.Text);
                decimal tarifa = decimal.Parse(txtTarifa.Text);

                Reserva nuevaReserva = CreadorReservas.CrearReserva(tipo, nombre, numHabitacion, fecha, duracion, tarifa);
                GestorReservas.Instancia.AgregarReserva(nuevaReserva);

                MessageBox.Show("Reserva agregada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
