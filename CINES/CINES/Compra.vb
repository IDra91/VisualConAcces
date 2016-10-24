Imports System.Data
Imports System.Data.OleDb

Public Class Compra
    Dim conexion As New OleDbConnection
    Dim comando As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet
    Private Sub CompraBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CompraBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CompraBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BasedatosDataSet)

    End Sub

    Private Sub Compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasedatosDataSet.compra' Puede moverla o quitarla según sea necesario.
        Me.CompraTableAdapter.Fill(Me.BasedatosDataSet.compra)
        Try
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\manuel\documents\visual studio 2013\Projects\CINES\CINES\basedatos.accdb"
            conexion.Open()
            MsgBox("Conexión disponible")
        Catch ex As Exception
            MsgBox("Error de conexión")
        End Try
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Try

            comando = New OleDbCommand("INSERT INTO compra (horario, cantidad, precio, subtotal) VALUES (TxtHorario, TxtCantidad, TxtPrecio, TxtSub)", conexion)
            comando.Parameters.AddWithValue("@horario", TxtHorario.Text)
            comando.Parameters.AddWithValue("@cantidad", TxtCantidad.Text)
            comando.Parameters.AddWithValue("@precio", TxtPrecio.Text)
            comando.Parameters.AddWithValue("@subtotal", TxtSub.Text)

            comando.ExecuteNonQuery()
            MsgBox("Se han insertado los datos correctamente :D", vbInformation, "Correcto")
            Me.CompraTableAdapter.Fill(Me.BasedatosDataSet.compra)
        Catch ex As Exception
            MsgBox("Error al guardar", vbCritical, "Error")
        End Try

    End Sub
    Private Sub LimpiarTodo()
        TxtCantidad.Clear()
        TxtCodigo.Clear()
        TxtHorario.Clear()
        TxtPrecio.Clear()
        TxtSub.Clear()
        CompraDataGridView.Update()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnMod.Click
        Dim actualizar As String
        actualizar = "UPDATE compra SET horario = " & TxtHorario.Text & ", cantidad = " & TxtCantidad.Text & ", precio = " & TxtPrecio.Text & ", subtotal = " & TxtSub.Text & " WHERE codigo = " & TxtCodigo.Text & ""
        comando = New OleDbCommand(actualizar, conexion)
        comando.ExecuteNonQuery()
        Me.LimpiarTodo()

        MsgBox("Datos actualizados correctamente :D", vbInformation, "Correcto")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Dim consulta As String
        Dim lista As Byte
        If TxtCodigo.Text <> "" Then
            consulta = "SELECT * From compra WHERE codigo = " & TxtCodigo.Text & ""
            adaptador = New OleDbDataAdapter(consulta, conexion)
            registros = New DataSet
            adaptador.Fill(registros, "compra")
            lista = registros.Tables("compra").Rows.Count
            If lista <> 0 Then
                MsgBox("La compra existe")
                CompraDataGridView.DataSource = registros
                CompraDataGridView.DataMember = "compra"
                TxtCodigo.Text = registros.Tables("compra").Rows(0).Item("codigo")
                TxtHorario.Text = registros.Tables("compra").Rows(0).Item("horario")
                TxtCantidad.Text = registros.Tables("compra").Rows(0).Item("cantidad")
                TxtPrecio.Text = registros.Tables("compra").Rows(0).Item("precio")
                TxtSub.Text = registros.Tables("compra").Rows(0).Item("subtotal")
            Else
                MsgBox("Compra no encontrado", vbCritical, "Error de compra")


            End If
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("Está seguro de eliminar?", vbYesNo, "Confirmar")
        If si = vbYes Then
            eliminar = "DELETE FROM compra WHERE codigo = " & TxtCodigo.Text & ""
            comando = New OleDbCommand(eliminar, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Compra eliminada correctamente :D", vbInformation, "Eliminación de compra")
            Me.LimpiarTodo()
        Else
            MsgBox("Eliminación cancelada", vbInformation, "Eliminación")
        End If
    End Sub
End Class