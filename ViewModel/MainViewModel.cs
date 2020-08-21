using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Xml.Linq;

namespace DisplayIDN
{
    public class MainViewModel : ViewModelBase
    {

        private ObservableCollection<IDNGroupItem> groups;
        public ObservableCollection<IDNGroupItem> Groups
        {
            get { return groups; }
            set { groups = value; RaisePropertyChanged(() => Groups); }
        }


        public MainViewModel()
        {
            Groups = new ObservableCollection<IDNGroupItem>();
            XDocument xml = XDocument.Load(@"Group.xml");
            foreach (var itemNodeOne in xml.Root.Elements())
            {
                string headerOne = itemNodeOne.Attribute("Header").Value;
                IDNGroupItem itemOne = new IDNGroupItem();
                itemOne.Header = headerOne;
                itemOne.HasChild = true;
                itemOne.Childs = new ObservableCollection<IDNGroupItem>();
                foreach (var itemNodeTwo in itemNodeOne.Elements())
                {
                    string headerTwo = itemNodeTwo.Attribute("Header").Value;
                    IDNGroupItem itemTwo = new IDNGroupItem();
                    itemTwo.Header = headerTwo;
                    itemTwo.HasChild = true;
                    itemTwo.Childs = new ObservableCollection<IDNGroupItem>();
                    foreach (var itemNodeThree in itemNodeTwo.Elements())
                    {
                        string headerThree = itemNodeThree.Attribute("Header").Value;
                        string moudleID = itemNodeThree.Attribute("MoudleID").Value;
                        IDNGroupItem itemThree = new IDNGroupItem();
                        itemThree.Header = headerThree;
                        itemThree.MoudleID = moudleID;
                        itemThree.HasChild = false;
                        itemTwo.Childs.Add(itemThree);
                    }
                    itemOne.Childs.Add(itemTwo);
                }
                Groups.Add(itemOne);
            }
        }
    }
}