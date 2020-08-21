using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DisplayIDN
{
    public class IDNModifyItem : ObservableObject
    {
        /// <summary>
        /// IDN值
        /// </summary>
        public string IDN { get; set; }
        /// <summary>
        /// IDN索引
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Label { get; set; }
        public ValueModify ReadWriteType { get; set; }

        private ValueAccess modifyAccess;
        public ValueAccess ModifyAccess
        {
            get { return modifyAccess; }
            set { modifyAccess = value; RaisePropertyChanged(() => ModifyAccess); }
        }

        /// <summary>
        /// 高级参数
        /// </summary>
        public bool IsAdvanced { get; set; }
        public bool IsNeedUpdated { get; set; }
        public bool IsNeedIndex { get; set; }
        public bool IsSwitch { get; set; }
        public ValueDisplay Display { get; set; }



        public string Tips { get; set; }

        private bool hasChanged;
        public bool HasChanged
        {
            get { return hasChanged; }
            set { hasChanged = value; RaisePropertyChanged(() => HasChanged); }
        }

        private int currentValue;
        public int CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; RaisePropertyChanged(() => CurrentValue); }
        }

        public IDNModifyItem()
        { }

        //public IDNModifyItem(string idn, string index, string label,ValueModify)
        //{

        //}
    }
}
