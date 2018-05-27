using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// This method is used to validate and compare two Objects of same type, which can be used to check whether the property 
        /// is actually updated by user or not.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <returns></returns>
        public static bool DetailedCompare<T>(this T object1, T object2)
        {
            //Get the type of the object
            Type type = typeof(T);

            //return false if any of the object is false

            if (object1 == null || object2 == null)
                return false;

            //Loop through each properties inside class and get values for the property from both the objects and compare

            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                if (property.Name != "ExtensionData")
                {
                    string Object1Value = string.Empty;
                    string Object2Value = string.Empty;
                    if (type.GetProperty(property.Name).GetValue(object1, null) != null)
                        Object1Value = type.GetProperty(property.Name).GetValue(object1, null).ToString();

                    if (type.GetProperty(property.Name).GetValue(object2, null) != null)
                        Object2Value = type.GetProperty(property.Name).GetValue(object2, null).ToString();

                    if (Object1Value.Trim() != Object2Value.Trim())
                        return false;

                }
            }
            return true; 
        }

        public static string ReplaceString(this string stringToSearch, string find, string replaceWith)
        {
            if (stringToSearch == null) return null;

            if (string.IsNullOrEmpty(find) || replaceWith == null) return stringToSearch;

            return stringToSearch.Replace(find, replaceWith);
        }
    }
}
