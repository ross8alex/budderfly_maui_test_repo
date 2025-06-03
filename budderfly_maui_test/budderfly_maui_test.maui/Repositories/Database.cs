using Budderfly_MAUI_Test.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

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
                        //A bug in .NET8+ causes the special folders to not work consistently across android and ios
#if ANDROID
                        _connection = new SQLiteConnection(Path.Combine(
                            Environment.GetFolderPath(SpecialFolder.UserProfile), "BudderflyMauiTestDb1.db3"),
                            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex, true);
#elif IOS
                        _connection = new SQLiteConnection(Path.Combine(
                            Environment.GetFolderPath(SpecialFolder.Personal), "BudderflyMauiTestDb1.db3"), 
                            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex, true);
#endif

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
