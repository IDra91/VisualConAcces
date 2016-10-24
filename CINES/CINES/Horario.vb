Imports System.Data
Imports System.Data.OleDb

Public Class Horario
    Dim conexion As New OleDbConnection
    Dim comando As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet
    Private Sub HorarioBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles HorarioBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.HorarioBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BasedatosDataSet)

    End Sub

    Private Sub Horario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasedatosDataSet.horario' Puede moverla o quitarla según sea necesario.
        Me.HorarioTableAdapter.Fill(Me.BasedatosDataSet.horario)
        Try
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\manuel\documents\visual studio 2013\Projects\CINES\CINES\basedatos.accdb"
            conexion.Open()
            MsgBox("Conexión disponible")
        Catch ex As Exception
            MsgBox("Error de conexión")
        End Try
    End Sub

    Private Sub HorarioDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles HorarioDataGridView.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            comando = New OleDbCommand("INSERT INTO horario (sala, pelicula, hora_inicio, hora_fin) VALUES (TxtSala, TxtPeli, TxtHoraI, TxtHoraF)", conexion)
            comando.Parameters.AddWithValue("@sala", TxtSala.Text)
            comando.Parameters.AddWithValue("@pelicula", TxtPeli.Text)
            comando.Parameters.AddWithValue("@hora_inicio", TxtHoraI.Text)
            comando.Parameters.AddWithValue("@hora_fin", TxtHoraF.Text)
            comando.ExecuteNonQuery()
            MsgBox("Se han insertado los datos correctamente :D", vbInformation, "Correcto")
            Me.HorarioTableAdapter.Fill(Me.BasedatosDataSet.horario)

        Catch ex As Exception
            MsgBox("Error al guardar", vbCritical, "Error")
        End Try
    End Sub
    Private Sub LimpiarTodo()
        TxtCodigo.Clear()
        TxtHoraF.Clear()
        TxtHoraI.Clear()
        TxtPeli.Clear()
        TxtSala.Clear()
        HorarioDataGridView.Update()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim actualizar As String
        actualizar = "UPDATE horario SET sala = " & TxtSala.Text & ", pelicula = " & TxtPeli.Text & ", hora_inicio = '" & TxtHoraI.Text & "', hora_fin = '" & TxtHoraF.Text & "' WHERE codigo = " & TxtCodigo.Text & ""
        comando = New OleDbCommand(actualizar, conexion)
        comando.ExecuteNonQuery()
        Me.LimpiarTodo()

        MsgBox("Datos actualizados correctamente :D", vbInformation, "Correcto")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim consulta As String
        Dim lista As Byte
        If TxtCodigo.Text <> "" Then
            consulta = "SELECT * From horario WHERE codigo = " & TxtCodigo.Text & ""
            adaptador = New OleDbDataAdapter(consulta, conexion)
            registros = New DataSet
            adaptador.Fill(registros, "horario")
            lista = registros.Tables("horario").Rows.Count
            If lista <> 0 Then
                MsgBox("El horario existe")
                HorarioDataGridView.DataSource = registros
                HorarioDataGridView.DataMember = "horario"
                TxtCodigo.Text = registros.Tables("horario").Rows(0).Item("codigo")
                TxtSala.Text = registros.Tables("horario").Rows(0).Item("sala")
                TxtPeli.Text = registros.Tables("horario").Rows(0).Item("pelicula")
                TxtHoraI.Text = registros.Tables("horario").Rows(0).Item("hora_inicio")
                TxtHoraF.Text = registros.Tables("horario").Rows(0).Item("hora_fin")
            Else
                MsgBox("Horario no encontrado", vbCritical, "Error de búsqueda")


            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("Está seguro de eliminar?", vbYesNo, "Confirmar")
        If si = vbYes Then
            eliminar = "DELETE FROM horario WHERE codigo = " & TxtCodigo.Text & ""
            comando = New OleDbCommand(eliminar, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Horario eliminado correctamente :D", vbInformation, "Eliminación de horario")
            Me.LimpiarTodo()
        Else
            MsgBox("Eliminación cancelada", vbInformation, "Eliminación")
        End If
    End Sub
End Class