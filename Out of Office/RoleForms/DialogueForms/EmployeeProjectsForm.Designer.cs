namespace Out_of_Office.RoleForms.DialogueForms
{
    partial class ProjectEmployeesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            SaveButton = new Guna.UI2.WinForms.Guna2Button();
            CancelButton = new Guna.UI2.WinForms.Guna2Button();
            ProjectEmployeesDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)ProjectEmployeesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // SaveButton
            // 
            SaveButton.Animated = true;
            SaveButton.BorderRadius = 10;
            SaveButton.CheckedState.FillColor = Color.FromArgb(13, 109, 188);
            SaveButton.CustomizableEdges = customizableEdges3;
            SaveButton.DisabledState.BorderColor = Color.DarkGray;
            SaveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SaveButton.DisabledState.FillColor = Color.FromArgb(123, 172, 136);
            SaveButton.DisabledState.ForeColor = Color.White;
            SaveButton.FillColor = Color.FromArgb(24, 178, 63);
            SaveButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SaveButton.ForeColor = Color.White;
            SaveButton.HoverState.FillColor = Color.FromArgb(19, 149, 38);
            SaveButton.Location = new Point(47, 377);
            SaveButton.Name = "SaveButton";
            SaveButton.PressedColor = Color.FromArgb(16, 124, 16);
            SaveButton.PressedDepth = 40;
            SaveButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            SaveButton.Size = new Size(113, 44);
            SaveButton.TabIndex = 59;
            SaveButton.Text = "Save";
            SaveButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Animated = true;
            CancelButton.BorderRadius = 10;
            CancelButton.CheckedState.FillColor = Color.FromArgb(13, 109, 188);
            CancelButton.CustomizableEdges = customizableEdges1;
            CancelButton.DisabledState.BorderColor = Color.DarkGray;
            CancelButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CancelButton.DisabledState.FillColor = Color.FromArgb(192, 123, 123);
            CancelButton.DisabledState.ForeColor = Color.White;
            CancelButton.FillColor = Color.FromArgb(232, 64, 78);
            CancelButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CancelButton.ForeColor = Color.White;
            CancelButton.HoverState.FillColor = Color.FromArgb(179, 49, 60);
            CancelButton.Location = new Point(282, 377);
            CancelButton.Name = "CancelButton";
            CancelButton.PressedColor = Color.FromArgb(102, 28, 34);
            CancelButton.PressedDepth = 25;
            CancelButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CancelButton.Size = new Size(113, 44);
            CancelButton.TabIndex = 60;
            CancelButton.Text = "Cancel";
            CancelButton.Click += CancelButton_Click;
            // 
            // ProjectEmployeesDataGridView
            // 
            ProjectEmployeesDataGridView.AllowUserToAddRows = false;
            ProjectEmployeesDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            ProjectEmployeesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ProjectEmployeesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProjectEmployeesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ProjectEmployeesDataGridView.BackgroundColor = Color.FromArgb(241, 248, 254);
            ProjectEmployeesDataGridView.BorderStyle = BorderStyle.FixedSingle;
            ProjectEmployeesDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(14, 75, 126);
            dataGridViewCellStyle2.Font = new Font("Montserrat SemiBold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.NullValue = "-";
            dataGridViewCellStyle2.Padding = new Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(13, 109, 188);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ProjectEmployeesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ProjectEmployeesDataGridView.ColumnHeadersHeight = 30;
            ProjectEmployeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(241, 248, 254);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.NullValue = "-";
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(190, 223, 249);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ProjectEmployeesDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            ProjectEmployeesDataGridView.GridColor = Color.FromArgb(190, 223, 249);
            ProjectEmployeesDataGridView.Location = new Point(35, 90);
            ProjectEmployeesDataGridView.Margin = new Padding(20, 50, 20, 100);
            ProjectEmployeesDataGridView.MaximumSize = new Size(1000, 500);
            ProjectEmployeesDataGridView.Name = "ProjectEmployeesDataGridView";
            ProjectEmployeesDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ProjectEmployeesDataGridView.RowHeadersVisible = false;
            ProjectEmployeesDataGridView.RowTemplate.Height = 25;
            ProjectEmployeesDataGridView.Size = new Size(374, 257);
            ProjectEmployeesDataGridView.TabIndex = 64;
            ProjectEmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            ProjectEmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            ProjectEmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ProjectEmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ProjectEmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ProjectEmployeesDataGridView.ThemeStyle.BackColor = Color.FromArgb(241, 248, 254);
            ProjectEmployeesDataGridView.ThemeStyle.GridColor = Color.FromArgb(190, 223, 249);
            ProjectEmployeesDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            ProjectEmployeesDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            ProjectEmployeesDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectEmployeesDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ProjectEmployeesDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ProjectEmployeesDataGridView.ThemeStyle.HeaderStyle.Height = 30;
            ProjectEmployeesDataGridView.ThemeStyle.ReadOnly = false;
            ProjectEmployeesDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            ProjectEmployeesDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ProjectEmployeesDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectEmployeesDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            ProjectEmployeesDataGridView.ThemeStyle.RowsStyle.Height = 25;
            ProjectEmployeesDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            ProjectEmployeesDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            ProjectEmployeesDataGridView.CellValueChanged += ProjectEmployeesDataGridView_CellValueChanged;
            ProjectEmployeesDataGridView.CurrentCellDirtyStateChanged += ProjectEmployeesDataGridView_CurrentCellDirtyStateChanged;
            ProjectEmployeesDataGridView.DataBindingComplete += ProjectsDataGridView_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat SemiBold", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(35, 42);
            label1.Name = "label1";
            label1.Size = new Size(138, 30);
            label1.TabIndex = 65;
            label1.Text = "Employees";
            // 
            // ProjectEmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 239, 252);
            ClientSize = new Size(440, 456);
            Controls.Add(label1);
            Controls.Add(ProjectEmployeesDataGridView);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProjectEmployeesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeProjectsForm";
            ((System.ComponentModel.ISupportInitialize)ProjectEmployeesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button SaveButton;
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private Guna.UI2.WinForms.Guna2DataGridView ProjectEmployeesDataGridView;
        private Label label1;
    }
}