using Dapper;
using Microsoft.Extensions.Configuration;
using MWSFDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MWSFDataAccess.DataService
{
    public abstract class AbstractGenericDataService<T> : IGenericDataService<T> where T : IDatabaseModel
    {
        protected string TableName; //assigned in base classes
        protected bool AutoIncrementId; //Some models do not have auto-incrementing so we want to capture that

        private readonly IConfiguration _config;

        public AbstractGenericDataService(IConfiguration config)
        {
            _config = config;
            TableName = "";
            AutoIncrementId = true;
        }
        protected string LoadConnectionString()
        {
            return _config.GetConnectionString(DataServiceConstants.DbName);
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        #region Crud
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                return (await db.QueryAsync<T>($"SELECT * FROM {TableName}")).ToList();
            }
        }

        public async Task DeleteRowAsync(ulong id)
        {
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                await db.ExecuteAsync($"DELETE FROM {TableName} WHERE Id=@Id", new { Id = id });
            }
        }

        public async Task<T> GetAsync(ulong id)
        {
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                var result = await db.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {TableName} WHERE Id=@Id", new { Id = id });

                if (result == null)
                {
                    Console.WriteLine($"{TableName} with id [{id}] could not be found.");
                }

                return result;
            }
        }

        public async Task<IEnumerable<T>> GetFirstXRows(int numRows)
        {
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                var query = $"Select * from {TableName} limit @NumRows";
                return (await db.QueryAsync<T>(query, new { NumRows = numRows })).ToList();
            }
        }

        public async Task<int> SaveRangeAsync(IEnumerable<T> list)
        {
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                inserted += await db.ExecuteAsync(query, list);
            }

            return inserted;
        }

        public async Task UpdateAsync(T t)
        {
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                var query = GenerateUpdateQuery();
                await db.ExecuteAsync(query, new DynamicParameters(t));
            }
        }

        public async Task InsertAsync(T t)
        {
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                var query = GenerateInsertQuery();
                await db.ExecuteAsync(query, t);
            }
        }
        #endregion

        #region QueryGenerators    
        //Get list of properties from a class, these will be used as column names for insert statements
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        //Dynamically generate the insert query based on properties in a model
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {TableName} ");

            insertQuery.Append("(");

            //Get list of properties from model
            var properties = GenerateListOfProperties(GetProperties);

            //Add each property as a column name (we don't want to use Id if it auto increments)
            properties.ForEach(property =>
            {
                if (property.ToLower().Equals("id") && AutoIncrementId) return;
                insertQuery.Append($"[{property}],");
            });

            //replace last open paren with closed one
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            //Add each value individually as a variable
            properties.ForEach(property =>
            {
                if (property.ToLower().Equals("id") && AutoIncrementId) return;
                insertQuery.Append($"@{property},");
            });

            //replace last open paren with a closed one
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            //Finally, return completed string
            return insertQuery.ToString();
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {TableName} SET ");

            var properties = GenerateListOfProperties(GetProperties);

            //Iterate each property except ID (since we use that to find the row and do not want to change it)
            //Also do not update created row
            properties.ForEach(property =>
            {
                if (!property.ToLower().Equals("id") && !property.ToLower().Equals("created"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            //Remove last comma from query
            updateQuery.Remove(updateQuery.Length - 1, 1);

            //Append where statement to ensure we are updating the correct row.
            updateQuery.Append(" WHERE Id=@Id");

            //Finally, return completed string
            return updateQuery.ToString();
        }
        #endregion
    
    }
}
