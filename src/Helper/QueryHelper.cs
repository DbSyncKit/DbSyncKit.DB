﻿using DbSyncKit.DB.Interface;
using DbSyncKit.DB.Manager;
using System.Reflection;

namespace DbSyncKit.DB.Helper
{
    /// <summary>
    /// Helper class for database queries and attribute retrieval.
    /// </summary>
    public class QueryHelper
    {
        /// <summary>
        /// Gets the table name of a specified type, considering the TableNameAttribute if present.
        /// </summary>
        /// <typeparam name="T">The type for which to get the table name. Must implement <see cref="IDataContractComparer"/>.</typeparam>
        /// <returns>The table name.</returns>
        public string GetTableName<T>() where T : IDataContractComparer
        {
            return CacheManager.GetTableName(typeof(T));
        }

        /// <summary>
        /// Gets the table schema of a specified type, considering the TableSchemaAttribute if present.
        /// </summary>
        /// <typeparam name="T">The type for which to get the table schema. Must implement <see cref="IDataContractComparer"/>.</typeparam>
        /// <returns>The table schema name or null if not specified.</returns>
        public string? GetTableSchema<T>() where T : IDataContractComparer
        {
            return CacheManager.GetTableSchema(typeof(T));
        }

        /// <summary>
        /// Gets whether the type specifies to generate an INSERT query with ID, considering the GenerateInsertWithIDAttribute if present.
        /// </summary>
        /// <typeparam name="T">The type for which to determine the generation of INSERT query with ID. Must implement <see cref="IDataContractComparer"/>.</typeparam>
        /// <returns>True if the INSERT query should include ID, otherwise false.</returns>
        public bool GetInsertWithID<T>() where T : IDataContractComparer
        {
            return CacheManager.GetInsertWithID(typeof(T));
        }

        /// <summary>
        /// Gets whether the type specifies to include database-specific SQL statements for identity insert behavior
        /// during insert query generation, considering the GenerateInsertWithIDAttribute if present.
        /// </summary>
        /// <typeparam name="T">The type for which to determine the inclusion of identity insert statements.
        /// Must implement <see cref="IDataContractComparer"/>.</typeparam>
        /// <returns><c>true</c> if identity insert statements should be included; otherwise, <c>false</c>.</returns>
        public bool GetIncludeIdentityInsert<T>() where T : IDataContractComparer
        {
            return CacheManager.GetIncludeIdentityInsert(typeof(T));
        }

        /// <summary>
        /// Gets the names of properties marked as key columns for a specified type.
        /// </summary>
        /// <typeparam name="T">The type for which to get the key columns. Must implement <see cref="IDataContractComparer"/>.</typeparam>
        /// <returns>A list of key column names.</returns>
        /// <seealso cref="IDataContractComparer"/>
        public List<string> GetKeyColumns<T>() where T : IDataContractComparer
        {
            return CacheManager.GetKeyColumns(typeof(T));
        }

        /// <summary>
        /// Gets the names of properties marked as excluded properties for a specified type.
        /// </summary>
        /// <typeparam name="T">The type for which to get the excluded properties. Must implement <see cref="IDataContractComparer"/>.</typeparam>
        /// <returns>A list of excluded property names.</returns>
        /// <seealso cref="IDataContractComparer"/>
        public List<string> GetExcludedColumns<T>() where T : IDataContractComparer
        {
            return CacheManager.GetExcludedColumns(typeof(T));
        }

        /// <summary>
        /// Gets the names of all properties for a specified type.
        /// </summary>
        /// <typeparam name="T">The type for which to get all properties. Must implement <see cref="IDataContractComparer"/>.</typeparam>
        /// <returns>A list of all property names.</returns>
        /// <seealso cref="IDataContractComparer"/>
        public List<string> GetAllColumns<T>() where T : IDataContractComparer
        {
            return CacheManager.GetAllColumns(typeof(T));
        }

        /// <summary>
        /// Retrieves a list of identity columns for a specified data contract type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type implementing the IDataContractComparer interface.</typeparam>
        /// <returns>A list containing the names of identity columns for the specified data contract type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// This method uses reflection to analyze the properties of the specified type <typeparamref name="T"/> and retrieves properties marked with a [Key] attribute, indicating identity columns.
        /// </remarks>
        /// <seealso cref="IDataContractComparer"/>
        public List<string> GetIdentityColumns<T>() where T : IDataContractComparer
        {
            return CacheManager.GetIdentityColumns(typeof(T));
        }

        /// <summary>
        /// Retrieves an array of <see cref="PropertyInfo"/> objects representing the properties that are used for data comparison
        /// in objects of type <typeparamref name="T"/>. These properties are determined based on the implementation of the
        /// <see cref="IDataContractComparer"/> interface.
        /// </summary>
        /// <typeparam name="T">The type of objects for which to retrieve comparable properties.</typeparam>
        /// <returns>An array of <see cref="PropertyInfo"/> objects representing the comparable properties of type <typeparamref name="T"/>.</returns>
        public PropertyInfo[] GetComparableProperties<T>() where T: IDataContractComparer
        {
            return CacheManager.GetComparableProperties(typeof(T));
        }

        /// <summary>
        /// Retrieves an array of <see cref="PropertyInfo"/> objects representing the properties that are used as key properties
        /// for uniquely identifying objects of type <typeparamref name="T"/>. These key properties are determined based on the
        /// implementation of the <see cref="IDataContractComparer"/> interface.
        /// </summary>
        /// <typeparam name="T">The type of objects for which to retrieve key properties.</typeparam>
        /// <returns>An array of <see cref="PropertyInfo"/> objects representing the key properties of type <typeparamref name="T"/>.</returns>
        public PropertyInfo[] GetKeyProperties<T>() where T : IDataContractComparer
        {
            return CacheManager.GetKeyProperties(typeof(T));
        }

    }
}
