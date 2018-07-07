using CheckboxTreeview.Model;
using System;
using System.Collections.Generic;

namespace CheckboxTreeview.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<TreeModel, Exception> callback)
        {
            // Use this to create design time data

            var item = new TreeModel("Welcome to MVVM Light [design]");
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