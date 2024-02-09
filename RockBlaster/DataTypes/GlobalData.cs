using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockBlaster.DataTypes
{
    public static class GlobalData
    {
        public static PlayerData PlayerData
        {
            get;
            private set;
        } = new PlayerData();
    }
}
