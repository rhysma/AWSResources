
namespace DyamoDB_WinForm
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
            this.createTable = new System.Windows.Forms.GroupBox();
            this.TableStatusLabel = new System.Windows.Forms.Label();
            this.CreateTableButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TableNameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CreateRecordButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.AddStatusLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GetButton = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.ListBox();
            this.createTable.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // createTable
            // 
            this.createTable.Controls.Add(this.TableStatusLabel);
            this.createTable.Controls.Add(this.CreateTableButton);
            this.createTable.Controls.Add(this.label1);
            this.createTable.Controls.Add(this.TableNameBox);
            this.createTable.Location = new System.Drawing.Point(12, 12);
            this.createTable.Name = "createTable";
            this.createTable.Size = new System.Drawing.Size(222, 167);
            this.createTable.TabIndex = 0;
            this.createTable.TabStop = false;
            this.createTable.Text = "Step 1: Create Table";
            // 
            // TableStatusLabel
            // 
            this.TableStatusLabel.AutoSize = true;
            this.TableStatusLabel.Location = new System.Drawing.Point(7, 141);
            this.TableStatusLabel.Name = "TableStatusLabel";
            this.TableStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.TableStatusLabel.TabIndex = 1;
            // 
            // CreateTableButton
            // 
            this.CreateTableButton.Location = new System.Drawing.Point(133, 82);
            this.CreateTableButton.Name = "CreateTableButton";
            this.CreateTableButton.Size = new System.Drawing.Size(75, 23);
            this.CreateTableButton.TabIndex = 2;
            this.CreateTableButton.Text = "Create";
            this.CreateTableButton.UseVisualStyleBackColor = true;
            this.CreateTableButton.Click += new System.EventHandler(this.CreateTableButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table Name";
            // 
            // TableNameBox
            // 
            this.TableNameBox.Location = new System.Drawing.Point(6, 42);
            this.TableNameBox.Name = "TableNameBox";
            this.TableNameBox.Size = new System.Drawing.Size(202, 20);
            this.TableNameBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddStatusLabel);
            this.groupBox1.Controls.Add(this.CreateRecordButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NameBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.IDBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 193);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 2: Create Record";
            // 
            // CreateRecordButton
            // 
            this.CreateRecordButton.Location = new System.Drawing.Point(133, 131);
            this.CreateRecordButton.Name = "CreateRecordButton";
            this.CreateRecordButton.Size = new System.Drawing.Size(75, 23);
            this.CreateRecordButton.TabIndex = 6;
            this.CreateRecordButton.Text = "Create";
            this.CreateRecordButton.UseVisualStyleBackColor = true;
            this.CreateRecordButton.Click += new System.EventHandler(this.CreateRecordButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(6, 99);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(202, 20);
            this.NameBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(6, 47);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(202, 20);
            this.IDBox.TabIndex = 2;
            // 
            // AddStatusLabel
            // 
            this.AddStatusLabel.AutoSize = true;
            this.AddStatusLabel.Location = new System.Drawing.Point(7, 169);
            this.AddStatusLabel.Name = "AddStatusLabel";
            this.AddStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.AddStatusLabel.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OutputBox);
            this.groupBox2.Controls.Add(this.GetButton);
            this.groupBox2.Location = new System.Drawing.Point(252, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 361);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 3: Get Records";
            // 
            // GetButton
            // 
            this.GetButton.Location = new System.Drawing.Point(6, 19);
            this.GetButton.Name = "GetButton";
            this.GetButton.Size = new System.Drawing.Size(75, 23);
            this.GetButton.TabIndex = 0;
            this.GetButton.Text = "Get";
            this.GetButton.UseVisualStyleBackColor = true;
            this.GetButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.FormattingEnabled = true;
            this.OutputBox.Location = new System.Drawing.Point(6, 54);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(302, 290);
            this.OutputBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.createTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.createTable.ResumeLayout(false);
            this.createTable.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox createTable;
        private System.Windows.Forms.Button CreateTableButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TableNameBox;
        private System.Windows.Forms.Label TableStatusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CreateRecordButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label AddStatusLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox OutputBox;
        private System.Windows.Forms.Button GetButton;
    }
}

