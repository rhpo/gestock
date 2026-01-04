using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GEStock.Data;
using GEStock.Models;

namespace GEStock.Services
{
    public class ProductService
    {
        public static List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT * FROM Products ORDER BY Name";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Code = reader.GetString(1),
                            Name = reader.GetString(2),
                            Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            CategoryId = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            Quantity = reader.GetInt32(6),
                            MinQuantity = reader.GetInt32(7),
                            CreatedAt = DateTime.Parse(reader.GetString(8)),
                            UpdatedAt = reader.IsDBNull(9) ? null : DateTime.Parse(reader.GetString(9)),
                            ImagePath = reader.IsDBNull(10) ? null : reader.GetString(10)
                        });
                    }
                }
            }
            return products;
        }

        public static Product? GetProductByCode(string code)
        {
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT * FROM Products WHERE Code = @code";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                Id = reader.GetInt32(0),
                                Code = reader.GetString(1),
                                Name = reader.GetString(2),
                                Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                CategoryId = reader.GetInt32(4),
                                Price = reader.GetDecimal(5),
                                Quantity = reader.GetInt32(6),
                                MinQuantity = reader.GetInt32(7),
                                CreatedAt = DateTime.Parse(reader.GetString(8)),
                                UpdatedAt = reader.IsDBNull(9) ? null : DateTime.Parse(reader.GetString(9)),
                                ImagePath = reader.IsDBNull(10) ? null : reader.GetString(10)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool AddProduct(Product product)
        {
            try
            {
                using (var connection = DatabaseManager.Instance.GetConnection())
                {
                    string query = @"INSERT INTO Products (Code, Name, Description, CategoryId, Price, Quantity, MinQuantity, CreatedAt, ImagePath)
                                   VALUES (@code, @name, @desc, @catId, @price, @qty, @minQty, @created, @image)";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", product.Code);
                        cmd.Parameters.AddWithValue("@name", product.Name);
                        cmd.Parameters.AddWithValue("@desc", product.Description ?? "");
                        cmd.Parameters.AddWithValue("@catId", product.CategoryId);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@qty", product.Quantity);
                        cmd.Parameters.AddWithValue("@minQty", product.MinQuantity);
                        cmd.Parameters.AddWithValue("@created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@image", (object?)product.ImagePath ?? DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
        }

        public static bool UpdateProduct(Product product)
        {
            try
            {
                using (var connection = DatabaseManager.Instance.GetConnection())
                {
                    string query = @"UPDATE Products
                                   SET Name = @name, Description = @desc, CategoryId = @catId,
                                       Price = @price, Quantity = @qty, MinQuantity = @minQty,
                                       UpdatedAt = @updated, ImagePath = @image
                                   WHERE Code = @code";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", product.Code);
                        cmd.Parameters.AddWithValue("@name", product.Name);
                        cmd.Parameters.AddWithValue("@desc", product.Description ?? "");
                        cmd.Parameters.AddWithValue("@catId", product.CategoryId);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@qty", product.Quantity);
                        cmd.Parameters.AddWithValue("@minQty", product.MinQuantity);
                        cmd.Parameters.AddWithValue("@updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@image", (object?)product.ImagePath ?? DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }

        public static bool DeleteProduct(string code)
        {
            try
            {
                using (var connection = DatabaseManager.Instance.GetConnection())
                {
                    string query = "DELETE FROM Products WHERE Code = @code";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", code);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }

        public static bool UpdateProductQuantity(int productId, int newQuantity)
        {
            try
            {
                using (var connection = DatabaseManager.Instance.GetConnection())
                {
                    string query = @"UPDATE Products SET Quantity = @qty, UpdatedAt = @updated WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@qty", newQuantity);
                        cmd.Parameters.AddWithValue("@updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@id", productId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
