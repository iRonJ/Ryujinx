<<<<<<< HEAD
#nullable enable
=======
﻿#nullable enable
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Reflection;
using System.Text;

<<<<<<< HEAD
namespace Ryujinx.Common.Logging.Formatters
{
    internal static class DynamicObjectFormatter
    {
        private static readonly ObjectPool<StringBuilder> _stringBuilderPool = SharedPools.Default<StringBuilder>();
=======
namespace Ryujinx.Common.Logging
{
    internal class DynamicObjectFormatter
    {
        private static readonly ObjectPool<StringBuilder> StringBuilderPool = SharedPools.Default<StringBuilder>();
>>>>>>> 1ec71635b (sync with main branch)

        public static string? Format(object? dynamicObject)
        {
            if (dynamicObject is null)
            {
                return null;
            }

<<<<<<< HEAD
            StringBuilder sb = _stringBuilderPool.Allocate();

=======
            StringBuilder sb = StringBuilderPool.Allocate();
            
>>>>>>> 1ec71635b (sync with main branch)
            try
            {
                Format(sb, dynamicObject);

                return sb.ToString();
            }
            finally
            {
<<<<<<< HEAD
                _stringBuilderPool.Release(sb);
=======
                StringBuilderPool.Release(sb);
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public static void Format(StringBuilder sb, object? dynamicObject)
        {
            if (dynamicObject is null)
            {
                return;
            }

            PropertyInfo[] props = dynamicObject.GetType().GetProperties();

            sb.Append('{');

            foreach (var prop in props)
            {
                sb.Append(prop.Name);
                sb.Append(": ");

                if (typeof(Array).IsAssignableFrom(prop.PropertyType))
                {
<<<<<<< HEAD
                    Array? array = (Array?)prop.GetValue(dynamicObject);
=======
                    Array? array = (Array?) prop.GetValue(dynamicObject);
>>>>>>> 1ec71635b (sync with main branch)

                    if (array is not null)
                    {
                        foreach (var item in array)
                        {
                            sb.Append(item);
                            sb.Append(", ");
                        }

                        if (array.Length > 0)
                        {
                            sb.Remove(sb.Length - 2, 2);
                        }
                    }
                }
                else
                {
                    sb.Append(prop.GetValue(dynamicObject));
                }

                sb.Append(" ; ");
            }

            // We remove the final ';' from the string
            if (props.Length > 0)
            {
                sb.Remove(sb.Length - 3, 3);
            }

            sb.Append('}');
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
