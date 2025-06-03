using Budderfly_MAUI_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budderfly_MAUI_Test.Repositories
{
    public class EnergySavingTipDAL
    {
        public List<EnergySavingTip> GetEnergySavingTips()
        {
            lock (Database.CollisionLock)
                return Database.Connection.Table<EnergySavingTip>().ToList();
        }

        public int SaveOrUpdateEnergySavingTip(EnergySavingTip energySavingTip)
        {
            lock (Database.CollisionLock)
            {
                if (energySavingTip.Id == 0 || GetEnergySavingTipById(energySavingTip.Id) == null)
                    return Database.Connection.Insert(energySavingTip);
                else
                    return Database.Connection.Update(energySavingTip);
            }
        }

        public List<EnergySavingTip> InsertAllEnergySavingTips(List<EnergySavingTip> energySavingTips)
        {
            lock (Database.CollisionLock)
            {
                Database.Connection.InsertAll(energySavingTips);

                return GetEnergySavingTips();
            }
        }

        public EnergySavingTip GetEnergySavingTipById(int id)
        {
            lock (Database.CollisionLock)
                return Database.Connection.Get<EnergySavingTip>(id);
        }
    }
}
