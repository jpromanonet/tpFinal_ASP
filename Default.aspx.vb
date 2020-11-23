'Clases de Input Output, para el Manejo de Archivos
Imports System.IO
'Clases para ADO, para la Conexion con la DB
Imports System.Data
Imports System.Data.SqlClient
'System.Globalization
Imports System.Globalization
'Clases para Envio y Recepcion de Mails.
Imports System.Net.Mail
Public Class _Default
    Inherits System.Web.UI.Page
    Public x As Integer
    Public connectionstring As String = ConfigurationManager.ConnectionStrings(ConfigurationManager.AppSettings("Conexion")).ToString()
    Public EmailActivo As String = ConfigurationManager.AppSettings("EmailActivo")
    Public Email As String = ConfigurationManager.AppSettings(EmailActivo)
    Public EmailPass As String = ConfigurationManager.AppSettings(EmailActivo & "Pass")
    Dim con As New SqlConnection(connectionstring)
    Dim ar As String
    Protected Sub btnPortada_Click(sender As Object, e As ImageClickEventArgs) Handles btnPortada.Click
        pnlPortada.Visible = False
        pnlLoginMenu.Visible = True
    End Sub

    Protected Sub btnVolverLogin_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverLogin.Click
        pnlPortada.Visible = True
        pnlLogin.Visible = False
    End Sub

    Protected Sub btnRegistrarse_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarse.Click
        pnlLoginMenu.Visible = False
        pnlRegistrarse.Visible = True
    End Sub

    Protected Sub btnRegistrarseVolverLoginU13_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarseVolverLoginU13.Click
        pnlLoginMenu.Visible = False
        pnlPortada.Visible = True
    End Sub
    Protected Sub btnRegistrarseU_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarseU.Click
        registroUsuario()
    End Sub

    Protected Sub btnReenviarClave_Click(sender As Object, e As ImageClickEventArgs) Handles btnReenviarClave.Click
        recuperarClave()
    End Sub

    Protected Sub btnIrLogin_Click(sender As Object, e As ImageClickEventArgs) Handles btnIrLogin.Click
        pnlLoginMenu.Visible = False
        pnlLogin.Visible = True
    End Sub

    Protected Sub btnCancelarVolverU_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarVolverU.Click
        limpiarCamposRegistroU()
        pnlLoginMenu.Visible = True
        pnlRegistrarse.Visible = False
    End Sub

    Protected Sub btnRegistrarseVolverLoginU_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarseVolverLoginU.Click
        pnlBienvenido.Visible = False
        pnlLogin.Visible = True
        txtUsuario.Text = Session("Usuario")
        txtClave.Text = Session("Password")
    End Sub
#Region "Alta de Usuarios"
    Sub registroUsuario()
        Dim ok As Boolean = True
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresRegistroU()
        'Comprobamos el Nombre
        txtNombreU.Text = txtNombreU.Text.Trim().ToUpper
        If comprobar(txtNombreU.Text) = False Then
            arreglarCampo(txtNombreU)
            ok = False
            lblErrorNombreU.Text = "El Nombre contenía caracteres inválidos, fueron quitados"
            lblErrorNombreU.Visible = True
        End If
        'Comprobamos el Apellido
        txtApellidoU.Text = txtApellidoU.Text.Trim().ToUpper
        If comprobar(txtApellidoU.Text) = False Then
            arreglarCampo(txtApellidoU)
            ok = False
            lblErrorApellidoU.Text = "El Apellido contenía caracteres inválidos, fueron quitados"
            lblErrorApellidoU.Visible = True
        End If
        'Comprobamos el DNI
        txtDocU.Text = txtDocU.Text.Trim()
        If comprobar(txtDocU.Text) = False Or Not IsNumeric(txtDocU.Text) Then
            soloNumeros(txtDocU)
            ok = False
            lblErrorDocU.Text = "El Documento no era válido, se ajustó a número "
            lblErrorDocU.Visible = True
        End If
        'Comprobamos el Email
        arreglarCampo(txtEmailU)
        If validateEmail(txtEmailU.Text) = False Then
            ok = False
            lblErrorEmailU.Text = "El Email no es válido."
            lblErrorEmailU.Visible = True
        End If
        'Coprobamos la Fecha de Nacimiento y la Edad
        Dim FechaNacimiento As Date
        ControlDeNacimiento(txtFechaNac, ok, lblErrorFechaNacU, lblFechaNacU, True, FechaNacimiento)
        'Comprobamos La Localidad
        txtLocalidadU.Text = txtLocalidadU.Text.Trim().ToUpper
        If comprobar(txtLocalidadU.Text) = False Then
            arreglarCampo(txtLocalidadU)
            ok = False
            lblErrorLocalidadU.Text = "La Localidad contenía caracteres inválidos, fueron quitados"
            lblErrorLocalidadU.Visible = True
        End If
        'Comprobamos La Direccion
        txtDireccionU.Text = txtDireccionU.Text.ToUpper
        If comprobar(txtDireccionU.Text) = False Then
            arreglarCampo(txtDireccionU)
            ok = False
            lblErrorDireccionU.Text = "La Direccion contenía caracteres inválidos, fueron quitados"
            lblErrorDireccionU.Visible = True
        End If
        'Comprobamos el Telefono
        txtTelefonoU.Text = txtTelefonoU.Text.Trim()
        If comprobar(txtTelefonoU.Text) = False Or Not IsNumeric(txtTelefonoU.Text) Then
            soloNumeros(txtTelefonoU)
            ok = False
            lblErrorTelefonoU.Text = "El Telefono no era válido, se ajustó a número "
            lblErrorTelefonoU.Visible = True
        End If
        'Comprobamos el Usuario
        txtUsuarioU.Text = txtUsuarioU.Text.Trim().ToUpper
        If comprobar(txtUsuarioU.Text) = False Or txtUsuarioU.Text.IndexOf(" ") > -1 Then
            txtUsuarioU.Text = txtUsuarioU.Text.Replace(" ", "")
            arreglarCampo(txtUsuarioU)
            ok = False
            lblErrorUsuarioU.Text = "El Usuario contenía caracteres inválidos, fueron quitados."
            lblErrorUsuarioU.Visible = True
        End If
        If txtUsuarioU.Text.Length < 5 Then
            ok = False
            lblErrorUsuarioU.Text = "El Usuario debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorUsuarioU.Visible = True
        End If
        'Comprobamos la Contraseña
        txtClaveU.Text = txtClaveU.Text.Trim()
        If comprobar(txtClaveU.Text) = False Or txtClaveU.Text.IndexOf(" ") > -1 Then
            txtClaveU.Text = txtClaveU.Text.Replace(" ", "")
            arreglarCampo(txtClaveU)
            ok = False
            lblErrorClaveU.Text = "L a Contraseña contenía caracteres inválidos.Prueba con Letras y Números."
            lblErrorClaveU.Visible = True
        End If
        If txtClaveU.Text.Length < 5 Then
            ok = False
            lblErrorClaveU.Text = "L a Contraseña debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorClaveU.Visible = True
        End If
        'Comprobamos la Segunda Contraseña
        txtClaveRepeatU.Text = txtClaveRepeatU.Text.Trim()
        If comprobar(txtClaveRepeatU.Text) = False Or txtClaveRepeatU.Text.IndexOf(" ") > -1 Then
            txtClaveRepeatU.Text = txtClaveRepeatU.Text.Replace(" ", "")
            arreglarCampo(txtClaveRepeatU)
            ok = False
            lblErrorClaveRepeatU.Text = "La Segunda Contraseña contenía caracteres inválidos.Prueba con Letras y Números."
            lblErrorClaveRepeatU.Visible = True
        End If
        If txtClaveU.Text <> txtClaveRepeatU.Text Then
            ok = False
            lblErrorClaveRepeatU.Text = "No Coinciden las Contraseñas."
            lblErrorClaveRepeatU.Visible = True
        End If
        'Si existen Errores los Mostramos el lblErroresU
        If ok = False Then
            lblErroresU.Text = "Surgieron Errores por favor Revisalos e Intenta de Nuevo."
            lblErroresU.Visible = True
            Exit Sub
        End If
        'Creamos las Distintas Sesiones
        Session("Usuario") = txtUsuarioU.Text
        Session("Password") = txtClaveU.Text
        Session("TipoDocumento") = ddlTipoDocU.SelectedValue.Trim
        Session("Documento") = txtDocU.Text.Trim
        Session("Email") = txtEmailU.Text.Trim
        'Comprobamos si Existe en la DB
        If YaExisteSql("SELECT idusuario FROM usuarios WHERE usuario='" & Session("Usuario") & "'") Then
            ok = False
            lblErrorUsuarioU.Text = "El usuario elegido ya existe. Prueba con otro."
            lblErrorUsuarioU.Visible = True
        End If
        If YaExisteSql("SELECT idusuario FROM usuarios WHERE Documento= '" & Session("Documento") & "'and tdoc= '" & Session("TipoDocumento") & "'") Then
            ok = False
            lblErrorDocU.Text = "Ya existe el " & Session("TipoDocumento") & " " & Session("Documento") & "."
            lblErrorDocU.Visible = True
        End If
        If YaExisteSql("SELECT idusuario FROM usuarios WHERE Email='" & Session("Email") & "'") Then
            ok = False
            lblErrorEmailU.Text = "El Emial Ingresado ya se Encuentra Registrado."
            lblErrorEmailU.Visible = True
        End If
        If ok = False Then
            lblErroresU.Text = "Solo se permite una inscripción por persona."
            lblErroresU.Visible = True
            Exit Sub
        End If
        Session("Usuario") = txtUsuarioU.Text.ToLower
        Session("Password") = txtClaveU.Text
        Session("TipoDocumento") = ddlTipoDocU.SelectedValue.Trim
        Session("Documento") = txtDocU.Text.Trim
        Session("ApellidoYNombre") = txtNombreU.Text.Trim & " " & txtApellidoU.Text.Trim
        Session("Email") = txtEmailU.Text.Trim
        limpiarErroresRegistroU()
        Session("sqlIngreso") = "INSERT INTO Usuarios (Apellido, Nombre, tDoc , Documento, Usuario, Clave, Email, idProv , Localidad,Domicilio, Telefono, fNacimiento) VALUES ( '" & txtApellidoU.Text.Trim & "','" & txtNombreU.Text.Trim & "', '" & Session("TipoDocumento") & "','" & Session("Documento") & "','" & Session("Usuario") & "', '" & Session("Password") & "' , '" & Session("Email") & "'," & ddlProvU.SelectedValue & ", '" & txtLocalidadU.Text.Trim & "' , '" & txtDireccionU.Text.Trim & "','" & txtTelefonoU.Text.Trim & "','" & FechaNacimiento.ToString("yyyy-MM-dd") & " ' ) "
        Dim codigo As String = crearCodigo(4)
        Session("codigo") = codigo
        Dim mensaje As String, en As String = Chr(13) & Chr(10)

        mensaje = "Saludos " & Session("ApellidoYNombre") & "." & en & en & "Te escribimos de sistema ABM, Equipamientos Informaticos, respuesta a tu solicitud de registro como un nuevo usuario de nuestra aplicación. " & en & en & "Por favor, ingresa el código: " & codigo & " en el cuadro de texto de la aplicación Web y presioná Validar. Esto completara tu registro como un Nuevo Usuario de , Equipamientos Informaticos." & en & en & "Felicitaciones" & en & en & "El Equipo de , Equipamientos Informaticos" & en & en & en & en & "(Por favor, no respondas éste mail, es automático... Muchas Gracias.)" & en & en

        Dim okEnviarMail As String = enviarMail(Session("Email"), ", Validar Email", mensaje)

        txtValidar.Text = ""
        lblErrorCodidoValidar.Visible = False
        pnlRegistrarse.Visible = False
        pnlValidarMail.Visible = True
    End Sub
