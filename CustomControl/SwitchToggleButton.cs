using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DisplayIDN
{
    public class SwitchToggleButton : ToggleButton
    {
        public SwitchToggleButton()
        {
            this.DefaultStyleKey = typeof(SwitchToggleButton);
        }

        public string CheckedContent
        {
            get { return (string)GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }
        public static readonly DependencyProperty CheckedContentProperty = DependencyProperty.Register("CheckedContent", typeof(string), typeof(SwitchToggleButton), new PropertyMetadata(""));


        public string UnCheckedContent
        {
            get { return (string)GetValue(UnCheckedContentProperty); }
            set { SetValue(UnCheckedContentProperty, value); }
        }
        public static readonly DependencyProperty UnCheckedContentProperty = DependencyProperty.Register("UnCheckedContent", typeof(string), typeof(SwitchToggleButton), new PropertyMetadata(""));

    }
}
