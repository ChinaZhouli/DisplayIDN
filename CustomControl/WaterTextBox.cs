using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DisplayIDN
{
    public class WaterTextBox : TextBox
    {
        public WaterTextBox()
        {
            this.DefaultStyleKey = typeof(WaterTextBox);
        }

        public string WaterText
        {
            get { return (string)GetValue(WaterTextProperty); }
            set { SetValue(WaterTextProperty, value); }
        }

        public static readonly DependencyProperty WaterTextProperty = DependencyProperty.Register("WaterText", typeof(string), typeof(WaterTextBox), new PropertyMetadata(""));

    }
}
