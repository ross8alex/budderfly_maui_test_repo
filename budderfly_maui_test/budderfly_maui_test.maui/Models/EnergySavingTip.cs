using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budderfly_MAUI_Test.Models
{
    public class EnergySavingTip
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }

        public string EnergyTipTitle { get; set; }
        public string EnergyTipDescription { get; set; }
        public string EnergyTipImage { get; set; }
        public bool HasImage { get; set; }
    }
}
