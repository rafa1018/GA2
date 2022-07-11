using System;
using System.ComponentModel;
using System.Reflection;

namespace GA2.Transversals.Commons
{
    /// <summary>
    /// Extension Enumeradores
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>18/02/2021</date>
    public static class HelpersEnums
    {
        /// <summary>
        /// Descripcion de Enumerables
        /// </summary>
        /// <param name="enumValue">Valor del enum</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        /// <returns>Descripcion de valor</returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return enumValue.ToString();
        }
    }
}
