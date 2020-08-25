using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInterface
{
    public delegate void DelegateExitAppNotify();

    public partial class FormExit : Form
    {
        public event DelegateExitAppNotify m_ExiAppNotifier;

        public FormExit()
        {
            InitializeComponent();
        }

        private void buttonYseExit_Click(object sender, EventArgs e)
        {
            OnYesButtonClick();
            this.Close();
        }

        protected virtual void OnYesButtonClick()
        {
            if (m_ExiAppNotifier != null)
            {
                m_ExiAppNotifier.Invoke();
            }
        }

        private void buttonNoExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
