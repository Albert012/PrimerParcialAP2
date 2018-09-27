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
    public partial class rCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int id = Utild.ToInt(Request.QueryString["id"]);
                if(id >0)
                {
                    Repositorio<Cuentas> repositorio = new Repositorio<Cuentas>();
                    var cuenta = repositorio.Buscar(id);

                    if (cuenta == null)
                        Mensaje(TipoMensaje.Error, "Registro No Encontrado");
                    else
                        LlenaCampos(cuenta);
                }
            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuentas> repositorio = new Repositorio<Cuentas>();
            Cuentas cuentas = LlenaClase();   //.Buscar(Utild.ToInt(CuentaIdTextBox.Text));
            bool paso = false;

            if (cuentas.CuentaId == 0)
                paso = repositorio.Guardar(LlenaClase());
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


            //if (cuentas == null)
            //{
            //    if (repositorio.Guardar(LlenaClase()))
            //    {
            //        Mensaje(TipoMensaje.Sucess, "Guardado Correctamente");
            //        Limpiar();
            //    }
            //    else
            //    {
            //        Mensaje(TipoMensaje.Error, "No Se Pudo Guardar");
            //        Limpiar();
            //    }
            //}
            //else
            //{
            //    if (repositorio.Modificar(LlenaClase()))
            //    {
            //        Mensaje(TipoMensaje.Sucess, "Modificado Correctamente");
            //        Limpiar();
            //    }
            //    else
            //    {
            //        Mensaje(TipoMensaje.Error, "No Se Pudo Modificar");
            //        Limpiar();
            //    }

            //}
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuentas> repositorio = new Repositorio<Cuentas>();
            Cuentas cuentas = repositorio.Buscar(Utild.ToInt(CuentaIdTextBox.Text));

            if(cuentas != null)
            {
                repositorio.Eliminar(cuentas.CuentaId);
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
            CuentaIdTextBox.Text = "";
            FechaTextBox.Text = "";
            NombreTextBox.Text = "";
            BalanceTextBox.Text = "";
        }

        private Cuentas LlenaClase()
        {
            Cuentas cuentas = new Cuentas();

            cuentas.CuentaId = Utild.ToInt(CuentaIdTextBox.Text);
            cuentas.Fecha = Utild.ToDateTime(FechaTextBox.Text).Date;
            cuentas.Nombre = NombreTextBox.Text;
            cuentas.Balance = Utild.ToDecimal(BalanceTextBox.Text);

            return cuentas;
        }

        private void LlenaCampos(Cuentas cuentas)
        {
            CuentaIdTextBox.Text = cuentas.CuentaId.ToString();
            FechaTextBox.Text = cuentas.Fecha.ToString();
            NombreTextBox.Text = cuentas.Nombre.ToString();
            BalanceTextBox.Text = cuentas.Balance.ToString();
        }

        void Mensaje(TipoMensaje tipo, string mensaje)
        {
            MensajeLabel.Text = mensaje;
            if (tipo == TipoMensaje.Sucess)
                MensajeLabel.CssClass = "alert-success";
            else
                MensajeLabel.CssClass = "alert-danger";
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuentas> repositorio = new Repositorio<Cuentas>();
            Cuentas cuentas = repositorio.Buscar(Utild.ToInt(CuentaIdTextBox.Text));

            if (cuentas != null)
            {
                LlenaCampos(cuentas);
            }
            else
            {
                Limpiar();
                Mensaje(TipoMensaje.Error, "No Encontrado");
               
            }
                


        }
    }
}