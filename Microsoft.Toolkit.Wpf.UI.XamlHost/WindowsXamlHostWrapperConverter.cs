// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Windows.Data;
using Windows.UI.Xaml;
using uwpXaml = Windows.UI.Xaml;

namespace Microsoft.Toolkit.Wpf.UI.XamlHost
{
    /// <summary>
    /// Dual interface (<see cref="IValueConverter"/> and <see cref="Windows.UI.Xaml.Data.IValueConverter"/>),
    /// assumes that the conversion is between a <see cref="WindowsXamlHostBase"/> and its wrapped <see cref="UIElement"/>
    /// and attempts to return the correct instance of each.
    /// </summary>
    public class WindowsXamlHostWrapperConverter : IValueConverter, Windows.UI.Xaml.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (value as uwpXaml.UIElement)?.GetWrapper();
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return (value as WindowsXamlHostBase)?.GetUwpInternalObject();
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}