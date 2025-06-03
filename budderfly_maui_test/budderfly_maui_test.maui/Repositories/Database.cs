using Budderfly_MAUI_Test.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Budderfly_MAUI_Test.Repositories
{
    public static class Database
    {
        public static object CollisionLock = new object();

        public static SQLiteConnection _connection;
        public static SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    try
                    {
                        _connection = new SQLiteConnection(Path.Combine(
                            Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "BudderflyMauiTestDb1.db3"), 
                            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex, true);

                        _connection.CreateTable<EnergySavingTip>();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }

                return _connection;
            }
        }
    }
}
