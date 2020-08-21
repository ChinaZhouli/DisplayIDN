using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DisplayIDN
{
    public class TriangleTextBox : TextBox
    {
        public TriangleTextBox()
        {
            this.DefaultStyleKey = typeof(TriangleTextBox);
        }



        public Brush TriangleBrush
        {
            get { return (Brush)GetValue(TriangleBrushProperty); }
            set { SetValue(TriangleBrushProperty, value); }
        }
        public static readonly DependencyProperty TriangleBrushProperty = DependencyProperty.Register("TriangleBrush", typeof(Brush), typeof(TriangleTextBox), new FrameworkPropertyMetadata());



        public bool IsChanged
        {
            get { return (bool)GetValue(IsChangedProperty); }
            set { SetValue(IsChangedProperty, value); }
        }
        public static readonly DependencyProperty IsChangedProperty = DependencyProperty.Register("IsChanged", typeof(bool), typeof(TriangleTextBox), new FrameworkPropertyMetadata(false));



    }
}
