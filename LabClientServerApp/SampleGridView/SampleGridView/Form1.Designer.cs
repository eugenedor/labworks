namespace SampleGridView
{
    partial class Form1
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
            this.dgvContinent = new System.Windows.Forms.DataGridView();
            this.redBookDataSet = new SampleGridView.RedBookDataSet();
            this.cTContinentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cT_ContinentsTableAdapter = new SampleGridView.RedBookDataSetTableAdapters.CT_ContinentsTableAdapter();
            this.continentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.continentCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.continentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redBookDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTContinentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContinent
            // 
            this.dgvContinent.AutoGenerateColumns = false;
            this.dgvContinent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContinent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.continentIdDataGridViewTextBoxColumn,
            this.continentCodeDataGridViewTextBoxColumn,
            this.continentNameDataGridViewTextBoxColumn});
            this.dgvContinent.DataSource = this.cTContinentsBindingSource;
            this.dgvContinent.Location = new System.Drawing.Point(13, 12);
            this.dgvContinent.Name = "dgvContinent";
            this.dgvContinent.Size = new System.Drawing.Size(373, 238);
            this.dgvContinent.TabIndex = 0;
            // 
            // redBookDataSet
            // 
            this.redBookDataSet.DataSetName = "RedBookDataSet";
            this.redBookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cTContinentsBindingSource
            // 
            this.cTContinentsBindingSource.DataMember = "CT_Continents";
            this.cTContinentsBindingSource.DataSource = this.redBookDataSet;
            // 
            // cT_ContinentsTableAdapter
            // 
            this.cT_ContinentsTableAdapter.ClearBeforeFill = true;
            // 
            // continentIdDataGridViewTextBoxColumn
            // 
            this.continentIdDataGridViewTextBoxColumn.DataPropertyName = "ContinentId";
            this.continentIdDataGridViewTextBoxColumn.HeaderText = "ContinentId";
            this.continentIdDataGridViewTextBoxColumn.Name = "continentIdDataGridViewTextBoxColumn";
            this.continentIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // continentCodeDataGridViewTextBoxColumn
            // 
            this.continentCodeDataGridViewTextBoxColumn.DataPropertyName = "ContinentCode";
            this.continentCodeDataGridViewTextBoxColumn.HeaderText = "ContinentCode";
            this.continentCodeDataGridViewTextBoxColumn.Name = "continentCodeDataGridViewTextBoxColumn";
            // 
            // continentNameDataGridViewTextBoxColumn
            // 
            this.continentNameDataGridViewTextBoxColumn.DataPropertyName = "ContinentName";
            this.continentNameDataGridViewTextBoxColumn.HeaderText = "ContinentName";
            this.continentNameDataGridViewTextBoxColumn.Name = "continentNameDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 262);
            this.Controls.Add(this.dgvContinent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redBookDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTContinentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContinent;
        private RedBookDataSet redBookDataSet;
        private System.Windows.Forms.BindingSource cTContinentsBindingSource;
        private RedBookDataSetTableAdapters.CT_ContinentsTableAdapter cT_ContinentsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn continentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn continentCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn continentNameDataGridViewTextBoxColumn;
    }
}

