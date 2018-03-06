using agenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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

        [WebMethod]
        public static int telefonoExisteTest(int anexo)
        {
            Agenda agenda = new Agenda();

            if (agenda.telefonoExiste(anexo) > 0)
            {
                return 1;
            }

            return 0;
        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modalEditar", "$('#modalEditar').modal('toggle')", true);

            ddlUsusarios.Items.Clear();
           
            ddlEditCiudad.Items.Clear();

            Agenda agenda = new Agenda();

            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string id = row.Cells[0].Text;
            string telefono = row.Cells[1].Text;
            string idUsuario = row.Cells[2].Text;
            string nombres = row.Cells[3].Text;
            int idPais = (String.IsNullOrEmpty(row.Cells[4].Text.ToString()) || row.Cells[4].Text.Equals("&nbsp;") ? 0 : int.Parse(row.Cells[4].Text));
            string pais = row.Cells[5].Text;
            string idCiudad = row.Cells[6].Text;
            string ciudad = row.Cells[7].Text;

            string estado = ddlEstado.SelectedValue;

            hdnID.Value = id;
            lblEditar.Text = id;

            txtTelefono.Text = telefono;

            //llenar ddlUsuarios
            ddlUsusarios.DataSource = agenda.getUsusrios();
            ddlUsusarios.DataValueField = "id";
            ddlUsusarios.DataTextField = "nombre";
            ddlUsusarios.DataBind();
            ddlUsusarios.Items.Insert(0, new ListItem("-Seleccione usuario-", "0"));
            ddlUsusarios.SelectedValue = (String.IsNullOrEmpty(idUsuario) || idUsuario.Equals("&nbsp;") ? "0" : idUsuario);

            //lenar ddllEditPais
            ddlEditPais.DataSource = agenda.get_pais_cascade();
            ddlEditPais.DataValueField = "id";
            ddlEditPais.DataTextField = "nombre";
            ddlEditPais.DataBind();
            ddlEditPais.Items.Insert(0, new ListItem("-Seleccione pais-", "0"));
            ddlEditPais.SelectedValue = (String.IsNullOrEmpty(idPais.ToString()) || idPais.Equals("&nbsp;") ? "0" : idPais.ToString());
            int paisSelected = int.Parse(ddlEditPais.SelectedValue);

            //llenar ddlEditCiudad
            ddlEditCiudad.DataSource = agenda.get_ciudad_cascade(idPais);
            ddlEditCiudad.DataValueField = "id";
            ddlEditCiudad.DataTextField = "nombre";
            ddlEditCiudad.DataBind();
            ddlEditCiudad.SelectedValue = (String.IsNullOrEmpty(idCiudad) || idCiudad.Equals("&nbsp;") ? "0" : idCiudad);

            ddlEstado.SelectedValue = estado;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id  = int.Parse(hdnID.Value);

            Agenda agenda = new Agenda(id);

            agenda.Telefonos = int.Parse(txtTelefono.Text);
            agenda.IdUsuario = int.Parse(ddlUsusarios.SelectedValue);
            agenda.Estado = ddlEstado.SelectedItem.Text;
            agenda.IdPais = int.Parse(ddlEditPais.SelectedValue);
            agenda.IdCiudad = (String.IsNullOrEmpty(ddlEditCiudad.SelectedValue.ToString()) || ddlEditCiudad.SelectedValue.ToString().Equals("&nbsp;") ? 0 : int.Parse(ddlEditCiudad.SelectedValue.ToString()));
            agenda.update();

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
            int id = int.Parse(hdnID.Value);

            Agenda agenda = new Agenda(id);
            agenda.Estado = "Inactivo";
            agenda.update();

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

        protected void ddlEditPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idpais = int.Parse(ddlEditPais.SelectedValue);

            Agenda agenda = new Agenda();

            ddlEditCiudad.DataSource = agenda.get_ciudad_cascade(idpais);
            ddlEditCiudad.DataValueField = "id";
            ddlEditCiudad.DataTextField = "nombre";
            ddlEditCiudad.DataBind();
        }

        protected void gv_index_PreRender(object sender, EventArgs e)
        {
            Funciones.VisibilidadColumna(gv_index, 0, false);
            Funciones.VisibilidadColumna(gv_index, 2, false);
            Funciones.VisibilidadColumna(gv_index, 4, false);
            Funciones.VisibilidadColumna(gv_index, 6, false);

            //if (gv_index.Rows.Count > 0)
            //{
            //    //This replaces <td> with <th> and adds the scope attribute
            //    gv_index.UseAccessibleHeader = true;

            //    //This will add the <thead> and <tbody> elements
            //    gv_index.HeaderRow.TableSection = TableRowSection.TableHeader;

            //    //This adds the <tfoot> element. 
            //    //Remove if you don't have a footer row
            //    //gv_index.FooterRow.TableSection = TableRowSection.TableFooter;
            //}

        }

        public void load_gv()
        {
            Agenda agenda = new Agenda();
            gv_index.DataSource = agenda.getTablaAgenda();
            gv_index.DataBind();
        }
    }
}