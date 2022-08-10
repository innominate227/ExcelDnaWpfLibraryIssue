namespace CustomPaneAddIn
{
    using ExcelDna.Integration;
    using ExcelDna.Integration.CustomUI;
    using ExcelDna.Registration;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Windows.Forms.Integration;

    public class CustomPaneAddIn : IExcelAddIn
    {
        public void AutoOpen()
        {
            ExcelRegistration.GetExcelCommands().RegisterCommands();
        }

        public void AutoClose() { }

        [ExcelCommand(Name = "ShowCustomPane", Description = "Show custom pane")]
        public static void ShowCustomPane()
        {
            try
            {
                var myControl = new MyUserControl();
                var customPane = CustomTaskPaneFactory.CreateCustomTaskPane(myControl, nameof(myControl));

                customPane.Visible = true;

            }
            catch (Exception e)
            {
                var handle = Control.FromHandle(ExcelDnaUtil.WindowHandle);
                MessageBox.Show(handle, $"{e.Message}\n\n Stack trace:\n{e.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public interface IMyUserControl { }

    [ComVisible(true)]
    public class MyRibbon : ExcelRibbon { }

    [ComVisible(true)]
    [ComDefaultInterface(typeof(IMyUserControl))]
    public class MyUserControl : UserControl, IMyUserControl 
    {
        private readonly ElementHost _control;

        /// <summary>
        /// Create new ComVisibleUserControl
        /// </summary>
        public MyUserControl()
        {
            _control = new ElementHost();
            _control.Location = new System.Drawing.Point(0, 0);
            _control.Dock = DockStyle.Fill;

            var control = new MyWpfControl();            
            _control.Child = control;            

            Controls.Add(_control);


        }

    }
}
