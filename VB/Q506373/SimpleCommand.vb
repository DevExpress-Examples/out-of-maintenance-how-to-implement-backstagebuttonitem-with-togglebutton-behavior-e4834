Imports System
Imports System.Linq
Imports System.Windows.Input

Namespace Q506373
	Public Class SimpleCommand
		Implements ICommand

		Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
			Return True
		End Function
		Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
		Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
			Console.WriteLine("SimpleCommand: Action!")
		End Sub
	End Class
End Namespace
