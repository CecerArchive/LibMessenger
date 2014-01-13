using IHI.Server;
using IHI.Server.Events;

namespace IHI.Server.Plugins.LibMessenger
{
    public class LibMessenger : Plugin
    {
        public override string Id
        {
            get
            {
                return "cecer:libmessenger";
            }
        }

        public override string Name
        {
            get
            {
                return "LibMessenger";
            }
        }

        public MessengerManager MessengerManager
        {
            get;
            private set;
        }


        internal EventFirer EventFirer
        {
            get;
            private set;
        }

        /// <summary>
        ///   Called when the plugin is started.
        /// </summary>
        public override void Start(EventFirer eventFirer)
        {
            EventFirer = eventFirer;

            MessengerManager = new MessengerManager(this);
            ExtensionMethods.RegisterPluginInstance(CoreManager.ServerCore, this);
        }
    }
}