using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHI.Server.Events;
using IHI.Server.Habbos;

namespace IHI.Server.Plugins.LibMessenger
{
    public class CategoryHabboEventArgs : HabboEventArgs
    {
        private readonly HashSet<Category> _categories;

        public CategoryHabboEventArgs(Habbo habbo): base(habbo)
        {
            _categories = new HashSet<Category>();
            Cancellable = false;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public CategoryHabboEventArgs AddCategory(Category category)
        {
            _categories.Add(category);
            return this;
        }
    }
}
