using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test_N_capas.Clases.Negocio;

namespace Test_N_capas
{
    public partial class recibe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                string telefono = Request.QueryString["telefono"];
                string idUsuario = Request.QueryString["idUsuario"];
                string nombres = Request.QueryString["nombres"];

                lblId.Text = id;
                txtTelefono.Text = telefono;

                //llenar ddl
                Agenda agenda = new Agenda();
                ddlUsuarios.DataSource = agenda.getUsusrios();
                ddlUsuarios.DataTextField = "nombre";
                ddlUsuarios.DataValueField = "id";
                ddlUsuarios.DataBind();
                ddlUsuarios.SelectedValue = idUsuario;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string idtelefono = Request.QueryString["id"];
            int id = Int32.Parse(idtelefono);
            Agenda agenda = new Agenda();
            int idUsuarioInt = Int32.Parse(ddlUsuarios.SelectedValue.ToString());
            int telefono = Int32.Parse(txtTelefono.Text);

            agenda.updateTelefono(id,idUsuarioInt,telefono,"Activo");
            Response.Redirect("index.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblId.Text = ddlUsuarios.SelectedValue;
        }
    }
}