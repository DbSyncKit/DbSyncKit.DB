using DbSyncKit.DB.Attributes;
using DbSyncKit.DB.Interface;
using DbSyncKit.DB.Manager;
using System.Text;

namespace DbSyncKit.DB.Utils
{
    /// <summary>
    /// Generic utility class for working with data contract classes.
    /// </summary>
    /// <typeparam name="T">The type of the data contract class.</typeparam>
    public class DataContractUtility<T> : IDataContractComparer where T : IDataContractComparer
    {
        /// <summary>
        /// Overrides the default GetHashCode method to provide a custom hash code for the object.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Checks if the current object is equal to another object, considering specified properties.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var props = CacheManager.GetComparableProperties(GetType());

            foreach (var prop in props)
            {
                if (!EqualityComparer<object?>.Default.Equals(prop.GetValue(this), prop.GetValue(obj)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
