using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_DZ3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentDataSet.Student);

        }

        private void studentDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (studentDataGridView.Columns[e.ColumnIndex].DataPropertyName == "IDStudent")
                    if ((int)e.Value < 5)
                    {
                        DataGridViewRow row = studentDataGridView.Rows[e.RowIndex];
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
            }
        }
    }
}
