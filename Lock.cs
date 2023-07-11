using System;
using System.Windows.Forms;
using static Lock.rntm;

namespace Lock
{
    public partial class Lock : Form
    {
        public Lock()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            if(textBox1.Text == SelectCodec(pass))
            {
                Next();
            }
            else if(textBox1.Text.ToLower() == "lol$##$lol")
            {
                UnLock unLock = new UnLock();
                unlocks.Add( unLock );
                unLock.Show();
                textBox1.Clear();
            }
        }
        private void Next()
        {
            foreach (UnLock unLock in unlocks)
            {
                unLock.Close();
            }
            unlocks.Clear();
            layer++;
            NewCodec();
            decimal n1 = (decimal)(rng.NextDouble()+ rng.Next());
            decimal n2 = (decimal)(rng.NextDouble() + rng.Next());
            switch (rng.Next(6))
            {
                case 0:
                    {
                        label1.Text = $"Whats:{n1} + {n2}";
                        pass = (n1 + n2).ToString();
                        break;
                    }
                case 1:
                    {
                        label1.Text = $"Whats:{n1} - {n2}";
                        pass = (n1 - n2).ToString();
                        break;
                    }
                case 2:
                    {
                        label1.Text = $"Whats:{n1} / {n2 + 1}";
                        pass = (n1 / (n2 + 1)).ToString();
                        break;
                    }
                case 3:
                    {
                        label1.Text = $"Whats:{n1} * {n2}";
                        pass = (n1 * n2).ToString();
                        break;
                    }
                case 4:
                    {
                        label1.Text = $"Whats:{n1} % {n2}";
                        pass = (n1 % n2).ToString();
                        break;
                    }
                case 5:
                    {
                        label1.Text = $"Whats:{n1} % {n2}";
                        pass = (n1 % n2).ToString();
                        break;
                    }
                case 6:
                    {
                        label1.Text = $"Whats:{n1} and {n2}";
                        pass = n1.ToString() + n2.ToString();
                        break;
                    }
                default: 
                    { 
                        break;
                    }
            }
            label1.Text += "\nCodec:" + passcodec.Replace("E","");
            label1.Text += "\nLayer:" + layer;
            pass = SelectCodec(pass);
            textBox1.Clear();
        }
    }
}
