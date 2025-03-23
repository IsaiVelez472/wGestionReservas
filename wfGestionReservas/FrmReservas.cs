using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace wfGestionReservas
{
    public partial class FrmReservas : Form
    {
        public FrmReservas()
        {
            InitializeComponent();
        }

        private void FrmReservas_Load(object sender, EventArgs e)
        {
            ReiniciarTipoHabitación();
            DeshabilitarBotonesCRUD();
            DeshabilitarFormulario();
            InicializarDataGrids();
        }

        #region[Eventos botones]
        private void BtnAgregarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoHabitacion = CmbTipoHabitacion.SelectedItem.ToString();
                string nombreCliente = TxtNombreCliente.Text;
                int numeroHabitacion;
                int duracionEstadia;
                double precioPorNoche;
                DateTime fechaReserva = DtpFechaReserva.Value;

                if (string.IsNullOrWhiteSpace(nombreCliente))
                {
                    MessageBox.Show("El nombre del cliente no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(TxtNumeroHabitación.Text, out numeroHabitacion) || numeroHabitacion <= 0)
                {
                    MessageBox.Show("El número de la habitacion debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(TxtDuracionEstadia.Text, out duracionEstadia) || duracionEstadia < 0)
                {
                    MessageBox.Show("La duración de la estadia debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(TxtPrecioNoche.Text, out precioPorNoche) || precioPorNoche < 0)
                {
                    MessageBox.Show("El precio de la habitación por noche debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                Reserva nuevaReserva = ReservaFactory.CrearReserva(tipoHabitacion, nombreCliente, numeroHabitacion, fechaReserva, duracionEstadia, precioPorNoche);
                bool insersionExitosa = GestorReservas.Instancia.AgregarReserva(nuevaReserva);

                if (insersionExitosa)
                {
                    MessageBox.Show("Reserva agregada correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (DtgReservas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una reserva para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow filaSeleccionada = DtgReservas.SelectedRows[0];

                Guid idReserva;

                if (!Guid.TryParse(filaSeleccionada.Cells[0].Value.ToString(), out idReserva))
                {
                    MessageBox.Show("El ID de la reserva no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombreCliente = TxtNombreCliente.Text;
                int numeroHabitacion;
                int duracionEstadia;
                double precioPorNoche;
                DateTime fechaReserva = DtpFechaReserva.Value;

                if (string.IsNullOrWhiteSpace(nombreCliente))
                {
                    MessageBox.Show("El nombre del cliente no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(TxtNumeroHabitación.Text, out numeroHabitacion) || numeroHabitacion <= 0)
                {
                    MessageBox.Show("El número de la habitacion debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(TxtDuracionEstadia.Text, out duracionEstadia) || duracionEstadia < 0)
                {
                    MessageBox.Show("La duración de la estadia debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(TxtPrecioNoche.Text, out precioPorNoche) || precioPorNoche < 0)
                {
                    MessageBox.Show("El precio de la habitación por noche debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool actualizacionExitosa = GestorReservas.Instancia.ActualizarReserva(
                    idReserva,
                    nombreCliente,
                    numeroHabitacion,
                    fechaReserva,
                    duracionEstadia,
                    precioPorNoche
                );

                if (actualizacionExitosa)
                {
                    MessageBox.Show("Reserva actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (DtgReservas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una reserva para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow filaSeleccionada = DtgReservas.SelectedRows[0];

                Guid idReserva;

                if (!Guid.TryParse(filaSeleccionada.Cells[0].Value.ToString(), out idReserva))
                {
                    MessageBox.Show("El ID de la reserva no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show("¿Está seguro de eliminar la reserva?", "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion != DialogResult.Yes) return;

                bool eliminacionExitosa = GestorReservas.Instancia.EliminarReserva(idReserva);

                if (eliminacionExitosa)
                {
                    MessageBox.Show("Reserva eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region[Helper functions]
        private void ReiniciarTipoHabitación()
        {
            CmbTipoHabitacion.Items.Clear();
            CmbTipoHabitacion.Items.Add("Estandar");
            CmbTipoHabitacion.Items.Add("VIP");
            CmbTipoHabitacion.SelectedIndex = -1;
        }

        private void HabilitarBotonesCRUD()
        {
            BtnActualizarReserva.Enabled = true;
            BtnEliminarReserva.Enabled = true;
        }

        private void DeshabilitarBotonesCRUD()
        {
            BtnAgregarReserva.Enabled = false;
            BtnActualizarReserva.Enabled = false;
            BtnEliminarReserva.Enabled = false;
        }

        private void DeshabilitarFormulario()
        {
            TxtNombreCliente.Enabled = false;
            TxtNumeroHabitación.Enabled = false;
            DtpFechaReserva.Enabled = false;
            TxtDuracionEstadia.Enabled = false;
            TxtPrecioNoche.Enabled = false;
        }

        private void LimpiarFormulario()
        {
            CmbTipoHabitacion.SelectedIndex = -1;
            CmbTipoHabitacion.Enabled = true;
            TxtNombreCliente.Text = null;
            TxtNumeroHabitación.Text = null;
            DtpFechaReserva.Value = DateTime.Now;
            TxtDuracionEstadia.Text = null;
            TxtPrecioNoche.Text = null;
        }

        private void HabilitarFormulario()
        {
            TxtNombreCliente.Enabled = true;
            TxtNumeroHabitación.Enabled = true;
            DtpFechaReserva.Enabled = true;
            TxtDuracionEstadia.Enabled = true;
            TxtPrecioNoche.Enabled = true;
        }

        private bool VerificarCmbTipoHabitacionValido()
        {
            return !string.IsNullOrWhiteSpace(CmbTipoHabitacion.Text) && CmbTipoHabitacion.SelectedIndex != -1;
        }

        private void VerificarEstadoFormulario()
        {
            if (VerificarCmbTipoHabitacionValido()) HabilitarFormulario();
            else DeshabilitarFormulario();
        }

        private void VerificarEstadoBtnAgregarReserva()
        {
            if (!VerificarCmbTipoHabitacionValido()
                || string.IsNullOrWhiteSpace(TxtNombreCliente.Text)
                || string.IsNullOrWhiteSpace(TxtNumeroHabitación.Text)
                || string.IsNullOrWhiteSpace(TxtDuracionEstadia.Text)
                || string.IsNullOrWhiteSpace(TxtPrecioNoche.Text)
                || !DtpFechaReserva.Checked)
            {
                BtnAgregarReserva.Enabled = false;
                return;
            }

            BtnAgregarReserva.Enabled = true;
        }

        private void ResetearFormulario()
        {
            ActualizarDataGridReservas(GestorReservas.Instancia.ObtenerReservas());
            LimpiarFormulario();
            DeshabilitarBotonesCRUD();
            DeshabilitarFormulario();
        }
        #endregion

        #region[FormEvents básicos]
        private void CmbTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarEstadoFormulario();
            VerificarEstadoBtnAgregarReserva();
        }

        private void CmbTipoHabitacion_TextChanged(object sender, EventArgs e)
        {
            VerificarEstadoFormulario();
            VerificarEstadoBtnAgregarReserva();
        }

        private void TxtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            VerificarEstadoBtnAgregarReserva();
        }

        private void TxtNumeroHabitación_TextChanged(object sender, EventArgs e)
        {
            VerificarEstadoBtnAgregarReserva();
        }

        private void TxtDuracionEstadia_TextChanged(object sender, EventArgs e)
        {
            VerificarEstadoBtnAgregarReserva();
        }

        private void TxtPrecioNoche_TextChanged(object sender, EventArgs e)
        {
            VerificarEstadoBtnAgregarReserva();
        }

        private void DtpFechaReserva_ValueChanged(object sender, EventArgs e)
        {
            VerificarEstadoBtnAgregarReserva();
        }
        #endregion

        #region[Datagrig funcitons]
        private void ActualizarDataGridReservas(List<Reserva> Reservas)
        {
            DtgReservas.Rows.Clear();

            foreach (var Reserva in Reservas)
            {
                DtgReservas.Rows.Add(
                    Reserva.Id,
                    Reserva.NombreCliente,
                    Reserva.NumeroHabitacion,
                    Reserva.FechaReserva.ToString(),
                    Reserva.DuracionEstadia,
                    Reserva.CalcularCostoTotal()
                );
            }
        }

        private void InicializarDataGrids()
        {
            DtgReservas.Rows.Clear();

            DtgReservas.Columns.Clear();
            DtgReservas.Columns.Add("Id Reserva", "Id Reserva");
            DtgReservas.Columns.Add("Nombre del cliente", "Nombre del cliente");
            DtgReservas.Columns.Add("Número de habitación", "Número de habitación");
            DtgReservas.Columns.Add("Fecha de reserva", "Fecha de reserva");
            DtgReservas.Columns.Add("Duración de la estadía", "Duración de la estadía");
            DtgReservas.Columns.Add("Costo total", "Costo total");
            DtgReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DtgReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgReservas.MultiSelect = false;
            DtgReservas.ReadOnly = true;
        }

        private void DtgReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow filaSeleccionada = DtgReservas.Rows[e.RowIndex];

                    if (Guid.TryParse(filaSeleccionada.Cells[0].Value.ToString(), out Guid idReserva))
                    {
                        Reserva reserva = GestorReservas.Instancia.ObtenerReservaPorId(idReserva);
                        if (reserva != null)
                        {
                            CmbTipoHabitacion.SelectedIndex = -1;
                            CmbTipoHabitacion.Enabled = false;
                            TxtNombreCliente.Text = reserva.NombreCliente;
                            TxtNumeroHabitación.Text = reserva.NumeroHabitacion.ToString();
                            DtpFechaReserva.Value = reserva.FechaReserva;
                            TxtDuracionEstadia.Text = reserva.DuracionEstadia.ToString();

                            if (reserva is HabitacionEstandar habitacionEstandar)
                            {
                                TxtPrecioNoche.Text = habitacionEstandar.TarifaPorNoche.ToString();
                            }
                            else if (reserva is HabitacionVIP habitacionVIP)
                            {
                                TxtPrecioNoche.Text = habitacionVIP.TarifaPorNoche.ToString();
                            }
                            else
                            {
                                TxtPrecioNoche.Text = "N/A";
                            }
                            HabilitarFormulario();
                            HabilitarBotonesCRUD();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}