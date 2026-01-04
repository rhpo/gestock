using System;
using System.Data.SQLite;
using System.IO;
using GEStock.Models;

namespace GEStock.Data
{
    public class DatabaseManager
    {
        private static DatabaseManager? _instance;
        private string _connectionString = string.Empty;
        private string _dbPath = string.Empty;

        public static DatabaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseManager();
                }
                return _instance;
            }
        }

        private DatabaseManager()
        {
            // Créer le dossier dans Documents si nécessaire
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appFolder = Path.Combine(documentsPath, "GEStock");

            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }

            _dbPath = Path.Combine(appFolder, "gestock.db");
            _connectionString = $"Data Source={_dbPath};Version=3;";

            InitializeDatabase();
        }

        public string GetDatabasePath() => _dbPath;

        private void InitializeDatabase()
        {
            bool isNewDatabase = !File.Exists(_dbPath);

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                if (isNewDatabase)
                {
                    CreateTables(connection);
                    SeedData(connection);
                }
                else
                {
                    // Migration: Add ImagePath if it doesn't exist
                    AddImagePathColumnIfMissing(connection);
                }
            }
        }

        private void CreateTables(SQLiteConnection connection)
        {
            string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    FullName TEXT NOT NULL,
                    Role INTEGER NOT NULL,
                    IsActive INTEGER NOT NULL DEFAULT 1,
                    CreatedAt TEXT NOT NULL
                );";

            string createProductsTable = @"
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Code TEXT NOT NULL UNIQUE,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    CategoryId INTEGER,
                    Price REAL NOT NULL DEFAULT 0,
                    Quantity INTEGER NOT NULL DEFAULT 0,
                    MinQuantity INTEGER NOT NULL DEFAULT 10,
                    CreatedAt TEXT NOT NULL,
                    UpdatedAt TEXT,
                    ImagePath TEXT
                );";

            string createMovementsTable = @"
                CREATE TABLE IF NOT EXISTS Movements (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProductId INTEGER NOT NULL,
                    Type INTEGER NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Reference TEXT,
                    Notes TEXT,
                    UserId INTEGER NOT NULL,
                    CreatedAt TEXT NOT NULL,
                    FOREIGN KEY (ProductId) REFERENCES Products(Id),
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );";

            string createCategoriesTable = @"
                CREATE TABLE IF NOT EXISTS Categories (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL UNIQUE,
                    Description TEXT
                );";

            ExecuteNonQuery(connection, createUsersTable);
            ExecuteNonQuery(connection, createProductsTable);
            ExecuteNonQuery(connection, createMovementsTable);
            ExecuteNonQuery(connection, createCategoriesTable);
        }

        private void SeedData(SQLiteConnection connection)
        {
            // Créer les utilisateurs par défaut
            string insertAdmin = @"
                INSERT INTO Users (Username, Password, FullName, Role, IsActive, CreatedAt)
                VALUES ('admin', 'admin123', 'Administrateur Système', 1, 1, @date);";

            string insertMagasinier = @"
                INSERT INTO Users (Username, Password, FullName, Role, IsActive, CreatedAt)
                VALUES ('magasinier', 'mag123', 'Magasinier Principal', 2, 1, @date);";

            string insertUser = @"
                INSERT INTO Users (Username, Password, FullName, Role, IsActive, CreatedAt)
                VALUES ('utilisateur', 'user123', 'Utilisateur Simple', 3, 1, @date);";

            using (var cmd = new SQLiteCommand(insertAdmin, connection))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(insertMagasinier, connection))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(insertUser, connection))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }

            // Créer quelques catégories
            ExecuteNonQuery(connection, "INSERT INTO Categories (Name, Description) VALUES ('Électronique', 'Produits électroniques');");
            ExecuteNonQuery(connection, "INSERT INTO Categories (Name, Description) VALUES ('Informatique', 'Matériel informatique');");
            ExecuteNonQuery(connection, "INSERT INTO Categories (Name, Description) VALUES ('Fournitures', 'Fournitures de bureau');");

            // Créer quelques produits de test
            string insertProduct1 = @"
                INSERT INTO Products (Code, Name, Description, CategoryId, Price, Quantity, MinQuantity, CreatedAt)
                VALUES ('PROD001', 'Ordinateur Portable HP', 'HP EliteBook 840 G8', 2, 45000, 15, 5, @date);";

            string insertProduct2 = @"
                INSERT INTO Products (Code, Name, Description, CategoryId, Price, Quantity, MinQuantity, CreatedAt)
                VALUES ('PROD002', 'Souris Logitech', 'Souris sans fil', 2, 2500, 50, 10, @date);";

            string insertProduct3 = @"
                INSERT INTO Products (Code, Name, Description, CategoryId, Price, Quantity, MinQuantity, CreatedAt)
                VALUES ('PROD003', 'Clavier Mécanique', 'Clavier gaming RGB', 2, 8500, 8, 10, @date);";

            using (var cmd = new SQLiteCommand(insertProduct1, connection))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(insertProduct2, connection))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(insertProduct3, connection))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }
        }

        private void AddImagePathColumnIfMissing(SQLiteConnection connection)
        {
            try
            {
                string checkColumnQuery = "PRAGMA table_info(Products);";
                bool hasImagePath = false;
                using (var cmd = new SQLiteCommand(checkColumnQuery, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["name"].ToString() == "ImagePath")
                        {
                            hasImagePath = true;
                            break;
                        }
                    }
                }

                if (!hasImagePath)
                {
                    ExecuteNonQuery(connection, "ALTER TABLE Products ADD COLUMN ImagePath TEXT;");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error migrating database: {ex.Message}");
            }
        }

        private void ExecuteNonQuery(SQLiteConnection connection, string query)
        {
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
