using System;
using System.Windows.Forms;
using static Lock.rntm;

namespace Lock
{
    public partial class UnLock : Form
    {
        public UnLock()
        {
            InitializeComponent();
        }

        private void UnLock_Shown( object sender, EventArgs e )
        {
            textBox1.Text = pass;
        }
    }
}
