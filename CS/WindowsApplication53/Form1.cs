using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace WindowsApplication53
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<object> fieldValueEnumerator;
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateTable();
            pivotGridControl1.RefreshData();

            fieldYear.BestFit();
            fieldDate.BestFit();

        }

        private List<object> CreateFieldValueEnumerator(PivotGridControl pivot, PivotGridField field)
        {
            List<object> enumerator = new List<object>();
            for (int columnIndex = 0; columnIndex < pivot.Cells.ColumnCount ; columnIndex++)
            {
                object columnValue = pivot.GetFieldValue(field, columnIndex);
                if (!enumerator.Contains(columnValue))
                    enumerator.Add(columnValue);
            }
            return enumerator;
        }
        private void PopulateTable()
        {
            DataTable myTable = dataSet1.Tables["Data"];
            myTable.Rows.Add(new object[] {"Aaa", DateTime.Today, 7});
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddDays(1), 4 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today, 12 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1), 14 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today, 11 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1), 10 });

            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1), 4 });
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1).AddDays(1), 2 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddYears(1), 3 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1).AddYears(1), 1 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddYears(1), 8 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1).AddYears(1), 22 });

            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(4), 4 });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddYears(4), 3 });            
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddYears(4), 8 });

            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1).AddYears(3), 1 });
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddDays(1).AddYears(3), 2 });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1).AddYears(3), 22 });
        }

        private void pivotGridControl1_CustomAppearance(object sender, DevExpress.XtraPivotGrid.PivotCustomAppearanceEventArgs e)
        {
            if (object.ReferenceEquals(e.ColumnField, fieldDate) && fieldValueEnumerator != null )            
            {
                if (fieldValueEnumerator.IndexOf(e.GetFieldValue(fieldYear )) % 2 > 0)
                    e.Appearance.BackColor = Color.GreenYellow;
                else
                    e.Appearance.BackColor = Color.Gold ;
            }
        }

        private void pivotGridControl1_GridLayout(object sender, EventArgs e)
        {
            fieldValueEnumerator = CreateFieldValueEnumerator(pivotGridControl1, fieldYear);
        }
       
    }
}