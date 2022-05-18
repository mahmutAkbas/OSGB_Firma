using DataAccess.Concrete.Dapper;
using Entities.Concrete;
using System;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnvanDal dp = new UnvanDal();
        
            var result = dp.GetAllAsync();
            if (result.IsCompleted)
            {
                comboBox1.Items.AddRange(result.Result.ToArray
                    );
               //comboBox1.DataSource = result.Result;
            }
        }
    }
}
