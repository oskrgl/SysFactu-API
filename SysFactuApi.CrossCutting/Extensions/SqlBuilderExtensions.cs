using Dapper;
using System.Reflection;

namespace SysFactuApi.CrossCutting.Extensions
{
    public static class SqlBuilderExtensions
    {
        public static DynamicParameters GetParameters<T>(this T obj) where T : class
        {
            var propertyInfos = obj.GetType().GetRuntimeProperties();
            var parameters = new DynamicParameters();
            foreach (var property in propertyInfos)
            {
                var value = property.GetValue(obj);
                var name = property.Name;
                if (value == null || (Object.ReferenceEquals(value.GetType(), typeof(string)) &&
                    string.IsNullOrWhiteSpace(value.ToString())) ||
                    value.IsDefaultValue())
                    continue;
                parameters.Add(name, value);
            }

            return parameters;

        }

        private static bool IsDefaultValue(this object value)
        {
            switch (value)
            {
                case int i:
                    return default(int) == i;
                case DateTime i:
                    return default(DateTime) == i;
                case decimal i:
                    return default(decimal) == i;
                case double i:
                    return default(double) == i;
                case float i:
                    return default(float) == i;
                case long i:
                    return default(long) == i;
                case short i:
                    return default(short) == i;
                case uint i:
                    return default(uint) == i;
                case ulong i:
                    return default(ulong) == i;
                case ushort i:
                    return default(ushort) == i;
                case sbyte i:
                    return default(sbyte) == i;
                case Guid i:
                    return default(Guid) == i;
                default:
                    return false;
            }
        }
    }

}
