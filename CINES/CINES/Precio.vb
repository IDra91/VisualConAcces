Imports System.Data
Imports System.Data.OleDb

Public Class Precio
    Dim conexion As New OleDbConnection
    Dim comando As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet
    Private Sub PrecioBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles PrecioBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.PrecioBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BasedatosDataSet)

    End Sub

    Private Sub Precio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasedatosDataSet.precio' Puede moverla o quitarla según sea necesario.
        Me.PrecioTableAdapter.Fill(Me.BasedatosDataSet.precio)
        Try
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\manuel\documents\visual studio 2013\Projects\CINES\CINES\basedatos.accdb"
            conexion.Open()
            MsgBox("Conexión disponible")
        Catch ex As Exception
            MsgBox("Error de conexión")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            comando = New OleDbCommand("INSERT INTO precio (nombre, valor) VALUES (TxtNombre, TxtValor)", conexion)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@valor", TxtValor.Text)
            comando.ExecuteNonQuery()
            MsgBox("Se han insertado los datos correctamente :D", vbInformation, "Correcto")
            Me.PrecioTableAdapter.Fill(Me.BasedatosDataSet.precio)

        Catch ex As Exception
            MsgBox("Error al guardar", vbCritical, "Error")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim actualizar As String
        actualizar = "UPDATE precio SET nombre = '" & TxtNombre.Text & "', valor = " & TxtValor.Text & " WHERE codigo = " & TxtCodigo.Text & ""
        comando = New OleDbCommand(actualizar, conexion)
        comando.ExecuteNonQuery()
        Me.LimpiarTodo()

        MsgBox("Datos actualizados correctamente :D", vbInformation, "Correcto")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim consulta As String
        Dim lista As Byte
        If TxtCodigo.Text <> "" Then
            consulta = "SELECT * From precio WHERE codigo = " & TxtCodigo.Text & ""
            adaptador = New OleDbDataAdapter(consulta, conexion)
            registros = New DataSet
            adaptador.Fill(registros, "precio")
            lista = registros.Tables("precio").Rows.Count
            If lista <> 0 Then
                MsgBox("El precio existe")
                PrecioDataGridView.DataSource = registros
                PrecioDataGridView.DataMember = "precio"
                TxtCodigo.Text = registros.Tables("precio").Rows(0).Item("codigo")
                TxtNombre.Text = registros.Tables("precio").Rows(0).Item("nombre")
                TxtValor.Text = registros.Tables("precio").Rows(0).Item("valor")
                
            Else
                MsgBox("Paquete no encontrado", vbCritical, "Error de precio")


            End If
        End If
    End Sub

    Private Sub LimpiarTodo()
        TxtCodigo.Clear()
        TxtNombre.Clear()
        TxtValor.Clear()
        PrecioDataGridView.Update()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("Está seguro de eliminar?", vbYesNo, "Confirmar")
        If si = vbYes Then
            eliminar = "DELETE FROM precio WHERE codigo = " & TxtCodigo.Text & ""
            comando = New OleDbCommand(eliminar, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Paquete eliminado correctamente :D", vbInformation, "Eliminación de precio")
            Me.LimpiarTodo()
        Else
            MsgBox("Eliminación cancelada", vbInformation, "Eliminación")
        End If
    End Sub
End Class