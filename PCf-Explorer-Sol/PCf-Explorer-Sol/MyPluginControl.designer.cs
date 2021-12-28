
namespace PCf_Explorer_Sol
{
	partial class MyPluginControl
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.toolStripMenu = new System.Windows.Forms.ToolStrip();
			this.tsbClose = new System.Windows.Forms.ToolStripButton();
			this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.txtsearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listViewPCF = new System.Windows.Forms.ListView();
			this.maintbllayout = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelinner = new System.Windows.Forms.TableLayoutPanel();
			this.listViewDetails = new System.Windows.Forms.ListView();
			this.txtpcfjson = new System.Windows.Forms.RichTextBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.comboBoxtotal = new System.Windows.Forms.ComboBox();
			this.headingpblpanel = new System.Windows.Forms.TableLayoutPanel();
			this.lbltotal = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.toolStripMenu.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.maintbllayout.SuspendLayout();
			this.tableLayoutPanelinner.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.headingpblpanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripMenu
			// 
			this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
			this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStripMenu.Name = "toolStripMenu";
			this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.toolStripMenu.Size = new System.Drawing.Size(1059, 25);
			this.toolStripMenu.TabIndex = 4;
			this.toolStripMenu.Text = "toolStrip1";
			// 
			// tsbClose
			// 
			this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbClose.Name = "tsbClose";
			this.tsbClose.Size = new System.Drawing.Size(86, 22);
			this.tsbClose.Text = "Close this tool";
			this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
			// 
			// tssSeparator1
			// 
			this.tssSeparator1.Name = "tssSeparator1";
			this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			this.tableLayoutPanel1.Controls.Add(this.txtsearch, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 31);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// txtsearch
			// 
			this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtsearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtsearch.Location = new System.Drawing.Point(153, 1);
			this.txtsearch.Margin = new System.Windows.Forms.Padding(1);
			this.txtsearch.Name = "txtsearch";
			this.txtsearch.Size = new System.Drawing.Size(248, 25);
			this.txtsearch.TabIndex = 0;
			this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
			this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyDown);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(1, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search control";
			// 
			// listViewPCF
			// 
			this.listViewPCF.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewPCF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listViewPCF.HideSelection = false;
			this.listViewPCF.Location = new System.Drawing.Point(1, 34);
			this.listViewPCF.Margin = new System.Windows.Forms.Padding(1);
			this.listViewPCF.Name = "listViewPCF";
			this.listViewPCF.Size = new System.Drawing.Size(402, 577);
			this.listViewPCF.TabIndex = 0;
			this.listViewPCF.UseCompatibleStateImageBehavior = false;
			this.listViewPCF.SelectedIndexChanged += new System.EventHandler(this.listViewPCF_SelectedIndexChanged);
			// 
			// maintbllayout
			// 
			this.maintbllayout.ColumnCount = 3;
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.5F));
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.5F));
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
			this.maintbllayout.Controls.Add(this.listViewPCF, 0, 1);
			this.maintbllayout.Controls.Add(this.tableLayoutPanelinner, 1, 1);
			this.maintbllayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.maintbllayout.Controls.Add(this.headingpblpanel, 1, 0);
			this.maintbllayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maintbllayout.Location = new System.Drawing.Point(0, 25);
			this.maintbllayout.Margin = new System.Windows.Forms.Padding(1);
			this.maintbllayout.Name = "maintbllayout";
			this.maintbllayout.RowCount = 2;
			this.maintbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.maintbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.maintbllayout.Size = new System.Drawing.Size(1059, 612);
			this.maintbllayout.TabIndex = 5;
			// 
			// tableLayoutPanelinner
			// 
			this.tableLayoutPanelinner.ColumnCount = 2;
			this.tableLayoutPanelinner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelinner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
			this.tableLayoutPanelinner.Controls.Add(this.listViewDetails, 0, 0);
			this.tableLayoutPanelinner.Controls.Add(this.txtpcfjson, 0, 1);
			this.tableLayoutPanelinner.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanelinner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelinner.Location = new System.Drawing.Point(405, 34);
			this.tableLayoutPanelinner.Margin = new System.Windows.Forms.Padding(1);
			this.tableLayoutPanelinner.Name = "tableLayoutPanelinner";
			this.tableLayoutPanelinner.RowCount = 2;
			this.tableLayoutPanelinner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.77936F));
			this.tableLayoutPanelinner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.22064F));
			this.tableLayoutPanelinner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelinner.Size = new System.Drawing.Size(643, 577);
			this.tableLayoutPanelinner.TabIndex = 1;
			// 
			// listViewDetails
			// 
			this.listViewDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listViewDetails.HideSelection = false;
			this.listViewDetails.Location = new System.Drawing.Point(1, 1);
			this.listViewDetails.Margin = new System.Windows.Forms.Padding(1);
			this.listViewDetails.Name = "listViewDetails";
			this.listViewDetails.Size = new System.Drawing.Size(437, 286);
			this.listViewDetails.TabIndex = 2;
			this.listViewDetails.UseCompatibleStateImageBehavior = false;
			// 
			// txtpcfjson
			// 
			this.tableLayoutPanelinner.SetColumnSpan(this.txtpcfjson, 2);
			this.txtpcfjson.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtpcfjson.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtpcfjson.Location = new System.Drawing.Point(3, 291);
			this.txtpcfjson.Name = "txtpcfjson";
			this.txtpcfjson.ReadOnly = true;
			this.tableLayoutPanelinner.SetRowSpan(this.txtpcfjson, 2);
			this.txtpcfjson.Size = new System.Drawing.Size(637, 283);
			this.txtpcfjson.TabIndex = 4;
			this.txtpcfjson.Text = "";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.listBox1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.comboBoxtotal, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(442, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.376964F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.62304F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(198, 282);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(1, 24);
			this.listBox1.Margin = new System.Windows.Forms.Padding(1);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(196, 257);
			this.listBox1.TabIndex = 2;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// comboBoxtotal
			// 
			this.comboBoxtotal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxtotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxtotal.FormattingEnabled = true;
			this.comboBoxtotal.Items.AddRange(new object[] {
            "Field",
            "Dataset",
            "Custom controls",
            "Default controls"});
			this.comboBoxtotal.Location = new System.Drawing.Point(1, 1);
			this.comboBoxtotal.Margin = new System.Windows.Forms.Padding(1);
			this.comboBoxtotal.Name = "comboBoxtotal";
			this.comboBoxtotal.Size = new System.Drawing.Size(196, 25);
			this.comboBoxtotal.TabIndex = 0;
			this.comboBoxtotal.SelectedIndexChanged += new System.EventHandler(this.comboBoxtotal_SelectedIndexChanged);
			// 
			// headingpblpanel
			// 
			this.headingpblpanel.ColumnCount = 3;
			this.headingpblpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.42572F));
			this.headingpblpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.57428F));
			this.headingpblpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
			this.headingpblpanel.Controls.Add(this.lbltotal, 1, 0);
			this.headingpblpanel.Controls.Add(this.linkLabel1, 2, 0);
			this.headingpblpanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.headingpblpanel.Location = new System.Drawing.Point(407, 3);
			this.headingpblpanel.Name = "headingpblpanel";
			this.headingpblpanel.RowCount = 1;
			this.headingpblpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.headingpblpanel.Size = new System.Drawing.Size(639, 27);
			this.headingpblpanel.TabIndex = 3;
			// 
			// lbltotal
			// 
			this.lbltotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbltotal.AutoSize = true;
			this.lbltotal.Location = new System.Drawing.Point(40, 7);
			this.lbltotal.Name = "lbltotal";
			this.lbltotal.Size = new System.Drawing.Size(35, 13);
			this.lbltotal.TabIndex = 0;
			this.lbltotal.Text = "label2";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(453, 7);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(102, 13);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Please rate if helpful";
			// 
			// MyPluginControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.maintbllayout);
			this.Controls.Add(this.toolStripMenu);
			this.Name = "MyPluginControl";
			this.Size = new System.Drawing.Size(1059, 637);
			this.Load += new System.EventHandler(this.MyPluginControl_Load);
			this.toolStripMenu.ResumeLayout(false);
			this.toolStripMenu.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.maintbllayout.ResumeLayout(false);
			this.tableLayoutPanelinner.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.headingpblpanel.ResumeLayout(false);
			this.headingpblpanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStripMenu;
		private System.Windows.Forms.ToolStripSeparator tssSeparator1;
		private System.Windows.Forms.ToolStripButton tsbClose;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox txtsearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listViewPCF;
		private System.Windows.Forms.TableLayoutPanel maintbllayout;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelinner;
		private System.Windows.Forms.ListView listViewDetails;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ComboBox comboBoxtotal;
		private System.Windows.Forms.RichTextBox txtpcfjson;
		private System.Windows.Forms.TableLayoutPanel headingpblpanel;
		private System.Windows.Forms.Label lbltotal;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}
