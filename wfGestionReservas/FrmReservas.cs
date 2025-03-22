using System;
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
        }


        private void DtgReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarBotonesCRUD();
        }

        #region[Eventos botones]
        private void BtnAgregarReserva_Click(object sender, EventArgs e)
        {
            DeshabilitarBotonesCRUD();
            LimpiarFormulario();
        }

        private void BtnActualizarReserva_Click(object sender, EventArgs e)
        {
            DeshabilitarBotonesCRUD();
        }

        private void BtnEliminarReserva_Click(object sender, EventArgs e)
        {
            DeshabilitarBotonesCRUD();
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
    }
}