using System;
using System.Data.SQLite;
using GEStock.Data;
using GEStock.Models;

namespace GEStock.Services
{
    public class AuthService
    {
        private static User? _currentUser;

        public static User? CurrentUser
        {
            get => _currentUser;
            private set => _currentUser = value;
        }

        public static bool IsAuthenticated => CurrentUser != null;

        public static User? Login(string username, string password)
        {
            try
            {
                using (var connection = DatabaseManager.Instance.GetConnection())
                {
                    string query = @"
                        SELECT Id, Username, Password, FullName, Role, IsActive, CreatedAt
                        FROM Users
                        WHERE Username = @username AND Password = @password AND IsActive = 1";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CurrentUser = new User
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    FullName = reader.GetString(3),
                                    Role = (UserRole)reader.GetInt32(4),
                                    IsActive = reader.GetInt32(5) == 1,
                                    CreatedAt = DateTime.Parse(reader.GetString(6))
                                };

                                return CurrentUser;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Login error: {ex.Message}");
            }

            return null;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool HasRole(UserRole role)
        {
            return IsAuthenticated && CurrentUser?.Role == role;
        }

        public static bool HasMinimumRole(UserRole minimumRole)
        {
            if (!IsAuthenticated || CurrentUser == null) return false;
            return CurrentUser.Role <= minimumRole;
        }
    }
}
