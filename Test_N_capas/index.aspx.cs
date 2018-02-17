using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test_N_capas.Clases.Negocio;

namespace Test_N_capas
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_gv();
            }
        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modalEliminarConfirm", "$('#modalEditar').modal('toggle')", true);
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string id = row.Cells[0].Text;
            string telefono = row.Cells[1].Text;
            string idUsuario = row.Cells[2].Text;
            string nombres = row.Cells[3].Text;
            hdnID.Value = id;
            lblEditar.Text = id;
       
            Agenda agenda = new Agenda();
            //llenar ddlUsuarios
            ddlUsusarios.DataSource = agenda.getUsusrios();
            ddlUsusarios.DataValueField = "id";
            ddlUsusarios.DataTextField = "nombre";
            ddlUsusarios.DataBind();
            ddlUsusarios.SelectedValue = idUsuario;
            
            txtTelefono.Text = telefono;
            ddlEstado.SelectedValue = "1";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string idh = hdnID.Value;
            int id = int.Parse(idh);
            string nombre = ddlUsusarios.SelectedValue;
            int idUsuario = int.Parse(nombre);
            string tel = txtTelefono.Text;
            int telefono = int.Parse(tel);
            string estado = ddlEstado.SelectedItem.Text;
            Agenda agenda = new Agenda();

            if (agenda.telefonoExiste(telefono) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "telExiste", "alert('Se actualizo el telefono para el usuario "+nombre+"')", true);
                agenda.updateTelefonoExiste(id, idUsuario, estado);
            }
            else
            {
                agenda.updateTelefono(id, idUsuario, telefono, estado);
            }
                

            load_gv();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modalEliminarConfirm", "$('#modalEliminar').modal('toggle')", true);
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string id = row.Cells[0].Text;
            string telefono = row.Cells[1].Text;
            hdnID.Value = id;
            lblTest.Text = telefono;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string idh = hdnID.Value;
            int id = int.Parse(idh);
            Agenda agenda = new Agenda();
            agenda.updateEstado(id, "Inactivo");

            load_gv();
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            txtAddTelefono.Text = String.Empty;
            ddlAddUsuario.Items.Clear();
            ddlAddPais.Items.Clear();
            ddlAddCiudad.Items.Clear();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modalAgregar", "$('#modalAgregar').modal('toggle')", true);

            Agenda agenda = new Agenda();
            //llenar ddlAddUsuario
            ddlAddUsuario.DataSource = agenda.getUsusrios();
            ddlAddUsuario.DataValueField = "id";
            ddlAddUsuario.DataTextField = "nombre";
            ddlAddUsuario.DataBind();
            ddlAddUsuario.Items.Insert(0, new ListItem("Seleccione usuario", "0"));

            //llenar ddlAddPais 
            ddlAddPais.DataSource = agenda.get_pais_cascade();
            ddlAddPais.DataValueField = "id";
            ddlAddPais.DataTextField = "nombre";
            ddlAddPais.DataBind();
            ddlAddPais.Items.Insert(0, new ListItem("-Seleccione país-", "0"));
            ddlAddCiudad.Items.Insert(0, new ListItem("-Seleccione ciudad","0"));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();

            agenda.Telefonos = (String.IsNullOrEmpty(txtAddTelefono.Text)) ? 0 : int.Parse(txtAddTelefono.Text);
            agenda.IdUsuario = int.Parse(ddlAddUsuario.SelectedValue);
            agenda.Estado = "Activo";
            agenda.IdPais = (String.IsNullOrEmpty(ddlAddPais.SelectedValue.ToString()) ? 0 : int.Parse(ddlAddPais.SelectedValue.ToString()));
            agenda.IdCiudad = (String.IsNullOrEmpty(ddlAddCiudad.SelectedValue.ToString()) ? 0 : int.Parse(ddlAddCiudad.SelectedValue.ToString()));
            agenda.insert();

            load_gv();
        }

        protected void ddlAddPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idpais = int.Parse(ddlAddPais.SelectedValue);
            Agenda agenda = new Agenda();

            ddlAddCiudad.DataSource = agenda.get_ciudad_cascade(idpais);
            ddlAddCiudad.DataValueField = "id";
            ddlAddCiudad.DataTextField = "nombre";
            ddlAddCiudad.DataBind();
        }

        public void load_gv()
        {
            Agenda agenda = new Agenda();
            gv_index.DataSource = agenda.getTablaAgenda();
            gv_index.DataBind();
        }

        protected void gv_index_PreRender(object sender, EventArgs e)
        {
            
        }
    }
}