#End Region
#Region "Limpiar Campos"
    'Funcion para limpiar los campos del Fomulario
    Sub arreglarCampo(ByRef campo As TextBox)
        campo.Text = campo.Text.Trim.Replace("'", "").Replace("""", "").Replace("*", "").Replace("+", "").Replace("-", "").Replace("/", "").Replace(": ", "").Replace("' ", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace("&", "")
    End Sub
#End Region
#Region "Evitar SQL Injection"
    'Funcion para Evitar el SQL Injection
    Function comprobar(ByVal user As String) As Boolean
        If user Is System.DBNull.Value Then
            Return False
        Else
            Dim aux As Boolean = True
            Dim listanegra, x As String
            listanegra = "'*+-/:;'><&" & """"
            If user <> "" Then
                For Each x In user
                    If aux = True Then
                        If InStr(1, listanegra, x) > 0 Then
                            aux = False
                        Else
                            aux = True
                        End If
                    Else
                        Return False
                    End If
                Next
                If aux = True Then
                    Return True
                End If
            Else
                Return False
            End If
        End If
    End Function
#End Region
#Region "Limpiar Errores Registro"

    'Funcion para Limpiar y Oculatar el Label que Muestra los Errores de Cada Campo 
    Sub limpiarErroresRegistroU()
        'Dejamos Vacios todos los campos
        lblErroresU.Text = ""
        lblErrorFechaNacU.Text = ""
        lblErrorNombreU.Text = ""
        lblErrorApellidoU.Text = ""
        lblErrorDocU.Text = ""
        lblErrorEmailU.Text = ""
        lblErrorLocalidadU.Text = ""
        lblErrorDireccionU.Text = ""
        lblErrorTelefonoU.Text = ""
        lblErrorUsuarioU.Text = ""
        lblErrorClaveU.Text = ""
        lblErrorClaveRepeatU.Text = ""
        'Ocultamos los Labels de los Errores
        lblErroresU.Visible = False
        lblErrorFechaNacU.Visible = False
        lblErrorNombreU.Visible = False
        lblErrorApellidoU.Visible = False
        lblErrorDocU.Visible = False
        lblErrorEmailU.Visible = False
        lblErrorLocalidadU.Visible = False
        lblErrorDireccionU.Visible = False
        lblErrorTelefonoU.Visible = False
        lblErrorUsuarioU.Visible = False
        lblErrorClaveU.Visible = False
        lblErrorClaveRepeatU.Visible = False
    End Sub
#End Region
#Region "Limpiar Campos"
    Sub limpiarCamposRegistroU()
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresRegistroU()
        pnlRegistrarse.Visible = False
        txtNombreU.Text = ""
        txtApellidoU.Text = ""
        ddlTipoDocU.SelectedIndex = 0
        txtDocU.Text = ""
        txtEmailU.Text = ""
        txtFechaNac.Text = ""
        ddlProvU.SelectedIndex = 0
        txtLocalidadU.Text = ""
        txtDireccionU.Text = ""
        txtTelefonoU.Text = ""
        txtUsuarioU.Text = ""
        txtClaveU.Text = ""
        txtClaveRepeatU.Text = ""
    End Sub
#End Region
#Region "Validar Mail Valido"
    Public Function validateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)
        Return emailMatch.Success
    End Function
#End Region
#Region "Solo Numeros"
    Sub soloNumeros(ByRef campo As TextBox)
        Dim cam As String = campo.Text.Trim, salida As String = "", c As String
        For Each c In cam
            If IsNumeric(c) Then salida &= c
        Next
        campo.Text = salida
    End Sub
#End Region
#Region "Transforma a Numero"
    'Para convertir los String o Num
    Function Vnum(ByVal NTexto As String) As Decimal
        'transforma un texto con algo, que puede ser un numero con coma o punto o perro, y devuelve un valor decimal siempre
        Return CDec(Val(NTexto.Trim.Replace(", ", ".")))
    End Function
#End Region
#Region "Formato Numero SQL"
    'Para convertir los Numeros en el formato correcto para SQL 
    Function NumSql(ByVal numero As String) As String
        'Recibe un número desde un textbox por ejemplo, lo verifica como número válido, 
        'y luego le cambia la coma por punto para que sea válido en una sentencia de sql,
        'luego lo devuelve
        Return CStr(Vnum(numero)).Trim.Replace(", ", ".")
    End Function
#End Region
#Region "Rellenar Numeros"
    'Para Rellenar los Numeros con la cantidad que necesitemos
    Function RellenaNum(ByVal numero As Integer, ByVal cantidad As Integer) As String
        'Rellena con 0s adelante el numero. Ideal para dias y meses:
        'RellenaNum(3,2)---> "03" RellenaNum(3,4)--->"0003"
        Dim snum As String = CStr(numero).Trim
        Return "00000000000000000000".Substring(0, cantidad - snum.Length) & snum
    End Function
#End Region
#Region "Fecha para SQL"
    'Para Formatear las Fechas en el formato correcto para SQL 
    Function FechaSql(ByVal fecha As Date) As String
        'Devuelve fecha en el formato 'AAAAMMDD'
        Return "'" & RellenaNum(Year(fecha), 4) & RellenaNum(Month(fecha), 2) & RellenaNum(fecha.Day, 2) & "'"
    End Function
#End Region
#Region "Fomato Americano Fecha"
    'Devuelve la fecha en formato Americano AAAA-MM
    Public Function AnioMes(ByVal fecha As Date) As String

        Return RellenaNum(Year(fecha), 4) & "-" & RellenaNum(Month(fecha), 2)
    End Function
#End Region
#Region "Verifica String"
    Public Function Vstr(ByVal algo As Object) As String
        If IsDBNull(algo) Then Return "" Else Return CStr(algo)
    End Function
#End Region
#Region "Calcular Edad"
    Public Function CalcularEdad(ByVal FechaNac As Date) As Integer
        Dim edad As Integer = DateTime.Today.AddTicks(-FechaNac.Ticks).Year - 1
        Return edad
    End Function
#End Region
#Region "Control de Fecha Nacimiento"
    Sub ControlDeNacimiento(ByRef xtF_Nac As TextBox,
                            ByRef ok As Boolean,
                            ByRef xlEFNac As Label,
                            ByRef xlEdad As Label,
                            ByVal Valida18 As Boolean,
                            ByRef FechaNacimiento As Date)
        arreglarCampo(xtF_Nac)
        xlEFNac.Visible = False
        If xtF_Nac.Text.Length < 6 Then
            ok = False
            xlEFNac.Text &= "El Campo de la Fecha de Nacimiento debe Tener 6 Números."
            xlEdad.Text = "0"
            xlEFNac.Visible = True
        Else
            Dim fechaX As String = xtF_Nac.Text
            Dim anioX As Integer = Vnum(fechaX.Substring(4, 2))
            If anioX + 2000 > Date.Today.Year Then anioX += 1900 Else anioX += 2000
            fechaX = anioX.ToString.Trim & "-" & fechaX.Substring(2, 2) & "-" & fechaX.Substring(0, 2)
            If Not IsDate(fechaX) Then
                ok = False
                xlEFNac.Text &= "El Campo de la Fecha de Nacimiento, es una Fecha Inválida."
                xlEdad.Text = "0"
                xlEFNac.Visible = True
            Else
                Dim dFechaX As Date
                dFechaX = CDate(fechaX)
                FechaNacimiento = dFechaX
                If dFechaX > Date.Today Then
                    ok = False
                    xlEFNac.Text &= "Creo que Naciste en el Futuro."
                    xlEdad.Text = "0"
                    xlEFNac.Visible = True
                Else
                    Dim edad As Integer = CalcularEdad(dFechaX)
                    xlEdad.Text = edad
                    If edad < 18 And Valida18 Then
                        ok = False
                        xlEFNac.Text &= "Debes ser Mayor de Edad (18 Años)."
                        xlEdad.Text = "0"
                        xlEFNac.Visible = True
                    End If
                End If
            End If
        End If
    End Sub
#End Region
#Region "Acciones del ABM"
    'Ejecuta las distintas acciones del ABM
    Public Function SqlAccion(ByVal Sql_de_accion As String) As Boolean
        'Ejecuta la consulta de accion 'sql_de_accion' abriendo la conexion automaticamente
        'se da cuenta si es de insert, update o delete, porque mira dentro de la sentencia que se le pasa
        'devuelve true si se pudo hacer, y false si hubo algún error
        Dim adapter As New SqlDataAdapter, salida As Boolean = True
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            If Sql_de_accion.ToUpper.IndexOf("INSERT") Then
                adapter.InsertCommand = New SqlCommand(Sql_de_accion, con)
                adapter.InsertCommand.ExecuteNonQuery()
            Else
                If Sql_de_accion.ToUpper.IndexOf("UPDATE") Then
                    adapter.UpdateCommand = New SqlCommand(Sql_de_accion, con)
                    adapter.UpdateCommand.ExecuteNonQuery()
                Else
                    If Sql_de_accion.ToUpper.IndexOf("DELETE") Then
                        adapter.DeleteCommand = New SqlCommand(Sql_de_accion, con)
                        adapter.DeleteCommand.ExecuteNonQuery()
                    Else
                        'esta mal la sintaxis porque no hay ni insert, ni delete ni update
                        salida = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & Sql_de_accion)
            salida = False
        End Try
        con.Close()
        Return salida
    End Function
#End Region
#Region "Lee un Campo del DB"
    Function LeeUnCampo(ByVal sql As String, ByVal campo As String) As Object
        'se le pasa un select de sql con un campo y devuelve el valor del campo como object. Se supone que devuelve nada o 1 registro (no más que 1)
        'por ejemplo valor=LeeUnCampo("select cosa from tabla where condi=1","cosa") valor tomará cosa. Si no encuentra nada devuelve "**NADA**". Si hay error devuelve "**ERROR**"
        Dim da1 As New SqlDataAdapter(sql, con)
        Dim ds1 As New DataSet
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            da1.Fill(ds1, "datos")
            If ds1.Tables("datos").Rows.Count < 1 Then
                Return "**NADA**"
            Else
                Return ds1.Tables("datos").Rows(0)(campo)
            End If
        Catch
            Return "**ERROR**"
        End Try
    End Function
#End Region
#Region "Existe en la DB"
    'Para comprobar si existe en la DB
    Function YaExisteSql(ByVal sql As String) As Boolean
        'Le pasamos un SELECT de SQL que en teoria busca algo, por ejemplo un numero de cheque, si hay registros la Funcion devuelve 
        'True, estilo "el cheque ya existe", si no esta, devuelve False
        Dim con As New SqlConnection(connectionstring)
        Dim da1 As New SqlDataAdapter(sql, con)
        Dim dsl As New DataSet
        da1.Fill(dsl, "afidesc")
        If dsl.Tables("afidesc").Rows.Count < 1 Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region
#Region "Limpiar Errores Nodificar Datos Personales"
    'Funcion para Limpiar y Oculatar el Label que Muestra los Errores de Cada Campo 
    Sub limpiarErroresModificarDatosU()
        'Dejamos Vacios todos los campos
        lblErrorEdit.Text = ""
        lblErrorEmailUedit.Text = ""
        lblErrorLocalidadUedit.Text = ""
        lblErrorDireccionUedit.Text = ""
        lblErrorTelefonoUedit.Text = ""
        lblErrorUsuarioUedit.Text = ""
        lblErrorClaveUedit.Text = ""
        'Ocultamos los Labels de los Errores
        lblErrorEdit.Visible = False
        lblErrorEmailUedit.Visible = False
        lblErrorLocalidadUedit.Visible = False
        lblErrorDireccionUedit.Visible = False
        lblErrorTelefonoUedit.Visible = False
        lblErrorUsuarioUedit.Visible = False
        lblErrorClaveUedit.Visible = False
    End Sub
