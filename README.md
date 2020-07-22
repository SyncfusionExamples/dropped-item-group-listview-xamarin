# How to get the dropped item group in Xamarin.Forms ListView (SfListView)

You can get the drop item group in Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview?) using [DisplayItems](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.DataSource.Portable~Syncfusion.DataSource.DisplayItems.html?).

You can also refer the following article.

https://www.syncfusion.com/kb/11436/how-to-get-the-dropped-item-group-in-xamarin-forms-listview-sflistview

**C#**

Get the group details after dragging in [ItemDragging](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemDragging_EV.html?) event when the action is **Drop**. Get the drop item index using [NewIndex](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemDraggingEventArgs~NewIndex.html?) from [ItemDraggingEventArgs](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemDraggingEventArgs.html?).

``` C#
namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        SfListView ListView;
 
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            ListView.ItemDragging += ListView_ItemDragging;
 
            base.OnAttachedTo(bindable);
        }
 
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
                if(itemData is GroupResult)
                {
                    if (args.OldIndex > args.NewIndex && item == itemData) break;
                    if (item is GroupResult) itemGroup = item as GroupResult;
                    if (args.OldIndex < args.NewIndex && item == itemData) break;
                }
                else
                {
                    if (item == itemData) break;
                    if (item is GroupResult) itemGroup = item as GroupResult;
                }
            }
            return itemGroup;
        }
    }
}
```
 **Output**
 
 ![DroppedItemGroup](https://github.com/SyncfusionExamples/dropped-item-group-listview-xamarin/blob/master/ScreenShots/DroppedItemGroup.gif)    
