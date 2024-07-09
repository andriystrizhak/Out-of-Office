namespace OutOfOffice
{
    partial class RoleSelectionForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            EmloyeeButton = new Guna.UI2.WinForms.Guna2Button();
            HRButton = new Guna.UI2.WinForms.Guna2Button();
            PMButton = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            CloseButton = new Guna.UI2.WinForms.Guna2Button();
            ApplyRoleButton = new Guna.UI2.WinForms.Guna2Button();
            MinimizeButton = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // EmloyeeButton
            // 
            EmloyeeButton.BorderColor = Color.FromArgb(26, 139, 221);
            EmloyeeButton.BorderThickness = 2;
            EmloyeeButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            EmloyeeButton.CheckedState.FillColor = Color.FromArgb(110, 170, 255);
            EmloyeeButton.CheckedState.ForeColor = Color.White;
            EmloyeeButton.CustomizableEdges = customizableEdges11;
            EmloyeeButton.DisabledState.BorderColor = Color.DarkGray;
            EmloyeeButton.DisabledState.CustomBorderColor = Color.DarkGray;
            EmloyeeButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            EmloyeeButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            EmloyeeButton.FillColor = Color.White;
            EmloyeeButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            EmloyeeButton.ForeColor = Color.DodgerBlue;
            EmloyeeButton.Location = new Point(58, 192);
            EmloyeeButton.Name = "EmloyeeButton";
            EmloyeeButton.PressedColor = Color.FromArgb(26, 139, 221);
            EmloyeeButton.ShadowDecoration.CustomizableEdges = customizableEdges12;
            EmloyeeButton.Size = new Size(180, 75);
            EmloyeeButton.TabIndex = 0;
            EmloyeeButton.Text = "Emloyee";
            EmloyeeButton.CheckedChanged += RolesRadioButtons_CheckedChanged;
            // 
            // HRButton
            // 
            HRButton.BorderColor = Color.FromArgb(26, 139, 221);
            HRButton.BorderThickness = 2;
            HRButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            HRButton.CheckedState.FillColor = Color.FromArgb(110, 170, 255);
            HRButton.CheckedState.ForeColor = Color.White;
            HRButton.CustomizableEdges = customizableEdges9;
            HRButton.DisabledState.BorderColor = Color.DarkGray;
            HRButton.DisabledState.CustomBorderColor = Color.DarkGray;
            HRButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            HRButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            HRButton.FillColor = Color.White;
            HRButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            HRButton.ForeColor = Color.DodgerBlue;
            HRButton.Location = new Point(259, 192);
            HRButton.Name = "HRButton";
            HRButton.PressedColor = Color.FromArgb(26, 139, 221);
            HRButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            HRButton.Size = new Size(180, 75);
            HRButton.TabIndex = 1;
            HRButton.Text = "HR Manager";
            HRButton.CheckedChanged += RolesRadioButtons_CheckedChanged;
            // 
            // PMButton
            // 
            PMButton.BorderColor = Color.FromArgb(26, 139, 221);
            PMButton.BorderThickness = 2;
            PMButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            PMButton.CheckedState.FillColor = Color.FromArgb(110, 170, 255);
            PMButton.CheckedState.ForeColor = Color.White;
            PMButton.CustomizableEdges = customizableEdges7;
            PMButton.DisabledState.BorderColor = Color.DarkGray;
            PMButton.DisabledState.CustomBorderColor = Color.DarkGray;
            PMButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            PMButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            PMButton.FillColor = Color.White;
            PMButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PMButton.ForeColor = Color.DodgerBlue;
            PMButton.Location = new Point(460, 192);
            PMButton.Name = "PMButton";
            PMButton.PressedColor = Color.FromArgb(26, 139, 221);
            PMButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            PMButton.Size = new Size(180, 75);
            PMButton.TabIndex = 2;
            PMButton.Text = "Project Manager";
            PMButton.CheckedChanged += RolesRadioButtons_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(227, 113);
            label1.Name = "label1";
            label1.Size = new Size(250, 37);
            label1.TabIndex = 3;
            label1.Text = "Choose your role";
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.Transparent;
            CloseButton.CheckedState.FillColor = Color.OrangeRed;
            CloseButton.CustomizableEdges = customizableEdges5;
            CloseButton.DisabledState.BorderColor = Color.DarkGray;
            CloseButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CloseButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CloseButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CloseButton.FillColor = Color.Transparent;
            CloseButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.FromArgb(14, 75, 126);
            CloseButton.HoverState.FillColor = Color.LightCoral;
            CloseButton.Location = new Point(650, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.PressedColor = Color.IndianRed;
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            CloseButton.Size = new Size(52, 44);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "x";
            CloseButton.Click += CloseButton_Click;
            // 
            // ApplyRoleButton
            // 
            ApplyRoleButton.CustomizableEdges = customizableEdges3;
            ApplyRoleButton.DisabledState.BorderColor = Color.DarkGray;
            ApplyRoleButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ApplyRoleButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ApplyRoleButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ApplyRoleButton.Enabled = false;
            ApplyRoleButton.FillColor = Color.FromArgb(26, 139, 221);
            ApplyRoleButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ApplyRoleButton.ForeColor = Color.White;
            ApplyRoleButton.Location = new Point(258, 319);
            ApplyRoleButton.Name = "ApplyRoleButton";
            ApplyRoleButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ApplyRoleButton.Size = new Size(180, 45);
            ApplyRoleButton.TabIndex = 5;
            ApplyRoleButton.Text = "Apply";
            ApplyRoleButton.Click += ApplyRoleButton_Click;
            // 
            // MinimizeButton
            // 
            MinimizeButton.BackColor = Color.Transparent;
            MinimizeButton.CheckedState.FillColor = Color.RoyalBlue;
            MinimizeButton.CustomizableEdges = customizableEdges1;
            MinimizeButton.DisabledState.BorderColor = Color.DarkGray;
            MinimizeButton.DisabledState.CustomBorderColor = Color.DarkGray;
            MinimizeButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            MinimizeButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            MinimizeButton.FillColor = Color.Transparent;
            MinimizeButton.Font = new Font("Montserrat ExtraBold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            MinimizeButton.ForeColor = Color.FromArgb(14, 75, 126);
            MinimizeButton.HoverState.FillColor = Color.RoyalBlue;
            MinimizeButton.Location = new Point(597, 0);
            MinimizeButton.Name = "MinimizeButton";
            MinimizeButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            MinimizeButton.Size = new Size(52, 44);
            MinimizeButton.TabIndex = 6;
            MinimizeButton.Text = "—";
            MinimizeButton.Click += MinimizeButton_Click;
            // 
            // RoleSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 239, 252);
            ClientSize = new Size(702, 428);
            Controls.Add(MinimizeButton);
            Controls.Add(ApplyRoleButton);
            Controls.Add(CloseButton);
            Controls.Add(label1);
            Controls.Add(PMButton);
            Controls.Add(HRButton);
            Controls.Add(EmloyeeButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RoleSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += This_MouseDown;
            MouseMove += This_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button EmloyeeButton;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button PMButton;
        private Guna.UI2.WinForms.Guna2Button HRButton;
        private Guna.UI2.WinForms.Guna2Button CloseButton;
        private Guna.UI2.WinForms.Guna2Button ApplyRoleButton;
        private Guna.UI2.WinForms.Guna2Button MinimizeButton;
    }
}
