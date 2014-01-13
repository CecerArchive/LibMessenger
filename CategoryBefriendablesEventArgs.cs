using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHI.Server.Events;
using IHI.Server.Habbos;
using IHI.Server.Habbos.Messenger;

namespace IHI.Server.Plugins.LibMessenger
{
    public class CategoryBefriendablesEventArgs : IHIEventArgs
    {
        private readonly HashSet<Befriendable> _befriendables;
 
        public Category Category
        {
            get; 
            private set;
        }

        public CategoryBefriendablesEventArgs(Category category)
        {
            Category = category;
            _befriendables = new HashSet<Befriendable>();
            Cancellable = false;
        }

        public IEnumerable<Befriendable> GetBefriendables()
        {
            return _befriendables;
        }

        public CategoryBefriendablesEventArgs AddBefriendable(Befriendable befriendable)
        {
            _befriendables.Add(befriendable);
            return this;
        }
    }
}
