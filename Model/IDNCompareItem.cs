using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DisplayIDN
{
    public class IDNCompareItem : ObservableObject
    {
        public string IDN { get; set; }

        public string Index { get; set; }

        public string Description { get; set; }

        public ValueModify ReadWriteType { get; set; }

        public bool NeedUpdate { get; set; }

        public bool IsString { get; set; }

        public bool NeedIndex { get; set; }

        public ValueAccess AccessLevel { get; set; }

        public string Min { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public string Max { get; set; }


        public string EnumString { get; set; }

        public string Tips { get; set; }

        private bool isHiddemRow;
        public bool IsHiddemRow
        {
            get { return isHiddemRow; }
            set { isHiddemRow = value; RaisePropertyChanged(() => IsHiddemRow); }
        }

        private bool hasChanged1;
        public bool HasChanged1
        {
            get { return hasChanged1; }
            set { hasChanged1 = value; RaisePropertyChanged(() => HasChanged1); }
        }
        private bool hasChanged2;
        public bool HasChanged2
        {
            get { return hasChanged2; }
            set { hasChanged2 = value; RaisePropertyChanged(() => HasChanged2); }
        }

        private int currentValue1;
        public int CurrentValue1
        {
            get { return currentValue1; }
            set { currentValue1 = value; RaisePropertyChanged(() => CurrentValue1); }
        }

        private int currentValue2;
        public int CurrentValue2
        {
            get { return currentValue2; }
            set { currentValue2 = value; RaisePropertyChanged(() => CurrentValue2); }
        }

        public void SetTips()
        {
            if (EnumString == "")
            {
                Tips = $"取值范围: {Min} - {Max}";
            }
            else
            {
                Tips = $"取值范围: {EnumString}";
            }
        }
    }
}

