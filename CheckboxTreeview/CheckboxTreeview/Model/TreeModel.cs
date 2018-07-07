using System.Collections.Generic;
using System.ComponentModel;

namespace CheckboxTreeview.Model
{
    public class TreeModel : INotifyPropertyChanged
    {
        #region Private 
        private string m_Id = string.Empty;
        private string m_Name = string.Empty;
        private string m_Icon = string.Empty;
        private bool m_IsChecked = false;
        private bool m_IsExpanded = false;
        private IList<TreeModel> m_Children = null;
        private TreeModel m_Parent = null;
        #endregion

        #region  Property

        public string Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public string Icon
        {
            get
            {
                return m_Icon;
            }
            set
            {
                m_Icon = value;
            }
        }

        public bool IsChecked
        {
            get
            {
                return m_IsChecked;
            }
            set
            {
                if (value != m_IsChecked)
                {
                    m_IsChecked = value;
                    NotifyPropertyChanged("IsChecked");

                    if (m_IsChecked)
                    {
                        if (Parent != null)
                        {
                            Parent.IsChecked = true;
                        }
                    }
                    else
                    {
                        foreach (TreeModel child in m_Children)
                        {
                            child.IsChecked = false;
                        }
                    }
                }
            }
        }



        public bool IsExpanded
        {
            get
            {
                return m_IsExpanded;
            }
            set
            {
                if (m_IsExpanded != value)
                {
                    m_IsExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }
        }

        public IList<TreeModel> Children
        {
            get
            {
                return m_Children;
            }
            set
            {
                m_Children = value;
            }
        }

        public TreeModel Parent
        {
            get
            {
                return m_Parent;
            }
            set
            {
                m_Parent = value;
            }
        }

        public string Tooltip
        {
            get
            {
                return string.Format("{0}-{1}", m_Id, m_Name);
            }
        }

        public string Title
        {
            get;
            set;
        }

        #endregion

        public void SetChildrenChecked(bool a_IsChecked)
        {
            foreach (TreeModel child in m_Children)
            {
                child.IsChecked = a_IsChecked;
                child.SetChildrenChecked(a_IsChecked);
            }
        }

        public void SetChildrenExpanded(bool a_IsExpended)
        {
            foreach (TreeModel child in m_Children)
            {
                child.IsExpanded = a_IsExpended;
                child.SetChildrenExpanded(a_IsExpended);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string a_Info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(a_Info));
            }
        }

        public TreeModel(string a_Name)
        {
            m_Children = new List<TreeModel>();
            m_IsChecked = false;
            m_IsExpanded = false;
            m_Icon = string.Empty;
            m_Name = a_Name;
        }


    }
}