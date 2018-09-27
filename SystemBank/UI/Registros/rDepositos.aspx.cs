using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemBank.Utilitary;

namespace SystemBank.UI.Registros
{
    public partial class rDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarCombos();
                int id = Utild.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    Repositorio<Depositos> repositorio = new Repositorio<Depositos>();
                    var cuenta = repositorio.Buscar(id);

                    if (cuenta == null)
                        Mensaje(TipoMensaje.Error, "Registro No Encontrado");
                    else
                        LlenaCampos(cuenta);
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            DepositosRepositorio depositosRepositorio = new DepositosRepositorio();
            Repositorio<Depositos> repositorio = new Repositorio<Depositos>();
            Depositos depositos = LlenaClase();   //.Buscar(Utild.ToInt(CuentaIdTextBox.Text));
            bool paso = false;

            if (depositos.DepositoId == 0)
                paso = depositosRepositorio.Guardar(LlenaClase());
            else
                paso = repositorio.Modificar(LlenaClase());

            if (paso)
            {
                Mensaje(TipoMensaje.Sucess, "Guardado Correctamente");
                Limpiar();
            }
            else
            {
                Mensaje(TipoMensaje.Error, "No Se Pudo Guardar");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            DepositosRepositorio repositorio = new DepositosRepositorio();
            Depositos depositos = repositorio.Buscar(Utild.ToInt(DepositoIdTextBox.Text));

            if (depositos != null)
            {
                repositorio.Eliminar(depositos.DepositoId);
                Mensaje(TipoMensaje.Sucess, "Eliminado Correctamente");
                Limpiar();
            }
            else
            {
                Mensaje(TipoMensaje.Error, "No Se Pudo Eliminar");
                Limpiar();
            }
        }

        private void Limpiar()
        {
            DepositoIdTextBox.Text = "";
            FechaTextBox.Text = "";
            CuentaDropDownList.SelectedIndex = 0;
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "";
            
        }

        void LlenarCombos()
        {
            Repositorio<Cuentas> repositorio = new Repositorio<Cuentas>();
            CuentaDropDownList.DataSource = repositorio.GetList(c => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }

        private Depositos LlenaClase()
        {
            Depositos depositos = new Depositos();

            depositos.DepositoId = Utild.ToInt(DepositoIdTextBox.Text);
            depositos.Fecha = Utild.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = Utild.ToInt(CuentaDropDownList.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = Utild.ToDecimal(MontoTextBox.Text);

            return depositos;
        }

        private void LlenaCampos(Depositos depositos)
        {
            DepositoIdTextBox.Text = depositos.DepositoId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString();
            CuentaDropDownList.Text = depositos.CuentaId.ToString();
            ConceptoTextBox.Text = depositos.Concepto;
            MontoTextBox.Text = depositos.Monto.ToString();
        }

        void Mensaje(TipoMensaje tipo, string mensaje)
        {
            MensajeLabel.Text = mensaje;
            if (tipo == TipoMensaje.Sucess)
                MensajeLabel.CssClass = "alert-success";
            else
                MensajeLabel.CssClass = "alert-danger";
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Depositos> repositorio = new Repositorio<Depositos>();
            Depositos depositos = repositorio.Buscar(Utild.ToInt(DepositoIdTextBox.Text));

            if (depositos != null)
            {
                LlenaCampos(depositos);
            }
            else
            {                
                Mensaje(TipoMensaje.Error, "No Encontrado");
                Limpiar();

            }
        }
    }
}