#End Region
#Region "Modificar Datos Personales"
    Sub editarDatosPersonales()
        Dim ok As Boolean = True
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresModificarDatosU()
        'Comprobamos el Email
        arreglarCampo(txtEmailUedit)
        If validateEmail(txtEmailUedit.Text) = False Then
            ok = False
            lblErrorEmailUedit.Text = "El Email no es válido."
            lblErrorEmailUedit.Visible = True
        End If
        'Comprobamos La Localidad
        txtLocalidadUedit.Text = txtLocalidadUedit.Text.Trim().ToUpper
        If comprobar(txtLocalidadUedit.Text) = False Then
            arreglarCampo(txtLocalidadUedit)
            ok = False
            lblErrorLocalidadUedit.Text = "La Localidad contenía caracteres inválidos, fueron quitados"
            lblErrorLocalidadUedit.Visible = True
        End If
        'Comprobamos La Direccion
        txtDireccionUedit.Text = txtDireccionUedit.Text.ToUpper
        If comprobar(txtDireccionUedit.Text) = False Then
            arreglarCampo(txtDireccionUedit)
            ok = False
            lblErrorDireccionUedit.Text = "La Direccion contenía caracteres inválidos, fueron quitados"
            lblErrorDireccionUedit.Visible = True
        End If
        'Comprobamos el Telefono
        txtTelefonoUedit.Text = txtTelefonoUedit.Text.Trim()
        If comprobar(txtTelefonoUedit.Text) = False Or Not IsNumeric(txtTelefonoUedit.Text) Then
            soloNumeros(txtTelefonoUedit)
            ok = False
            lblErrorTelefonoUedit.Text = "El Telefono no era válido, se ajustó a número "
            lblErrorTelefonoUedit.Visible = True
        End If
        'Comprobamos el Usuario
        txtUsuarioUedit.Text = txtUsuarioUedit.Text.Trim().ToUpper
        If comprobar(txtUsuarioUedit.Text) = False Or txtUsuarioUedit.Text.IndexOf(" ") > -1 Then
            txtUsuarioUedit.Text = txtUsuarioUedit.Text.Replace(" ", "")
            arreglarCampo(txtUsuarioUedit)
            ok = False
            lblErrorUsuarioUedit.Text = "El Usuario contenía caracteres inválidos, fueron quitados."
            lblErrorUsuarioUedit.Visible = True
        End If
        If txtUsuarioUedit.Text.Length < 5 Then
            ok = False
            lblErrorUsuarioUedit.Text = "El Usuario debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorUsuarioUedit.Visible = True
        End If
        'Comprobamos la Contraseña
        txtClaveUedit.Text = txtClaveUedit.Text.Trim()
        If comprobar(txtClaveUedit.Text) = False Or txtClaveUedit.Text.IndexOf(" ") > -1 Then
            txtClaveUedit.Text = txtClaveUedit.Text.Replace(" ", "")
            arreglarCampo(txtClaveUedit)
            ok = False
            lblErrorClaveUedit.Text = "L a Contraseña contenía caracteres inválidos.Prueba con Letras y Números."
            lblErrorClaveUedit.Visible = True
        End If
        If txtClaveUedit.Text.Length < 5 Then
            ok = False
            lblErrorClaveUedit.Text = "L a Contraseña debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorClaveUedit.Visible = True
        End If
        'Si existen Errores los Mostramos el lblErroresU
        If ok = False Then
            lblErrorEdit.Text = "Surgieron Errores por favor Revisalos e Intenta de Nuevo."
            lblErrorEdit.Visible = True
            Exit Sub
        End If
        'Creamos las Distintas Sesiones
        If txtUsuarioUedit.Text <> Session("Usuario") Then
            Session("Usuario") = txtUsuarioUedit.Text
            'Comprobamos si Existe en la DB
            If YaExisteSql("SELECT idusuario FROM usuarios WHERE usuario='" & Session("Usuario") & "'") Then
                ok = False
                lblErrorUsuarioU.Text = "El usuario elegido ya existe. Prueba con otro."
                lblErrorUsuarioU.Visible = True
            End If
        End If
        Session("Password") = txtClaveUedit.Text
        Session("Usuario") = txtUsuarioUedit.Text.ToLower
        Session("Password") = txtClaveUedit.Text
        Session("Email") = txtEmailUedit.Text.Trim
        Session("Direccion") = txtDireccionUedit.Text.Trim
        Session("Localidad") = txtLocalidadUedit.Text.Trim
        Session("Telefono") = txtTelefonoUedit.Text.Trim
        limpiarErroresModificarDatosU()
        'Si pasa la Validacion lo Insertanos en la DB
        Select Case Session("QueEs")
            Case "Usuarios"
                If SqlAccion("UPDATE Usuarios SET Email='" & Session("Email") & "', idProv='" & ddlProvUedit.SelectedValue & "', Localidad = '" & txtLocalidadUedit.Text.Trim & "', Domicilio= '" & txtDireccionUedit.Text.Trim & "', Telefono='" & txtTelefonoUedit.Text.Trim & "', Usuario='" & Session("Usuario") & "', Clave='" & Session("Password") & "' WHERE idUsuario =" & Session("idUsuario")) = False Then
                    lblErroresU.Text = "Se ha producido un error al querer guardar tus datos."
                    lblErroresU.Visible = True
                    Exit Sub
                End If
            Case "Administradores"
                If SqlAccion("UPDATE Administradores SET Email='" & Session("Email") & "', idProv='" & ddlProvUedit.SelectedValue & "', Localidad = '" & txtLocalidadUedit.Text.Trim & "', Domicilio= '" & txtDireccionUedit.Text.Trim & "', Telefono='" & txtTelefonoUedit.Text.Trim & "', Usuario='" & Session("Usuario") & "', Clave='" & Session("Password") & "' WHERE idAdmin =" & Session("idAdmin")) = False Then
                    lblErroresU.Text = "Se ha producido un error al querer guardar tus datos."
                    lblErroresU.Visible = True
                    Exit Sub
                End If
            Case Else

        End Select
        pnlCambiarDatosPersonales.Visible = False
        pnlDatosModificadosOk.Visible = True
        btnVolverAreaUsuario.Focus()
    End Sub
#End Region
#Region "Loguear Usuario"
    Sub Loguea()
        Dim usu As String = txtUsuario.Text.Trim.ToUpper, pass As String = txtClave.Text.Trim
        If comprobar(txtUsuario.Text.Trim) = False Or comprobar(txtClave.Text.Trim) = False Then
            lblErrorLogin.Text = "El Usuario o la Contraseña son Incorrectos. Revise por favor."
            lblErrorLogin.Visible = True
            Exit Sub
        End If
        Dim da1 As New SqlDataAdapter("SELECT * FROM " & Session("QueEs") & " WHERE UPPER(LTRIM(RTRIM(usuario)))='" & usu & "' AND LTRIM(RTRIM(clave))='" & pass & "' AND Activo = 1", con)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "Login")
        If ds1.Tables("Login").Rows.Count = 0 Then
            lblErrorLogin.Text = "El Usuario o la Contraseña son Incorrectos. Revise por favor."
            lblErrorLogin.Visible = True
            Exit Sub
        End If
        'Para Comprobar que Tipo de Usuario es y ver de donde tomamos los datos
        Select Case Session("QueEs")
            Case "Usuarios"
                Session("idUsuario") = ds1.Tables("Login").Rows(0)("idUsuario")
                Session("Usuario") = usu
                Session("Password") = pass
                Session("TipoDocumento") = ds1.Tables("Login").Rows(0)("tDoc")
                Session("Documento") = ds1.Tables("Login").Rows(0)("Documento").ToString.Trim
                Session("ApellidoYNombre") = ds1.Tables("Login").Rows(0)("Nombre").ToString.Trim & " " & ds1.Tables("Login").Rows(0)("Apellido").ToString.Trim
                Session("Email") = ds1.Tables("Login").Rows(0)("Email").ToString.Trim
                Session("idprov") = ds1.Tables("Login").Rows(0)("idProv").ToString.Trim
                Session("Localidad") = ds1.Tables("Login").Rows(0)("Localidad").ToString.Trim
                Session("Direccion") = ds1.Tables("Login").Rows(0)("Domicilio").ToString.Trim
                Session("Telefono") = ds1.Tables("Login").Rows(0)("Telefono").ToString.Trim
                lblBienvenidoAreaU.Text = "Bienvenido " & Session("ApellidoYNombre") & ", a tu Área de Usuario."
                limpiarCamposRegistroU()
                pnlLogin.Visible = False
                pnlAreaUsuario.Visible = True
                mostrarBotonesUsuario()
            Case "Administradores"
                Session("idAdmin") = ds1.Tables("Login").Rows(0)("idAdmin")
                Session("Usuario") = usu
                Session("Password") = pass
                Session("Denominacion") = ds1.Tables("Login").Rows(0)("Nombre").ToString.Trim & " " & ds1.Tables("Login").Rows(0)("Apellido").ToString.Trim
                Session("Email") = ds1.Tables("Login").Rows(0)("Email").ToString.Trim
                Session("idprov") = ds1.Tables("Login").Rows(0)("idProv").ToString.Trim
                Session("Localidad") = ds1.Tables("Login").Rows(0)("Localidad").ToString.Trim
                Session("Direccion") = ds1.Tables("Login").Rows(0)("Domicilio").ToString.Trim
                Session("Telefono") = ds1.Tables("Login").Rows(0)("Telefono").ToString.Trim
                lblBienvenidoAreaU.Text = "Bienvenido " & Session("Denominacion") & ", a tu Área de Administrador."
                pnlLogin.Visible = False
                pnlAreaUsuario.Visible = True
                mostrarBotonesAdmin()
                'lblAdherente0.Text = "Bienvenido Administrador " & Session("Denominacion") & "."
                'MostrarCuantosAEliminar()
                'MostrarCuantosUsuariosHay()
                'pnlAdministradores.Visible = True
        End Select
    End Sub
#End Region
#Region "Mostrar Botones Segun Tipo de Usuario"
    Sub mostrarBotonesUsuario()
        btnAbmPedidoFabrica.Visible = False
        btnAbmUsuariosMenu.Visible = False
        btnHacerPedidoFabrica.Visible = True
        btnHacerPedido.Visible = False
        btnVerHistorico.Visible = True
        btnAbmProductos.Visible = False
    End Sub
    Sub mostrarBotonesAdmin()
        btnHacerPedidoFabrica.Visible = False
        btnAbmUsuariosMenu.Visible = True
        btnAbmPedidoFabrica.Visible = True
        btnAbmProductos.Visible = True
        btnHacerPedido.Visible = False
        btnVerHistorico.Visible = False
    End Sub
#End Region
#Region "Para Limpiar el Login"
    Sub limpiarLogin()
        lblErrorLogin.Text = ""
        lblErrorLogin.Visible = False
        txtUsuario.Text = ""
        pnlRegistrarse.Visible = False
    End Sub
#End Region
#Region "Mostrar Datos Personales"
    Sub mostrarDatosPersonales()
        txtEmailUedit.Text = Session("Email")
        txtLocalidadUedit.Text = Session("Localidad")
        txtDireccionUedit.Text = Session("Direccion")
        ddlProvUedit.SelectedValue = Session("idprov")
        txtTelefonoUedit.Text = Session("Telefono")
        txtUsuarioUedit.Text = Session("Usuario")
        txtClaveUedit.Text = Session("Password")
    End Sub
#End Region
#Region "Cargar Productos en DropDownList"
    'Carga los productos en el ddlProducto
    Sub cargarProductos()
        'index para contar las candidad de registros para el FOR y datos para guardar los resultados
        Dim index As Integer, datos As String
        Dim consulta As String = "SELECT * FROM productos ORDER BY NombreProducto"
        Dim dataAdapter As New SqlDataAdapter(consulta, con)
        Dim dataSet As New DataSet
        'Limpiamos los Items del ddl para no ir duplicando cada vez que llamamos a la funcion
        ddlProducto.Items.Clear()
        'Traemos los datos
        dataAdapter.Fill(dataSet, "datos")
        'Comprobamos si hay algo
        If dataSet.Tables("datos").Rows.Count = 0 Then
            ddlProducto.Items.Add("Lo Sentimos. No Hay Productos Disponibles")
            Exit Sub
        End If
        For index = 0 To dataSet.Tables("datos").Rows.Count - 1
            datos = dataSet.Tables("datos").Rows(index)("NombreProducto").ToString.Trim
            'Agregamos un Item al ddlProducto
            ddlProducto.Items.Add(datos)
        Next
        'Seleccionamos el Primer Item del ddlProducto
        ddlProducto.SelectedIndex = 0
        lblCosaAgregar.Text = ddlProducto.SelectedItem.ToString
        lblQueEs.Text = "Equipos Informaticos"
    End Sub
#End Region
#Region "Cargar Productos a la Grilla Temporal "
    Sub cargarTemporal()
        Dim idUser As Integer = Vnum(Session("idUsuario"))
        'Seleccionamos todos los productos que tiene cargado el usuario en la tabla de pedidos temporal
        Dim consulta As String = "SELECT Item, Cantidad FROM Pedidos_Temporal WHERE Num_Cli=" & idUser & " ORDER BY Item"
        Dim dataAdapter As New SqlDataAdapter(consulta, con)
        Dim dataSet As New DataSet
        'Traemos los datos
        dataAdapter.Fill(dataSet, "pedidos")
        gwListaPedido.DataSource = dataSet.Tables("pedidos")
        gwListaPedido.DataBind()
        If dataSet.Tables("pedidos").Rows.Count = 0 Then
            lblErrorHistorico.Text = ""
            gwListaPedido.Visible = False
            btnSolicitarPedido.Visible = False
            btnQuitarTodos.Visible = False
        Else
            gwListaPedido.Visible = True
            btnSolicitarPedido.Visible = True
            btnQuitarTodos.Visible = True
        End If

    End Sub
