﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class SelectCourseForm : Form
    {
        private Model _model;
        public SelectCourseForm(Model model)
        {
            this._model = model;
            List<CourseInfoDto> courseInfo = model.GetCourseInfo();
            Dictionary<string, string> dataGridViewHeader = model.GetCourseHeader();

            InitializeComponent();
            // handle unupdate checkbox problem when user click the same checkbox to fast
            this._selectCourseDataGridView.CellContentDoubleClick += SelectCourseDataGridViewCellContentClick;

            AddCheckBoxColumn();
            _submitConfirmButton.Enabled = false;

            _selectCourseDataGridView.DataSource = courseInfo;
            foreach (KeyValuePair<string, string> entry in dataGridViewHeader)
            {
                _selectCourseDataGridView.Columns[entry.Key].HeaderText = entry.Value;
            }
        }

        // enable _submitConfirmButton if any checkbox was checked
        private void SelectCourseDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _model.UpdateCourseChecked(e.RowIndex);
            if (_model.IsAnyCourseChecked())
            {
                _submitConfirmButton.Enabled = true;
                return;
            }
            _submitConfirmButton.Enabled = false;
        }

        // add checkbox column
        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn selectCourseCheckBoxColumn = new DataGridViewCheckBoxColumn();
            selectCourseCheckBoxColumn.HeaderText = "選";
            _selectCourseDataGridView.Columns.Add(selectCourseCheckBoxColumn);
        }
    }
}

