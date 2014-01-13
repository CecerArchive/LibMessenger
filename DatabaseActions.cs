using System;

using System.Collections.Generic;
using IHI.Server.Database;
using MySql.Data.MySqlClient;

namespace IHI.Server.Plugins.LibMessenger
{
    public static class DatabaseActions
    {
        #region Action: GetCategoryIdsFromHabboId
        /// <summary>
        ///   
        /// </summary>
        /// <param name="habboId">The Habbo ID to match.</param>
        /// <param name="connection">The connection to use. If not specified (or null) then a connection will be picked automatically.</param>
        /// <returns></returns>
        public static IEnumerable<int> GetCategoryIdsFromHabboId(int habboId, WrappedMySqlConnection connection = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@habbo_id"] = habboId;

            List<int> categoryIds = new List<int>();

            using (connection = connection ?? CoreManager.ServerCore.MySqlConnectionProvider.GetConnection())
            {
                using (MySqlDataReader reader = connection.GetCommand("SELECT `category_id` FROM `messenger_habbo_categories` WHERE `habbo_id` = @habbo_id").ExecuteReader(parameters))
                {
                    while (reader.Read())
                    {
                        categoryIds.Add((int)reader["category_id"]);
                    }

                    return categoryIds;
                }
            }
        }
        #endregion

        #region Action: GetCategoryIdsFromHabboId
        /// <summary>
        ///   
        /// </summary>
        /// <param name="habboId">The category ID to match.</param>
        /// <param name="connection">The connection to use. If not specified (or null) then a connection will be picked automatically.</param>
        /// <returns></returns>
        public static string GetCategoryNameFromCategoryId(int categoryId, WrappedMySqlConnection connection = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@category_id"] = categoryId;

            return CoreManager.ServerCore.MySqlConnectionProvider.HelperGetAction<string>("SELECT `category_name` FROM `messenger_categories` WHERE `category_id` = @category_id", parameters, connection);
        }
        #endregion

        #region Action: GetBefriendableHabboIdsFromCategoryId
        /// <summary>
        ///   
        /// </summary>
        /// <param name="categoryId">The category ID to match.</param>
        /// <param name="connection">The connection to use. If not specified (or null) then a connection will be picked automatically.</param>
        /// <returns></returns>
        public static IEnumerable<int> GetBefriendableHabboIdsFromCategoryId(int categoryId, WrappedMySqlConnection connection = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@category_id"] = categoryId;

            List<int> habboIds = new List<int>();

            using (connection = connection ?? CoreManager.ServerCore.MySqlConnectionProvider.GetConnection())
            {
                using (MySqlDataReader reader = connection.GetCommand("SELECT `habbo_id` FROM `messenger_habbo_friendships` WHERE `category_id` = @category_id").ExecuteReader(parameters))
                {
                    while (reader.Read())
                    {
                        habboIds.Add((int)reader["habbo_id"]);
                    }

                    return habboIds;
                }
            }
        }
        #endregion
        
    }
}