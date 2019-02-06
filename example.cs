using System;
using System.Windows.Forms;

namespace Anti_UI_Blocking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Btn_Show_Click(object sender, EventArgs e)
        {
            FrmDisplay frmDisplay = new FrmDisplay();
            ShowForm(frmDisplay, () => {
                if (1 != 0)
                    MessageBox.Show("It works! :)", "Anti ShowDialog UI Blocking", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        public static void ShowForm(dynamic frm, Action func)
        {
            frm.FormClosed += new FormClosedEventHandler((s, ev) => { func(); });
            frm.Show();
        }
    }
}
