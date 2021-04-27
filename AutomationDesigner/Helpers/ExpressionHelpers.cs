using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.Helpers
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lamda">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamda)
        {
            return lamda.Compile().Invoke();
        }

        /// <summary>
        /// The the underlying properties value th the given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">the type of the value to set</typeparam>
        /// <param name="lamda">the expression</param>
        /// <param name="value"></param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamda, T value)
        {
            //converts a lamba ()=> some.Property to some property
            if (!(lamda.Body is MemberExpression expression)) return;
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //Set the property value
            propertyInfo.SetValue(target, value);
        }

    }
}
