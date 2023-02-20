using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Infra.Configs
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return "Server=containers-us-west-67.railway.app;Port=7210;Database=railway;Uid=root;Pwd=QJ2Ao4xN05fwz1Ekdg6S";
        }
    }
}
