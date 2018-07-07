using System;
using System.Collections.Generic;

namespace CheckboxTreeview.Model
{
    public interface IDataService
    {
        void GetData(Action<TreeModel, Exception> callback);
        void GetData(Action<IList<TreeModel>, Exception> callback);
    }
}