#End Region
#Region "Borrar Temporal Usuario Logeado"
    Public Function borrarPedidosTemporal() As Boolean
        'Borramos el Teporal de los Pedidos del Usuario
        Dim salida As Boolean = True
        Dim consulta As String = "DELETE pedidos_temporal WHERE num_cli = " & Vnum(Session("idUsuario"))
        If SqlAccion(consulta) = False Then
            salida = False
        End If
        Return salida
    End Function
#End Region
#Region "Acciones Boton Nuevo Pedido"
    Sub nuevoPedidoBtnAccion()
        Dim enter As String = "<br>"
        Dim instrucciones As String
        instrucciones = "<span>Instrucciones</span>" & enter & enter & "1) Elige el Producto a Solicitar a la Fabrica o Proveedor, los veras en Agregar:" & enter & "2) Indique la Cantidad deL Producto." & enter & "3) Oprima el Botón Agregar a la Lista. El Item elegido y la Cantidad se veran en la Lista Inferior. Si quieren sacar algún Item (quita por completo), solo deben seleccionar el Item en la lista para seleccionar y oprima el botón Quitar. Si agrega un Item que ya se encontraba en la lista se sumaran las cantidades." & enter & "4) Cuando Haya Terminado oprima el botón Enviar el Pedido. Todos los Items figuraran como Solicitado, y desde Revisar Estado de los Pedidos, podrá ver si cabiaron a Despachado o Enviado. Desde allí podrá anular los pedidos que aún esten Solicitado."
        lblInstrucciones.Text = instrucciones
        lblInstrucciones.Visible = False
        btnInstrucciones.Text = "Abrir Instrucciones"
        lblCosaAgregar.Text = ""
        cargarProductos()
        btnQuitarTodos.Visible = False
        btnSolicitarPedido.Visible = False
        lblErrorPedido.Text = ""
        If IsNothing(Session("idUsuario")) Then
            pnlLogin.Visible = True
            Exit Sub
        End If
        borrarPedidosTemporal()
        cargarTemporal()
    End Sub
#End Region
#Region "Agregar Los Productos a la Lista de Pedidos Temporal"
    Sub agregarListaPedidosTemporal()
        Dim index As Integer = 0, c As String, numero As Integer = 0
        Dim producto As String = lblCosaAgregar.Text.Trim
        'Si no hay Productos Seleccionados salimos
        If producto = "-----------" Then Exit Sub
        'Obtenemos la Cantidad de los Productos
        Dim cantidad As Integer = Vnum(ddlCantidad.SelectedValue.ToString)
        'Si la cantidad es 0 salimos
        If cantidad <= 0 Then Exit Sub
        lblErrorPedido.Text = ""
        'Comprobamos si el Item elegido ya esta en la lista
        Dim consulta As String = "SELECT Cantidad FROM Pedidos_Temporal WHERE Num_Cli=" & Vnum(Session("idUsuario")) & "AND LTRIM(RTRIM(Item))='" & producto & "'"
        Dim dataAdapter As New SqlDataAdapter(consulta, con)
        Dim dataSet As New DataSet
        dataAdapter.Fill(dataSet, "datos")
        If dataSet.Tables("datos").Rows.Count > 0 Then
            'Es decir que estaba en la lista
            cantidad += Vnum(dataSet.Tables("datos").Rows(0)("Cantidad"))
            Dim queryAddCantidad = "UPDATE Pedidos_Temporal SET Cantidad=" & cantidad & " WHERE Num_Cli=" & Vnum(Session("idUsuario")) & " AND LTRIM(RTRIM(Item))='" & producto & "'"
            If SqlAccion(queryAddCantidad) = False Then
                lblErrorPedido.Text = "No se Pudo Modificar el Item Elegido. Intente más Tarde."
                Exit Sub
            End If
        Else
            Dim queryAddItem = "INSERT INTO Pedidos_Temporal (Num_Cli, Item, Cantidad) VALUES (" & Vnum(Session("idUsuario")) & ", '" & producto & "' ," & cantidad & ")"
            If SqlAccion(queryAddItem) = False Then
                lblErrorPedido.Text = "No se Pudo Agregar el Item Elegido a la Lista. Intente más Tarde."
                Exit Sub
            End If
        End If
        ddlCantidad.SelectedIndex = 0
        cargarTemporal()
    End Sub
#End Region
#Region "Eliminar Item de la Lista de Pedidos_Temporal"
    Sub quitarItem(ByVal e As GridViewCommandEventArgs)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gwListaPedido.Rows(index)
        Dim item As String = row.Cells(1).Text, enter As String = Chr(13) & Chr(10)
        Dim consulta As String = "DELETE Pedidos_Temporal WHERE LTRIM(RTRIM(iTEM)) ='" & item & "' AND Num_Cli =" & Vnum(Session("idUsuario"))
        lblErrorPedido.Text = ""
        If (e.CommandName = "Quitar") Then
            If SqlAccion(consulta) = False Then
                lblErrorPedido.Text = "No se Pudo Quitar el Item de la Lista. Intente más Tarde."
                Exit Sub
            End If
            cargarTemporal()
        End If
    End Sub
#End Region
#Region "Limpiar Errores Alta Producto"

    'Funcion para Limpiar y Oculatar el Label que Muestra los Errores de Cada Campo 
    Sub limpiarErroresAltaProducto()
        'Dejamos Vacios todos los campos
        lblErrorCodProducto.Text = ""
        lblErrorNomPro.Text = ""
        lblErrorMarca.Text = ""
        lblErrorDescripcion.Text = ""
        lblErrorPrecio.Text = ""
        lblErrorStock.Text = ""
        lblErrorCategoria.Text = ""
        lblErroresProducto.Text = ""
        'Ocultamos los Labels de los Errores
        lblErrorCodProducto.Visible = False
        lblErrorNomPro.Visible = False
        lblErrorMarca.Visible = False
        lblErrorDescripcion.Visible = False
        lblErrorPrecio.Visible = False
        lblErrorStock.Visible = False
        lblErrorCategoria.Visible = False
        lblErroresProducto.Visible = False
    End Sub
#End Region
#Region "Limpiar Campos Productos"
    Sub limpiarCamposAltaProducto()
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresAltaProducto()
        txtCodigoProducto.Text = ""
        txtNombreProducto.Text = ""
        txtMarca.Text = ""
        txtDescripcion.Text = ""
        txtPrecio.Text = ""
        txtStock.Text = ""
        ddlCategoria.SelectedIndex = 0
        ddlEstado.SelectedIndex = 0
    End Sub
#End Region
#Region "Alta Producto"
    Sub altaProducto()
        Dim ok As Boolean = True
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresAltaProducto()
        'Comprobamos el Nombre
        txtCodigoProducto.Text = txtCodigoProducto.Text.Trim().ToUpper
        If comprobar(txtCodigoProducto.Text) = False Then
            arreglarCampo(txtCodigoProducto)
            ok = False
            lblErrorNomPro.Text = "El Código contenía caracteres inválidos, fueron quitados"
            lblErrorNomPro.Visible = True
        End If
        'Comprobamos el Nombre
        txtNombreProducto.Text = txtNombreProducto.Text.Trim().ToUpper
        If comprobar(txtNombreProducto.Text) = False Then
            arreglarCampo(txtNombreProducto)
            ok = False
            lblErrorNomPro.Text = "El Nombre contenía caracteres inválidos, fueron quitados"
            lblErrorNomPro.Visible = True
        End If
        'Comprobamos Marca
        txtMarca.Text = txtMarca.Text.Trim().ToUpper
        If comprobar(txtMarca.Text) = False Then
            arreglarCampo(txtMarca)
            ok = False
            lblErrorMarca.Text = "La Marca contenía caracteres inválidos, fueron quitados"
            lblErrorMarca.Visible = True
        End If
        'Comprobamos la Descripcion
        txtDescripcion.Text = txtDescripcion.Text.Trim().ToUpper
        If comprobar(txtDescripcion.Text) = False Then
            arreglarCampo(txtDescripcion)
            ok = False
            lblErrorDescripcion.Text = "La Descripción contenía caracteres inválidos, fueron quitados"
            lblErrorDescripcion.Visible = True
        End If
        'Comprobamos el Precio
        txtPrecio.Text = txtPrecio.Text.Trim()
        If comprobar(txtPrecio.Text) = False Or Not IsNumeric(txtPrecio.Text) Then
            soloNumeros(txtPrecio)
            ok = False
            lblErrorPrecio.Text = "El Precio no era válido, se ajustó a número "
            lblErrorPrecio.Visible = True
        End If
        'Comprobamos el Precio
        txtStock.Text = txtStock.Text.Trim()
        If comprobar(txtStock.Text) = False Or Not IsNumeric(txtStock.Text) Then
            soloNumeros(txtStock)
            ok = False
            lblErrorStock.Text = "El Stock no era válido, se ajustó a número "
            lblErrorStock.Visible = True
        End If
        If ddlCategoria.SelectedValue = "Seleccionar" Then
            ok = False
            lblErrorCategoria.Text = "Debe Seleccionar una Categoria para el Producto."
            lblErrorCategoria.Visible = True
        End If
        'Si existen Errores los Mostramos el lblErroresProducto
        If ok = False Then
            lblErroresProducto.Text = "Surgieron Errores por favor Revisalos e Intenta de Nuevo."
            lblErroresProducto.Visible = True
            Exit Sub
        End If
        'Comprobamos si Existe en la DB
        If YaExisteSql("SELECT CodigoProducto FROM Productos WHERE CodigoProducto='" & txtCodigoProducto.Text.Trim & "'") Then
            ok = False
            lblErrorCodProducto.Text = "El Código Ingresado ya existe."
            lblErrorCodProducto.Visible = True
        End If
        If ok = False Then
            lblErroresProducto.Text = "El Código de Producto No se Puede Repetir."
            lblErroresProducto.Visible = True
            Exit Sub
        End If
        'Si pasa la Validacion lo Insertanos en la DB
        Dim consulta = "INSERT INTO Productos (CodigoProducto, NombreProducto, MarcaProducto , DescripcionProducto, PrecioProducto, StockProducto, CategoriaProducto, Estado) VALUES ('" & txtCodigoProducto.Text.Trim & "', '" & txtNombreProducto.Text.Trim & "', '" & txtMarca.Text.Trim & "', '" & txtDescripcion.Text.Trim & "', " & NumSql(txtPrecio.Text.Trim) & ", " & NumSql(txtStock.Text.Trim) & ", '" & ddlCategoria.SelectedValue & "', " & ddlEstado.SelectedValue & ")"
        If SqlAccion(consulta) = False Then
            lblErroresProducto.Text = "Se ha producido un error al querer guardar tus datos."
            lblErroresProducto.Visible = True
            Exit Sub
        End If
        limpiarCamposAltaProducto()
        pnlAltaProductos.Visible = False
        pnlProductoCreado.Visible = True
        btnVolverAltaProducto.Focus()
    End Sub
#End Region
#Region "Listado de Todos los Productos"
    Sub listarProductos()
        'Seleccionamos todos los productos que tiene cargado el usuario en la tabla de pedidos temporal
        Dim consulta As String = "SELECT CodigoProducto, NombreProducto, MarcaProducto, PrecioProducto, StockProducto FROM Productos ORDER BY MarcaProducto"
        Dim dataAdapter As New SqlDataAdapter(consulta, con)
        Dim dataSet As New DataSet
        'Traemos los datos
        dataAdapter.Fill(dataSet, "productos")
        gvListadoProductos.DataSource = dataSet.Tables("productos")
        gvListadoProductos.DataBind()
        If dataSet.Tables("productos").Rows.Count = 0 Then
            lblErrorListadoProductos.Text = ""
            gvListadoProductos.Visible = False
        Else
            gvListadoProductos.Visible = True
        End If

    End Sub
