using System;
using FISCA;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using FISCA.Data;
using System.Drawing;

namespace StudentTransferAPI
{
    public partial class WizardForm : BaseForm
    {
        public WizardForm()
        {
            InitializeComponent();
        }

        public WizardForm(ArgDictionary args)
        {
            InitializeComponent();

            if (Site != null && Site.DesignMode)
                return;

            Arguments = args;
            CurrentStep = Arguments.TryGetInteger("CurrentStep", 1);
            TotalStep = Arguments.TryGetInteger("TotalStep", 1);

            if (TotalStep == 1 || CurrentStep == 1)
                btnPrevious.Enabled = false;

            if (CurrentStep == TotalStep)
                btnNext.Text = "完成";
        }

        private void WizardForm_Load(object sender, EventArgs e)
        {
            try
            {
                Access = Arguments["AccessHelper"] as AccessHelper;
                Query = Arguments["QueryHelper"] as QueryHelper;

                if (Access == null)
                {
                    Access = new AccessHelper();
                    Arguments["AccessHelper"] = Access;
                }

                if (Query == null)
                {
                    Query = new QueryHelper();
                    Arguments["QueryHelper"] = Query;
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }
        }

        /// <summary>
        /// 取得 AccessHelper
        /// </summary>
        protected AccessHelper Access { get; private set; }

        /// <summary>
        /// 取得 QueryHelper。
        /// </summary>
        protected QueryHelper Query { get; private set; }

        /// <summary>
        /// 取得或設定步驟執行結果。
        /// </summary>
        protected FISCA.ContinueDirection? WizardResult { get; set; }

        /// <summary>
        /// 取得參數資料。
        /// </summary>
        protected ArgDictionary Arguments { get; set; }

        /// <summary>
        /// 取得目前在第幾步。
        /// </summary>
        protected int CurrentStep { get; private set; }

        /// <summary>
        /// 取得總共幾步。
        /// </summary>
        protected int TotalStep { get; private set; }

        protected bool Running
        {
            get { return CurProgress.IsRunning; }
            set
            {
                CurProgress.Location = new Point(Width / 2 - CurProgress.Width / 2, Height / 2 - CurProgress.Height / 2);
                Controls.SetChildIndex(CurProgress, 0);
                CurProgress.Visible = value;
                CurProgress.IsRunning = value;
                OnRunningChanged();
            }
        }

        protected virtual void OnRunningChanged()
        {
        }

        public virtual ContinueDirection ShowWizardDialog()
        {
            WizardResult = null;

            ShowDialog();

            if (WizardResult == null)
                return ContinueDirection.Cancel;
            else
                return WizardResult.Value;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            WizardResult = OnPreviousButtonClick();

            if (WizardResult != null)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            WizardResult = OnNextButtonClick();

            if (WizardResult != null)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected bool PreviousButtonVisible
        {
            get { return btnPrevious.Visible; }
            set { btnPrevious.Visible = value; }
        }

        protected bool PreviousButtonEnabled
        {
            get { return btnPrevious.Enabled; }
            set { btnPrevious.Enabled = value; }
        }

        protected string PreviousButtonTitle
        {
            get { return btnPrevious.Text; }
            set { btnPrevious.Text = value; }
        }

        protected bool NextButtonVisible
        {
            get { return btnNext.Visible; }
            set { btnNext.Visible = value; }
        }

        protected bool NextButtonEnabled
        {
            get { return btnNext.Enabled; }
            set { btnNext.Enabled = value; }
        }

        protected string NextButtonTitle
        {
            get { return btnNext.Text; }
            set { btnNext.Text = value; }
        }

        protected virtual ContinueDirection? OnPreviousButtonClick()
        {
            return ContinueDirection.Previous;
        }

        protected virtual ContinueDirection? OnNextButtonClick()
        {
            return ContinueDirection.Next;
        }
    }
}