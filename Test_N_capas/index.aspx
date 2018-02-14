<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Test_N_capas.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <title></title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="jumbotron jumbotron-fluid">
                        <div class="container">
                            <h1 class="display-4">Agenda HCM</h1>
                            <p class="lead">testing bootstrap...</p>
                            <asp:Button ID="btn_agregar" runat="server" Text="Nuevo" OnClick="btn_agregar_Click" CssClass="btn btn-outline-success float-right"/>
                        </div>
                    </div>
                    <asp:GridView ID="gv_index" runat="server" OnPreRender="gv_index_PreRender" AutoGenerateColumns="false" CssClass="table table-hover">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="idUsuario" HeaderText="ID Ususario" />
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
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
                        <div class="modal-body">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                    ¿Desea eliminar teléfono? 
                                    <strong>
                                        <asp:Label ID="lblTest" runat="server" Text="MI ID es"></asp:Label>
                                    </strong>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                        </div>
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
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <h3>Editar Teléfono</h3>
                                    <!--<asp:Label ID="lblEditar" runat="server" Text="MI ID es"></asp:Label>-->
                                    <div class="form-group">
                                        <label>Usuario:</label>
                                        <asp:DropDownList ID="ddlUsusarios" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Telefono:</label>
                                        <asp:TextBox ID="txtTelefono" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Estado:</label>
                                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1" Text="Activo"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Inactivo"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
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
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <h3>Agregar Teléfono</h3>
                                    <div class="form-group">
                                        <label>Telefono:</label>
                                        <asp:TextBox ID="txtAddTelefono" runat="server" placeholder="Nuevo teléfono" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Usuario:</label>
                                        <asp:DropDownList ID="ddlAddUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label>Pais:</label>
                                                <asp:DropDownList ID="ddlAddPais" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAddPais_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label>Ciudad:</label>
                                                <asp:DropDownList ID="ddlAddCiudad" runat="server" CssClass="form-control" AutoPostBack="true">
                                                    <asp:ListItem Value="0" Text="-Seleccione ciudad-"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group">
                                        <label>Estado:</label>
                                        <asp:DropDownList ID="ddlAddEstado" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0" Text="-seleccione estado-"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Activo"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Inactivo"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
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
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
