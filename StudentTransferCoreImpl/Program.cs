using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FISCA;
using FISCA.Data;
using FISCA.Permission;
using K12.Presentation;
using StudentTransferAPI;
using StudentTransferCoreImpl.Properties;

namespace StudentTransferCoreImpl
{
    public static class Program
    {
        public static bool Debug { get; internal set; }

        public static string CurrentMode { get; internal set; }

        public const string Hsinchu = "Hsinchu";

      

        #region Wizard Codes
        public static string FC_TransferOutWizard = "ischool/國中系統/共同/學籍/學生/線上轉學精靈-轉出";

        public static string FC_TransferInWizard = "ischool/國中系統/共同/學籍/學生/線上轉學精靈-轉入";

        public static string FC_TransferStatusConfirm = "ischool/國中系統/共同/學籍/學生/線上轉學精靈-學生轉學狀態查詢";

        public static string Private_TransferIn = "__Private_TransferIn";

        private static string TransferPermission = "37a3eab1-66f2-478f-aec3-9ce9dabfa107";
        #endregion

        //[MainMethod]
         [ApplicationMain()]
        public static void Main()
        {
            

            //FIE987D3@chhs.hcc.edu.tw
            //FIE987D3@http://www.ischool.com.tw/is4/chhs.hcc.edu.tw

            #region 註冊權限代碼
            FISCA.Permission.Catalog Catalog = FISCA.Permission.RoleAclSource.Instance["學生"]["功能按鈕"];
            Catalog.Add(new RibbonFeature(TransferPermission, "轉學"));
            #endregion

            try
            {
                CurrentMode = "";

                if (RTContext.ConstantDefined("Hsinchu"))
                    CurrentMode = Hsinchu;
                else
                    CurrentMode = Module.GetCurrentModule().GetDeployParametsers()["Mode"];
            }
            catch { }

            try
            {
                Debug = RTContext.ConstantDefined("StudentTransferDebug");
                #region UDM
                if (RTContext.ConstantDefined("StudentTransferUDM"))
                {
                    string url = RTContext.GetConstant("StudentTransferUDM");
                    if (!string.IsNullOrWhiteSpace(url))
                        ServerModule.AutoManaged(url);
                }
                else
                    ServerModule.AutoManaged("http://module.ischool.com.tw:8080/module/148/StudentTransfer/udm.xml");
            }
            catch
            {
                ServerModule.AutoManaged("http://module.ischool.com.tw:8080/module/148/StudentTransfer/udm.xml");
            }
                #endregion

            #region Ribbon Bar Buttons
            NLDPanels.Student.SelectedSourceChanged += delegate
            {
                NLDPanels.Student.RibbonBarItems["線上轉學"]["學生轉出"].Enable =
                    NLDPanels.Student.SelectedSource.Count == 1 && FISCA.Permission.UserAcl.Current[TransferPermission].Executable;
            };

            NLDPanels.Student.RibbonBarItems["線上轉學"]["學生轉出"].Image = Resources._轉出_image_size_up_64;
            NLDPanels.Student.RibbonBarItems["線上轉學"]["學生轉出"].Enable = false;
            NLDPanels.Student.RibbonBarItems["線上轉學"]["學生轉出"].Click += delegate
            {
                ArgDictionary args = new ArgDictionary();
                args.Add(StudentTransferCoreImpl.Consts.StudentID, NLDPanels.Student.SelectedSource[0]);
                Features.Invoke(FC_TransferOutWizard, args);
            };

            NLDPanels.Student.RibbonBarItems["線上轉學"]["學生轉入"].Image = Resources._轉入_mask_add_64;
            NLDPanels.Student.RibbonBarItems["線上轉學"]["學生轉入"].Enable = FISCA.Permission.UserAcl.Current[TransferPermission].Executable;
            NLDPanels.Student.RibbonBarItems["線上轉學"]["學生轉入"].Click += delegate
            {
                Features.Invoke(FC_TransferInWizard);
            };

            NLDPanels.Student.RibbonBarItems["線上轉學"]["轉入/轉出確認"].Image = Resources._轉入轉出確認layers_ok_64;
            NLDPanels.Student.RibbonBarItems["線上轉學"]["轉入/轉出確認"].Enable = FISCA.Permission.UserAcl.Current[TransferPermission].Executable;
            NLDPanels.Student.RibbonBarItems["線上轉學"]["轉入/轉出確認"].Click += delegate
            {
                Features.Invoke(FC_TransferStatusConfirm);
            };

            //目前不需要
            //https://mail.google.com/mail/u/0/?ui=2&shva=1#inbox/13f31ee7ccb88c82
            //if (CurrentMode == Hsinchu)
            //{
            //    K12.Presentation.NLDPanels.Student.SelectedSourceChanged += delegate
            //    {
            //        NLDPanels.Student.RibbonBarItems["數位學生證"]["手動資料同步"].Enable =
            //            K12.Presentation.NLDPanels.Student.SelectedSource.Count == 1;
            //    };

            //    NLDPanels.Student.RibbonBarItems["數位學生證"]["手動資料同步"].Enable = false;
            //    NLDPanels.Student.RibbonBarItems["數位學生證"]["手動資料同步"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Large;
            //    NLDPanels.Student.RibbonBarItems["數位學生證"]["手動資料同步"].Image = Resources.live_update_up_128;
            //    NLDPanels.Student.RibbonBarItems["數位學生證"]["手動資料同步"].Click += delegate
            //    {
            //        new StudentTransferCoreImpl.CardDataSync.ManualSync().ShowDialog();
            //    };
            //}
            #endregion

            //轉學狀態確認。
            Features.Register(FC_TransferStatusConfirm, args =>
            {
                new StatusForm().ShowDialog();
            });

            //轉入要求
            Features.Register(FC_TransferInWizard, args =>
            {
                new TransferInRequire().ShowDialog();
            });

            #region 學生轉出
            //註冊 FISCA Feature.
            int transferOutStepCount = 6, transferOutStep = 0;
            string[] transferOuts = GetInvocationCodes(FC_TransferOutWizard, transferOutStepCount);

            //學生轉出
            Features.Register(FC_TransferOutWizard, args =>
            {
                Features.Invoke(args, transferOuts);
            });

            //學生轉出精靈串列
            // Welcome
            Features.Register(transferOuts[transferOutStep++], args =>
            {
                return new TransferOut.Welcome(args).ShowWizardDialog();
            });
            //異動記錄
            Features.Register(transferOuts[transferOutStep++], args =>
            {
                return new TransferOut.UpdateRecord(args).ShowWizardDialog();
            });
            //學生身分
            Features.Register(transferOuts[transferOutStep++], args =>
            {
                return new TransferOut.StudentTag(args).ShowWizardDialog();
            });
            //選擇要轉出的資料
            Features.Register(transferOuts[transferOutStep++], args =>
            {
                return new TransferOut.ExportDataOptions(args).ShowWizardDialog();
            });
            //產生 Xml 資料
            Features.Register(transferOuts[transferOutStep++], args =>
            {
                return new TransferOut.GenerateData(args).ShowWizardDialog();
            });

            //列印綜合資料轉移證明單
            Features.Register(transferOuts[transferOutStep++], args =>
            {
                return new TransferOut.FinalStep(args).ShowWizardDialog();
            });
            #endregion

            #region 學生轉入
            //註冊 FISCA Feature.
            int transferInStepCount = 6, transferInStep = 0;
            string[] transferIns = GetInvocationCodes(Private_TransferIn, transferInStepCount);

            //學生轉入主功能
            Features.Register(Private_TransferIn, args =>
            {
                Features.Invoke(args, transferIns);
            });

            //精靈串列...
            Features.Register(transferIns[transferInStep++], args =>
            {
                return new TransferIn.Welcome(args).ShowWizardDialog();
            });

             
            Features.Register(transferIns[transferInStep++], args =>
            {
                 IStudentBriefBaseAPI item1 = FISCA.InteractionService.DiscoverAPI<IStudentBriefBaseAPI>();

                if (item1 != null)
                {
                    return item1.CreateForm(args).ShowWizardDialog();
                }
                else
                {
                    return new TransferIn.StudentBrief(args).ShowWizardDialog();
                }
            });

            Features.Register(transferIns[transferInStep++], args =>
            {
                return new TransferIn.UpdateRecord(args).ShowWizardDialog();
            });

            Features.Register(transferIns[transferInStep++], args =>
            {
                return new TransferIn.ImportDataOptions(args).ShowWizardDialog();
            });
            Features.Register(transferIns[transferInStep++], args =>
            {
                return new TransferIn.ImportDataForm(args).ShowWizardDialog();
            });

            Features.Register(transferIns[transferInStep++], args =>
            {
                return new TransferIn.AddTransStudCourse(args).ShowWizardDialog();
            });
            #endregion

            #region TransferProcessor
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.StudentBrief());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.StudentComplete());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.SemesterHistory());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.SemesterScore());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.SemesterMoralScore());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.MoralScoreDetail());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.TheCadreRecord());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.ServiceLearningRecord());
            TransferProcessor.Register(new StudentTransferCoreImpl.Processors.FitnessRecord());
            #endregion

            //檢查是否有需要使用者確認的狀態
            if (FISCA.Permission.UserAcl.Current[TransferPermission].Executable)
                CheckConfirmStatus();
        }

        /// <summary>
        /// 檢查是否有需要使用者確認的狀態
        /// </summary>
        private static void CheckConfirmStatus()
        {
            try
            {
                //在「轉出校」- 有學生的狀態是「待確認」的時後要提醒。
                string outCmd = string.Format(@"select * from $st_transferout where $st_transferout.status=2");
                //在「轉入校」- 有學生的狀態是「已確認」的時後要提醒。
                string inCmd = string.Format(@"select * from $st_transferin where $st_transferin.status=2");

                DataTable outTable = null, inTable = null;
                Task task = Task.Factory.StartNew(() =>
                {
                    QueryHelper query = new QueryHelper();
                    outTable = query.Select(outCmd);
                    inTable = query.Select(inCmd);
                });

                task.ContinueWith((t) =>
                {
                    if (t.IsFaulted)
                    {
                        RTOut.WriteError(t.Exception);
                        MessageBox.Show(t.Exception.Message, "線上轉學功能提醒");
                        return;
                    }

                    StringBuilder strBuilder = new StringBuilder();

                    if (outTable.Rows.Count > 0)
                        MessageBox.Show("有學校要求取得轉出學生資料，" + System.Environment.NewLine + "請至「轉入/轉出確認」功能中進行確認。");

                    if (inTable.Rows.Count > 0)
                        MessageBox.Show("他校已同意取得轉入學生資料，" + System.Environment.NewLine + "請至「轉入/轉出確認」功能中進行轉入作業。");

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                FISCA.RTOut.WriteError(ex);
                MessageBox.Show(ex.Message, "線上轉學功能提醒");
            }
        }

        private static string[] GetInvocationCodes(string prefix, int count)
        {
            List<string> outs = new List<string>();
            for (int i = 0; i < count; i++)
                outs.Add(prefix + i.ToString().PadLeft(2, '0'));

            return outs.ToArray();
        }
    }
}
