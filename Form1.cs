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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para editar.");
                return;
            }

            try
            {
                int filaSeleccionada = dgvReservas.SelectedRows[0].Index;
                string tipo = cbTipoHabitacion.SelectedItem.ToString();
                string nombre = txtNombreCliente.Text;
                int numHabitacion = int.Parse(txtNumeroHabitacion.Text);
                DateTime fecha = dtpFechaReserva.Value;
                int duracion = int.Parse(txtDuracion.Text);
                decimal tarifa = decimal.Parse(txtTarifa.Text);

               
                GestorReservas.Instancia.EliminarReserva(numHabitacion, fecha);
                Reserva reservaEditada = CreadorReservas.CrearReserva(tipo, nombre, numHabitacion, fecha, duracion, tarifa);
                GestorReservas.Instancia.AgregarReserva(reservaEditada);

                MessageBox.Show("Reserva editada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para eliminar.");
                return;
            }

            try
            {
                int numHabitacion = int.Parse(dgvReservas.SelectedRows[0].Cells["NumeroHabitacion"].Value.ToString());
                DateTime fecha = DateTime.Parse(dgvReservas.SelectedRows[0].Cells["FechaReserva"].Value.ToString());

                GestorReservas.Instancia.EliminarReserva(numHabitacion, fecha);
                MessageBox.Show("Reserva eliminada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ActualizarGrid()
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = GestorReservas.Instancia.ObtenerReservas();
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }
    }
}
