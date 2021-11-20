﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NotMVMMSuck.Converters
{
   public class ImageConverter : IValueConverter
   {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value.ToString()) ? 
                File.ReadAllBytes(@"../../products/picture.png") : File.ReadAllBytes($"../../{value}");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
   }
}
