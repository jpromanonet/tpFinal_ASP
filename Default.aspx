<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Sistema._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema de Altas. Bajas y Modificaciones</title>
    <style>
        #form1{
            width:767px;
            height:886px;
            margin: auto auto;
            margin-top: auto;
            margin-bottom: auto;
        }
        #body{
            background: #ffffff;
        }
        .auto-style1 {
            width: 70%;
        }
        .auto-style3 {
            width: 39%;
        }
        .auto-style4 {
            width: 39%;
            height: 43px;
        }
        .auto-style5 {
            width: 70%;
            height: 43px;
        }
        .auto-style6 {
            width: 40%;
            height: 43px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--Panel Portada--%>
        <asp:Panel ID="pnlPortada" runat="server" Width="765px" Height="350px">
            <asp:ImageButton ID="btnPortada" ImageUrl="~/imagenes/portada.jpg" ImageAlign="Middle" runat="server" />
        </asp:Panel>
        <%--Panel Login--%>
        <asp:Panel ID="pnlLogin" runat="server" Width="765px" Height="350px" Font-Bold="true" ForeColor="Blue" Font-Size="Large" BorderStyle="Solid" Visible="false" >
            <%--Tabla Info Login--%>
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="lblVersion" Text="Versión" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#999999"/>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="lblMsgLogin" Text="Ingresa tu usuario y contraseña, y presiona enter" runat="server" Font-Bold="true" Font-Size="X-Large" />
                    </td>
                </tr>
            </table>
            <%--Tabla Datos para Login--%>
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="lblUsuario" Text="Usuario: " runat="server"  Font-Bold="true" Font-Size="Large" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" />
                    </td>
                    <td>
                        <asp:Label ID="lblClave" Text="Contraseña: " runat="server"  Font-Bold="true" Font-Size="Large" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" TextMode="Password" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnEntrar" ImageUrl="~/imagenes/entrar.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:right">
                        <asp:Label ID="lblAdmin" Text="Si eres administrador usa este botón para acceder" runat="server"  Font-Bold="true" Font-Size="Large" />
                    </td>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnEntrarAdmin" ImageUrl="~/imagenes/entrar.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align:center">
                        <asp:Label ID="lblErrorLogin" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align:center">
                        <asp:ImageButton ID="btnReenviarClave" ImageUrl="~/imagenes/reenviarclave.png" runat="server" Visible="true" />
                        <asp:Label ID="lblReenviarClave" Text="" runat="server"  Visible="false" Font-Bold="true" ForeColor="Blue"/>
                    </td>
                </tr>
            </table>
            <%--Tabla Cerrar Sesion o Volver al Login--%>
            <table style="width:100%">
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVolverLogin" ImageUrl="~/imagenes/terminarvolver.png" runat="server" Width="259px" Height="68px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Menu Login--%>
        <asp:Panel ID="pnlLoginMenu" runat="server" Width="767px" Height="392px" Font-Bold="True" ForeColor="Blue" Font-Size="Large" BorderStyle="Solid" Visible="false">
            <table style="width:100%">
                <tr>
                    <td style="text-align:center">
                        <asp:Image ImageUrl="~/imagenes/registrate.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnRegistrarse" ImageUrl="~/imagenes/registrateaqui.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnIrLogin" ImageUrl="~/imagenes/yaregistrado.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnRegistrarseVolverLoginU13" ImageUrl="~/imagenes/terminarvolver.png" runat="server" Width="259px" Height="68px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Registrarse--%>
        <asp:Panel ID="pnlRegistrarse" runat="server" ForeColor="#372C57" Font-Size="Large" Visible="false" BackColor="#009999" Width="">
            <%--Tabla Titulos de Registro e Informacion--%>
            <table style="width:100%">
                <tr>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Image ImageUrl="~/imagenes/header.png" runat="server" Width="767px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:justify">
                        <p>
                            Es necesario ser mayor de edad o contar con permiso de tus padres y residir en Argentina para registrarte</p>
                        <p>
                            Sólo se pude hacer un registro por DNI. Los datos deben ser reales, correctos y vigentes.
                        </p>
                        <p>
                            Por favor completa todos los datos obligatorios.</p>
                    </td>
                </tr>
            </table>
             <%--Tabla Datos para Registro--%>
            <table style="width:100%">
                 <%--Campos y Validacion Nombres--%>
                <tr>
                    <td>Tu/s Nombre/s:</td>
                    <td>
                      <asp:TextBox ID="txtNombreU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorNombreU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Apellidos--%>
                <tr>
                    <td>Apellido/s:</td>
                    <td>
                      <asp:TextBox ID="txtApellidoU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorApellidoU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Tipo de Documento--%>
                <tr>
                    <td>Tipo de Doc.:</td>
                    <td>
        
                        <asp:DropDownList ID="ddlTipoDocU" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Height="28px" Width="279px">
                            <asp:ListItem Value="DNI" Text="Documento Nacional de Identidad" />
                            <asp:ListItem Value="LC" Text="Libreta Cívica" />
                            <asp:ListItem Value="LE" Text="Libreta de Enrolamiento" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align:center">
                    </td>
                </tr>
                <%--Campos y Validacion Numero de Doc.--%>
                <tr>
                    <td>DNI:</td>
                    <td>
                      <asp:TextBox ID="txtDocU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="8" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorDocU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Fecha de Nacimiento y Edad.--%>
                <tr>
                    <td>Fecha de Nac. (ddmmaa):</td>
                    <td>
                      <asp:TextBox ID="txtFechaNac" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="6" Width="150px" />
                        <asp:Label ID="lblFechaNacU" Text="" runat="server" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorFechaNacU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Email.--%>
                <tr>
                    <td>Email:</td>
                    <td>
                      <asp:TextBox ID="txtEmailU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="70" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorEmailU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Provincia--%>
                <tr>
                    <td>Provincia:</td>
                    <td>
                        <asp:DropDownList ID="ddlProvU" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="1" Text="Buenos Aires" />
                            <asp:ListItem Value="2" Text="Catamarca" />
                            <asp:ListItem Value="3" Text="Chaco" />
                            <asp:ListItem Value="4" Text="Chubut" />
                            <asp:ListItem Value="5" Text="CABA" />
                            <asp:ListItem Value="6" Text="Córdoba" />
                            <asp:ListItem Value="7" Text="Corrientes" />
                            <asp:ListItem Value="8" Text="Entre Ríos" />
                            <asp:ListItem Value="9" Text="Formosa" />
                            <asp:ListItem Value="10" Text="Jujuy" />
                            <asp:ListItem Value="11" Text="La Pampa" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="13" Text="Mendoza" />
                            <asp:ListItem Value="14" Text="Misiones" />
                            <asp:ListItem Value="15" Text="Neuquén" />
                            <asp:ListItem Value="16" Text="Río Negro" />
                            <asp:ListItem Value="17" Text="Salta" />
                            <asp:ListItem Value="18" Text="San Juan" />
                            <asp:ListItem Value="19" Text="San Luis" />
                            <asp:ListItem Value="20" Text="Santa Cruz" />
                            <asp:ListItem Value="21" Text="Santa Fe" />
                            <asp:ListItem Value="22" Text="Santiago del Estero" />
                            <asp:ListItem Value="23" Text="Tucumán" />
                            <asp:ListItem Value="24" Text="Tierra del Fuego" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align:center">
                    </td>
                </tr>
                <%--Campos y Validacion Localidad--%>
                <tr>
                    <td>Localidad:</td>
                    <td>
                      <asp:TextBox ID="txtLocalidadU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorLocalidadU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Direccion.--%>
                <tr>
                    <td>Dirección:</td>
                    <td>
                      <asp:TextBox ID="txtDireccionU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="100" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorDireccionU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Telefono--%>
                <tr>
                    <td>Teléfono (agregue carateristica):</td>
                    <td>
                      <asp:TextBox ID="txtTelefonoU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorTelefonoU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Usuario--%>
                <tr>
                    <td>Usuario:</td>
                    <td>
                      <asp:TextBox ID="txtUsuarioU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px"/>
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorUsuarioU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Contraseña--%>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                      <asp:TextBox ID="txtClaveU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" TextMode="Password" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorClaveU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Repetir Contraseña--%>
                <tr>
                    <td>Repetir contraseña:</td>
                    <td>
                      <asp:TextBox ID="txtClaveRepeatU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" TextMode="Password" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorClaveRepeatU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td colspan="3" style="text-align:center">
                        <asp:Label ID="lblErroresU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%--Tabla Botones --%>
            <table style="width:100%">
                <tr style="text-align:center">
                    <td>
                        <asp:ImageButton ID="btnRegistrarseU" ImageUrl="~/imagenes/registrarse.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarVolverU" ImageUrl="~/imagenes/cancelarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Bienvenido--%>
        <asp:Panel ID="pnlBienvenido" runat="server" BorderColor="#66CCFF" Height="535px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Bienvenida para al Registrarse --%>
            <table style="width:100%">
                <tr>
                    <td style="text-align:justify">
                        <asp:Label ID="lblBienvenido" Text="" runat="server"  Visible="false" />
                        <p>Usted ha sido registrado con exito.</p>
                        <p></p>
                        <p>Muchas gracias por confiar en nosotros.</p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnRegistrarseVolverLoginU" ImageUrl="~/imagenes/todook.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Area Usuario--%>
        <asp:Panel ID="pnlAreaUsuario" runat="server" BorderColor="#66CCFF" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <table style="width:100%">
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="lblBienvenidoAreaU" Text="Bienvenido/a" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#000000" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnAhoraQueHago" ImageUrl="~/imagenes/ahora_que_hago.png" runat="server" />
                        <p>Aca podes gestionar tu perfil.</p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnHacerPedido" ImageUrl="~/imagenes/hacerpedido.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVerHistorico" ImageUrl="~/imagenes/vertodosmov.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnModificarDatos" ImageUrl="~/imagenes/modificardatos.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnAbmProductos" ImageUrl="~/imagenes/abmProductos.png" runat="server" Width="263px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnAbmUsuariosMenu" ImageUrl="~/imagenes/abmUsuarios.png" runat="server" Width="263px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnHacerPedidoFabrica" ImageUrl="~/imagenes/pedidosfabrica.png" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnAbmPedidoFabrica" ImageUrl="~/imagenes/abmPedidosFabrica.png" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVolverLoginU1" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Ahora que Hago--%>
        <asp:Panel ID="pnlAhoraQueHago" runat="server" BorderColor="#66CCFF" Height="535px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <table style="width: 100%">
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblTeCuento" Text="Un poco de info" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#000000" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:justify">
                        <p>Pedidos Online </p>
                        <p></p>
                        <p>Acá vas a poder comprar los equipos informáticos más innovadores hasta el día de hoy.</p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVolverU2" ImageUrl="~/imagenes/terminarvolver.png" runat="server"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Datos Personales--%>
        <asp:Panel ID="pnlCambiarDatosPersonales" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/datospersonales.jpg">
            <%--Tabla Datos para Registro--%>
            <table style="width: 100%">
                <%--Campos y Validacion Email.--%>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmailUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="70" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorEmailUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Provincia--%>
                <tr>
                    <td>Provincia:</td>
                    <td>
                        <asp:DropDownList ID="ddlProvUedit" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="1" Text="Buenos Aires" />
                            <asp:ListItem Value="2" Text="Catamarca" />
                            <asp:ListItem Value="3" Text="Chaco" />
                            <asp:ListItem Value="4" Text="Chubut" />
                            <asp:ListItem Value="5" Text="CABA" />
                            <asp:ListItem Value="6" Text="Córdoba" />
                            <asp:ListItem Value="7" Text="Corrientes" />
                            <asp:ListItem Value="8" Text="Entre Ríos" />
                            <asp:ListItem Value="9" Text="Formosa" />
                            <asp:ListItem Value="10" Text="Jujuy" />
                            <asp:ListItem Value="11" Text="La Pampa" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="13" Text="Mendoza" />
                            <asp:ListItem Value="14" Text="Misiones" />
                            <asp:ListItem Value="15" Text="Neuquén" />
                            <asp:ListItem Value="16" Text="Río Negro" />
                            <asp:ListItem Value="17" Text="Salta" />
                            <asp:ListItem Value="18" Text="San Juan" />
                            <asp:ListItem Value="19" Text="San Luis" />
                            <asp:ListItem Value="20" Text="Santa Cruz" />
                            <asp:ListItem Value="21" Text="Santa Fe" />
                            <asp:ListItem Value="22" Text="Santiago del Estero" />
                            <asp:ListItem Value="23" Text="Tucumán" />
                            <asp:ListItem Value="24" Text="Tierra del Fuego" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center"></td>
                </tr>
                <%--Campos y Validacion Localidad--%>
                <tr>
                    <td>Localidad:</td>
                    <td>
                        <asp:TextBox ID="txtLocalidadUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorLocalidadUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Direccion.--%>
                <tr>
                    <td>Dirección:</td>
                    <td>
                        <asp:TextBox ID="txtDireccionUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="100" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorDireccionUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Telefono--%>
                <tr>
                    <td>Teléfono</td>
                    <td>
                        <asp:TextBox ID="txtTelefonoUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorTelefonoUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Usuario--%>
                <tr>
                    <td>Usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuarioUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorUsuarioUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Contraseña--%>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtClaveUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorClaveUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Label ID="lblErrorEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnCambiarDatos" ImageUrl="~/imagenes/cambiarlosdatos.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarVolverEdit" ImageUrl="~/imagenes/cancelarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Datos Personales Modificados OK--%>
        <asp:Panel ID="pnlDatosModificadosOk" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/datospersonales.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Label ID="lblDatosModificadosOk" Text="Se han actualizado tus datos con exito." runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#000000" />

                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnVolverAreaUsuario" ImageUrl="~/imagenes/volveratuarea.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Hacer Pedidos Fabrica--%>
        <asp:Panel ID="pnlPedidosFabrica" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: left">
                    <td>
                        <h1>Carritos de compras</h1>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnNuevoPedido" ImageUrl="~/imagenes/nuevopedido.png" runat="server" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnTodosLosPedidos" ImageUrl="~/imagenes/todoslospedidos.png" runat="server" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnTerminarVolverPedido" ImageUrl="~/imagenes/terminar.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Nuevo Pedido Fabrica--%>
        <asp:Panel ID="pnlNuevoPedidoFabrica" runat="server" BorderColor="#66CCFF" ForeColor="#372c57" Font-Size="Large" Visible="false" BackColor="#94bbd4">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: left">
                    <td colspan="4">
                        <h1>Solicitar al proveedor</h1>
                    </td>
                </tr>                
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="btnInstrucciones" runat="server" />
                    </td>
                    <td class="auto-style1" colspan="3">
                        <asp:Label ID="lblInstrucciones" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">Seleccione el producto</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:DropDownList ID="ddlProducto" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="Black" Width="85%" AutoPostBack="True">
                            <asp:ListItem Value="0" Text="Sin enlazar" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        Agregar: 
                    </td>
                    <td colspan="2">
                      <asp:Label ID="lblCosaAgregar" Text="" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="Black"/>
                    </td>
                    <td>
                        <asp:Label ID="lblQueEs" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        Cantidad:
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlCantidad" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="Black" Width="30%">
                            <asp:ListItem Value="1" Text="1" />
                            <asp:ListItem Value="2" Text="2" />
                            <asp:ListItem Value="3" Text="3" />
                            <asp:ListItem Value="4" Text="4" />
                            <asp:ListItem Value="5" Text="5" />
                            <asp:ListItem Value="6" Text="6" />
                            <asp:ListItem Value="7" Text="7" />
                            <asp:ListItem Value="8" Text="8" />
                            <asp:ListItem Value="9" Text="9" />
                            <asp:ListItem Value="10" Text="10" />
                            <asp:ListItem Value="11" Text="11" />
                            <asp:ListItem Value="12" Text="12" />
                        </asp:DropDownList>
                    </td>
                    <td colspan="2" style="text-align: center; " class="auto-style6">
                        <asp:ImageButton ID="btnAgregarAlista" ImageUrl="~/imagenes/agregar.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">Su carrito de compras.</td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="4">
                        <asp:GridView ID="gwListaPedido" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="Quitar" ImageUrl="~/imagenes/quitar.png" Text="Quitar" >
                                <HeaderStyle Width="15%" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="Item" HeaderText="Item Solicitado" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cant." >
                                <HeaderStyle Width="15%" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                         <asp:ImageButton ID="btnQuitarTodos" ImageUrl="~/imagenes/quitartodos.png" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:ImageButton ID="btnSolicitarPedido" ImageUrl="~/imagenes/solicitar.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarPedido" ImageUrl="~/imagenes/cancelarpedido.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center">
                        <asp:Label ID="lblErrorPedido" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Pedido Creado--%>
        <asp:Panel ID="pnlPedidoCreado" runat="server" BorderColor="#66CCFF" Height="389px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr>
                    <td>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Label ID="lblPedidoCreado" Text="" runat="server" Font-Bold="true" Font-Size="Large"/>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnTerminarVolverCreado" ImageUrl="~/imagenes/terminar.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Historico--%>
        <asp:Panel ID="pnlHistorico" runat="server" BorderColor="#66CCFF" Height="389px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: left">
                    <td colspan="2">
                        <h1>Histórico de Pedidos y Revisar Estado</h1>
                    </td>
                </tr>   
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblErrorHistorico" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="2">
                        <asp:GridView ID="gwHistorico" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:ButtonField ButtonType="Button" CommandName="Ver" Text="Ver Pedido" >
                                <ControlStyle BackColor="#009933" Font-Bold="True" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" CommandName="Anular" HeaderText="(sólo &quot;Solicitado&quot;)" Text="Anular Pedido" >
                                <ControlStyle BackColor="Red" Font-Bold="True" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="NPedido" HeaderText="Nº Pedido" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha y Hora" />
                                <asp:BoundField DataField="estado" HeaderText="Estado del Pedido" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnActulizarHistorico" ImageUrl="~/imagenes/actualizar.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnTerminarHistorico" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Ver Un Pedido--%>
        <asp:Panel ID="pnlVerUnPedido" runat="server" BorderColor="#66CCFF" Height="389px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: left">
                    <td>
                        <h2>Datalle del Pedido Nº:
                        <asp:Label ID="lblNroPedido" Text="" runat="server" /></h2>
                    </td>
                </tr>   
                <tr style="text-align: center">
                    <td>
                        <asp:GridView ID="gwVerUnPedido" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="Item" HeaderText="Item Solicitado" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cant" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorVerUnPedido" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnTerminarVerUnPedido" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Abm Productos--%>
        <asp:Panel ID="pnlAbmProductos" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                        <h1>ABM Productos</h1>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnNuevoProducto" ImageUrl="~/imagenes/nuevoproducto.png" runat="server" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnTodosLosProductos" ImageUrl="~/imagenes/todoslosproductos.png" runat="server" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="bntTerminarMenuProductos" ImageUrl="~/imagenes/terminar.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel de Alta de Productos --%>
        <asp:Panel ID="pnlAltaProductos" runat="server" ForeColor="#372C57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Titulos de Registro e Informacion--%>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Image ImageUrl="~/imagenes/header.png" runat="server" Width="763px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <h2>
                        Bienvenido al Alta de Productos
                        </h2>
                    </td>
                </tr>
            </table>
            <%--Tabla Datos para Alta--%>
            <table style="width: 100%">
                <%--Campos y Validacion Codigo Producto--%>
                <tr>
                    <td>Código del Producto:</td>
                    <td>
                        <asp:TextBox ID="txtCodigoProducto" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorCodProducto" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Nombre--%>
                <tr>
                    <td>Nombre del Producto:</td>
                    <td>
                        <asp:TextBox ID="txtNombreProducto" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorNomPro" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Marca--%>
                <tr>
                    <td>Marca:</td>
                    <td>
                        <asp:TextBox ID="txtMarca" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorMarca" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Descripcion.--%>
                <tr>
                    <td>Descripción:</td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="100" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorDescripcion" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Precio--%>
                <tr>
                    <td>Precio $:</td>
                    <td>
                        <asp:TextBox ID="txtPrecio" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="6" Width="150px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorPrecio" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Stock--%>
                <tr>
                    <td>Stock:</td>
                    <td>
                        <asp:TextBox ID="txtStock" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="6" Width="150px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorStock" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para las Categorias--%>
                <tr>
                    <td>Categoria:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategoria" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="Seleccionar" Text="Seleccionar" />
                            <asp:ListItem Value="1" Text="Mothers y Micros" />
                            <asp:ListItem Value="2" Text="Almacenamietnto" />
                            <asp:ListItem Value="3" Text="Placas" />
                            <asp:ListItem Value="4" Text="Gabinetes y Coolers" />
                            <asp:ListItem Value="5" Text="Fuentes" />
                            <asp:ListItem Value="6" Text="Accesorios y Perifericos" />
                            <asp:ListItem Value="7" Text="Otros" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorCategoria" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Estado del Producto--%>
                <tr>
                    <td>Categoria:</td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="1" Text="Activo" />
                            <asp:ListItem Value="0" Text="Inactivo" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center"></td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Label ID="lblErroresProducto" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnAgregarProducto" ImageUrl="~/imagenes/agregar.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarAgregarProducto" ImageUrl="~/imagenes/cancelarpedido.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Producto Creado--%>
        <asp:Panel ID="pnlProductoCreado" runat="server" BorderColor="#66CCFF" Height="389px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr>
                    <td>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Label ID="lblProductoCreado" Text="El Producto Fue dado de Alta Correctamente." runat="server" Font-Bold="true" Font-Size="Large"/>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnVolverAltaProducto" ImageUrl="~/imagenes/terminar.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Todos los Productos --%>
        <asp:Panel ID="pnlListadoProductos" runat="server" BorderColor="#66CCFF" ForeColor="#372c57" Font-Size="Large" Visible="false" BackColor="#94bbd4">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: left">
                    <td colspan="2">
                        <h1>Listado de Todos los Productos</h1>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblErrorListadoProductos" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="2">
                        <asp:GridView ID="gvListadoProductos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="CodigoProducto" HeaderText="Cod. Producto" />
                                <asp:BoundField DataField="NombreProducto" HeaderText="Nombre" />
                                <asp:BoundField DataField="MarcaProducto" HeaderText="Marca" />
                                <asp:BoundField DataField="PrecioProducto" HeaderText="Precio" />
                                <asp:BoundField DataField="StockProducto" HeaderText="Stock" />
                                <asp:ButtonField ButtonType="Button" CommandName="VerEditar" HeaderText="Acción"  Text="Detalles/Editar">
                                    <ControlStyle BackColor="#009933" Font-Bold="True" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" CommandName="Eliminar" HeaderText="Acción" Text="Eliminar">
                                    <ControlStyle BackColor="Red" Font-Bold="True" />
                                </asp:ButtonField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnActulizarListadoProducto" ImageUrl="~/imagenes/actualizar.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnVolverAbmProducto" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Editar Productos --%>
        <asp:Panel ID="pnlEditarProducto" runat="server" ForeColor="#372C57" Font-Size="Large" Visible="false" BackColor="#94bbd4">
            <%--Tabla Titulos de Registro e Informacion--%>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Image ImageUrl="~/imagenes/header.png" runat="server" Width="763px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <h2>Estas Viendo el Producto: <asp:Label ID="lblCodigoProducto" Text="" runat="server" />
                        </h2>
                    </td>
                </tr>
            </table>
            <%--Tabla Datos para Editar--%>
            <table style="width: 100%">
                <%--Campos y Validacion Nombre--%>
                <tr>
                    <td>Nombre del Producto:</td>
                    <td>
                        <asp:TextBox ID="txtNombreProductoEdit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorNombreProductoEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Marca--%>
                <tr>
                    <td>Marca:</td>
                    <td>
                        <asp:TextBox ID="txtMarcaEdit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorMarcaEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Descripcion.--%>
                <tr>
                    <td>Descripción:</td>
                    <td>
                        <asp:TextBox ID="txtDescripcionEdit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="100" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorDescripcionEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Precio--%>
                <tr>
                    <td>Precio $:</td>
                    <td>
                        <asp:TextBox ID="txtPrecioEdit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="6" Width="150px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorPrecioEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Stock--%>
                <tr>
                    <td>Stock:</td>
                    <td>
                        <asp:TextBox ID="txtStockEdit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="6" Width="150px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorStockEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para las Categorias--%>
                <tr>
                    <td>Categoria:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategoriaEdit" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="Seleccionar" Text="Seleccionar" />
                            <asp:ListItem Value="1" Text="Mothers y Micros" />
                            <asp:ListItem Value="2" Text="Almacenamietnto" />
                            <asp:ListItem Value="3" Text="Placas" />
                            <asp:ListItem Value="4" Text="Gabinetes y Coolers" />
                            <asp:ListItem Value="5" Text="Fuentes" />
                            <asp:ListItem Value="6" Text="Accesorios y Perifericos" />
                            <asp:ListItem Value="7" Text="Otros" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorCategoriaEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Estado del Producto--%>
                <tr>
                    <td>Categoria:</td>
                    <td>
                        <asp:DropDownList ID="ddlEstadoEdit" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="1" Text="Activo" />
                            <asp:ListItem Value="0" Text="Inactivo" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center"></td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Label ID="lblErroresProductoEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnEditarProducto" ImageUrl="~/imagenes/editar.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarEditarProducto" ImageUrl="~/imagenes/cancelarpedido.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Producto Editado--%>
        <asp:Panel ID="pnlProductoEditado" runat="server" BorderColor="#66CCFF" Height="389px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr>
                    <td>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <h2>
                            El Producto <asp:Label ID="lblProductoEditado" Text="" runat="server" Font-Bold="true"/> &nbsp;fue Actualizado Correctamente.
                        </h2>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnVolverListado" ImageUrl="~/imagenes/terminar.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%-- Panel ABM Pedidos Fabricas --%>
        <asp:Panel ID="pnlAbmPedidosFabrica" runat="server" BorderColor="#66CCFF" ForeColor="#372c57" Font-Size="Large" Visible="false" BackColor="#94bbd4">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td colspan="2">
                        <h1>Pedidos Realizados por Clientes</h1>
                    </td>
                </tr>
                <tr style="text-align: center; vertical-align:central">
                    <td>Nº de Cliente <br />
                      <asp:TextBox ID="txtNumeroCliente" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" Width="200px" />
                    </td>
                    <td style="text-align: center; vertical-align:central">
                        <asp:ImageButton ID="btnFiltrarCliente" ImageUrl="~/imagenes/filtrarCliente.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblErrorPedidosClientes" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="2">
                        <asp:GridView ID="gvPedidosClientes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="NPedido" HeaderText="Nº Pedido" />
                                <asp:BoundField DataField="Num_Cli" HeaderText="Nº Cliente" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha y Hora" />
                                <asp:BoundField DataField="estado" HeaderText="Estado" />
                                <asp:ButtonField ButtonType="Button" CommandName="VerEditar" Text="Ver/Editar">
                                <ControlStyle BackColor="#339933" Font-Bold="True" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" CommandName="Anular" Text="Anular">
                                <ControlStyle BackColor="#FF5050" Font-Bold="True" />
                                </asp:ButtonField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnActualizarPedidosClientes" ImageUrl="~/imagenes/actualizar.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnVolverAbmPedidosClientes" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Detalle del Pedido --%>
        <asp:Panel ID="pnlDetallePedidoCliente" runat="server" BorderColor="#66CCFF" ForeColor="#372c57" Font-Size="Large" Visible="false" BackColor="#94bbd4">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: left">
                    <td>
                        <h3>Datalle del Pedido Nº 
                        <asp:Label ID="lblNroPedidoCliente" runat="server" /> &nbsp;del Cliente <asp:Label ID="lblNroCliente" Text="" runat="server" /></h3>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:GridView ID="gvDetallePedidoCliente" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="Item" HeaderText="Item Solicitado" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:ButtonField ButtonType="Image" CommandName="Quitar" ImageUrl="~/imagenes/quitar.png" Text="Quitar" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorDpedidoCliente" runat="server" Visible="False" Font-Bold="True" ForeColor="Red" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnTerminarVolverAbmFabrica" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%-- Menu ABM Usuarios --%>
<asp:Panel ID="pnlAbmUsuariosMenu" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/fondo.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                        <h1>Menu ABM Usuarios</h1>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnAbmUsuarios" ImageUrl="~/imagenes/todoslosusuarios.png" runat="server" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnAbmUsuariosAdmin" ImageUrl="~/imagenes/todoslosadmin.png" runat="server" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="bntTerminarMenuUsuarios" ImageUrl="~/imagenes/terminar.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel ABM Usuarios --%>
<asp:Panel ID="pnlAbmUsuarios" runat="server" BorderColor="#66CCFF" ForeColor="#372c57" Font-Size="Large" Visible="false" BackColor="#94bbd4" style="width: 800px">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td colspan="2">
                        <h1>Listado de <asp:Label ID="lblTipoUsuarios" Text="" runat="server" /></h1>
                    </td>
                </tr>
                <tr style="text-align: center; vertical-align:central">
                    <td>Usuario
                        <br />
                      <asp:TextBox ID="txtUsuarioFiltrar" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" Width="200px" />
                    </td>
                    <td style="text-align: center; vertical-align:central">
                        <asp:ImageButton ID="btnFiltrarUsuario" ImageUrl="~/imagenes/filtrarCliente.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblErrorAbmUsuarios" runat="server" Visible="False" Font-Bold="True" ForeColor="Red" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="2">
                        <asp:GridView ID="gvAbmUsuarios" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="EMail" HeaderText="Email" />
                                <asp:BoundField DataField="NombreApellido" HeaderText="Nombre y Apellido" />
                                <asp:BoundField DataField="Activo" HeaderText="Estado" />
                                <asp:ButtonField ButtonType="Button" CommandName="Desactivar" Text="Desactivar">
                                <ControlStyle BackColor="#FF9933" Font-Bold="True" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar">
                                <ControlStyle BackColor="#FF5050" Font-Bold="True" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" CommandName="Admin" Text="Activar Admin" HeaderText="Permiso">
                                    <ControlStyle BackColor="#009900" Font-Bold="True" />
                                </asp:ButtonField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnActulizarAbmUsuarios" ImageUrl="~/imagenes/actualizar.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnTerminarAbmUsuarios" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Motivo --%>
        <asp:Panel ID="pnlMotivo" runat="server" BorderColor="#66CCFF" ForeColor="#372c57" Font-Size="Large" Visible="false" BackColor="#94bbd4">
            <%--Tabla Datos para Registro--%>
            <table style="width: 100%">
                <%--Campos y Validacion Email.--%>
                <tr>
                    <td>Estas por: <asp:Label ID="lblAccionMotivo" Text="" runat="server" Font-Bold="true"/></td>
                    <td>
                        El Usuario: <asp:Label ID="lblUsuarioAccion" Text="" runat="server" Font-Bold="true"/>
                        <asp:Label ID="lblEmailAccion" Text="" runat="server" Font-Bold="true" Visible="false"/>
                    </td>
                </tr>
                <tr>
                    <td>Indique Motivo:</td>
                    <td>
                        <asp:TextBox ID="txtMotivo" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="250" Rows="6" Columns="50" TextMode="MultiLine" />
                    </td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblErrorMotivo" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnConfirmarAbmUsuarios" ImageUrl="~/imagenes/confirmarAccionUsuario.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarAbmUsuarios" ImageUrl="~/imagenes/cancelarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Verificar Email --%>
<asp:Panel ID="pnlValidarMail" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/datospersonales.jpg">
            <%--Tabla Datos para Registro--%>
            <table style="width: 100%">
                <%--Campos y Validacion Email.--%>
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <h3>
                            Te hemos enviado un código de verificación al email que ingresaste. Abrí el email, copiá el código y pegalo en el cuadro de texto a continuacón. Luego oprimí Validar. Para conrregir algún dato ingresaod, oprimí "Volver al Registro"; o bien "Cancelar y Volver" para anular la operacion y volver al Login.
                        </h3>
                    </td>
                </tr>
                <%--Campos y Validacion Codigo --%>
                <tr style="text-align: center">
                    <td>
                        <asp:TextBox ID="txtValidar" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="White" BackColor="#382858" MaxLength="6" />
                    </td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorCodidoValidar" Text="***Código de Verificación Inválido***" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Button ID="btnValidarCodigo" Text="Validar el Código" runat="server" Font-Bold="true" BackColor="#339966" Height="59px" Width="228px" Font-Size="Large"/>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Button ID="btnRegresarRegistro" Text="Regresar al Registro" runat="server" Font-Bold="true" BackColor="#CCCC00" Height="59px" Width="228px" Font-Size="Large"/>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnCancelarRegistro" ImageUrl="~/imagenes/cancelarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
