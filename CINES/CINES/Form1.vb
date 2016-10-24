Imports System.Data
Imports System.Data.OleDb

Public Class Form1

    Private Sub GéneroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GéneroToolStripMenuItem.Click
        Genero.Visible = True
    End Sub

    Private Sub CompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraToolStripMenuItem.Click
        Compra.Visible = True
    End Sub

    Private Sub HorarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HorarioToolStripMenuItem.Click
        Horario.Visible = True
    End Sub

    Private Sub PelículaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PelículaToolStripMenuItem.Click
        Pelicula.Visible = True
    End Sub

    Private Sub PrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrecioToolStripMenuItem.Click
        Precio.Visible = True
    End Sub

    Private Sub SalaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalaToolStripMenuItem.Click
        Sala.Visible = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()

    End Sub
End Class
