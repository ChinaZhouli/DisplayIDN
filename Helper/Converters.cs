using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace DisplayIDN
{
    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ReverseBoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReadWriteToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ValueModify rw = (ValueModify)value;
            SolidColorBrush scb = new SolidColorBrush();
            switch (rw)
            {
                case ValueModify.ReadOnly:

                    break;
                case ValueModify.Immediately:

                    break;
                case ValueModify.PowerOff:
                    scb.Color = Color.FromArgb(0xFF, 0x67, 0xC2, 0x3A);
                    break;
                case ValueModify.Restart:
                    scb.Color = Color.FromArgb(0xFF, 0xF5, 0x22, 0x2D);
                    break;
            }
            return scb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReadWriteToReadOnly : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ValueModify rw = (ValueModify)value;
            bool isReadOnly = false;
            switch (rw)
            {
                case ValueModify.ReadOnly:
                    isReadOnly = true;
                    break;
                case ValueModify.Immediately:

                    break;
                case ValueModify.PowerOff:

                    break;
                case ValueModify.Restart:

                    break;
            }
            return isReadOnly;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ChangedToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hasChanged = (bool)value;
            SolidColorBrush scb = new SolidColorBrush();
            if (hasChanged)
            {
                scb.Color = Color.FromArgb(0x26, 0xF6, 0x9D, 0x04);
            }
            return scb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AccessAndHiddenTo : IMultiValueConverter

    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ValueAccess accessLevel = (ValueAccess)values[0];
            ValueAccess userLevel = (ValueAccess)values[1];
            bool isHidden = (bool)values[2];

            if (isHidden)
            {
                return true;
            }

            if (userLevel == ValueAccess.Administrators)
            {
                return true;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
