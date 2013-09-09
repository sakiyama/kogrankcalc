namespace KOGRankCalc
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.Run = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameTxtBox = new System.Windows.Forms.TextBox();
            this.contestRoundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileFullPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(851, 22);
            this.statusStrip1.TabIndex = 6;
            // 
            // MainDataGridView
            // 
            this.MainDataGridView.AllowDrop = true;
            this.MainDataGridView.AllowUserToAddRows = false;
            this.MainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainDataGridView.AutoGenerateColumns = false;
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contestRoundDataGridViewTextBoxColumn,
            this.fileFullPathDataGridViewTextBoxColumn});
            this.MainDataGridView.DataSource = this.fileNameDataSetBindingSource;
            this.MainDataGridView.Location = new System.Drawing.Point(14, 59);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.RowTemplate.Height = 21;
            this.MainDataGridView.Size = new System.Drawing.Size(827, 406);
            this.MainDataGridView.TabIndex = 5;
            this.MainDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainDataGridView_DragDrop);
            this.MainDataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainDataGridView_DragEnter);
            this.MainDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainDataGridView_KeyDown);
            // 
            // Run
            // 
            this.Run.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Run.Location = new System.Drawing.Point(14, 11);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(108, 34);
            this.Run.TabIndex = 2;
            this.Run.Text = "実行";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClearBtn.Location = new System.Drawing.Point(134, 11);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(108, 34);
            this.ClearBtn.TabIndex = 7;
            this.ClearBtn.Text = "リスト消去";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "出力ファイル名";
            // 
            // FileNameTxtBox
            // 
            this.FileNameTxtBox.Location = new System.Drawing.Point(254, 26);
            this.FileNameTxtBox.Name = "FileNameTxtBox";
            this.FileNameTxtBox.Size = new System.Drawing.Size(584, 19);
            this.FileNameTxtBox.TabIndex = 9;
            this.FileNameTxtBox.DoubleClick += new System.EventHandler(this.FileNameTxtBox_DoubleClick);
            // 
            // contestRoundDataGridViewTextBoxColumn
            // 
            this.contestRoundDataGridViewTextBoxColumn.DataPropertyName = "contestRound";
            this.contestRoundDataGridViewTextBoxColumn.HeaderText = "大会番号";
            this.contestRoundDataGridViewTextBoxColumn.Name = "contestRoundDataGridViewTextBoxColumn";
            // 
            // fileFullPathDataGridViewTextBoxColumn
            // 
            this.fileFullPathDataGridViewTextBoxColumn.DataPropertyName = "fileFullPath";
            this.fileFullPathDataGridViewTextBoxColumn.HeaderText = "ファイルパス";
            this.fileFullPathDataGridViewTextBoxColumn.Name = "fileFullPathDataGridViewTextBoxColumn";
            this.fileFullPathDataGridViewTextBoxColumn.Width = 550;
            // 
            // fileNameDataSetBindingSource
            // 
            this.fileNameDataSetBindingSource.DataSource = typeof(KOGRankCalc.FileNameDataSet);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 500);
            this.Controls.Add(this.FileNameTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.MainDataGridView);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Ranking Calculation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.BindingSource fileNameDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn contestRoundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileFullPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileNameTxtBox;
    }
}

