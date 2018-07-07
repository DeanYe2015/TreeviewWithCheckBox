using System;
using System.Collections.Generic;

namespace CheckboxTreeview.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<TreeModel, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new TreeModel("Welcome to MVVM Light");
            callback(item, null);
        }

        public void GetData(Action<IList<TreeModel>, Exception> callback)
        {
            IList<TreeModel> items = new List<TreeModel>();
            TreeModel item = new TreeModel("System");
            TreeModel item1 = new TreeModel("User");
            TreeModel item2 = new TreeModel("Role");
            TreeModel item3 = new TreeModel("Function");

            items.Add(item);
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            callback(items, null);
        }
    }
}