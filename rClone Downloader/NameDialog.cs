using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rClone_GUI
{
    public partial class NameDialog : Form
    {
        public NameDialog()
        {
            InitializeComponent();

            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;

            Location = new Point
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - Height) / 2)
            };

            textBox1.SelectAll();
            textBox1.Focus();
        }

        private void onOK(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        public string getName()
        {
            return textBox1.Text;
        }

        private void onCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void onEnterKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                onOK(sender, e);
            }
        }
    }
}
