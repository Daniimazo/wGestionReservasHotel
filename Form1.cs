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
            cbTipoHabitacion.Items.Add("Estandar");
            cbTipoHabitacion.Items.Add("VIP");
            cbTipoHabitacion.SelectedIndex = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoHabitacion = cbTipoHabitacion.SelectedItem?.ToString();
                string nombreCliente = txtNombreCliente.Text.Trim();
                int numHabitacion;
                DateTime fechaReserva = dtpFechaReserva.Value;
                int duracion;
                decimal tarifa;

                if (!int.TryParse(txtNumeroHabitacion.Text, out numHabitacion))
                {
                    MessageBox.Show("El número de habitación debe ser un número válido.");
                    return;
                }

                if (!int.TryParse(txtDuracion.Text, out duracion) || duracion < 1)
                {
                    MessageBox.Show("La duración de la estadía debe ser un número mayor o igual a 1.");
                    return;
                }

                if (!decimal.TryParse(txtTarifa.Text, out tarifa) || tarifa <= 0)
                {
                    MessageBox.Show("La tarifa debe ser un número mayor a 0.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(nombreCliente))
                {
                    MessageBox.Show("El nombre del cliente es obligatorio.");
                    return;
                }

                if (string.IsNullOrEmpty(tipoHabitacion))
                {
                    MessageBox.Show("Debe seleccionar un tipo de habitación.");
                    return;
                }

                Reserva nuevaReserva = CreadorReservas.CrearReserva(tipoHabitacion, nombreCliente, numHabitacion, fechaReserva, duracion, tarifa);

                GestorReservas.Instancia.AgregarReserva(nuevaReserva);

                MessageBox.Show("Reserva agregada exitosamente.");
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
