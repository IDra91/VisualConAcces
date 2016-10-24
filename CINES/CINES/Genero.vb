Imports System.Data
Imports System.Data.OleDb

Public Class Genero
    Dim conexion As New OleDbConnection
    Dim comando As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet


    Private Sub GeneroBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles GeneroBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.GeneroBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BasedatosDataSet)

    End Sub

    Private Sub Genero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasedatosDataSet.genero' Puede moverla o quitarla según sea necesario.
        Me.GeneroTableAdapter.Fill(Me.BasedatosDataSet.genero)
        Try
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\manuel\documents\visual studio 2013\Projects\CINES\CINES\basedatos.accdb"
            conexion.Open()
            MsgBox("Conexión disponible")
        Catch ex As Exception
            MsgBox("Error de conexión")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try

            comando = New OleDbCommand("INSERT INTO genero (nombre) VALUES (TxtGenero)", conexion)
            comando.Parameters.AddWithValue("@genero", TxtGenero.Text)
            comando.ExecuteNonQuery()
            MsgBox("Se han insertado los datos correctamente :D", vbInformation, "Correcto")
            Me.GeneroTableAdapter.Fill(Me.BasedatosDataSet.genero)

        Catch ex As Exception
            MsgBox("Error al guardar", vbCritical, "Error")
        End Try
    End Sub
    Private Sub LimpiarTodo()
        TxtCodigo.Clear()
        TxtGenero.Clear()
        GeneroDataGridView.Columns.Clear()

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Dim consulta As String
        Dim lista As Byte
        If TxtCodigo.Text <> "" Then
            consulta = "SELECT * From genero WHERE codigo = " & TxtCodigo.Text & ""
            adaptador = New OleDbDataAdapter(consulta, conexion)
            registros = New DataSet
            adaptador.Fill(registros, "genero")
            lista = registros.Tables("genero").Rows.Count
            If lista <> 0 Then
                MsgBox("El género existe")
                GeneroDataGridView.DataSource = registros
                GeneroDataGridView.DataMember = "genero"
                TxtCodigo.Text = registros.Tables("genero").Rows(0).Item("codigo")
                TxtGenero.Text = registros.Tables("genero").Rows(0).Item("nombre")

            Else
                MsgBox("Género no encontrado", vbCritical, "Error de género")


            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("Está seguro de eliminar?", vbYesNo, "Confirmar")
        If si = vbYes Then
            eliminar = "DELETE FROM genero WHERE codigo = " & TxtCodigo.Text & ""
            comando = New OleDbCommand(eliminar, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Género eliminado correctamente :D", vbInformation, "Eliminación de género")
            Me.LimpiarTodo()
            Me.GeneroTableAdapter.Fill(Me.BasedatosDataSet.genero)
        Else
            MsgBox("Eliminación cancelada", vbInformation, "Eliminación")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnMod.Click
        Dim actualizar As String
        actualizar = "UPDATE genero SET nombre = '" & TxtGenero.Text & "' WHERE codigo = " & TxtCodigo.Text & ""
        comando = New OleDbCommand(actualizar, conexion)
        comando.ExecuteNonQuery()
        Me.LimpiarTodo()
        GeneroDataGridView.Update()

        MsgBox("Datos actualizados correctamente :D", vbInformation, "Correcto")



    End Sub
End Class