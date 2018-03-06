<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Test_N_capas.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.css" />

    <title></title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div class="jumbotron jumbotron-fluid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="container">
                            <h1 class="display-4">Agenda HCM</h1>
                            <p class="lead">testing bootstrap...</p>
                            <asp:Button ID="btn_agregar" runat="server" Text="Nuevo" OnClick="btn_agregar_Click" CssClass="btn btn-outline-success float-right" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gv_index" runat="server" OnPreRender="gv_index_PreRender" AutoGenerateColumns="false" CssClass="table table-hover">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="idUsuario" HeaderText="ID Ususario" />
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                            <asp:BoundField DataField="IdPais" HeaderText="ID Pais" />
                            <asp:BoundField DataField="Pais" HeaderText="Pais" />
                            <asp:BoundField DataField="IdCiudad" HeaderText="ID Ciudad" />
                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                            <asp:TemplateField HeaderText="Operaciones" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Button ID="btn_editar" runat="server" Text="Editar" OnClick="btn_editar_Click" CssClass="btn btn-primary" />
                                    <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" OnClick="btn_eliminar_Click" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hdnID" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- Modal Eliminar -->
            <div class="modal fade" tabindex="-1" role="dialog" id="modalEliminar">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Eliminar Teléfono</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    ¿Desea eliminar teléfono? 
                                    <strong>
                                        <asp:Label ID="lblTest" runat="server" Text="MI ID es"></asp:Label>
                                    </strong>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="modal-footer">
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn alert-danger" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Fin Modal Eliminar -->
            <!-- Modal Editar -->
            <div class="modal fade" tabindex="-1" role="dialog" id="modalEditar">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Editar Teléfono</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <h3>Editar Teléfono</h3>
                                    <!--<asp:Label ID="lblEditar" runat="server" Text="MI ID es"></asp:Label>-->
                                    <div class="form-group">
                                        <label>Telefono:</label>
                                        <asp:TextBox ID="txtTelefono" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Usuario:</label>
                                        <asp:DropDownList ID="ddlUsusarios" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Pais:</label>
                                        <asp:DropDownList ID="ddlEditPais" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlEditPais_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Ciudad:</label>
                                        <asp:DropDownList ID="ddlEditCiudad" runat="server" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Estado:</label>
                                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Activo"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Inactivo"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="modal-footer">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" CssClass="btn btn-primary" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Fin Modal Editar -->
            <!-- Modal Agregar -->
            <div class="modal fade" tabindex="-1" role="dialog" id="modalAgregar">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Agregar Teléfono</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="alert alert-danger alert-dismissible fade show" id="telefonoAddError" role="alert" style="display: none">
                                                <strong>Error!</strong>
                                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <h3>Agregar Teléfono</h3>
                                    <div class="form-group">
                                        <label>Telefono:</label>
                                        <asp:TextBox ID="txtAddTelefono" runat="server" placeholder="Nuevo teléfono" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Usuario:</label>
                                        <asp:DropDownList ID="ddlAddUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Pais:</label>
                                        <asp:DropDownList ID="ddlAddPais" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAddPais_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Ciudad:</label>
                                        <asp:DropDownList ID="ddlAddCiudad" runat="server" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="modal-footer">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Fin Modal Agregar -->
        </form>
    </div>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.js"></script>
    <!--<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.js"></script>

    <!-- datatable buttons -->
   
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/buttons/1.5.1/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/buttons/1.5.1/js/buttons.flash.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/pdfmake.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/vfs_fonts.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/buttons/1.5.1/js/buttons.html5.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/buttons/1.5.1/js/buttons.print.min.js"></script>

    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/select/1.2.5/js/dataTables.select.min.js"></script>

    <script>
        $(document).ready(function () {

            $(function () {
                $("#gv_index").prepend($("<thead></thead>").append($("#gv_index").find("tr:first"))).dataTable({

                    dom: 'Bfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ]
                });
            });
        });

        $("#btnAgregar").click(function (e) {

            var mensaje = "";


            if ($("#txtAddTelefono").val() == "") {
                e.preventDefault();
                mensaje = "Agregue anexo";
                $("#lblMensaje").text(mensaje);
                $("#telefonoAddError").show();
            }

            $.ajax({
                type: "POST",
                url: "index.aspx/telefonoExisteTest",
                data: '{anexo: "' + $("#<%=txtAddTelefono.ClientID%>")[0].value + '" }',
                async: false, // espera respuesta del servidor
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: miFuncion,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function miFuncion(res) {

                if (res.d == 1) {
                    e.preventDefault();
                    mensaje = "El anexo ya existe.";
                    $("#lblMensaje").text(mensaje);
                    $("#telefonoAddError").show();
                }
            }
            
        });
    </script>
</body>
</html>
