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

namespace ControlsAndResources
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlsAndResources"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlsAndResources;assembly=ControlsAndResources"
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
    ///     <MyNamespace:LabeledTextblock/>
    ///
    /// </summary>
    public class LabeledTextblock : Control
    {
        static LabeledTextblock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledTextblock), new FrameworkPropertyMetadata(typeof(LabeledTextblock)));
        }
        #region Label
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabeledTextblock), new PropertyMetadata(default(string)));
        public TextAlignment LabelTextAlignment
        {
            get => (TextAlignment)GetValue(LabelTextAlignmentProperty);
            set => SetValue(LabelTextAlignmentProperty, value);
        }
        // Using a DependencyProperty as the backing store for LabelTextAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTextAlignmentProperty =
            DependencyProperty.Register(nameof(LabelTextAlignment), typeof(TextAlignment), typeof(LabeledTextblock), new PropertyMetadata(TextAlignment.Right));
        #endregion
        #region Textblock
        public string Input
        {
            get => (string)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }
        // Using a DependencyProperty as the backing store for Input.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputProperty =
            DependencyProperty.Register(nameof(Input), typeof(string), typeof(LabeledTextblock), new FrameworkPropertyMetadata(default(string)));
        public TextAlignment TextboxTextAlignment
        {
            get => (TextAlignment)GetValue(TextboxTextAlignmentProperty);
            set => SetValue(TextboxTextAlignmentProperty, value);
        }
        // Using a DependencyProperty as the backing store for TextboxTextAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextboxTextAlignmentProperty =
            DependencyProperty.Register(nameof(TextboxTextAlignment), typeof(TextAlignment), typeof(LabeledTextblock), new PropertyMetadata(TextAlignment.Left));
        #endregion
    }
}
