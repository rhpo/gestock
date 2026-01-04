using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GEStock.Data;
using GEStock.Models;

namespace GEStock.Services
{
    public static class CategoryService
    {
        public static List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT * FROM Categories ORDER BY Name ASC";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString() ?? "",
                            Description = reader["Description"]?.ToString() ?? ""
                        });
                    }
                }
            }
            return categories;
        }

        public static Category? GetCategoryById(int id)
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT * FROM Categories WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Category
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString() ?? "",
                                Description = reader["Description"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
