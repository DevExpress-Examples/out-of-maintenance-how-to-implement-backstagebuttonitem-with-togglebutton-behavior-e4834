Imports DevExpress.Xpf.Ribbon
Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Input

Namespace Q506373
	Public Class BackstageCheckItem
		Inherits BackstageButtonItem

		Public Shared ReadOnly CloseOnToggleProperty As DependencyProperty = DependencyProperty.Register("CloseOnToggle", GetType(Boolean), GetType(BackstageCheckItem), New PropertyMetadata(False))
		Public Shared ReadOnly IsCheckedProperty As DependencyProperty = DependencyProperty.Register("IsChecked", GetType(Boolean), GetType(BackstageCheckItem), New PropertyMetadata(False))
		Public Property IsChecked() As Boolean
			Get
				Return DirectCast(GetValue(IsCheckedProperty), Boolean)
			End Get
			Set(ByVal value As Boolean)
				SetValue(IsCheckedProperty, value)
			End Set
		End Property
		Public Property CloseOnToggle() As Boolean
			Get
				Return DirectCast(GetValue(CloseOnToggleProperty), Boolean)
			End Get
			Set(ByVal value As Boolean)
				SetValue(CloseOnToggleProperty, value)
			End Set
		End Property
		Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs)
            IsChecked = Not IsChecked
            e.Handled = True
            If CloseOnToggle Then
				MyBase.OnMouseLeftButtonUp(e)
			Else
				ExecuteCommand()
			End If
		End Sub
	End Class

	Public Class MyRibbonCheckedBorderControl
		Inherits RibbonCheckedBorderControl

		Private Sub UpdateVisualStates()
			Dim state As String = "Normal"
			Dim checkedState As String = "Unchecked"
			If IsMouseOver Then
				state = If(IsLeftButtonPressed, "Pressed", "Hover")
			End If
			If IsChecked.Equals(True) Then
				state = "Pressed"
				checkedState = "Checked"
			End If
			If IsChecked Is Nothing AndAlso Not MergeCheckedStates Then
				checkedState = "Indeterminate"
			End If
			If MergeCheckedStates Then
				SetVisualState(state & checkedState)
			Else
				SetVisualState(state)
				SetVisualState(checkedState)
			End If
			If UseAppFocusValue Then
				SetVisualState(If(AppFocusValue, "Focused", "Unfocused"))
			Else
				SetVisualState(If(IsFocused, "Focused", "Unfocused"))
			End If
			SetVisualState(If(IsEnabled, "Enabled", "Disabled"))
			SetVisualState(If(IsInRibbonWindow, "RibbonWindow", "Standalone"))
		End Sub

		Protected Overrides Sub OnIsCheckedChanged(ByVal oldValue? As Boolean)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnMergeCheckedStatesChanged(ByVal oldValue As Boolean)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnIsLeftButtonPressedChanged(ByVal oldValue As Boolean)

		End Sub
		Protected Overrides Sub OnUseAppFocusValueChanged(ByVal oldValue As Boolean)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnAppFocusValueChanged(ByVal oldValue As Boolean)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub IsInRibbonWindowChanged(ByVal oldValue As Boolean)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnIsEnabledChanged(ByVal oldValue As Boolean)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
			MyBase.OnMouseLeftButtonDown(e)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs)
			MyBase.OnMouseLeftButtonUp(e)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnMouseLeave(ByVal e As MouseEventArgs)
			MyBase.OnMouseLeave(e)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnMouseEnter(ByVal e As MouseEventArgs)
			UpdateVisualStates()
		End Sub
		Public Overrides Sub OnApplyTemplate()
			MyBase.OnApplyTemplate()
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnGotFocus(ByVal e As RoutedEventArgs)
			MyBase.OnGotFocus(e)
			UpdateVisualStates()
		End Sub
		Protected Overrides Sub OnLostFocus(ByVal e As RoutedEventArgs)
			MyBase.OnLostFocus(e)
			UpdateVisualStates()
		End Sub
	End Class
End Namespace
