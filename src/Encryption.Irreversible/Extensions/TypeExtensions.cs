using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Extensions
{
    /// <summary>
    /// <see cref="Type"/>扩展方法
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 若类型包含<see cref="DescriptionAttribute"/>, 则返回其<see cref="DescriptionAttribute.Description"/>。
        /// 否则，返回类型的完全限定名称，即<see cref="Type.FullName"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDescription(this Type type) 
            => type.GetCustomAttribute<DescriptionAttribute>()?.Description ?? type.FullName;
    }
}
