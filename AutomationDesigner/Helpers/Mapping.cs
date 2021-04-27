using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.Helpers
{
    public static class Mapping
    {
        /// <summary>
        /// Maps matching names between objects
        /// </summary>
        /// <typeparam name="T2">Object to write values into</typeparam>
        /// <typeparam name="T1">Object to read values from</typeparam>
        /// <param name="entityToWrite"></param>
        /// <param name="entityToRead"></param>
        /// <param name="propertiesToSkip">Name of any properties that should be skipped</param>
        public static void Map<T2, T1>(this T2 entityToWrite, T1 entityToRead, List<string> propertiesToSkip = null) where T1 : class where T2 : class
        {
            // loop through each property in read
            foreach (PropertyInfo propertyInRead in entityToRead.GetType().GetProperties().Where(x => !x.GetGetMethod().GetParameters().Any()))
            {
                // if property in read matches a name in propertiesToSkip then continue
                if (propertiesToSkip != null && propertiesToSkip.Count > 0)
                {
                    if (propertiesToSkip.Any(x => x.ToUpper() == propertyInRead.Name.ToUpper())) continue;
                }

                // loop through the properties in write that have a setter
                foreach (PropertyInfo propertyInWrite in entityToWrite.GetType().GetProperties().Where(x => !x.GetGetMethod().GetParameters().Any()))
                {
                    // get the property type
                    var type = propertyInWrite.PropertyType;

                    // check if the property can be a null type
                    bool canBeNull = !type.IsValueType || (Nullable.GetUnderlyingType(type) != null);

                    // if property cannot be null the check if the property in read is null
                    if (!canBeNull)
                    {
                        // if property in read is null then continue
                        if (propertyInRead.GetValue(entityToRead, null) == null) continue;
                    }

                    // if property doesn't have a setter then continue
                    if (propertyInWrite.GetSetMethod() == null) continue;

                    // if property in read equals property in write then set the value
                    if (propertyInRead.Name.ToUpper() == propertyInWrite.Name.ToUpper())
                    {
                        // set the value of property in write to match property in read
                        propertyInWrite.SetValue(entityToWrite, propertyInRead.GetValue(entityToRead, null));
                    }
                }
            }
        }

        // returns a completed object
        // object must have a default constructor with no parameters
        public static T1 Map<T1>(object propertyToMap) where T1 : class, new()
        {
            // get the object type
            var type = typeof(T1);

            // get the first constructor that 0 parameters
            var contructor = type.GetConstructors().FirstOrDefault(x => x.GetParameters().Count() == 0);

            // if constructor is null then throw exception
            if (contructor == null)
            {
                throw new ArgumentNullException(nameof(propertyToMap), $"{type.FullName} does not have a constructor with 0 parameters");
            }

            // create a new object 
            var value = new T1();

            // map the values
            value.Map(propertyToMap);

            // return the object
            return value;
        }
    }
}
