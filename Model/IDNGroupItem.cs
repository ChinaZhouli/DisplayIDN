using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayIDN
{
    public class IDNGroupItem : ObservableObject
    {
        private string header;
        public string Header
        {
            get { return header; }
            set { header = value; RaisePropertyChanged(() => Header); }
        }

        private bool hasChild;
        public bool HasChild
        {
            get { return hasChild; }
            set { hasChild = value; RaisePropertyChanged(() => HasChild); }
        }


        private string moudleID;
        public string MoudleID
        {
            get { return moudleID; }
            set { moudleID = value; RaisePropertyChanged(() => MoudleID); }
        }


        private ObservableCollection<IDNGroupItem> childs;
        public ObservableCollection<IDNGroupItem> Childs
        {
            get { return childs; }
            set { childs = value; RaisePropertyChanged(() => Childs); }
        }

    }
}