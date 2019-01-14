namespace LevelManagerExample
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            this.DrawBox = new System.Windows.Forms.Button();
            this.SetColorByLevel = new System.Windows.Forms.Button();
            this.SelectGeometryByLevel = new System.Windows.Forms.Button();
            this.MoveGeometryToLevel = new System.Windows.Forms.Button();
            this.GetListOfLevelNames = new System.Windows.Forms.Button();
            this.SetLevelSetName = new System.Windows.Forms.Button();
            this.MoveAllLines = new System.Windows.Forms.Button();
            this.ToolTipControl = new System.Windows.Forms.ToolTip(this.components);
            this.CloseView = new System.Windows.Forms.Button();
            this.MoveGroupGeometry = new System.Windows.Forms.Button();
            this.CopyLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawBox
            // 
            this.DrawBox.Location = new System.Drawing.Point(20, 20);
            this.DrawBox.Name = "DrawBox";
            this.DrawBox.Size = new System.Drawing.Size(188, 30);
            this.DrawBox.TabIndex = 0;
            this.DrawBox.Text = "Draw Box";
            this.DrawBox.UseVisualStyleBackColor = true;
            this.DrawBox.Click += new System.EventHandler(this.OnDrawBox);
            // 
            // SetColorByLevel
            // 
            this.SetColorByLevel.Location = new System.Drawing.Point(20, 56);
            this.SetColorByLevel.Name = "SetColorByLevel";
            this.SetColorByLevel.Size = new System.Drawing.Size(188, 30);
            this.SetColorByLevel.TabIndex = 1;
            this.SetColorByLevel.Text = "Set Color By Level";
            this.SetColorByLevel.UseVisualStyleBackColor = true;
            this.SetColorByLevel.Click += new System.EventHandler(this.OnSetColorByLevel);
            // 
            // SelectGeometryByLevel
            // 
            this.SelectGeometryByLevel.Location = new System.Drawing.Point(20, 92);
            this.SelectGeometryByLevel.Name = "SelectGeometryByLevel";
            this.SelectGeometryByLevel.Size = new System.Drawing.Size(188, 30);
            this.SelectGeometryByLevel.TabIndex = 2;
            this.SelectGeometryByLevel.Text = "Select Geometry By Level";
            this.SelectGeometryByLevel.UseVisualStyleBackColor = true;
            this.SelectGeometryByLevel.Click += new System.EventHandler(this.OnSelectGeometryByLevel);
            // 
            // MoveGeometryToLevel
            // 
            this.MoveGeometryToLevel.Location = new System.Drawing.Point(20, 128);
            this.MoveGeometryToLevel.Name = "MoveGeometryToLevel";
            this.MoveGeometryToLevel.Size = new System.Drawing.Size(188, 30);
            this.MoveGeometryToLevel.TabIndex = 3;
            this.MoveGeometryToLevel.Text = "Move Geometry To Level";
            this.MoveGeometryToLevel.UseVisualStyleBackColor = true;
            this.MoveGeometryToLevel.Click += new System.EventHandler(this.OnMoveGeometryToLevel);
            // 
            // GetListOfLevelNames
            // 
            this.GetListOfLevelNames.Location = new System.Drawing.Point(20, 164);
            this.GetListOfLevelNames.Name = "GetListOfLevelNames";
            this.GetListOfLevelNames.Size = new System.Drawing.Size(188, 30);
            this.GetListOfLevelNames.TabIndex = 4;
            this.GetListOfLevelNames.Text = "Get List Of Level Names";
            this.GetListOfLevelNames.UseVisualStyleBackColor = true;
            this.GetListOfLevelNames.Click += new System.EventHandler(this.OnGetListOfLevelNames);
            // 
            // SetLevelSetName
            // 
            this.SetLevelSetName.Location = new System.Drawing.Point(20, 200);
            this.SetLevelSetName.Name = "SetLevelSetName";
            this.SetLevelSetName.Size = new System.Drawing.Size(188, 30);
            this.SetLevelSetName.TabIndex = 5;
            this.SetLevelSetName.Text = "Set Level Set Name";
            this.SetLevelSetName.UseVisualStyleBackColor = true;
            this.SetLevelSetName.Click += new System.EventHandler(this.OnSetLevelSetName);
            // 
            // MoveAllLines
            // 
            this.MoveAllLines.Location = new System.Drawing.Point(20, 236);
            this.MoveAllLines.Name = "MoveAllLines";
            this.MoveAllLines.Size = new System.Drawing.Size(188, 30);
            this.MoveAllLines.TabIndex = 6;
            this.MoveAllLines.Text = "Move All Lines";
            this.MoveAllLines.UseVisualStyleBackColor = true;
            this.MoveAllLines.Click += new System.EventHandler(this.OnMoveGeometry);
            // 
            // CloseView
            // 
            this.CloseView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseView.Location = new System.Drawing.Point(141, 368);
            this.CloseView.Name = "CloseView";
            this.CloseView.Size = new System.Drawing.Size(67, 26);
            this.CloseView.TabIndex = 7;
            this.CloseView.Text = "Close";
            this.CloseView.UseVisualStyleBackColor = true;
            this.CloseView.Click += new System.EventHandler(this.OnCloseView);
            // 
            // MoveGroupGeometry
            // 
            this.MoveGroupGeometry.Location = new System.Drawing.Point(20, 308);
            this.MoveGroupGeometry.Name = "MoveGroupGeometry";
            this.MoveGroupGeometry.Size = new System.Drawing.Size(188, 30);
            this.MoveGroupGeometry.TabIndex = 19;
            this.MoveGroupGeometry.Text = "Translate Arc Group Result";
            this.MoveGroupGeometry.UseVisualStyleBackColor = true;
            this.MoveGroupGeometry.Click += new System.EventHandler(this.OnMoveGroupGeometry);
            // 
            // CopyLevel
            // 
            this.CopyLevel.Location = new System.Drawing.Point(20, 272);
            this.CopyLevel.Name = "CopyLevel";
            this.CopyLevel.Size = new System.Drawing.Size(188, 30);
            this.CopyLevel.TabIndex = 18;
            this.CopyLevel.Text = "Copy Level";
            this.CopyLevel.UseVisualStyleBackColor = true;
            this.CopyLevel.Click += new System.EventHandler(this.OnCopyLevel);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 403);
            this.Controls.Add(this.MoveGroupGeometry);
            this.Controls.Add(this.CopyLevel);
            this.Controls.Add(this.CloseView);
            this.Controls.Add(this.MoveAllLines);
            this.Controls.Add(this.SetLevelSetName);
            this.Controls.Add(this.GetListOfLevelNames);
            this.Controls.Add(this.MoveGeometryToLevel);
            this.Controls.Add(this.SelectGeometryByLevel);
            this.Controls.Add(this.SetColorByLevel);
            this.Controls.Add(this.DrawBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Level Examples";
            this.Load += new System.EventHandler(this.OnMainView);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DrawBox;
        private System.Windows.Forms.Button SetColorByLevel;
        private System.Windows.Forms.Button SelectGeometryByLevel;
        private System.Windows.Forms.Button MoveGeometryToLevel;
        private System.Windows.Forms.Button GetListOfLevelNames;
        private System.Windows.Forms.Button SetLevelSetName;
        private System.Windows.Forms.Button MoveAllLines;
        private System.Windows.Forms.ToolTip ToolTipControl;
        private System.Windows.Forms.Button CloseView;
        private System.Windows.Forms.Button MoveGroupGeometry;
        private System.Windows.Forms.Button CopyLevel;
    }
}