/*
 * Created by SharpDevelop.
 * User: Patricia
 * Date: 28. 3. 2017
 * Time: 18:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GUI
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelToListBox = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(704, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "TOWER";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(704, 304);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "PAUSE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(704, 360);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 48);
            this.button4.TabIndex = 3;
            this.button4.Text = "LOAD";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(704, 416);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 48);
            this.button5.TabIndex = 4;
            this.button5.Text = "SAVE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(584, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 32);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(504, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "SCORE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(578, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(704, 165);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(91, 69);
            this.listBox1.TabIndex = 9;
            // 
            // labelToListBox
            // 
            this.labelToListBox.AutoSize = true;
            this.labelToListBox.Location = new System.Drawing.Point(701, 138);
            this.labelToListBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelToListBox.Name = "labelToListBox";
            this.labelToListBox.Size = new System.Drawing.Size(80, 13);
            this.labelToListBox.TabIndex = 10;
            this.labelToListBox.Text = "Select Difficulty";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(704, 62);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 48);
            this.button6.TabIndex = 11;
            this.button6.Text = "MULTI TOWER";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(823, 550);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.labelToListBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Defenders of H6";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelToListBox;
        private System.Windows.Forms.Button button6;
    }
}
