using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GEStock.Data;
using GEStock.Models;

namespace GEStock.Services
{
    public class StatsService
    {
        public static int GetTotalProducts()
        {
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Products";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static int GetLowStockCount()
        {
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Products WHERE Quantity <= MinQuantity";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static int GetRecentMovementsCount(int days = 7)
        {
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT COUNT(*) FROM Movements
                                WHERE CreatedAt >= @startDate";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@startDate",
                        DateTime.Now.AddDays(-days).ToString("yyyy-MM-dd HH:mm:ss"));
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static decimal GetTotalStockValue()
        {
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT SUM(Price * Quantity) FROM Products";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

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
                            UpdatedAt = reader.IsDBNull(9) ? null : DateTime.Parse(reader.GetString(9))
                        });
                    }
                }
            }
            return products;
        }

        public static List<Movement> GetRecentMovements(int limit = 10)
        {
            var movements = new List<Movement>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT * FROM Movements ORDER BY CreatedAt DESC LIMIT @limit";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@limit", limit);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movements.Add(new Movement
                            {
                                Id = reader.GetInt32(0),
                                ProductId = reader.GetInt32(1),
                                Type = (MovementType)reader.GetInt32(2),
                                Quantity = reader.GetInt32(3),
                                Reference = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Notes = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                UserId = reader.GetInt32(6),
                                CreatedAt = DateTime.Parse(reader.GetString(7))
                            });
                        }
                    }
                }
            }
            return movements;
        }
        public static List<int> GetDailyMovementCounts(int days = 10)
        {
            var counts = new List<int>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                for (int i = days - 1; i >= 0; i--)
                {
                    string dateStr = DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd");
                    string query = "SELECT COUNT(*) FROM Movements WHERE CreatedAt LIKE @date";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@date", dateStr + "%");
                        counts.Add(Convert.ToInt32(cmd.ExecuteScalar()));
                    }
                }
            }
            return counts;
        }

        public static List<(string Name, int Count, string? ImagePath)> GetTopProducts(int limit = 5)
        {
            var top = new List<(string Name, int Count, string? ImagePath)>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT p.Name, COUNT(m.Id) as MoveCount, p.ImagePath
                                FROM Products p
                                JOIN Movements m ON p.Id = m.ProductId
                                GROUP BY p.Id
                                ORDER BY MoveCount DESC
                                LIMIT @limit";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@limit", limit);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            top.Add((reader.GetString(0), reader.GetInt32(1), reader.IsDBNull(2) ? null : reader.GetString(2)));
                        }
                    }
                }
            }
            return top;
        }

        public static int GetProductsWithoutImagesCount()
        {
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Products WHERE ImagePath IS NULL OR ImagePath = ''";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<string> GetCriticalStockNames()
        {
            var names = new List<string>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT Name FROM Products WHERE Quantity < (MinQuantity * 0.2)";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) names.Add(reader.GetString(0));
                }
            }
            return names;
        }

        public static List<string> GetHighValueLowSalesNames()
        {
            var names = new List<string>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                // Products with price > average price AND movements < 2
                string query = @"SELECT p.Name FROM Products p
                                LEFT JOIN Movements m ON p.Id = m.ProductId
                                WHERE p.Price > (SELECT AVG(Price) FROM Products)
                                GROUP BY p.Id
                                HAVING COUNT(m.Id) < 2
                                LIMIT 3";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) names.Add(reader.GetString(0));
                }
            }
            return names;
        }

        public static List<string> GetStagnantProducts(int days = 30)
        {
            var names = new List<string>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string dateStr = DateTime.Now.AddDays(-days).ToString("yyyy-MM-dd HH:mm:ss");
                string query = @"SELECT Name FROM Products
                                WHERE Id NOT IN (SELECT ProductId FROM Movements WHERE CreatedAt > @date)
                                LIMIT 3";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@date", dateStr);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) names.Add(reader.GetString(0));
                    }
                }
            }
            return names;
        }
    }
}
