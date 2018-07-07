using CheckboxTreeview.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CheckboxTreeview.View
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : UserControl
    {
        private IList<TreeModel> m_ItemsSourceData = null;

        public TreeView()
        {
            InitializeComponent();
        }

        public IList<Model.TreeModel> ItemsSourceData
        {
            get
            {
                return m_ItemsSourceData;
            }
            set
            {
                m_ItemsSourceData = value;
                treeView.ItemsSource = m_ItemsSourceData;
            }
        }

        public int SetCheckedById(string id, IList<TreeModel> treeList)
        {
            foreach (var tree in treeList)
            {
                if (tree.Id.Equals(id))
                {
                    tree.IsChecked = true;
                    return 1;
                }
                if (SetCheckedById(id, tree.Children) == 1)
                {
                    return 1;
                }
            }

            return 0;
        }

        public int SetCheckedById(string id)
        {
            foreach (var tree in ItemsSourceData)
            {
                if (tree.Id.Equals(id))
                {
                    tree.IsChecked = true;
                    return 1;
                }
                if (SetCheckedById(id, tree.Children) == 1)
                {
                    return 1;
                }
            }

            return 0;
        }

        public IList<Model.TreeModel> CheckedItemsIgnoreRelation()
        {

            return GetCheckedItemsIgnoreRelation(m_ItemsSourceData);
        }

        private IList<Model.TreeModel> GetCheckedItemsIgnoreRelation(IList<Model.TreeModel> list)
        {
            IList<Model.TreeModel> treeList = new List<Model.TreeModel>();
            foreach (var tree in list)
            {
                if (tree.IsChecked)
                {
                    treeList.Add(tree);
                }
                foreach (var child in GetCheckedItemsIgnoreRelation(tree.Children))
                {
                    treeList.Add(child);
                }
            }
            return treeList;
        }

        private void menuSelectAllChild_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                Model.TreeModel tree = (Model.TreeModel)treeView.SelectedItem;
                tree.IsChecked = true;
                tree.SetChildrenChecked(true);
            }
        }

        private void menuExpandAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Model.TreeModel tree in treeView.ItemsSource)
            {
                tree.IsExpanded = true;
                tree.SetChildrenExpanded(true);
            }
        }

        private void menuUnExpandAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Model.TreeModel tree in treeView.ItemsSource)
            {
                tree.IsExpanded = false;
                tree.SetChildrenExpanded(false);
            }
        }

        private void menuSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Model.TreeModel tree in treeView.ItemsSource)
            {
                tree.IsChecked = true;
                tree.SetChildrenChecked(true);
            }
        }

        private void menuUnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Model.TreeModel tree in treeView.ItemsSource)
            {
                tree.IsChecked = false;
                tree.SetChildrenChecked(false);
            }
        }

        private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (item != null)
            {
                item.Focus();
                e.Handled = true;
            }
        }
        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }
    }
}
