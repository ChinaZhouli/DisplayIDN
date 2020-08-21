using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace DisplayIDN
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (r, s) =>
            {
                this.MouseDown += (x, y) =>
                {
                    if (y.LeftButton == MouseButtonState.Pressed)
                    {
                        this.DragMove();
                    }
                };
            };
            //DataTable dt = new DataTable();
            //dt.Columns.Add("id", typeof(string));
            //dt.Columns.Add("标题", typeof(string));
            //dt.Columns.Add("内容", typeof(string));
            //dt.Columns.Add("iscp", typeof(bool));

            //dt.Rows.Add("1", "情歌", "情歌是简述一个美好的爱情故事", false);
            //dt.Rows.Add("2", "What Are Words", "讲述一个不离不弃的爱情故事", false);
            //this.DatagIDN.DataContext = dt;
            //this.DatagIDN.IsReadOnly = true;

            //this.DatagIDN.MouseDoubleClick += new MouseButtonEventHandler(dataGrid1_MouseDoubleClick);

            //this.DatagIDN.RowDetailsVisibilityChanged += new EventHandler<DataGridRowDetailsEventArgs>(dataGrid1_RowDetailsVisibilityChanged);

            this.DataContext = new MainViewModel();
        }

        /// <summary>
        /// 圆角标题栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            double height = e.NewSize.Height;

            Rect rectTop = new Rect(new Size(width, 10));
            RectangleGeometry gmTop = new RectangleGeometry(rectTop, 5, 5);
            Rect rectBottom = new Rect(new Point(0, 5), new Size(width, height - 5));
            RectangleGeometry gmBottom = new RectangleGeometry(rectBottom);
            Geometry gm = Geometry.Combine(gmTop, gmBottom, GeometryCombineMode.Union, null);
            ((UIElement)sender).Clip = gm;
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            double normalWidth = 1200;
            double normalHeight = 700;
            double maxWidth = SystemParameters.WorkArea.Width;
            double maxHeight = SystemParameters.WorkArea.Height;
            if (maxWidth < normalWidth || maxHeight < normalHeight)
            {
                return;
            }
            if (this.Width == 1200)
            {
                this.Top = 0;
                this.Left = 0;
                this.Width = maxWidth;
                this.Height = maxHeight;
            }
            else
            {
                this.Top = (maxHeight - normalHeight) / 2;
                this.Left = (maxWidth - normalWidth) / 2;
                this.Width = normalWidth;
                this.Height = normalHeight;
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            //DataGridRow row = (DataGridRow)DatagIDN.ItemContainerGenerator.ContainerFromIndex(this.DatagIDN.SelectedIndex);

            //DataRowView rowview = this.DatagIDN.SelectedItem as DataRowView;
            //if (Convert.ToBoolean(rowview["iscp"]) == false)
            //{
            //    rowview["iscp"] = true;
            //    row.DetailsVisibility = System.Windows.Visibility.Visible;
            //}
            //else
            //{
            //    rowview["iscp"] = false;
            //    row.DetailsVisibility = System.Windows.Visibility.Collapsed;
            //}
        }
        void dataGrid1_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {
            DataGridRow row = e.Row;
            TextBlock inne = e.DetailsElement as TextBlock;
            System.Data.DataRowView rowview = row.Item as System.Data.DataRowView;

            if (Convert.ToBoolean(rowview["iscp"]))
            {
                row.DetailsVisibility = System.Windows.Visibility.Visible;
                string value = rowview["内容"].ToString();
                inne.Height = 100;
                inne.Text = value;
            }
            else
            {
                row.DetailsVisibility = System.Windows.Visibility.Collapsed;
            }
        }

        #region ModifyOpen
        private DispatcherTimer timerModifyOpen;
        private void btnModifyOpen_MouseEnter(object sender, MouseEventArgs e)
        {
            this.popupModifyOpen.IsOpen = true;
        }
        private void TimerModifyOpen_Tick(object sender, EventArgs e)
        {
            Popup pop = timerModifyOpen.Tag as Popup;
            if (!pop.IsMouseOver)
            {
                if (btnModifyOpen != null)
                {
                    if (!btnModifyOpen.IsMouseOver)
                    {
                        pop.IsOpen = false;
                        timerModifyOpen.Stop();
                    }
                }
                else
                {
                    pop.IsOpen = false;
                    timerModifyOpen.Stop();
                }
            }
        }
        private void ModifyOpenMouseLeave()
        {
            if (timerModifyOpen == null)
            {
                timerModifyOpen = new DispatcherTimer();
                timerModifyOpen.Interval = new TimeSpan(0, 0, 0, 0, 200);
                timerModifyOpen.Tag = popupModifyOpen;
                timerModifyOpen.Tick += TimerModifyOpen_Tick;
            }
            timerModifyOpen.Stop();
            timerModifyOpen.Start();
        }
        private void btnModifyOpen_MouseLeave(object sender, MouseEventArgs e)
        {
            ModifyOpenMouseLeave();
        }
        private void popupModifyOpen_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ModifyOpenMouseLeave();
        }
        #endregion

        #region ModifySave
        private DispatcherTimer timerModifySave;
        private void btnModifySave_MouseEnter(object sender, MouseEventArgs e)
        {
            this.popupModifySave.IsOpen = true;
        }
        private void TimerModifySave_Tick(object sender, EventArgs e)
        {
            Popup pop = timerModifySave.Tag as Popup;
            if (!pop.IsMouseOver)
            {
                if (btnModifySave != null)
                {
                    if (!btnModifySave.IsMouseOver)
                    {
                        pop.IsOpen = false;
                        timerModifySave.Stop();
                    }
                }
                else
                {
                    pop.IsOpen = false;
                    timerModifySave.Stop();
                }
            }
        }
        private void ModifySaveMouseLeave()
        {
            if (timerModifySave == null)
            {
                timerModifySave = new DispatcherTimer();
                timerModifySave.Interval = new TimeSpan(0, 0, 0, 0, 200);
                timerModifySave.Tag = popupModifySave;
                timerModifySave.Tick += TimerModifySave_Tick;
            }
            timerModifySave.Stop();
            timerModifySave.Start();
        }
        private void btnModifySave_MouseLeave(object sender, MouseEventArgs e)
        {
            ModifySaveMouseLeave();
        }
        private void popupModifySave_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ModifySaveMouseLeave();
        }
        #endregion

        #region CompareOpen1
        private DispatcherTimer timerCompareOpen1;
        private void btnCompareOpen1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.popupCompareOpen1.IsOpen = true;
        }
        private void TimerCompareOpen1_Tick(object sender, EventArgs e)
        {
            Popup pop = timerCompareOpen1.Tag as Popup;
            if (!pop.IsMouseOver)
            {
                if (btnCompareOpen1 != null)
                {
                    if (!btnCompareOpen1.IsMouseOver)
                    {
                        pop.IsOpen = false;
                        timerCompareOpen1.Stop();
                    }
                }
                else
                {
                    pop.IsOpen = false;
                    timerCompareOpen1.Stop();
                }
            }
        }
        private void CompareOpen1MouseLeave()
        {
            if (timerCompareOpen1 == null)
            {
                timerCompareOpen1 = new DispatcherTimer();
                timerCompareOpen1.Interval = new TimeSpan(0, 0, 0, 0, 200);
                timerCompareOpen1.Tag = popupCompareOpen1;
                timerCompareOpen1.Tick += TimerCompareOpen1_Tick;
            }
            timerCompareOpen1.Stop();
            timerCompareOpen1.Start();
        }
        private void btnCompareOpen1_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareOpen1MouseLeave();
        }

        private void popupCompareOpen1_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareOpen1MouseLeave();
        }
        #endregion

        #region CompareSave1
        private DispatcherTimer timerCompareSave1;
        private void btnCompareSave1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.popupCompareSave1.IsOpen = true;
        }
        private void TimerCompareSave1_Tick(object sender, EventArgs e)
        {
            Popup pop = timerCompareSave1.Tag as Popup;
            if (!pop.IsMouseOver)
            {
                if (btnCompareSave1 != null)
                {
                    if (!btnCompareSave1.IsMouseOver)
                    {
                        pop.IsOpen = false;
                        timerCompareSave1.Stop();
                    }
                }
                else
                {
                    pop.IsOpen = false;
                    timerCompareSave1.Stop();
                }
            }
        }
        private void CompareSave1MouseLeave()
        {
            if (timerCompareSave1 == null)
            {
                timerCompareSave1 = new DispatcherTimer();
                timerCompareSave1.Interval = new TimeSpan(0, 0, 0, 0, 200);
                timerCompareSave1.Tag = popupCompareSave1;
                timerCompareSave1.Tick += TimerCompareSave1_Tick;
            }
            timerCompareSave1.Stop();
            timerCompareSave1.Start();
        }
        private void btnCompareSave1_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareSave1MouseLeave();
        }
        private void popupCompareSave1_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareSave1MouseLeave();
        }
        #endregion

        #region CompareOpen2
        private DispatcherTimer timerCompareOpen2;
        private void btnCompareOpen2_MouseEnter(object sender, MouseEventArgs e)
        {
            this.popupCompareOpen2.IsOpen = true;
        }
        private void TimerCompareOpen2_Tick(object sender, EventArgs e)
        {
            Popup pop = timerCompareOpen2.Tag as Popup;
            if (!pop.IsMouseOver)
            {
                if (btnCompareOpen2 != null)
                {
                    if (!btnCompareOpen2.IsMouseOver)
                    {
                        pop.IsOpen = false;
                        timerCompareOpen2.Stop();
                    }
                }
                else
                {
                    pop.IsOpen = false;
                    timerCompareOpen2.Stop();
                }
            }
        }
        private void CompareOpen2MouseLeave()
        {
            if (timerCompareOpen2 == null)
            {
                timerCompareOpen2 = new DispatcherTimer();
                timerCompareOpen2.Interval = new TimeSpan(0, 0, 0, 0, 200);
                timerCompareOpen2.Tag = popupCompareOpen2;
                timerCompareOpen2.Tick += TimerCompareOpen2_Tick;
            }
            timerCompareOpen2.Stop();
            timerCompareOpen2.Start();
        }
        private void btnCompareOpen2_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareOpen2MouseLeave();
        }
        private void popupCompareOpen2_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareOpen2MouseLeave();
        }
        #endregion

        #region CompareSave2
        private DispatcherTimer timerCompareSave2;
        private void btnCompareSave2_MouseEnter(object sender, MouseEventArgs e)
        {
            this.popupCompareSave2.IsOpen = true;
        }
        private void TimerCompareSave2_Tick(object sender, EventArgs e)
        {
            Popup pop = timerCompareSave2.Tag as Popup;
            if (!pop.IsMouseOver)
            {
                if (btnCompareSave2 != null)
                {
                    if (!btnCompareSave2.IsMouseOver)
                    {
                        pop.IsOpen = false;
                        timerCompareSave2.Stop();
                    }
                }
                else
                {
                    pop.IsOpen = false;
                    timerCompareSave2.Stop();
                }
            }
        }
        private void CompareSave2MouseLeave()
        {
            if (timerCompareSave2 == null)
            {
                timerCompareSave2 = new DispatcherTimer();
                timerCompareSave2.Interval = new TimeSpan(0, 0, 0, 0, 200);
                timerCompareSave2.Tag = popupCompareSave2;
                timerCompareSave2.Tick += TimerCompareSave2_Tick;
            }
            timerCompareSave2.Stop();
            timerCompareSave2.Start();
        }
        private void btnCompareSave2_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareSave2MouseLeave();
        }

        private void popupCompareSave2_MouseLeave(object sender, MouseEventArgs e)
        {
            CompareSave2MouseLeave();
        }
        #endregion
    }
}
