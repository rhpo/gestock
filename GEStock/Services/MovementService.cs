using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GEStock.Data;
using GEStock.Models;

namespace GEStock.Services
{
    public class MovementService
    {
        public static bool AddMovement(Movement movement)
        {
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insérer le mouvement
                        string insertQuery = @"INSERT INTO Movements (ProductId, Type, Quantity, Reference, Notes, UserId, CreatedAt)
                                             VALUES (@prodId, @type, @qty, @ref, @notes, @userId, @created)";

                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@prodId", movement.ProductId);
                            cmd.Parameters.AddWithValue("@type", (int)movement.Type);
                            cmd.Parameters.AddWithValue("@qty", movement.Quantity);
                            cmd.Parameters.AddWithValue("@ref", movement.Reference ?? "");
                            cmd.Parameters.AddWithValue("@notes", movement.Notes ?? "");
                            cmd.Parameters.AddWithValue("@userId", movement.UserId);
                            cmd.Parameters.AddWithValue("@created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            cmd.ExecuteNonQuery();
                        }

                        // Mettre à jour la quantité du produit
                        string selectQuery = "SELECT Quantity FROM Products WHERE Id = @id";
                        int currentQty = 0;

                        using (var cmd = new SQLiteCommand(selectQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", movement.ProductId);
                            currentQty = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        int newQty = movement.Type == MovementType.Entree
                            ? currentQty + movement.Quantity
                            : currentQty - movement.Quantity;

                        if (newQty < 0)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        string updateQuery = @"UPDATE Products SET Quantity = @qty, UpdatedAt = @updated WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@qty", newQty);
                            cmd.Parameters.AddWithValue("@updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@id", movement.ProductId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        System.Diagnostics.Debug.WriteLine($"Error adding movement: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public static List<Movement> GetAllMovements()
        {
            var movements = new List<Movement>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = "SELECT * FROM Movements ORDER BY CreatedAt DESC";
                using (var cmd = new SQLiteCommand(query, connection))
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
            return movements;
        }

        public static bool DeleteMovement(int movementId)
        {
            // Note: En production, il faudrait aussi restaurer la quantité du produit
            try
            {
                using (var connection = DatabaseManager.Instance.GetConnection())
                {
                    string query = "DELETE FROM Movements WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", movementId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<dynamic> GetMovementsWithDetails()
        {
            var movements = new List<dynamic>();
            using (var connection = DatabaseManager.Instance.GetConnection())
            {
                string query = @"SELECT m.Id, m.CreatedAt, m.Type, m.Quantity, m.Reference, m.Notes,
                                       p.Code, p.Name, u.FullName, p.ImagePath
                                FROM Movements m
                                INNER JOIN Products p ON m.ProductId = p.Id
                                INNER JOIN Users u ON m.UserId = u.Id
                                ORDER BY m.CreatedAt DESC";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movements.Add(new
                        {
                            Id = reader.GetInt32(0),
                            Date = DateTime.Parse(reader.GetString(1)),
                            Type = (MovementType)reader.GetInt32(2),
                            TypeName = (MovementType)reader.GetInt32(2) == MovementType.Entree ? "Entrée" : "Sortie",
                            Quantity = reader.GetInt32(3),
                            Reference = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Notes = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            ProductCode = reader.GetString(6),
                            ProductName = reader.GetString(7),
                            UserName = reader.GetString(8),
                            ProductImage = reader.IsDBNull(9) ? null : reader.GetString(9)
                        });
                    }
                }
            }
            return movements;
        }
    }
}
