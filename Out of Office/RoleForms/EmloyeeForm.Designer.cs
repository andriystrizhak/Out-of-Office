namespace OutOfOffice.RoleForms
{
    partial class EmployeeForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            MinimizeButton = new Guna.UI2.WinForms.Guna2Button();
            CloseButton = new Guna.UI2.WinForms.Guna2Button();
            ApplyRoleButton = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // MinimizeButton
            // 
            MinimizeButton.CheckedState.FillColor = Color.RoyalBlue;
            MinimizeButton.CustomizableEdges = customizableEdges3;
            MinimizeButton.DisabledState.BorderColor = Color.DarkGray;
            MinimizeButton.DisabledState.CustomBorderColor = Color.DarkGray;
            MinimizeButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            MinimizeButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            MinimizeButton.Font = new Font("Montserrat SemiBold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            MinimizeButton.ForeColor = Color.White;
            MinimizeButton.HoverState.FillColor = Color.RoyalBlue;
            MinimizeButton.Location = new Point(695, 0);
            MinimizeButton.Name = "MinimizeButton";
            MinimizeButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            MinimizeButton.Size = new Size(52, 44);
            MinimizeButton.TabIndex = 8;
            MinimizeButton.Text = "_";
            MinimizeButton.Click += MinimizeButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.CheckedState.FillColor = Color.OrangeRed;
            CloseButton.CustomizableEdges = customizableEdges5;
            CloseButton.DisabledState.BorderColor = Color.DarkGray;
            CloseButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CloseButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CloseButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CloseButton.Font = new Font("Montserrat SemiBold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.White;
            CloseButton.HoverState.FillColor = Color.OrangeRed;
            CloseButton.Location = new Point(748, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.PressedColor = Color.Firebrick;
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            CloseButton.Size = new Size(52, 44);
            CloseButton.TabIndex = 7;
            CloseButton.Text = "X";
            CloseButton.Click += CloseButton_Click;
            // 
            // ApplyRoleButton
            // 
            ApplyRoleButton.CustomizableEdges = customizableEdges1;
            ApplyRoleButton.DisabledState.BorderColor = Color.DarkGray;
            ApplyRoleButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ApplyRoleButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ApplyRoleButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ApplyRoleButton.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ApplyRoleButton.ForeColor = Color.White;
            ApplyRoleButton.Location = new Point(318, 347);
            ApplyRoleButton.Name = "ApplyRoleButton";
            ApplyRoleButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ApplyRoleButton.Size = new Size(180, 45);
            ApplyRoleButton.TabIndex = 9;
            ApplyRoleButton.Text = "Get";
            ApplyRoleButton.Click += ApplyRoleButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(61, 132);
            label1.Name = "label1";
            label1.Size = new Size(250, 37);
            label1.TabIndex = 10;
            label1.Text = "Choose your role";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(ApplyRoleButton);
            Controls.Add(MinimizeButton);
            Controls.Add(CloseButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeForm";
            Text = "DeveloperForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button MinimizeButton;
        private Guna.UI2.WinForms.Guna2Button CloseButton;
        private Guna.UI2.WinForms.Guna2Button ApplyRoleButton;
        private Label label1;
    }
}