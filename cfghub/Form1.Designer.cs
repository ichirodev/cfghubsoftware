
namespace cfghub
{
    partial class CFGHUB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFGHUB));
            this.LowerPanel = new System.Windows.Forms.Panel();
            this.DonateButton = new System.Windows.Forms.Button();
            this.InformationButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BAdd = new System.Windows.Forms.Button();
            this.TBName = new System.Windows.Forms.TextBox();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.ButtonRecover = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonUpdateAll = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.PanelData = new System.Windows.Forms.Panel();
            this.LVFolders = new System.Windows.Forms.ListView();
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnLastUpdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnSrc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LabelCFGHUB = new System.Windows.Forms.Label();
            this.LowerPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelButtons.SuspendLayout();
            this.PanelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // LowerPanel
            // 
            this.LowerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LowerPanel.Controls.Add(this.LabelCFGHUB);
            this.LowerPanel.Controls.Add(this.DonateButton);
            this.LowerPanel.Controls.Add(this.InformationButton);
            this.LowerPanel.Controls.Add(this.panel2);
            resources.ApplyResources(this.LowerPanel, "LowerPanel");
            this.LowerPanel.Name = "LowerPanel";
            // 
            // DonateButton
            // 
            this.DonateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.DonateButton, "DonateButton");
            this.DonateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DonateButton.FlatAppearance.BorderSize = 0;
            this.DonateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DonateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DonateButton.Name = "DonateButton";
            this.DonateButton.UseVisualStyleBackColor = false;
            this.DonateButton.Click += new System.EventHandler(this.DonateButton_Click);
            // 
            // InformationButton
            // 
            this.InformationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.InformationButton, "InformationButton");
            this.InformationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InformationButton.FlatAppearance.BorderSize = 0;
            this.InformationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InformationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InformationButton.Name = "InformationButton";
            this.InformationButton.UseVisualStyleBackColor = false;
            this.InformationButton.Click += new System.EventHandler(this.InformationButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.BAdd);
            this.panel2.Controls.Add(this.TBName);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // BAdd
            // 
            this.BAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            resources.ApplyResources(this.BAdd, "BAdd");
            this.BAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAdd.FlatAppearance.BorderSize = 0;
            this.BAdd.ForeColor = System.Drawing.Color.Transparent;
            this.BAdd.Name = "BAdd";
            this.BAdd.UseVisualStyleBackColor = false;
            this.BAdd.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // TBName
            // 
            this.TBName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TBName, "TBName");
            this.TBName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TBName.Name = "TBName";
            this.TBName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PanelButtons
            // 
            this.PanelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.PanelButtons.Controls.Add(this.ButtonOpenFolder);
            this.PanelButtons.Controls.Add(this.ButtonExport);
            this.PanelButtons.Controls.Add(this.ButtonRecover);
            this.PanelButtons.Controls.Add(this.ButtonDelete);
            this.PanelButtons.Controls.Add(this.ButtonUpdateAll);
            this.PanelButtons.Controls.Add(this.ButtonUpdate);
            this.PanelButtons.Controls.Add(this.ButtonAdd);
            resources.ApplyResources(this.PanelButtons, "PanelButtons");
            this.PanelButtons.Name = "PanelButtons";
            // 
            // ButtonOpenFolder
            // 
            this.ButtonOpenFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.ButtonOpenFolder, "ButtonOpenFolder");
            this.ButtonOpenFolder.FlatAppearance.BorderSize = 0;
            this.ButtonOpenFolder.ForeColor = System.Drawing.Color.White;
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.UseVisualStyleBackColor = false;
            this.ButtonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // ButtonExport
            // 
            this.ButtonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.ButtonExport, "ButtonExport");
            this.ButtonExport.FlatAppearance.BorderSize = 0;
            this.ButtonExport.ForeColor = System.Drawing.Color.White;
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.UseVisualStyleBackColor = false;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // ButtonRecover
            // 
            this.ButtonRecover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.ButtonRecover, "ButtonRecover");
            this.ButtonRecover.FlatAppearance.BorderSize = 0;
            this.ButtonRecover.ForeColor = System.Drawing.Color.White;
            this.ButtonRecover.Name = "ButtonRecover";
            this.ButtonRecover.UseVisualStyleBackColor = false;
            this.ButtonRecover.Click += new System.EventHandler(this.ButtonRecover_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.ButtonDelete, "ButtonDelete");
            this.ButtonDelete.FlatAppearance.BorderSize = 0;
            this.ButtonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonUpdateAll
            // 
            this.ButtonUpdateAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.ButtonUpdateAll, "ButtonUpdateAll");
            this.ButtonUpdateAll.FlatAppearance.BorderSize = 0;
            this.ButtonUpdateAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ButtonUpdateAll.Name = "ButtonUpdateAll";
            this.ButtonUpdateAll.UseVisualStyleBackColor = false;
            this.ButtonUpdateAll.Click += new System.EventHandler(this.ButtonUpdateAll_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.ButtonUpdate, "ButtonUpdate");
            this.ButtonUpdate.FlatAppearance.BorderSize = 0;
            this.ButtonUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.UseVisualStyleBackColor = false;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.ButtonAdd, "ButtonAdd");
            this.ButtonAdd.FlatAppearance.BorderSize = 0;
            this.ButtonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.UseVisualStyleBackColor = false;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // PanelData
            // 
            this.PanelData.BackColor = System.Drawing.Color.Transparent;
            this.PanelData.Controls.Add(this.LVFolders);
            resources.ApplyResources(this.PanelData, "PanelData");
            this.PanelData.Name = "PanelData";
            // 
            // LVFolders
            // 
            this.LVFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LVFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LVFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.ColumnLastUpdate,
            this.ColumnSrc,
            this.ColumnSize});
            resources.ApplyResources(this.LVFolders, "LVFolders");
            this.LVFolders.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LVFolders.HideSelection = false;
            this.LVFolders.Name = "LVFolders";
            this.LVFolders.UseCompatibleStateImageBehavior = false;
            this.LVFolders.View = System.Windows.Forms.View.Details;
            this.LVFolders.SelectedIndexChanged += new System.EventHandler(this.LVFolders_SelectedIndexChanged);
            // 
            // ColumnName
            // 
            resources.ApplyResources(this.ColumnName, "ColumnName");
            // 
            // ColumnLastUpdate
            // 
            resources.ApplyResources(this.ColumnLastUpdate, "ColumnLastUpdate");
            // 
            // ColumnSrc
            // 
            resources.ApplyResources(this.ColumnSrc, "ColumnSrc");
            // 
            // ColumnSize
            // 
            resources.ApplyResources(this.ColumnSize, "ColumnSize");
            // 
            // LabelCFGHUB
            // 
            resources.ApplyResources(this.LabelCFGHUB, "LabelCFGHUB");
            this.LabelCFGHUB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelCFGHUB.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelCFGHUB.Name = "LabelCFGHUB";
            // 
            // CFGHUB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.Controls.Add(this.PanelData);
            this.Controls.Add(this.PanelButtons);
            this.Controls.Add(this.LowerPanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "CFGHUB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LowerPanel.ResumeLayout(false);
            this.LowerPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelButtons.ResumeLayout(false);
            this.PanelData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LowerPanel;
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonUpdateAll;
        private System.Windows.Forms.Button ButtonOpenFolder;
        private System.Windows.Forms.Button ButtonExport;
        private System.Windows.Forms.Button ButtonRecover;
        private System.Windows.Forms.Panel PanelData;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnLastUpdate;
        private System.Windows.Forms.ColumnHeader ColumnSrc;
        private System.Windows.Forms.ColumnHeader ColumnSize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.Button BAdd;
        private System.Windows.Forms.ListView LVFolders;
        private System.Windows.Forms.Button InformationButton;
        private System.Windows.Forms.Button DonateButton;
        private System.Windows.Forms.Label LabelCFGHUB;
    }
}

