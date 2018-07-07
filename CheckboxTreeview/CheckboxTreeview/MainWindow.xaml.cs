using CheckboxTreeview.Model;
using CheckboxTreeview.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace CheckboxTreeview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

            TreeModel sys = new TreeModel("System");

            TreeModel user = new TreeModel("User");
            user.Parent = sys;
            TreeModel role = new TreeModel("Role");
            role.Parent = sys;
            TreeModel function = new TreeModel("Function");
            function.Parent = sys;

            IList<TreeModel> sysChildren = new List<TreeModel>();
            sysChildren.Add(user);
            sysChildren.Add(role);
            sysChildren.Add(function);
            sys.Children = sysChildren;

            TreeModel help = new TreeModel("Help");

            TreeModel about = new TreeModel("About");
            about.Parent = help;
            TreeModel subHelp = new TreeModel("Help");
            subHelp.Parent = help;

            IList<TreeModel> helpChildren = new List<TreeModel>();
            helpChildren.Add(about);
            helpChildren.Add(subHelp);
            help.Children = helpChildren;

            IList<TreeModel> demo = new List<TreeModel>();
            demo.Add(sys);
            demo.Add(help);
            treeViewModel.ItemsSourceData = demo;
        }
    }
}