#End Region
#Region "Acciones Botones GridView ABM Productos"
    Sub accionBotonesgvListadoProductos(ByVal e As GridViewCommandEventArgs)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gvListadoProductos.Rows(index)
        Dim codigoProducto As String = row.Cells(0).Text
        Select Case e.CommandName
            Case "Eliminar"
                If MsgBox("¿Está seguro de eliminar este Producto?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    eliminarProducto(codigoProducto)
                End If
            Case "VerEditar"
                If mostrarDatosProducto(codigoProducto) Then
                    pnlListadoProductos.Visible = False
                    pnlEditarProducto.Visible = True
                End If
            Case Else
                lblErrorListadoProductos.Text = "No se Pudeo Ejecutar la Accion Elegida."
                lblErrorListadoProductos.Visible = True
        End Select

    End Sub
#End Region
#Region "Eliminar Producto"
    Sub eliminarProducto(ByVal codigoProducto As String)
        Dim consulta As String = "DELETE Productos WHERE LTRIM(RTRIM(CodigoProducto))='" & codigoProducto & "'"
        lblErrorPedido.Text = ""
        If SqlAccion(consulta) = False Then
            lblErrorListadoProductos.Text = "No se Pudo Eliminar el Producto. Intente más Tarde."
            lblErrorListadoProductos.Visible = True
            Exit Sub
        End If
        listarProductos()
    End Sub
#End Region
#Region "Mostrar los Datos del Producto Para Editar"
    Function mostrarDatosProducto(ByVal codigoProducto As String) As Boolean
        Dim salida As Boolean = True
        Dim consulta As String = "SELECT * FROM Productos WHERE LTRIM(RTRIM(CodigoProducto))='" & codigoProducto & "'"
        Dim dataAdapter As New SqlDataAdapter(consulta, con)
        Dim dataSet As New DataSet
        lblErrorPedido.Text = ""
        'Traemos los datos
        dataAdapter.Fill(dataSet, "productos")
        If dataSet.Tables("productos").Rows.Count > 0 Then
            lblErrorListadoProductos.Text = ""
            lblCodigoProducto.Text = dataSet.Tables("productos").Rows(0)("CodigoProducto").ToString.Trim
            txtNombreProductoEdit.Text = dataSet.Tables("productos").Rows(0)("NombreProducto").ToString.Trim
            txtMarcaEdit.Text = dataSet.Tables("productos").Rows(0)("MarcaProducto").ToString.Trim
            txtDescripcionEdit.Text = dataSet.Tables("productos").Rows(0)("DescripcionProducto").ToString.Trim
            txtPrecioEdit.Text = dataSet.Tables("productos").Rows(0)("PrecioProducto").ToString.Trim
            txtStockEdit.Text = dataSet.Tables("productos").Rows(0)("StockProducto").ToString.Trim
            ddlCategoriaEdit.SelectedValue = dataSet.Tables("productos").Rows(0)("CategoriaProducto").ToString.Trim
            ddlEstadoEdit.SelectedValue = IIf(dataSet.Tables("productos").Rows(0)("Estado") = False, 0, 1)
        Else
            lblErrorListadoProductos.Text = "Surgio un Error. Intente más Tarde."
            lblErrorListadoProductos.Visible = True
            salida = False
        End If
        Return salida
    End Function
#End Region
#Region "Limpiar Errores Alta Producto"

    'Funcion para Limpiar y Oculatar el Label que Muestra los Errores de Cada Campo 
    Sub limpiarErroresEditarProducto()
        'Dejamos Vacios todos los campos
        lblErrorNombreProductoEdit.Text = ""
        lblErrorMarcaEdit.Text = ""
        lblErrorDescripcionEdit.Text = ""
        lblErrorPrecioEdit.Text = ""
        lblErrorStockEdit.Text = ""
        lblErrorCategoriaEdit.Text = ""
        lblErroresProductoEdit.Text = ""
        'Ocultamos los Labels de los Errores
        lblErrorNombreProductoEdit.Visible = False
        lblErrorMarcaEdit.Visible = False
        lblErrorDescripcionEdit.Visible = False
        lblErrorPrecioEdit.Visible = False
        lblErrorStockEdit.Visible = False
        lblErrorCategoriaEdit.Visible = False
        lblErroresProductoEdit.Visible = False
    End Sub
#End Region
#Region "Limpiar Campos Editar Productos"
    Sub limpiarCamposEditarProducto()
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresEditarProducto()
        txtNombreProductoEdit.Text = ""
        txtMarcaEdit.Text = ""
        txtDescripcionEdit.Text = ""
        txtPrecioEdit.Text = ""
        txtStockEdit.Text = ""
        ddlCategoriaEdit.SelectedIndex = 0
        ddlEstadoEdit.SelectedIndex = 0
    End Sub
#End Region
#Region "Editar Productos"
    Sub editarProducto()
        Dim ok As Boolean = True
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresEditarProducto()
        'Comprobamos el Nombre
        txtNombreProductoEdit.Text = txtNombreProductoEdit.Text.Trim().ToUpper
        If comprobar(txtNombreProductoEdit.Text) = False Then
            arreglarCampo(txtNombreProductoEdit)
            ok = False
            lblErrorNombreProductoEdit.Text = "El Nombre contenía caracteres inválidos, fueron quitados"
            lblErrorNombreProductoEdit.Visible = True
        End If
        'Comprobamos Marca
        txtMarcaEdit.Text = txtMarcaEdit.Text.Trim().ToUpper
        If comprobar(txtMarcaEdit.Text) = False Then
            arreglarCampo(txtMarcaEdit)
            ok = False
            lblErrorMarcaEdit.Text = "La Marca contenía caracteres inválidos, fueron quitados"
            lblErrorMarcaEdit.Visible = True
        End If
        'Comprobamos la Descripcion
        txtDescripcionEdit.Text = txtDescripcionEdit.Text.Trim().ToUpper
        If comprobar(txtDescripcionEdit.Text) = False Then
            arreglarCampo(txtDescripcionEdit)
            ok = False
            lblErrorDescripcionEdit.Text = "La Descripción contenía caracteres inválidos, fueron quitados"
            lblErrorDescripcionEdit.Visible = True
        End If
        'Comprobamos el Precio
        txtPrecioEdit.Text = txtPrecioEdit.Text.Trim()
        If comprobar(txtPrecioEdit.Text) = False Or Not IsNumeric(txtPrecioEdit.Text) Then
            soloNumeros(txtPrecioEdit)
            ok = False
            lblErrorPrecioEdit.Text = "El Precio no era válido, se ajustó a número "
            lblErrorPrecioEdit.Visible = True
        End If
        'Comprobamos el Stock
        txtStockEdit.Text = txtStockEdit.Text.Trim()
        If comprobar(txtStockEdit.Text) = False Or Not IsNumeric(txtStockEdit.Text) Then
            soloNumeros(txtPrecioEdit)
            ok = False
            lblErrorStockEdit.Text = "El Stock no era válido, se ajustó a número "
            lblErrorStockEdit.Visible = True
        End If
        'Comprobamos la Categoria
        If ddlCategoriaEdit.SelectedValue = "Seleccionar" Then
            ok = False
            lblErrorCategoriaEdit.Text = "Debe Seleccionar una Categoria para el Producto."
            lblErrorCategoriaEdit.Visible = True
        End If
        'Si existen Errores los Mostramos el lblErroresProducto
        If ok = False Then
            lblErroresProductoEdit.Text = "Surgieron Errores por favor Revisalos e Intenta de Nuevo."
            lblErroresProductoEdit.Visible = True
            Exit Sub
        End If
        'Si pasa la Validacion lo Insertanos en la DB
        Dim consulta = "UPDATE Productos SET NombreProducto='" & txtNombreProductoEdit.Text.Trim & "', MarcaProducto='" & txtMarcaEdit.Text.Trim & "' , DescripcionProducto='" & txtDescripcionEdit.Text.Trim & "', PrecioProducto=" & NumSql(txtPrecioEdit.Text.Trim) & ", StockProducto=" & NumSql(txtStockEdit.Text.Trim) & ", CategoriaProducto='" & ddlCategoriaEdit.SelectedValue & "', Estado= " & ddlEstadoEdit.SelectedValue & "WHERE CodigoProducto = " & lblCodigoProducto.Text.Trim
        If SqlAccion(consulta) = False Then
            lblErroresProductoEdit.Text = "Se ha producido un error al querer guardar tus datos."
            lblErroresProductoEdit.Visible = True
            Exit Sub
        End If
        limpiarCamposEditarProducto()
        pnlEditarProducto.Visible = False
        pnlProductoEditado.Visible = True
        lblProductoEditado.Text = lblCodigoProducto.Text
        btnVolverListado.Focus()
    End Sub
#End Region
#Region "Solicitar Pedidos"
    Sub solicitarPedido()
        Dim idUsuario As Integer = Vnum(Session("idUsuario"))
        Dim nPedido As Integer = 0, vItem As String = "", vTipo As String = "", vCantidad As Integer = 0
        Dim linea As String = "", enter As String = Chr(13) & Chr(10)
        Dim insertPedidos As String, insertPedidosDetalle As String, selectPedidosTemporal As String, selectPedidos As String, deletePedidosTemporal As String
        lblErrorPedido.Text = ""
        insertPedidos = "INSERT INTO Pedidos (Num_Cli) VALUES (" & Session("idUsuario") & ")"
        selectPedidos = "SELECT TOP 1 NPedido FROM Pedidos WHERE Num_Cli=" & Session("idUsuario") & " ORDER BY NPedido DESC"
        insertPedidosDetalle = "INSERT INTO Pedidos_Detalle (Item, Cantidad, NPedido) "
        deletePedidosTemporal = "DELETE FROM Pedidos_Temporal WHERE Num_Cli=" & idUsuario
        If SqlAccion(insertPedidos) = True Then
            Dim dataAdapter As New SqlDataAdapter(selectPedidos, con)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "dato")
            If dataSet.Tables("dato").Rows.Count > 0 Then
                nPedido = dataSet.Tables("dato").Rows(0)("NPedido")
                selectPedidosTemporal = "SELECT Pedidos_Temporal.Item, Pedidos_Temporal.Cantidad, " & nPedido & " AS NPedido FROM Pedidos_Temporal WHERE Num_Cli=" & idUsuario

                If SqlAccion(insertPedidosDetalle & selectPedidosTemporal) = True Then
                    lblPedidoCreado.Text = "El Pedido Nº " & nPedido & ", fue Creado Correctamente."
                    Dim dataAdapterMail As New SqlDataAdapter(selectPedidosTemporal, con)
                    Dim dataSetMail As New DataSet
                    Dim mensaje As String
                    dataAdapterMail.Fill(dataSetMail, "mail")
                    For index = 0 To dataSetMail.Tables("mail").Rows.Count - 1
                        mensaje = mensaje & " Producto: " & dataSetMail.Tables("mail").Rows(index)("Item").ToString.Trim & " Cantidad: " & dataSetMail.Tables("mail").Rows(index)("Cantidad").ToString.Trim & enter
                    Next
                    enviarMail(Email, "Ingreso de Pedido", mensaje)
                    pnlNuevoPedidoFabrica.Visible = False
                    pnlPedidoCreado.Visible = True
                    If SqlAccion(deletePedidosTemporal) = True Then
                    End If
                Else
                    lblErrorPedido.Text = "Hubo un Error al intentar Guardar el Detalle del Pedido" & nPedido & ", quedó vacío o con una Carga Parcial. Anúlelo e Intente más Tarde."
                    Exit Sub
                End If
                Exit Sub
            Else
                lblErrorPedido.Text = "Hubo un Error al intentar Guardar el Detalle del Pedido" & nPedido & ", quedó vacío o con una Carga Parcial. Anúlelo e Intente más Tarde."
                Exit Sub
            End If
        Else
            lblErrorPedido.Text = "Hubo un Error al intentar Guardar el Pedido. Intente más Tarde."
        End If
    End Sub
#End Region
#Region "Cargar Historico"
    Sub cargaHistorico()
        lblErrorHistorico.Text = ""
        Dim idUsuario As Integer = Vnum(Session("idUsuario"))
        Dim selectPedidos As String
        selectPedidos = "SELECT NPedido, Fecha, Estado FROM Pedidos WHERE Num_Cli=" & Session("idUsuario") & " AND Estado <>'Enviado' ORDER BY NPedido DESC"
        Dim dataAdapter As New SqlDataAdapter(selectPedidos, con)
        Dim dataSet As New DataSet
        dataAdapter.Fill(dataSet, "historico")
        gwHistorico.DataSource = dataSet.Tables("historico")
        gwHistorico.DataBind()
        If dataSet.Tables("historico").Rows.Count = 0 Then
            lblErrorHistorico.Text = "No hay Pedidos Anteriores o Hubo un Error al Cargarlos. Reintente más Tarde."
            pnlHistorico.Visible = False
        Else
            gwHistorico.Visible = True
        End If
        pnlPedidosFabrica.Visible = False
        pnlHistorico.Visible = True
    End Sub
