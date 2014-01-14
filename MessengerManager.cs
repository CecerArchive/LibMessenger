using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHI.Server.Habbos;
using IHI.Server.Habbos.Messenger;
using IHI.Server.Useful;

namespace IHI.Server.Plugins.LibMessenger
{
    public class MessengerManager
    {
        private LibMessenger _pluginInstance;
        private WeakCache<int, Category> _categoryCache;

        public MessengerManager(LibMessenger pluginInstance)
        {
            _pluginInstance = pluginInstance;
            _categoryCache = new WeakCache<int, Category>(LoadCategory);

            CoreManager.ServerCore.EventManager.StrongBind<CategoryHabboEventArgs>(_pluginInstance.Id + ":habbo_category_request:before", LoadHabboCategoriesFromDatabase);
            CoreManager.ServerCore.EventManager.StrongBind<CategoryBefriendablesEventArgs>(_pluginInstance.Id + ":category_friendship_request:before", LoadCategoryHabboBefriendablesFromDatabase);
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryCache[categoryId];
        }

        public IEnumerable<Category> GetCategories(Habbo habbo)
        {
            CategoryHabboEventArgs eventArgs = new CategoryHabboEventArgs(habbo);
            _pluginInstance.EventFirer.Fire(_pluginInstance.Id + ":habbo_category_request:before", eventArgs);
            _pluginInstance.EventFirer.Fire(_pluginInstance.Id + ":habbo_category_request:after", eventArgs);

            return eventArgs.GetCategories();
        }

        public Befriendable GetBefriendable(Habbo habbo)
        {
            Befriendable befriendableInstance = habbo.InstanceStorage[_pluginInstance, "befriendable_instance"];

            if (befriendableInstance == null)
            {
                befriendableInstance = new Befriendable(
                    (() => habbo.Id),
                    (() => habbo.DisplayName),
                    (() => habbo.Motto),
                    (() => habbo.Figure),
                    (() => habbo.Position),
                    (() => habbo.LoggedIn),
                    (() => habbo.LastAccess));

                habbo.InstanceStorage[_pluginInstance, "befriendable_instance"] = befriendableInstance;
            }
            return befriendableInstance;
        }

        public MessengerManager AddBefriendableToCategory(Befriendable befriendable, Category category)
        {
            category.AddFriend(befriendable);
            return this;
        }

        public MessengerManager RemoveBefriendableFromCategory(Befriendable befriendable, Category category)
        {
            category.RemoveFriend(befriendable);
            return this;
        }

        private Category LoadCategory(int categoryId)
        {
            string categoryName = DatabaseActions.GetCategoryNameFromCategoryId(categoryId);

            if (categoryName == null)
                return null;

            return new Category(categoryId, categoryName);
        }

        private void LoadHabboCategoriesFromDatabase(CategoryHabboEventArgs eventArgs)
        {
            foreach (int categoryId in DatabaseActions.GetCategoryIdsFromHabboId(eventArgs.Habbo.Id))
            {
                eventArgs.AddCategory(GetCategory(categoryId));
            }
        }

        private void LoadCategoryHabboBefriendablesFromDatabase(CategoryBefriendablesEventArgs eventArgs)
        {
            foreach (int habboId in DatabaseActions.GetBefriendableHabboIdsFromCategoryId(eventArgs.Category.Id))
            {
                eventArgs.AddBefriendable(GetBefriendable(CoreManager.ServerCore.HabboDistributor[habboId]));
            }
        }

    }
}
