using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHI.Server.Habbos;
using IHI.Server.Habbos.Messenger;

namespace IHI.Server.Plugins.LibMessenger
{
    public class Category
    {
        private readonly HashSet<Befriendable> _befriendables;

        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            set;
        }

        #region Method: Category (Constructor)
        public Category(int categoryId, string name = "")
        {
            Id = categoryId;
            Name = name;
            _befriendables = new HashSet<Befriendable>();
        }
        #endregion
        
        internal void AddFriend(Befriendable friend)
        {
            _befriendables.Add(friend);
        }
        internal void RemoveFriend(Befriendable friend)
        {
            _befriendables.Remove(friend);
        }

        public IEnumerable<Befriendable> GetFriends()
        {
            return _befriendables;
        }
    }
}