#End Region
#Region "Anular  Pedido"
    Sub anularPedido(ByVal nPedido As String)
        Dim selectPedido As String = "SELECT * FROM Pedidos WHERE LTRIM(RTRIM(NPedido))=" & nPedido
        Dim updatePedido As String = "UPDATE Pedidos SET Estado='Anulado' WHERE LTRIM(RTRIM(NPedido))='" & nPedido & "'"
        Dim dataAdapter As New SqlDataAdapter(selectPedido, con)
        Dim dataSet As New DataSet
        lblErrorHistorico.Text = ""
        'Traemos los datos
        dataAdapter.Fill(dataSet, "hitorico")
        If dataSet.Tables("hitorico").Rows.Count = 0 Then
            lblErrorHistorico.Text = "No puedo acceder al Pedido Nº: " & nPedido & ". Reintente mas Tarde."
            Exit Sub
        Else
            Dim estado As String = dataSet.Tables("hitorico")(0)("Estado").ToString.Trim
            If estado <> "Solicitado" Then
                If estado = "Anulado" Then
                    lblErrorHistorico.Text = "El Pedido Nº: " & nPedido & ". Ya estaba Anulado."
                    lblErrorHistorico.Visible = True
                    Exit Sub
                Else
                    lblErrorHistorico.Text = "El Pedido tiene Estado: " & estado & " y ya no puede Anularse por Web (sólo Solicitado). Llame a la Fabrica por favor."
                    lblErrorHistorico.Visible = True
                    Exit Sub
                End If
            Else
                If SqlAccion(updatePedido) = False Then
                    lblErrorHistorico.Text = "No he Podido Cambiar el Estado,hubo algún Error de Conexión. Por Favor, Reintente más Tarde o llame a la Fabrica para Avisar la Anulación."
                    lblErrorHistorico.Visible = True
                    Exit Sub
                Else
                    lblErrorHistorico.Text = "El Pedido Nº: " & nPedido & "fue Anulado."
                    lblErrorHistorico.Visible = True
                    cargaHistorico()
                    Exit Sub
                End If
            End If
        End If
    End Sub
#End Region
#Region "Mostrar los Detalle del Pedido"
    Sub mostrarDetallePedido(ByVal nPedido As String)
        Dim consulta As String = "SELECT * FROM Pedidos_Detalle WHERE LTRIM(RTRIM(NPedido))=" & nPedido & " ORDER BY Item"
        Dim dataAdapter As New SqlDataAdapter(consulta, con)
        Dim dataSet As New DataSet
        lblNroPedido.Text = nPedido
        'Traemos los datos
        dataAdapter.Fill(dataSet, "detalle")
        gwVerUnPedido.DataSource = dataSet.Tables("detalle")
        gwVerUnPedido.DataBind()
        If dataSet.Tables("detalle").Rows.Count = 0 Then
            lblErrorVerUnPedido.Text = "Hubo un Error al Cargar los Items del Pedido : " & nPedido & ", porque no se leyó ninguno.Intente más Tarde."
            lblErrorVerUnPedido.Visible = True
            gwVerUnPedido.Visible = False
        Else
            gwVerUnPedido.Visible = True
        End If
    End Sub
