using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHI.Server.Plugins.LibMessenger
{
    public static class ExtensionMethods
    {
        private static Dictionary<ServerCore, LibMessenger> _pluginInstanceLookup = new Dictionary<ServerCore, LibMessenger>();

        internal static void RegisterPluginInstance(ServerCore serverCore, LibMessenger pluginInstance)
        {
            _pluginInstanceLookup[serverCore] = pluginInstance;
        }

        public static MessengerManager GetMessengerManager(this ServerCore serverCore)
        {
            return _pluginInstanceLookup[serverCore].MessengerManager;
        }
    }
}
