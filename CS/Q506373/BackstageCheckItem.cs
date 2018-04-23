using DevExpress.Xpf.Ribbon;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Q506373 {
    public class BackstageCheckItem : BackstageButtonItem {
        public static readonly DependencyProperty CloseOnToggleProperty =
            DependencyProperty.Register("CloseOnToggle", typeof(bool), typeof(BackstageCheckItem), new PropertyMetadata(false));
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(BackstageCheckItem), new PropertyMetadata(false));
        public bool IsChecked {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        public bool CloseOnToggle {
            get { return (bool)GetValue(CloseOnToggleProperty); }
            set { SetValue(CloseOnToggleProperty, value); }
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
            IsChecked = !IsChecked;
            e.Handled = true;
            if (CloseOnToggle)
                base.OnMouseLeftButtonUp(e);
            else
                ExecuteCommand();
        }
    }

    public class MyRibbonCheckedBorderControl : RibbonCheckedBorderControl {
        void UpdateVisualStates() {
            string state = "Normal";
            string checkedState = "Unchecked";
            if (IsMouseOver) {
                state = IsLeftButtonPressed ? "Pressed" : "Hover";
            }
            if (IsChecked == true) {
                state = "Pressed";
                checkedState = "Checked";
            }
            if (IsChecked == null && !MergeCheckedStates)
                checkedState = "Indeterminate";
            if (MergeCheckedStates) {
                SetVisualState(state + checkedState);
            } else {
                SetVisualState(state);
                SetVisualState(checkedState);
            }
            if (UseAppFocusValue) {
                SetVisualState(AppFocusValue ? "Focused" : "Unfocused");
            } else {
                SetVisualState(IsFocused ? "Focused" : "Unfocused");
            }
            SetVisualState(IsEnabled ? "Enabled" : "Disabled");
            SetVisualState(IsInRibbonWindow ? "RibbonWindow" : "Standalone");
        }

        protected override void OnIsCheckedChanged(bool? oldValue) {
            UpdateVisualStates();
        }
        protected override void OnMergeCheckedStatesChanged(bool oldValue) {
            UpdateVisualStates();
        }
        protected override void OnIsLeftButtonPressedChanged(bool oldValue) {
            
        }
        protected override void OnUseAppFocusValueChanged(bool oldValue) {
            UpdateVisualStates();
        }
        protected override void OnAppFocusValueChanged(bool oldValue) {
            UpdateVisualStates();
        }
        protected override void IsInRibbonWindowChanged(bool oldValue) {
            UpdateVisualStates();
        }
        protected override void OnIsEnabledChanged(bool oldValue) {
            UpdateVisualStates();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
            base.OnMouseLeftButtonDown(e);
            UpdateVisualStates();
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
            base.OnMouseLeftButtonUp(e);
            UpdateVisualStates();
        }
        protected override void OnMouseLeave(MouseEventArgs e) {
            base.OnMouseLeave(e);
            UpdateVisualStates();
        }
        protected override void OnMouseEnter(MouseEventArgs e) {
            UpdateVisualStates();
        }
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
            UpdateVisualStates();
        }
        protected override void OnGotFocus(RoutedEventArgs e) {
            base.OnGotFocus(e);
            UpdateVisualStates();
        }
        protected override void OnLostFocus(RoutedEventArgs e) {
            base.OnLostFocus(e);
            UpdateVisualStates();
        }
    }
}
