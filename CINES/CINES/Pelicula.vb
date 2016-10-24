Imports System.Data
Imports System.Data.OleDb
Public Class Pelicula
    Dim conexion As New OleDbConnection
    Dim comando As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet


    Private Sub PeliculaBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles PeliculaBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.PeliculaBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BasedatosDataSet)

    End Sub

    Private Sub Pelicula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'BasedatosDataSet.pelicula' Puede moverla o quitarla según sea necesario.
        Me.PeliculaTableAdapter.Fill(Me.BasedatosDataSet.pelicula)
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
            
            comando = New OleDbCommand("INSERT INTO pelicula (nombre, descripcion, duracion, clasificacion, nacionalidad, idioma, genero) VALUES (TxtNombre, TxtDescripcion, TxtDuracion, TxtClasificacion, TxtNacionalidad, TxtIdioma, TxtGenero)", conexion)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@descripcion", TxtDescripcion.Text)
            comando.Parameters.AddWithValue("@duracion", TxtDuracion.Text)
            comando.Parameters.AddWithValue("@clasificacion", TxtClasificacion.Text)
            comando.Parameters.AddWithValue("@nacionalidad", TxtNacionalidad.Text)
            comando.Parameters.AddWithValue("@idioma", TxtIdioma.Text)
            comando.Parameters.AddWithValue("@genero", TxtGenero.Text)
            comando.ExecuteNonQuery()
            MsgBox("Se han insertado los datos correctamente :D", vbInformation, "Correcto")
            Me.PeliculaTableAdapter.Fill(Me.BasedatosDataSet.pelicula)

        Catch ex As Exception
            MsgBox("Error al guardar", vbCritical, "Error")
        End Try

    End Sub
    Private Sub LimpiarTodo()
        TxtClasificacion.Clear()
        TxtCodigo.Clear()
        TxtDescripcion.Clear()
        TxtDuracion.Clear()
        TxtGenero.Clear()
        TxtIdioma.Clear()
        TxtNacionalidad.Clear()
        TxtNombre.Clear()
        PeliculaDataGridView.Update()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim actualizar As String
        actualizar = "UPDATE pelicula SET nombre = '" & TxtNombre.Text & "', descripcion = '" & TxtDescripcion.Text & "', duracion = " & TxtDuracion.Text & ", clasificacion = '" & TxtClasificacion.Text & "', nacionalidad = '" & TxtNacionalidad.Text & "', idioma = '" & TxtIdioma.Text & "', genero = " & TxtGenero.Text & " WHERE codigo = " & TxtCodigo.Text & ""
        comando = New OleDbCommand(actualizar, conexion)
        comando.ExecuteNonQuery()
        Me.LimpiarTodo()

        MsgBox("Datos actualizados correctamente :D", vbInformation, "Correcto")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim consulta As String
        Dim lista As Byte
        If TxtCodigo.Text <> "" Then
            consulta = "SELECT * From pelicula WHERE codigo = " & TxtCodigo.Text & ""
            adaptador = New OleDbDataAdapter(consulta, conexion)
            registros = New DataSet
            adaptador.Fill(registros, "pelicula")
            lista = registros.Tables("pelicula").Rows.Count
            If lista <> 0 Then
                MsgBox("La pelicula existe")
                PeliculaDataGridView.DataSource = registros
                PeliculaDataGridView.DataMember = "pelicula"
                TxtCodigo.Text = registros.Tables("pelicula").Rows(0).Item("codigo")
                TxtDescripcion.Text = registros.Tables("pelicula").Rows(0).Item("descripcion")
                TxtDuracion.Text = registros.Tables("pelicula").Rows(0).Item("duracion")
                TxtClasificacion.Text = registros.Tables("pelicula").Rows(0).Item("clasificacion")
                TxtNacionalidad.Text = registros.Tables("pelicula").Rows(0).Item("nacionalidad")
                TxtIdioma.Text = registros.Tables("pelicula").Rows(0).Item("idioma")
                TxtGenero.Text = registros.Tables("pelicula").Rows(0).Item("genero")
            Else
                MsgBox("Pelicula no encontrada", vbCritical, "Error de busqueda")


            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim eliminar As String
        Dim si As Byte
        si = MsgBox("Está seguro de eliminar?", vbYesNo, "Confirmar")
        If si = vbYes Then
            eliminar = "DELETE FROM pelicula WHERE codigo = " & TxtCodigo.Text & ""
            comando = New OleDbCommand(eliminar, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Pelicula eliminada correctamente :D", vbInformation, "Eliminación de pelicula")
            Me.LimpiarTodo()
        Else
            MsgBox("Eliminación cancelada", vbInformation, "Eliminación")
        End If
    End Sub
End Class