using Syncfusion.DataSource.Extensions;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields

        SfListView ListView;
        #endregion

        #region Overrides

        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            ListView.ItemDragging += ListView_ItemDragging;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView.ItemDragging -= ListView_ItemDragging;
            ListView = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Private methods
        private void ListView_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            if (e.Action == DragAction.Drop)
            {
                int dropIndex = e.NewIndex;
                var dropItem = ListView.DataSource.DisplayItems[dropIndex];
                var dropedGroup = GetGroup(dropItem);

                App.Current.MainPage.DisplayAlert("Dropped group", "" + dropedGroup.Key, "Ok");
            }
        }

        public GroupResult GetGroup(object itemData)
        {
            GroupResult itemGroup = null;

            foreach (var item in this.ListView.DataSource.DisplayItems)
            {
                if (item is GroupResult)
                    itemGroup = item as GroupResult;

                if (item == itemData)
                    break;
            }
            return itemGroup;
        }
        #endregion
    }
}