#End Region
#Region "Acciones Botones GridView Historico"
    Sub accionBotonesgwHistorico(ByVal e As GridViewCommandEventArgs)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gwHistorico.Rows(index)
        Dim nPedido As String = Vnum(row.Cells(2).Text)
        Select Case e.CommandName
            Case "Anular"
                If MsgBox("¿Está seguro de Anular este Pedido?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    anularPedido(nPedido)
                End If
            Case "Ver"
                mostrarDetallePedido(nPedido)
                pnlHistorico.Visible = False
                pnlVerUnPedido.Visible = True
            Case Else
                lblErrorHistorico.Text = "No se Pudeo Ejecutar la Accion Elegida."
                lblErrorHistorico.Visible = True
        End Select

    End Sub
#End Region
#Region "Cargar Pedidos Clientes"
    Sub cargaPedidosClientes()
        lblErrorPedidosClientes.Text = ""
        txtNumeroCliente.Text = txtNumeroCliente.Text.Trim()
        soloNumeros(txtNumeroCliente)
        Dim filtro As String
        If txtNumeroCliente.Text <> "" Then
            filtro = " WHERE Num_Cli=" & txtNumeroCliente.Text
        End If
        Dim selectPedidos As String
        selectPedidos = "SELECT Num_Cli, NPedido, Fecha, Estado FROM Pedidos" & filtro & " ORDER BY Num_Cli"
        Dim dataAdapter As New SqlDataAdapter(selectPedidos, con)
        Dim dataSet As New DataSet
        dataAdapter.Fill(dataSet, "pedidos")
        gvPedidosClientes.DataSource = dataSet.Tables("pedidos")
        gvPedidosClientes.DataBind()
        If dataSet.Tables("pedidos").Rows.Count = 0 Then
            lblErrorPedidosClientes.Text = "No hay Pedidos de Clientes o Hubo un Error al Cargarlos. Reintente más Tarde."
            lblErrorPedidosClientes.Visible = True
            gvPedidosClientes.Visible = False
        Else
            gvPedidosClientes.Visible = True
        End If
    End Sub
#End Region
#Region "Mostrar los Detalle del Pedido Cliente"
    Sub mostrarDetallePedidoCliente(ByVal nPedido As String, ByVal nCliente As String)
        Dim consulta As String = "SELECT * FROM Pedidos_Detalle WHERE LTRIM(RTRIM(NPedido))=" & nPedido & " ORDER BY Item"
        Dim dataAdapter As New SqlDataAdapter(consulta, con)
        Dim dataSet As New DataSet
        lblNroPedidoCliente.Text = nPedido
        lblNroCliente.Text = nCliente
        'Traemos los datos
        dataAdapter.Fill(dataSet, "detalle")
        gvDetallePedidoCliente.DataSource = dataSet.Tables("detalle")
        gvDetallePedidoCliente.DataBind()
        If dataSet.Tables("detalle").Rows.Count = 0 Then
            lblErrorDpedidoCliente.Text = "Hubo un Error al Cargar los Items del Pedido : " & nPedido & ", porque no se leyó ninguno.Intente más Tarde."
            lblErrorDpedidoCliente.Visible = True
            gvDetallePedidoCliente.Visible = False
        Else
            gvDetallePedidoCliente.Visible = True
        End If
    End Sub
#End Region
#Region "Anular  Pedido Cliente"
    Sub anularPedidoCliente(ByVal nPedido As String)
        Dim selectPedido As String = "SELECT * FROM Pedidos WHERE LTRIM(RTRIM(NPedido))=" & nPedido
        Dim updatePedido As String = "UPDATE Pedidos SET Estado='Anulado' WHERE LTRIM(RTRIM(NPedido))='" & nPedido & "'"
        Dim dataAdapter As New SqlDataAdapter(selectPedido, con)
        Dim dataSet As New DataSet
        lblErrorPedidosClientes.Text = ""
        'Traemos los datos
        dataAdapter.Fill(dataSet, "hitorico")
        If dataSet.Tables("hitorico").Rows.Count = 0 Then
            lblErrorPedidosClientes.Text = "No puedo acceder al Pedido Nº: " & nPedido & ". Reintente mas Tarde."
            Exit Sub
        Else
            Dim estado As String = dataSet.Tables("hitorico")(0)("Estado").ToString.Trim
            If estado <> "Solicitado" Then
                If estado = "Anulado" Then
                    lblErrorPedidosClientes.Text = "El Pedido Nº: " & nPedido & ". Ya estaba Anulado."
                    lblErrorPedidosClientes.Visible = True
                    Exit Sub
                Else
                    lblErrorPedidosClientes.Text = "El Pedido tiene Estado: " & estado & " y ya no puede Anularse por Web (sólo Solicitado). Llame a la Fabrica por favor."
                    lblErrorPedidosClientes.Visible = True
                    Exit Sub
                End If
            Else
                If SqlAccion(updatePedido) = False Then
                    lblErrorPedidosClientes.Text = "No he Podido Cambiar el Estado,hubo algún Error de Conexión. Por Favor, Reintente más Tarde."
                    lblErrorPedidosClientes.Visible = True
                    Exit Sub
                Else
                    lblErrorPedidosClientes.Text = "El Pedido Nº: " & nPedido & "fue Anulado."
                    lblErrorPedidosClientes.Visible = True
                    cargaPedidosClientes()
                    Exit Sub
                End If
            End If
        End If
    End Sub
#End Region
#Region "Acciones Botones GridView Pedidos Clientes"
    Sub accionBotonesgvPedidosClientes(ByVal e As GridViewCommandEventArgs)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gvPedidosClientes.Rows(index)
        Dim nPedido As String = Vnum(row.Cells(0).Text)
        Dim nCliente As String = Vnum(row.Cells(1).Text)
        Select Case e.CommandName
            Case "Anular"
                If MsgBox("¿Está seguro de Anular este Pedido?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    anularPedidoCliente(nPedido)
                End If
            Case "VerEditar"
                mostrarDetallePedidoCliente(nPedido, nCliente)
                pnlAbmPedidosFabrica.Visible = False
                pnlDetallePedidoCliente.Visible = True
            Case Else
                lblErrorPedidosClientes.Text = "No se Pudeo Ejecutar la Accion Elegida."
                lblErrorPedidosClientes.Visible = True
        End Select

    End Sub
#End Region
#Region "Eliminar Item de la Lista de Pedidos Detalle Cliente"
    Sub quitarItemCliente(ByVal e As GridViewCommandEventArgs)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gvDetallePedidoCliente.Rows(index)
        Dim item As String = row.Cells(0).Text, enter As String = Chr(13) & Chr(10)
        Dim nPedido As Integer = Vnum(lblNroPedidoCliente.Text.Trim)
        Dim nCliente As Integer = Vnum(lblNroCliente.Text.Trim)
        Dim selectUsuarioPedido = "SELECT EMail FROM Usuarios WHERE idUsuario = " & nCliente
        Dim dataAdapterMail As New SqlDataAdapter(selectUsuarioPedido, con)
        Dim dataSetMail As New DataSet
        dataAdapterMail.Fill(dataSetMail, "mail")
        Dim mail As String = dataSetMail.Tables("mail").Rows(0)("EMail").ToString.Trim()
        Dim mensaje As String = "El Administrador ha Quitado " & item & " de tu Lista de Pedido."
        dataAdapterMail.Fill(dataSetMail, "mail")
        Dim consulta As String = "DELETE Pedidos_Detalle WHERE LTRIM(RTRIM(Item)) ='" & item & "' AND NPedido =" & nPedido
        lblErrorDpedidoCliente.Text = ""
        If (e.CommandName = "Quitar") Then
            If SqlAccion(consulta) = False Then
                lblErrorDpedidoCliente.Text = "No se Pudo Quitar el Item de la Lista. Intente más Tarde."
                Exit Sub
            End If
            enviarMail(mail, "Item Eliminado", mensaje)
            mostrarDetallePedidoCliente(nPedido, nCliente)
        End If
    End Sub
#End Region
#Region "Envio de Emails"
    Function enviarMail(ByVal emailDestino As String, ByVal subjet As String, ByVal mensaje As String) As String
        'Devuelve OK si se envio el mail caso contrario Devuelve el error.
        Dim resultado As String = "OK"
        Dim smtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        Try
            mail = New MailMessage()
            mail.From = New MailAddress(Email, "")
            mail.To.Add(emailDestino)
            mail.Subject = subjet
            mail.Body = mensaje
            mail.IsBodyHtml = False
            mail.Priority = MailPriority.Normal
            If EmailActivo = "EmailGmail" Then
                smtpServer.Credentials = New Net.NetworkCredential(Email, EmailPass)
                smtpServer.Host = "smtp.gmail.com"
                smtpServer.Port = 587
                smtpServer.EnableSsl = True
            Else
                'Para EmailDonWeb
                'smtpServer.Host = "localhost"
                smtpServer.Credentials = New Net.NetworkCredential(Email, EmailPass)
                smtpServer.Host = "dtcwin033.ferozo.com"
                smtpServer.Port = 467
                smtpServer.EnableSsl = True
            End If
            smtpServer.Send(mail)
        Catch
            resultado = Err.Description
        End Try
        mail.Dispose()
        Return resultado
    End Function
#End Region
#Region "Recuperacion de Contraseña"
    Sub recuperarClave()
        Dim usuario As String = txtUsuario.Text.Trim.ToUpper, emailEnviar As String, usuarioEnviar As String, mensaje As String, claveEnviar As String
        Dim enter As String = Chr(13) & Chr(10)
        If comprobar(usuario) = False Then
            lblReenviarClave.Text = "**** El Usuario es Incorrecto Revisá Por Favor."
            lblReenviarClave.Visible = True
            Exit Sub
        End If
        Dim selectUsuario As String = "SELECT LTRIM(RTRIM(Nombre))+ ' ' + LTRIM(RTRIM(Apellido)) AS nombre_apellido, Clave, Email FROM Usuarios WHERE UPPER(LTRIM(RTRIM(Usuario)))='" & usuario & "'"
        Dim dataAdapter As New SqlDataAdapter(selectUsuario, con)
        Dim dataSet As New DataSet
        'Traemos los datos
        dataAdapter.Fill(dataSet, "recuperar")
        If dataSet.Tables("recuperar").Rows.Count = 0 Then
            lblReenviarClave.Text = "**** El Usuario es Incorrecto Revisá Por Favor."
            lblReenviarClave.Visible = True
            Exit Sub
        End If
        emailEnviar = dataSet.Tables("recuperar").Rows(0)("Email").ToString.Trim.ToLower
        claveEnviar = dataSet.Tables("recuperar").Rows(0)("Clave").ToString.Trim
        usuarioEnviar = dataSet.Tables("recuperar").Rows(0)("nombre_apellido").ToString.Trim
        mensaje = "Hola " & usuarioEnviar & "," & enter & "Te escribimos desde , respondiendo a tu pedido de Recuperación de Clave" & enter & enter & "Su Usuario es: " & usuario & enter & "Su Clave es: " & claveEnviar & enter & enter & "Ya podes volver a Entrar y Armar tus Pedidos" & enter & "Saludos desde " & enter & enter & enter & enter & "(Por Favor no Responda esté Email, es automático. Gracias.)" & enter & enter
        Dim ok As String = enviarMail(emailEnviar, ", Recuperación de Clave", mensaje)
        If ok = "OK" Then
            lblReenviarClave.Text = "**** Te Eviamos un Email Por Tu Clave."
        Else
            lblReenviarClave.Text = "**** Hubo un Error al Enviar el Email."
        End If
        lblReenviarClave.Visible = True
    End Sub

#End Region
#Region "Cargar Usuarios"
    Sub cargaUsuarios()
        lblTipoUsuarios.Text = Session("tipoUsuarioAbm")
        lblErrorAbmUsuarios.Text = ""
        txtUsuarioFiltrar.Text = txtUsuarioFiltrar.Text.Trim()
        arreglarCampo(txtUsuarioFiltrar)
        Dim filtro As String
        If txtUsuarioFiltrar.Text <> "" Then
            filtro = " WHERE Usuario LIKE '%" & txtUsuarioFiltrar.Text & "%' "
        End If
        Dim selectUsuarios As String
        selectUsuarios = "SELECT LTRIM(RTRIM(Usuario)) AS Usuario, LTRIM(RTRIM(EMail)) AS EMail, LTRIM(RTRIM(Nombre))+ ' ' + LTRIM(RTRIM(Apellido)) AS NombreApellido, (CASE WHEN Activo=1 THEN 'Activo' ELSE 'Inactivo' END) AS Activo FROM " & Session("tipoUsuarioAbm") & filtro & " ORDER BY Usuario"
        Dim dataAdapter As New SqlDataAdapter(selectUsuarios, con)
        Dim dataSet As New DataSet
        dataAdapter.Fill(dataSet, "usuarios")
        gvAbmUsuarios.DataSource = dataSet.Tables("usuarios")
        gvAbmUsuarios.DataBind()
        If Session("tipoUsuarioAbm") = "Administradores" Then
            gvAbmUsuarios.Columns(6).Visible = False
        Else
            gvAbmUsuarios.Columns(6).Visible = True
        End If
        If dataSet.Tables("usuarios").Rows.Count = 0 Then
            lblErrorAbmUsuarios.Text = "No hay Usuarios o Hubo un Error al Cargarlos. Reintente más Tarde."
            lblErrorAbmUsuarios.Visible = True
            gvAbmUsuarios.Visible = False
        Else
            gvAbmUsuarios.Visible = True
        End If
    End Sub
#End Region
#Region "Accion Botones gvAbmUsuarios"
    Sub accionBotenesgvAbmUsuarios(ByVal e As GridViewCommandEventArgs)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = gvAbmUsuarios.Rows(index)
        lblUsuarioAccion.Text = row.Cells(0).Text
        lblEmailAccion.Text = row.Cells(1).Text
        Select Case e.CommandName
            Case "Eliminar"
                If MsgBox("¿Está seguro de eliminar este Usuario?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    lblAccionMotivo.Text = "Eliminar"
                End If
            Case "Desactivar"
                If MsgBox("¿Está seguro de Desactivar este Usuario?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    lblAccionMotivo.Text = "Desactivar"
                End If
            Case "Admin"
                If MsgBox("¿Está seguro dar Permiso de Administrador al Usuario?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If YaExisteSql("Select idAdmin FROM Administradores WHERE Email='" & lblEmailAccion.Text & "'") Then
                        lblErrorAbmUsuarios.Text = "El Usuario ya es Administrador."
                        lblErrorAbmUsuarios.Visible = True
                        Exit Sub
                    End If
                    If YaExisteSql("SELECT idAdmin FROM Administradores WHERE Usuario='" & lblUsuarioAccion.Text & "'") Then
                        lblErrorAbmUsuarios.Text = "El Usuario ya es Administrador."
                        lblErrorAbmUsuarios.Visible = True
                        Exit Sub
                    End If
                    lblAccionMotivo.Text = "Admin"
                End If
            Case Else
                lblErrorAbmUsuarios.Text = "No se Pudeo Ejecutar la Accion Elegida."
                lblErrorAbmUsuarios.Visible = True
        End Select
        pnlAbmUsuarios.Visible = False
        pnlMotivo.Visible = True
    End Sub
#End Region
#Region "Acciones Motivos ABM Usuarios"
    Sub accionMotivoAbmUsuarios()
        Dim accion As String = lblAccionMotivo.Text.Trim
        Dim usuario As String = lblUsuarioAccion.Text.Trim
        Dim email As String = lblEmailAccion.Text.ToLower.Trim
        Dim mensaje As String = txtMotivo.Text
        Dim queryEliminar As String = "DELETE " & Session("tipoUsuarioAbm") & " WHERE LTRIM(RTRIM(Usuario)) ='" & usuario & "'"
        Dim queryDesactivar As String = "UPDATE " & Session("tipoUsuarioAbm") & " SET Activo = 0 WHERE LTRIM(RTRIM(Usuario)) ='" & usuario & "'"
        Dim queryInsertAdmin As String = "INSERT INTO Administradores (Apellido, Nombre, tDoc , Documento, Usuario, Clave, Email, idProv , Localidad,Domicilio, Telefono, fNacimiento)"
        Dim querySelectUsuario As String = "SELECT Apellido, Nombre, tDoc , Documento, Usuario, Clave, Email, idProv , Localidad,Domicilio, Telefono, fNacimiento FROM Usuarios WHERE LTRIM(RTRIM(Usuario)) ='" & usuario & "'"
        If comprobar(txtMotivo.Text) = False Then
            arreglarCampo(txtMotivo)
            lblErrorMotivo.Text = "El Motivo contenía caracteres inválidos, fueron quitados"
            lblErrorMotivo.Visible = True
            Exit Sub
        End If
        Select Case accion
            Case "Eliminar"
                If SqlAccion(queryEliminar) = False Then
                    lblErroresProductoEdit.Text = "Se ha producido un error al querer guardar tus datos."
                    lblErroresProductoEdit.Visible = True
                    Exit Sub
                End If
                enviarMail(email, ", Usuario Eliminado", mensaje)
            Case "Desactivar"
                If SqlAccion(queryDesactivar) = False Then
                    lblErrorMotivo.Text = "Se ha producido un error al querer guardar tus datos."
                    lblErrorMotivo.Visible = True
                    Exit Sub
                End If
            Case "Admin"

                If SqlAccion(queryInsertAdmin & querySelectUsuario) = False Then
                    lblErrorMotivo.Text = "Se ha producido un error al querer guardar tus datos."
                    lblErrorMotivo.Visible = True
                    Exit Sub
                End If
                enviarMail(email, ", Usuario Administrador", mensaje)
        End Select
        pnlMotivo.Visible = False
        pnlAbmUsuariosMenu.Visible = True
    End Sub
#End Region
#Region "Generar Codigo Validar Email"
    Public Function crearCodigo(ByVal cantCaracteres As Integer) As String
        'Crear un código de tantos carteres como cantidad de caracteres le pasamenos, mezclando números y letras mayusculas
        Dim strRand As String = Nothing, r As New Random, c As String, i As Integer
        For index = 0 To cantCaracteres - 1
            If Math.Round(r.Next(0, 2)) = 0 Then
                c = Chr(Math.Round(r.Next(48, 58)))
            Else
                c = Chr(Math.Round(r.Next(65, 91)))
            End If
            strRand &= c
        Next
        Return strRand
    End Function
#End Region
#Region "Validar Email y Terminar Registro"
    Sub validarCodigo()
        Dim sqlIngreso As String = Session("sqlIngreso") & " "
        If sqlIngreso.Length < 10 Or sqlIngreso.IndexOf("INSERT") < 0 Then
            lblErroresU.Text = "Hubo un error con el Código. Por Favor, trate de generar un nuevo código."
            Exit Sub
            lblErroresU.Visible = True
            pnlValidarMail.Visible = False
            pnlRegistrarse.Visible = True
        End If
        If txtValidar.Text.Trim.ToUpper <> Session("codigo") Then
            lblErrorCodidoValidar.Visible = True
            Exit Sub
        End If
        'Si pasa la Validacion lo Insertanos en la DB
        If SqlAccion(sqlIngreso) = False Then
            lblErroresU.Text = "Hubo un error al tratar de validar el Código. Por Favor, trate de generar un nuevo código."
            lblErroresU.Visible = True
            Exit Sub
        End If
        Session("idUsuario") = Vnum(LeeUnCampo("SELECT TOP 1 idUsuario FROM usuarios WHERE Usuario='" & Session("Usuario") & "'and Clave='" & Session("Password") & "' ", "idUsuario"))

        Dim mensaje As String, xusuario As String = Session("ApellidoYNombre"), en As String = Chr(13) & Chr(10)
        mensaje = "Bienvenido " & xusuario & " a , Equipamientos Informaticos." & en & en & "Te damos una cordial Bienvenida a ." & en & en & "Tu usuario es " & " " & Session("Usuario") & " " & en & en & "Tu clave es " & " " & Session("Password") & " " & en & en & "Ya podés loguearte para ver tus datos! !." & en & en

        Dim okEnviarMail As String = enviarMail(Session("Email"), ", Registro de Usuario", mensaje)
        If okEnviarMail = "OK" Then
            lblBienvenido.Text = "Bienvenido " & Session("ApellidoYNombre") & "!!!" & en & en & "Te Eviamos un Email con Todos tus Datos."
        Else
            lblBienvenido.Text = "Bienvenido " & Session("ApellidoYNombre") & "!!!" & en & en & "Hubo un Error al Enviar el Email con Tus Datos de Usuario."
        End If

        lblBienvenido.Visible = True
        limpiarCamposRegistroU()
        pnlValidarMail.Visible = False
        pnlBienvenido.Visible = True
        btnRegistrarseVolverLoginU.Focus()
    End Sub
#End Region
    Protected Sub btnEntrar_Click(sender As Object, e As ImageClickEventArgs) Handles btnEntrar.Click
        Session("QueEs") = "Usuarios"
        Loguea()
    End Sub

    Protected Sub btnAhoraQueHago_Click(sender As Object, e As ImageClickEventArgs) Handles btnAhoraQueHago.Click
        pnlAreaUsuario.Visible = False
        pnlAhoraQueHago.Visible = True
    End Sub
    Protected Sub btnVolverLoginU1_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverLoginU1.Click
        limpiarLogin()
        limpiarCamposRegistroU()
        lblReenviarClave.Text = "" : lblReenviarClave.Visible = False
        pnlLogin.Visible = True
        pnlAreaUsuario.Visible = False
        txtUsuario.Text = Session("Usuario")
        txtClave.Text = Session("Password")
    End Sub

    Protected Sub btnVolverU2_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverU2.Click
        pnlAhoraQueHago.Visible = False
        pnlAreaUsuario.Visible = True
    End Sub
    Protected Sub btnModificarDatos_Click(sender As Object, e As ImageClickEventArgs) Handles btnModificarDatos.Click
        mostrarDatosPersonales()
        pnlAreaUsuario.Visible = False
        pnlCambiarDatosPersonales.Visible = True
    End Sub

    Protected Sub btnCancelarVolverEdit_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarVolverEdit.Click
        pnlAreaUsuario.Visible = True
        pnlCambiarDatosPersonales.Visible = False
    End Sub
    Protected Sub btnCambiarDatos_Click(sender As Object, e As ImageClickEventArgs) Handles btnCambiarDatos.Click
        editarDatosPersonales()
    End Sub

    Protected Sub btnVolverAreaUsuario_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverAreaUsuario.Click
        pnlDatosModificadosOk.Visible = False
        pnlAreaUsuario.Visible = True
    End Sub

    Protected Sub btnHcerPedidoFabrica_Click(sender As Object, e As ImageClickEventArgs) Handles btnHacerPedidoFabrica.Click
        pnlAreaUsuario.Visible = False
        pnlPedidosFabrica.Visible = True
    End Sub

    Protected Sub btnTerminarVolverPedido_Click(sender As Object, e As ImageClickEventArgs) Handles btnTerminarVolverPedido.Click
        pnlAreaUsuario.Visible = True
        pnlPedidosFabrica.Visible = False
    End Sub

    Protected Sub btnNuevoPedido_Click(sender As Object, e As ImageClickEventArgs) Handles btnNuevoPedido.Click
        nuevoPedidoBtnAccion()
        pnlNuevoPedidoFabrica.Visible = True
        pnlPedidosFabrica.Visible = False
    End Sub

    Protected Sub btnTerminarHistorico_Click(sender As Object, e As ImageClickEventArgs) Handles btnTerminarHistorico.Click
        pnlHistorico.Visible = False
        pnlPedidosFabrica.Visible = True
    End Sub

    Protected Sub btnTerminarVerUnPedido_Click(sender As Object, e As ImageClickEventArgs) Handles btnTerminarVerUnPedido.Click
        pnlVerUnPedido.Visible = False
        pnlHistorico.Visible = True
    End Sub

    Protected Sub btnCancelarPedido_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarPedido.Click
        If borrarPedidosTemporal() = False Then
        End If
        pnlNuevoPedidoFabrica.Visible = False
        pnlPedidosFabrica.Visible = True
    End Sub

    Protected Sub btnTodosLosPedidos_Click(sender As Object, e As ImageClickEventArgs) Handles btnTodosLosPedidos.Click
        pnlPedidosFabrica.Visible = False
        pnlHistorico.Visible = True
        cargaHistorico()
    End Sub

    Protected Sub btnEntrarAdmin_Click(sender As Object, e As ImageClickEventArgs) Handles btnEntrarAdmin.Click
        Session("QueEs") = "Administradores"
        Loguea()
    End Sub

    Protected Sub btnInstrucciones_Click(sender As Object, e As EventArgs) Handles btnInstrucciones.Click
        If btnInstrucciones.Text = "Abrir Instrucciones" Then
            btnInstrucciones.Text = "Cerrar Instrucciones"
            lblInstrucciones.Visible = True
        Else
            btnInstrucciones.Text = "Abrir Instrucciones"
            lblInstrucciones.Visible = False
        End If
    End Sub

    Protected Sub ddlProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProducto.SelectedIndexChanged
        lblCosaAgregar.Text = ddlProducto.SelectedItem.ToString
        lblQueEs.Text = "Equipos Informaticos"
    End Sub

    Protected Sub btnAgregarAlista_Click(sender As Object, e As ImageClickEventArgs) Handles btnAgregarAlista.Click
        agregarListaPedidosTemporal()
    End Sub
    Protected Sub gwListaPedido_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gwListaPedido.RowCommand
        quitarItem(e)
    End Sub

    Protected Sub btnQuitarTodos_Click(sender As Object, e As ImageClickEventArgs) Handles btnQuitarTodos.Click
        If borrarPedidosTemporal() = False Then
            lblErrorPedido.Text = "No se Pudo Quitar a Todos los Items de la Lista. Intente más Tarde."
            Exit Sub
        End If
        cargarTemporal()
    End Sub

    Protected Sub btnNuevoProducto_Click(sender As Object, e As ImageClickEventArgs) Handles btnNuevoProducto.Click
        pnlAbmProductos.Visible = False
        pnlAltaProductos.Visible = True
    End Sub

    Protected Sub bntTerminarMenuProductos_Click(sender As Object, e As ImageClickEventArgs) Handles bntTerminarMenuProductos.Click
        pnlAbmProductos.Visible = False
        pnlAreaUsuario.Visible = True
    End Sub

    Protected Sub btnCancelarAgregarProducto_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarAgregarProducto.Click
        limpiarCamposAltaProducto()
        limpiarErroresAltaProducto()
        pnlAltaProductos.Visible = False
        pnlAbmProductos.Visible = True
    End Sub

    Protected Sub btnAbmProductos_Click(sender As Object, e As ImageClickEventArgs) Handles btnAbmProductos.Click
        pnlAreaUsuario.Visible = False
        pnlAbmProductos.Visible = True
    End Sub
    Protected Sub btnTerminarVolverCreado_Click(sender As Object, e As ImageClickEventArgs) Handles btnTerminarVolverCreado.Click
        pnlPedidoCreado.Visible = False
        pnlPedidosFabrica.Visible = True
    End Sub

    Protected Sub btnVolverAltaProducto_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverAltaProducto.Click
        pnlProductoCreado.Visible = False
        pnlAltaProductos.Visible = True
    End Sub

    Protected Sub btnAgregarProducto_Click(sender As Object, e As ImageClickEventArgs) Handles btnAgregarProducto.Click
        altaProducto()
    End Sub

    Protected Sub btnTodosLosProductos_Click(sender As Object, e As ImageClickEventArgs) Handles btnTodosLosProductos.Click
        pnlAbmProductos.Visible = False
        pnlListadoProductos.Visible = True
        listarProductos()
    End Sub

    Protected Sub btnVolverAbmProducto_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverAbmProducto.Click
        pnlListadoProductos.Visible = False
        pnlAbmProductos.Visible = True
    End Sub

    Protected Sub gvListadoProductos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvListadoProductos.RowCommand
        accionBotonesgvListadoProductos(e)
    End Sub

    Protected Sub btnCancelarEditarProducto_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarEditarProducto.Click
        pnlEditarProducto.Visible = False
        pnlListadoProductos.Visible = True
    End Sub

    Protected Sub btnEditarProducto_Click(sender As Object, e As ImageClickEventArgs) Handles btnEditarProducto.Click
        editarProducto()
    End Sub

    Protected Sub btnVolverListado_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverListado.Click
        pnlProductoEditado.Visible = False
        listarProductos()
        pnlListadoProductos.Visible = True
    End Sub

    Protected Sub btnSolicitarPedido_Click(sender As Object, e As ImageClickEventArgs) Handles btnSolicitarPedido.Click
        solicitarPedido()
    End Sub

    Protected Sub gwHistorico_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gwHistorico.RowCommand
        accionBotonesgwHistorico(e)
    End Sub

    Protected Sub btnActulizarHistorico_Click(sender As Object, e As ImageClickEventArgs) Handles btnActulizarHistorico.Click
        cargaHistorico()
    End Sub

    Protected Sub btnVolverAbmPedidosClientes_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverAbmPedidosClientes.Click
        pnlAbmPedidosFabrica.Visible = False
        pnlAreaUsuario.Visible = True
    End Sub

    Protected Sub btnAbmPedidoFabrica_Click(sender As Object, e As ImageClickEventArgs) Handles btnAbmPedidoFabrica.Click
        cargaPedidosClientes()
        pnlAbmPedidosFabrica.Visible = True
        pnlAreaUsuario.Visible = False
    End Sub

    Protected Sub btnActualizarPedidosClientes_Click(sender As Object, e As ImageClickEventArgs) Handles btnActualizarPedidosClientes.Click
        cargaPedidosClientes()
    End Sub

    Protected Sub btnFiltrarCliente_Click(sender As Object, e As ImageClickEventArgs) Handles btnFiltrarCliente.Click
        cargaPedidosClientes()
    End Sub

    Protected Sub gvPedidosClientes_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvPedidosClientes.RowCommand
        accionBotonesgvPedidosClientes(e)
    End Sub

    Protected Sub btnTerminarVolverAbmFabrica_Click(sender As Object, e As ImageClickEventArgs) Handles btnTerminarVolverAbmFabrica.Click
        cargaPedidosClientes()
        pnlAbmPedidosFabrica.Visible = True
        pnlDetallePedidoCliente.Visible = False
    End Sub

    Protected Sub gvDetallePedidoCliente_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDetallePedidoCliente.RowCommand
        quitarItemCliente(e)
    End Sub

    Protected Sub btnTerminarAbmUsuarios_Click(sender As Object, e As ImageClickEventArgs) Handles btnTerminarAbmUsuarios.Click
        pnlAbmUsuarios.Visible = False
        pnlAbmUsuariosMenu.Visible = True
    End Sub

    Protected Sub btnAbmUsuarios_Click(sender As Object, e As ImageClickEventArgs) Handles btnAbmUsuariosMenu.Click
        pnlAreaUsuario.Visible = False
        pnlAbmUsuariosMenu.Visible = True
    End Sub

    Protected Sub btnFiltrarUsuario_Click(sender As Object, e As ImageClickEventArgs) Handles btnFiltrarUsuario.Click
        cargaUsuarios()
    End Sub

    Protected Sub btnActulizarAbmUsuarios_Click(sender As Object, e As ImageClickEventArgs) Handles btnActulizarAbmUsuarios.Click
        cargaUsuarios()
    End Sub

    Protected Sub gvAbmUsuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAbmUsuarios.RowCommand
        accionBotenesgvAbmUsuarios(e)
    End Sub

    Protected Sub btnCancelarAbmUsuarios_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarAbmUsuarios.Click
        pnlMotivo.Visible = False
        pnlAbmUsuarios.Visible = True
        cargaUsuarios()
    End Sub

    Protected Sub btnConfirmarAbmUsuarios_Click(sender As Object, e As ImageClickEventArgs) Handles btnConfirmarAbmUsuarios.Click
        accionMotivoAbmUsuarios()
    End Sub

    Protected Sub btnValidarCodigo_Click(sender As Object, e As EventArgs) Handles btnValidarCodigo.Click
        validarCodigo()
    End Sub

    Protected Sub btnRegresarRegistro_Click(sender As Object, e As EventArgs) Handles btnRegresarRegistro.Click
        pnlValidarMail.Visible = False
        txtValidar.Text = ""
        pnlRegistrarse.Visible = True
    End Sub

    Protected Sub btnCancelarRegistro_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarRegistro.Click
        pnlValidarMail.Visible = False
        txtValidar.Text = ""
        pnlRegistrarse.Visible = True
    End Sub

    Protected Sub bntTerminarMenuUsuarios_Click(sender As Object, e As ImageClickEventArgs) Handles bntTerminarMenuUsuarios.Click
        pnlAbmUsuariosMenu.Visible = False
        pnlAreaUsuario.Visible = True
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles btnAbmUsuarios.Click
        Session("tipoUsuarioAbm") = "Usuarios"
        cargaUsuarios()
        pnlAbmUsuariosMenu.Visible = False
        pnlAbmUsuarios.Visible = True
    End Sub

    Protected Sub btnAbmUsuariosAdmin_Click(sender As Object, e As ImageClickEventArgs) Handles btnAbmUsuariosAdmin.Click
        Session("tipoUsuarioAbm") = "Administradores"
        cargaUsuarios()
        pnlAbmUsuariosMenu.Visible = False
        pnlAbmUsuarios.Visible = True
    End Sub
End Class