
namespace MegaDesk_Stratton
{
    partial class ViewAllQuotes
    {

        private System.ComponentModel.IContainer components = null;

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
            this.allQuotesClose = new System.Windows.Forms.Button();
            this.quotesListView = new System.Windows.Forms.ListView();
            this.customerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rush = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.depth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.material = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.drawers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.materialComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // allQuotesClose
            // 
            this.allQuotesClose.Location = new System.Drawing.Point(713, 415);
            this.allQuotesClose.Name = "allQuotesClose";
            this.allQuotesClose.Size = new System.Drawing.Size(75, 23);
            this.allQuotesClose.TabIndex = 0;
            this.allQuotesClose.Text = "Close";
            this.allQuotesClose.UseVisualStyleBackColor = true;
            this.allQuotesClose.Click += new System.EventHandler(this.allQuotesClose_Click);
            // 
            // quotesListView
            // 
            this.quotesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.customerName,
            this.Rush,
            this.width,
            this.depth,
            this.material,
            this.drawers});
            this.quotesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotesListView.HideSelection = false;
            this.quotesListView.Location = new System.Drawing.Point(12, 60);
            this.quotesListView.Name = "quotesListView";
            this.quotesListView.Size = new System.Drawing.Size(776, 333);
            this.quotesListView.TabIndex = 1;
            this.quotesListView.UseCompatibleStateImageBehavior = false;
            this.quotesListView.View = System.Windows.Forms.View.Details;
            // 
            // customerName
            // 
            this.customerName.Text = "Customer";
            this.customerName.Width = 200;
            // 
            // Rush
            // 
            this.Rush.Text = "Rush";
            // 
            // width
            // 
            this.width.Text = "Width";
            this.width.Width = 80;
            // 
            // depth
            // 
            this.depth.Text = "Depth";
            this.depth.Width = 80;
            // 
            // material
            // 
            this.material.Text = "Material";
            this.material.Width = 160;
            // 
            // drawers
            // 
            this.drawers.Text = "Drawers";
            this.drawers.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter by material:";
            // 
            // materialComboBox
            // 
            this.materialComboBox.FormattingEnabled = true;
            this.materialComboBox.Location = new System.Drawing.Point(667, 12);
            this.materialComboBox.Name = "materialComboBox";
            this.materialComboBox.Size = new System.Drawing.Size(121, 21);
            this.materialComboBox.TabIndex = 3;
            this.materialComboBox.SelectedValueChanged += new System.EventHandler(this.materialComboBox_SelectedValueChanged);
            // 
            // ViewAllQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quotesListView);
            this.Controls.Add(this.allQuotesClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAllQuotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View All Quotes";
            this.Load += new System.EventHandler(this.materialComboBox_SelectedValueChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button allQuotesClose;
        private System.Windows.Forms.ListView quotesListView;
        private System.Windows.Forms.ColumnHeader customerName;
        private System.Windows.Forms.ColumnHeader Rush;
        private System.Windows.Forms.ColumnHeader width;
        private System.Windows.Forms.ColumnHeader depth;
        private System.Windows.Forms.ColumnHeader material;
        private System.Windows.Forms.ColumnHeader drawers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox materialComboBox;
    }
}