namespace Molecular_Mass_Calculator
{
    partial class MolecularMass
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
            this.UI_DGV_Data = new System.Windows.Forms.DataGridView();
            this.UI_BTN_Name = new System.Windows.Forms.Button();
            this.UI_BTN_Number = new System.Windows.Forms.Button();
            this.UI_BTN_SingleSymbol = new System.Windows.Forms.Button();
            this.UI_TB_Formula = new System.Windows.Forms.TextBox();
            this.UI_TB_Mass = new System.Windows.Forms.TextBox();
            this.UI_LBL_Formula = new System.Windows.Forms.Label();
            this.UI_LBL_Mass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_DGV_Data
            // 
            this.UI_DGV_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DGV_Data.Location = new System.Drawing.Point(12, 12);
            this.UI_DGV_Data.Name = "UI_DGV_Data";
            this.UI_DGV_Data.Size = new System.Drawing.Size(466, 494);
            this.UI_DGV_Data.TabIndex = 0;
            // 
            // UI_BTN_Name
            // 
            this.UI_BTN_Name.Location = new System.Drawing.Point(484, 12);
            this.UI_BTN_Name.Name = "UI_BTN_Name";
            this.UI_BTN_Name.Size = new System.Drawing.Size(137, 23);
            this.UI_BTN_Name.TabIndex = 1;
            this.UI_BTN_Name.Text = "Sort By Name";
            this.UI_BTN_Name.UseVisualStyleBackColor = true;
            this.UI_BTN_Name.Click += new System.EventHandler(this.UI_BTN_Name_Click);
            // 
            // UI_BTN_Number
            // 
            this.UI_BTN_Number.Location = new System.Drawing.Point(484, 41);
            this.UI_BTN_Number.Name = "UI_BTN_Number";
            this.UI_BTN_Number.Size = new System.Drawing.Size(137, 23);
            this.UI_BTN_Number.TabIndex = 2;
            this.UI_BTN_Number.Text = "Sort By Atomic Number";
            this.UI_BTN_Number.UseVisualStyleBackColor = true;
            this.UI_BTN_Number.Click += new System.EventHandler(this.UI_BTN_Number_Click);
            // 
            // UI_BTN_SingleSymbol
            // 
            this.UI_BTN_SingleSymbol.Location = new System.Drawing.Point(484, 70);
            this.UI_BTN_SingleSymbol.Name = "UI_BTN_SingleSymbol";
            this.UI_BTN_SingleSymbol.Size = new System.Drawing.Size(137, 23);
            this.UI_BTN_SingleSymbol.TabIndex = 3;
            this.UI_BTN_SingleSymbol.Text = "Single Character Symbols";
            this.UI_BTN_SingleSymbol.UseVisualStyleBackColor = true;
            this.UI_BTN_SingleSymbol.Click += new System.EventHandler(this.UI_BTN_SingleSymbol_Click);
            // 
            // UI_TB_Formula
            // 
            this.UI_TB_Formula.Location = new System.Drawing.Point(108, 508);
            this.UI_TB_Formula.Name = "UI_TB_Formula";
            this.UI_TB_Formula.Size = new System.Drawing.Size(285, 20);
            this.UI_TB_Formula.TabIndex = 4;
            this.UI_TB_Formula.TextChanged += new System.EventHandler(this.UI_TB_Formula_TextChanged);
            // 
            // UI_TB_Mass
            // 
            this.UI_TB_Mass.Location = new System.Drawing.Point(508, 508);
            this.UI_TB_Mass.Name = "UI_TB_Mass";
            this.UI_TB_Mass.ReadOnly = true;
            this.UI_TB_Mass.Size = new System.Drawing.Size(113, 20);
            this.UI_TB_Mass.TabIndex = 5;
            this.UI_TB_Mass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_LBL_Formula
            // 
            this.UI_LBL_Formula.AutoSize = true;
            this.UI_LBL_Formula.Location = new System.Drawing.Point(12, 509);
            this.UI_LBL_Formula.Name = "UI_LBL_Formula";
            this.UI_LBL_Formula.Size = new System.Drawing.Size(93, 13);
            this.UI_LBL_Formula.TabIndex = 6;
            this.UI_LBL_Formula.Text = "Chemical Formula:";
            // 
            // UI_LBL_Mass
            // 
            this.UI_LBL_Mass.AutoSize = true;
            this.UI_LBL_Mass.Location = new System.Drawing.Point(399, 509);
            this.UI_LBL_Mass.Name = "UI_LBL_Mass";
            this.UI_LBL_Mass.Size = new System.Drawing.Size(103, 13);
            this.UI_LBL_Mass.TabIndex = 7;
            this.UI_LBL_Mass.Text = "Approx. Molar Mass:";
            // 
            // MolecularMass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 537);
            this.Controls.Add(this.UI_LBL_Mass);
            this.Controls.Add(this.UI_LBL_Formula);
            this.Controls.Add(this.UI_TB_Mass);
            this.Controls.Add(this.UI_TB_Formula);
            this.Controls.Add(this.UI_BTN_SingleSymbol);
            this.Controls.Add(this.UI_BTN_Number);
            this.Controls.Add(this.UI_BTN_Name);
            this.Controls.Add(this.UI_DGV_Data);
            this.MaximumSize = new System.Drawing.Size(649, 576);
            this.MinimumSize = new System.Drawing.Size(649, 576);
            this.Name = "MolecularMass";
            this.Text = "Molar Mass Calculator";
            this.Load += new System.EventHandler(this.MolecularMass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DGV_Data;
        private System.Windows.Forms.Button UI_BTN_Name;
        private System.Windows.Forms.Button UI_BTN_Number;
        private System.Windows.Forms.Button UI_BTN_SingleSymbol;
        private System.Windows.Forms.TextBox UI_TB_Formula;
        private System.Windows.Forms.TextBox UI_TB_Mass;
        private System.Windows.Forms.Label UI_LBL_Formula;
        private System.Windows.Forms.Label UI_LBL_Mass;
    }
}

