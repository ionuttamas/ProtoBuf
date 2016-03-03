using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommandLineParser.Reflection
{
    public static class ReflectionExtensions
    {
        public static Dictionary<PropertyInfo, TAttr> GetAttributes<T, TAttr>() where TAttr : class
        {
            Dictionary<PropertyInfo, TAttr> propertiesAttributes = new Dictionary<PropertyInfo, TAttr>();
            Type classType = typeof(T);
            Type attributeType = typeof(TAttr);
            PropertyInfo[] properties = classType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object attribute = property
                    .GetCustomAttributes(attributeType, true)
                    .FirstOrDefault();

                if (attribute == null)
                    continue;

                propertiesAttributes[property] = attribute as TAttr;
            }

            return propertiesAttributes;
        }

        public static void SetProperty(this object instance, string name, object value)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            if (name == null)
                throw new ArgumentNullException("name");

            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
                throw new InvalidOperationException(string.Format("Type {0} does not have a property {1}", type, name));

            property.SetValue(instance, value, null);
        }

        public static object GetProperty(this object instance, string name)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            if (name == null)
                throw new ArgumentNullException("name");

            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
                throw new InvalidOperationException(string.Format("Type {0} does not have a property {1}", type, name));

            object result = property.GetValue(instance, null);

            return result;
        }

        public static bool IsNumeric(this Type type)
        {
            if (type == typeof(byte?) ||
                type == typeof(int?) ||
                type == typeof(double?) ||
                type == typeof(float?) ||
                type == typeof(decimal?))
                return true;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsString(this Type type)
        {
            return Type.GetTypeCode(type) == TypeCode.String;
        }

        public static bool IsBoolean(this Type type)
        {
            if (type == typeof(bool?))
                return true;

            return Type.GetTypeCode(type) == TypeCode.Boolean;
        }
    }
}
