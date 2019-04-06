using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xne_Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Xne_Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Xne_Controls;assembly=Xne_Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:LabeledText/>
    ///
    /// </summary>
    public class LabeledText : Control
    {
        static LabeledText()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledText), new FrameworkPropertyMetadata(typeof(LabeledText)));
        }
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabeledText), new PropertyMetadata(null));
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register(nameof(LabelWidth), typeof(GridLength), typeof(LabeledText), new PropertyMetadata(GridLength.Auto));
        public TextAlignment LabelTextAlignment
        {
            get => (TextAlignment)GetValue(LabelTextAlignmentProperty);
            set => SetValue(LabelTextAlignmentProperty, value);
        }
        public static readonly DependencyProperty LabelTextAlignmentProperty =
            DependencyProperty.Register(nameof(LabelTextAlignment), typeof(TextAlignment), typeof(LabeledText), new PropertyMetadata(TextAlignment.Right));
        public VerticalAlignment LabelVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(LabelVerticalAlignmentProperty);
            set => SetValue(LabelVerticalAlignmentProperty, value);
        }
        public static readonly DependencyProperty LabelVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(LabelVerticalAlignment), typeof(VerticalAlignment), typeof(LabeledText), new PropertyMetadata(VerticalAlignment.Top));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(LabeledText), new PropertyMetadata(null));
        public GridLength TextWidth
        {
            get => (GridLength)GetValue(TextWidthProperty);
            set => SetValue(TextWidthProperty, value);
        }
        public static readonly DependencyProperty TextWidthProperty =
            DependencyProperty.Register(nameof(TextWidth), typeof(GridLength), typeof(LabeledText), new PropertyMetadata(GridLength.Auto));
        public TextAlignment TextAlignment
        {
            get => (TextAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }
        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(LabeledText), new PropertyMetadata(TextAlignment.Left));
        public VerticalAlignment TextVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(TextVerticalAlignmentProperty);
            set => SetValue(TextVerticalAlignmentProperty, value);
        }
        public static readonly DependencyProperty TextVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(TextVerticalAlignment), typeof(VerticalAlignment), typeof(LabeledText), new PropertyMetadata(VerticalAlignment.Center));

        public Visibility TextBoxVisibility
        {
            get => (Visibility)GetValue(TextBoxVisibilityProperty);
            set => SetValue(TextBoxVisibilityProperty, value);
        }
        public static readonly DependencyProperty TextBoxVisibilityProperty =
            DependencyProperty.Register(nameof(TextBoxVisibility), typeof(Visibility), typeof(LabeledText), new PropertyMetadata(Visibility.Collapsed));

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(LabeledText), new PropertyMetadata(true));

        public GridLength RowHeight
        {
            get => (GridLength)GetValue(RowHeightProperty);
            set => SetValue(RowHeightProperty, value);
        }
        public static readonly DependencyProperty RowHeightProperty =
            DependencyProperty.Register(nameof(RowHeight), typeof(GridLength), typeof(LabeledText), new PropertyMetadata(GridLength.Auto));

        public Thickness InnerPadding
        {
            get => (Thickness)GetValue(InnerPaddingProperty);
            set => SetValue(InnerPaddingProperty, value);
        }
        public static readonly DependencyProperty InnerPaddingProperty =
            DependencyProperty.Register(nameof(InnerPadding), typeof(Thickness), typeof(LabeledText), new PropertyMetadata(new Thickness(.5)));

        public Thickness InnerMargin
        {
            get => (Thickness)GetValue(InnerMarginProperty);
            set => SetValue(InnerMarginProperty, value);
        }
        public static readonly DependencyProperty InnerMarginProperty =
            DependencyProperty.Register(nameof(InnerMargin), typeof(Thickness), typeof(LabeledText), new PropertyMetadata(new Thickness(.5)));
    }
}