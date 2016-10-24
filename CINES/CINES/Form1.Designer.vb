<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GéneroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PelículaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrecioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(554, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GéneroToolStripMenuItem, Me.CompraToolStripMenuItem, Me.HorarioToolStripMenuItem, Me.PelículaToolStripMenuItem, Me.PrecioToolStripMenuItem, Me.SalaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'GéneroToolStripMenuItem
        '
        Me.GéneroToolStripMenuItem.Name = "GéneroToolStripMenuItem"
        Me.GéneroToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GéneroToolStripMenuItem.Text = "Género"
        '
        'CompraToolStripMenuItem
        '
        Me.CompraToolStripMenuItem.Name = "CompraToolStripMenuItem"
        Me.CompraToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CompraToolStripMenuItem.Text = "Compra"
        '
        'HorarioToolStripMenuItem
        '
        Me.HorarioToolStripMenuItem.Name = "HorarioToolStripMenuItem"
        Me.HorarioToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HorarioToolStripMenuItem.Text = "Horario"
        '
        'PelículaToolStripMenuItem
        '
        Me.PelículaToolStripMenuItem.Name = "PelículaToolStripMenuItem"
        Me.PelículaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PelículaToolStripMenuItem.Text = "Película"
        '
        'PrecioToolStripMenuItem
        '
        Me.PrecioToolStripMenuItem.Name = "PrecioToolStripMenuItem"
        Me.PrecioToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrecioToolStripMenuItem.Text = "Precio"
        '
        'SalaToolStripMenuItem
        '
        Me.SalaToolStripMenuItem.Name = "SalaToolStripMenuItem"
        Me.SalaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SalaToolStripMenuItem.Text = "Sala"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Image = Global.CINES.My.Resources.Resources.logo_valentines
        Me.Label1.Location = New System.Drawing.Point(94, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 225)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Cine"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GéneroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PelículaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrecioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
