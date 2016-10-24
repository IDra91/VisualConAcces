Imports System.Data
Imports System.Data.OleDb

Public Class Sala
    Dim conexion As New OleDbConnection
    Dim comando As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet
    Private Sub SalaBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SalaBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SalaBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BasedatosDataSet)

    End Sub

    Private Sub Sala_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasedatosDataSet.sala' Puede moverla o quitarla según sea necesario.
        Me.SalaTableAdapter.Fill(Me.BasedatosDataSet.sala)
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

            comando = New OleDbCommand("INSERT INTO sala (numero, capacidad, tipo) VALUES (TxtNumero, TxtCapacidad, TxtTipo)", conexion)
            comando.Parameters.AddWithValue("@numero", TxtNumero.Text)
            comando.Parameters.AddWithValue("@capacidad", TxtCapacidad.Text)
            comando.Parameters.AddWithValue("@tipo", TxtTipo.Text)
            comando.ExecuteNonQuery()
            MsgBox("Se han insertado los datos correctamente :D", vbInformation, "Correcto")
            Me.SalaTableAdapter.Fill(Me.BasedatosDataSet.sala)

        Catch ex As Exception
            MsgBox("Error al guardar", vbCritical, "Error")
        End Try
    End Sub
    Private Sub LimpiarTodo()
        TxtCapacidad.Clear()
        TxtCodigo.Clear()
        TxtNumero.Clear()
        TxtTipo.Clear()
        SalaDataGridView.Update()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim actualizar As String
        actualizar = "UPDATE sala SET numero = " & TxtNumero.Text & ", capacidad = " & TxtCapacidad.Text & ", tipo = '" & TxtTipo.Text & "' WHERE codigo = " & TxtCodigo.Text & ""
        comando = New OleDbCommand(actualizar, conexion)
        comando.ExecuteNonQuery()
        Me.LimpiarTodo()

        MsgBox("Datos actualizados correctamente :D", vbInformation, "Correcto")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim consulta As String
        Dim lista As Byte
        If TxtCodigo.Text <> "" Then
            consulta = "SELECT * From sala WHERE codigo = " & TxtCodigo.Text & ""
            adaptador = New OleDbDataAdapter(consulta, conexion)
            registros = New DataSet
            adaptador.Fill(registros, "sala")
            lista = registros.Tables("sala").Rows.Count
            If lista <> 0 Then
                MsgBox("La sala existe")
                SalaDataGridView.DataSource = registros
                SalaDataGridView.DataMember = "sala"
                TxtCodigo.Text = registros.Tables("sala").Rows(0).Item("codigo")
                TxtNumero.Text = registros.Tables("sala").Rows(0).Item("numero")
                TxtCapacidad.Text = registros.Tables("sala").Rows(0).Item("capacidad")
                TxtTipo.Text = registros.Tables("sala").Rows(0).Item("tipo")

            Else
                MsgBox("Sala no encontrada", vbCritical, "Error de busqueda")


            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("Está seguro de eliminar?", vbYesNo, "Confirmar")
        If si = vbYes Then
            eliminar = "DELETE FROM sala WHERE codigo = " & TxtCodigo.Text & ""
            comando = New OleDbCommand(eliminar, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Sala eliminada correctamente :D", vbInformation, "Eliminación de sala")
            Me.LimpiarTodo()
        Else
            MsgBox("Eliminación cancelada", vbInformation, "Eliminación")
        End If
    End Sub
End Class