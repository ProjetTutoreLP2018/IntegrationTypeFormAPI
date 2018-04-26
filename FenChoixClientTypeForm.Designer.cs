namespace LettreCooperation
{
	partial class FenChoixClientTypeForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.cbChoixClientTypeForm = new System.Windows.Forms.ComboBox();
			this.btnValideChoixClientTypeForm = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Client : ";
			// 
			// cbChoixClientTypeForm
			// 
			this.cbChoixClientTypeForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChoixClientTypeForm.FormattingEnabled = true;
			this.cbChoixClientTypeForm.Location = new System.Drawing.Point(63, 12);
			this.cbChoixClientTypeForm.Name = "cbChoixClientTypeForm";
			this.cbChoixClientTypeForm.Size = new System.Drawing.Size(326, 21);
			this.cbChoixClientTypeForm.TabIndex = 1;
			// 
			// btnValideChoixClientTypeForm
			// 
			this.btnValideChoixClientTypeForm.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnValideChoixClientTypeForm.Location = new System.Drawing.Point(314, 61);
			this.btnValideChoixClientTypeForm.Name = "btnValideChoixClientTypeForm";
			this.btnValideChoixClientTypeForm.Size = new System.Drawing.Size(75, 23);
			this.btnValideChoixClientTypeForm.TabIndex = 2;
			this.btnValideChoixClientTypeForm.Text = "Valider";
			this.btnValideChoixClientTypeForm.UseVisualStyleBackColor = true;
			this.btnValideChoixClientTypeForm.Click += new System.EventHandler(this.btnValideChoixClientTypeForm_Click);
			// 
			// FenChoixClientTypeForm
			// 
			this.AcceptButton = this.btnValideChoixClientTypeForm;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 96);
			this.Controls.Add(this.btnValideChoixClientTypeForm);
			this.Controls.Add(this.cbChoixClientTypeForm);
			this.Controls.Add(this.label1);
			this.Name = "FenChoixClientTypeForm";
			this.Text = "Choisissez le client";
			this.Load += new System.EventHandler(this.FenChoixClientTypeForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbChoixClientTypeForm;
		private System.Windows.Forms.Button btnValideChoixClientTypeForm;
	}
}