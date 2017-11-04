using Microsoft.Win32;
using System;

namespace Prism.VisualStudio.Wizards.Core
{
    public static class RegistryHelper
    {

        const String KeyName = @"SOFTWARE\Prism";

        public static T GetValue<T>(String entryName, T defaultValue = default(T))
        {
            if (String.IsNullOrWhiteSpace(entryName))
                throw new ArgumentException(nameof(entryName));

            using (var rk = Registry.CurrentUser.CreateSubKey(KeyName))
            {
                if (rk == null)
                    return defaultValue;

                var readValue = rk.GetValue(entryName, defaultValue, RegistryValueOptions.DoNotExpandEnvironmentNames);
                if (readValue.ToString().ToLower() == "true")
                    readValue = true;

                if (readValue.ToString().ToLower() == "false")
                    readValue = false;

                if (typeof(T).IsEnum)
                    return (T)Enum.Parse(typeof(T), readValue.ToString());

                return (T)readValue;
            }
        }

        public static void WriteValue(String entryName, Object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (String.IsNullOrWhiteSpace(entryName))
                throw new ArgumentException(nameof(entryName));

            using (var rk = Registry.CurrentUser.CreateSubKey(KeyName))
            {
                if (rk == null)
                    return;

                rk.SetValue(entryName, value);
            }
        }
    }
}
