namespace Out_of_Office.RoleForms.DialogueForms
{
    partial class EmployeeProjectsForm
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
            ActivateButton = new Guna.UI2.WinForms.Guna2Button();
            DeactivateButton = new Guna.UI2.WinForms.Guna2Button();
            ProjectsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            IsAssigned = new DataGridViewCheckBoxColumn();
            ProjectId = new DataGridViewTextBoxColumn();
            ProjectName = new DataGridViewTextBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)ProjectsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ActivateButton
            // 
            ActivateButton.Animated = true;
            ActivateButton.BorderRadius = 10;
            ActivateButton.CheckedState.FillColor = Color.FromArgb(13, 109, 188);
            ActivateButton.CustomizableEdges = customizableEdges3;
            ActivateButton.DisabledState.BorderColor = Color.DarkGray;
            ActivateButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ActivateButton.DisabledState.FillColor = Color.FromArgb(123, 172, 136);
            ActivateButton.DisabledState.ForeColor = Color.White;
            ActivateButton.FillColor = Color.FromArgb(24, 178, 63);
            ActivateButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ActivateButton.ForeColor = Color.White;
            ActivateButton.HoverState.FillColor = Color.FromArgb(19, 149, 38);
            ActivateButton.Location = new Point(47, 377);
            ActivateButton.Name = "ActivateButton";
            ActivateButton.PressedColor = Color.FromArgb(16, 124, 16);
            ActivateButton.PressedDepth = 40;
            ActivateButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ActivateButton.Size = new Size(113, 44);
            ActivateButton.TabIndex = 59;
            ActivateButton.Text = "Save";
            ActivateButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // DeactivateButton
            // 
            DeactivateButton.Animated = true;
            DeactivateButton.BorderRadius = 10;
            DeactivateButton.CheckedState.FillColor = Color.FromArgb(13, 109, 188);
            DeactivateButton.CustomizableEdges = customizableEdges1;
            DeactivateButton.DisabledState.BorderColor = Color.DarkGray;
            DeactivateButton.DisabledState.CustomBorderColor = Color.DarkGray;
            DeactivateButton.DisabledState.FillColor = Color.FromArgb(192, 123, 123);
            DeactivateButton.DisabledState.ForeColor = Color.White;
            DeactivateButton.FillColor = Color.FromArgb(232, 64, 78);
            DeactivateButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DeactivateButton.ForeColor = Color.White;
            DeactivateButton.HoverState.FillColor = Color.FromArgb(179, 49, 60);
            DeactivateButton.Location = new Point(282, 377);
            DeactivateButton.Name = "DeactivateButton";
            DeactivateButton.PressedColor = Color.FromArgb(102, 28, 34);
            DeactivateButton.PressedDepth = 25;
            DeactivateButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            DeactivateButton.Size = new Size(113, 44);
            DeactivateButton.TabIndex = 60;
            DeactivateButton.Text = "Cancel";
            DeactivateButton.Click += DeactivateButton_Click;
            // 
            // ProjectsDataGridView
            // 
            ProjectsDataGridView.AllowUserToAddRows = false;
            ProjectsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            ProjectsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ProjectsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProjectsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ProjectsDataGridView.BackgroundColor = Color.FromArgb(241, 248, 254);
            ProjectsDataGridView.BorderStyle = BorderStyle.FixedSingle;
            ProjectsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(14, 75, 126);
            dataGridViewCellStyle2.Font = new Font("Montserrat SemiBold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.NullValue = "-";
            dataGridViewCellStyle2.Padding = new Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(13, 109, 188);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ProjectsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ProjectsDataGridView.ColumnHeadersHeight = 30;
            ProjectsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ProjectsDataGridView.Columns.AddRange(new DataGridViewColumn[] { IsAssigned, ProjectId, ProjectName });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(241, 248, 254);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.NullValue = "-";
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(190, 223, 249);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ProjectsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            ProjectsDataGridView.GridColor = Color.FromArgb(190, 223, 249);
            ProjectsDataGridView.Location = new Point(35, 90);
            ProjectsDataGridView.Margin = new Padding(20, 50, 20, 100);
            ProjectsDataGridView.MaximumSize = new Size(1000, 500);
            ProjectsDataGridView.Name = "ProjectsDataGridView";
            ProjectsDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ProjectsDataGridView.RowHeadersVisible = false;
            ProjectsDataGridView.RowTemplate.Height = 25;
            ProjectsDataGridView.Size = new Size(374, 257);
            ProjectsDataGridView.TabIndex = 64;
            ProjectsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            ProjectsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            ProjectsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ProjectsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ProjectsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ProjectsDataGridView.ThemeStyle.BackColor = Color.FromArgb(241, 248, 254);
            ProjectsDataGridView.ThemeStyle.GridColor = Color.FromArgb(190, 223, 249);
            ProjectsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            ProjectsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            ProjectsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ProjectsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ProjectsDataGridView.ThemeStyle.HeaderStyle.Height = 30;
            ProjectsDataGridView.ThemeStyle.ReadOnly = false;
            ProjectsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            ProjectsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ProjectsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            ProjectsDataGridView.ThemeStyle.RowsStyle.Height = 25;
            ProjectsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            ProjectsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            ProjectsDataGridView.CellValueChanged += Guna2DataGridView_CellValueChanged;
            ProjectsDataGridView.CurrentCellDirtyStateChanged += Guna2DataGridView_CurrentCellDirtyStateChanged;
            // 
            // IsAssigned
            // 
            IsAssigned.HeaderText = "Assigned";
            IsAssigned.Name = "IsAssigned";
            IsAssigned.Width = 85;
            // 
            // ProjectId
            // 
            ProjectId.HeaderText = "Id";
            ProjectId.Name = "ProjectId";
            ProjectId.Width = 51;
            // 
            // ProjectName
            // 
            ProjectName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProjectName.HeaderText = "Name";
            ProjectName.Name = "ProjectName";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat SemiBold", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(35, 42);
            label1.Name = "label1";
            label1.Size = new Size(212, 30);
            label1.TabIndex = 65;
            label1.Text = "Avaliable Projects";
            // 
            // EmployeeProjectsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 239, 252);
            ClientSize = new Size(440, 456);
            Controls.Add(label1);
            Controls.Add(ProjectsDataGridView);
            Controls.Add(DeactivateButton);
            Controls.Add(ActivateButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeProjectsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeProjectsForm";
            ((System.ComponentModel.ISupportInitialize)ProjectsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button ActivateButton;
        private Guna.UI2.WinForms.Guna2Button DeactivateButton;
        private Guna.UI2.WinForms.Guna2DataGridView ProjectsDataGridView;
        private DataGridViewCheckBoxColumn IsAssigned;
        private DataGridViewTextBoxColumn ProjectId;
        private DataGridViewTextBoxColumn ProjectName;
        private Label label1;
    }
}