namespace KaloScriptEdit
{
    partial class KaloScriptEdit
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
            this.propListBox = new System.Windows.Forms.ListBox();
            this.deletePropButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.globalPropertiesListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stateListBox = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.addPropButton = new System.Windows.Forms.Button();
            this.addStateButton = new System.Windows.Forms.Button();
            this.deleteStateButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.globalPropertyValueTextBox = new System.Windows.Forms.TextBox();
            this.reviewStateListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.statePropertyValueTextBox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.sceneListBox = new System.Windows.Forms.ListBox();
            this.addSceneButton = new System.Windows.Forms.Button();
            this.deleteSceneButton = new System.Windows.Forms.Button();
            this.globalPropertiesPlusOneButton = new System.Windows.Forms.Button();
            this.globalPropertiesMinusOneButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.globalPropertiesHoldMsTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.globalPropertiesTargetTextBox = new System.Windows.Forms.TextBox();
            this.statePropertiesPlusOneButton = new System.Windows.Forms.Button();
            this.statePropertiesMinusOneButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.statePropertiesHoldMsTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // propListBox
            // 
            this.propListBox.FormattingEnabled = true;
            this.propListBox.Location = new System.Drawing.Point(14, 34);
            this.propListBox.Name = "propListBox";
            this.propListBox.Size = new System.Drawing.Size(158, 342);
            this.propListBox.TabIndex = 1;
            // 
            // deletePropButton
            // 
            this.deletePropButton.Location = new System.Drawing.Point(14, 411);
            this.deletePropButton.Name = "deletePropButton";
            this.deletePropButton.Size = new System.Drawing.Size(158, 23);
            this.deletePropButton.TabIndex = 0;
            this.deletePropButton.Text = "Delete Prop";
            this.deletePropButton.UseVisualStyleBackColor = true;
            this.deletePropButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.globalPropertiesTargetTextBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.globalPropertiesHoldMsTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.globalPropertiesMinusOneButton);
            this.panel1.Controls.Add(this.globalPropertiesPlusOneButton);
            this.panel1.Controls.Add(this.globalPropertyValueTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.globalPropertiesListBox);
            this.panel1.Location = new System.Drawing.Point(178, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 410);
            this.panel1.TabIndex = 3;
            // 
            // globalPropertiesListBox
            // 
            this.globalPropertiesListBox.FormattingEnabled = true;
            this.globalPropertiesListBox.Location = new System.Drawing.Point(6, 21);
            this.globalPropertiesListBox.Name = "globalPropertiesListBox";
            this.globalPropertiesListBox.Size = new System.Drawing.Size(206, 173);
            this.globalPropertiesListBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.propListBox);
            this.panel2.Controls.Add(this.addPropButton);
            this.panel2.Controls.Add(this.deletePropButton);
            this.panel2.Location = new System.Drawing.Point(112, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 443);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Prop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Review Global Properties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Choose State";
            // 
            // stateListBox
            // 
            this.stateListBox.FormattingEnabled = true;
            this.stateListBox.Location = new System.Drawing.Point(11, 33);
            this.stateListBox.Name = "stateListBox";
            this.stateListBox.Size = new System.Drawing.Size(144, 342);
            this.stateListBox.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.deleteStateButton);
            this.panel3.Controls.Add(this.addStateButton);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.stateListBox);
            this.panel3.Location = new System.Drawing.Point(505, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 449);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.statePropertyValueTextBox);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.statePropertiesHoldMsTextBox);
            this.panel4.Controls.Add(this.reviewStateListBox);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.statePropertiesMinusOneButton);
            this.panel4.Controls.Add(this.statePropertiesPlusOneButton);
            this.panel4.Location = new System.Drawing.Point(148, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 413);
            this.panel4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Review State Properties";
            // 
            // addPropButton
            // 
            this.addPropButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addPropButton.Location = new System.Drawing.Point(14, 387);
            this.addPropButton.Name = "addPropButton";
            this.addPropButton.Size = new System.Drawing.Size(158, 23);
            this.addPropButton.TabIndex = 0;
            this.addPropButton.Text = "Add Prop";
            this.addPropButton.UseVisualStyleBackColor = true;
            // 
            // addStateButton
            // 
            this.addStateButton.Location = new System.Drawing.Point(11, 385);
            this.addStateButton.Name = "addStateButton";
            this.addStateButton.Size = new System.Drawing.Size(131, 23);
            this.addStateButton.TabIndex = 9;
            this.addStateButton.Text = "Add State";
            this.addStateButton.UseVisualStyleBackColor = true;
            // 
            // deleteStateButton
            // 
            this.deleteStateButton.Location = new System.Drawing.Point(11, 414);
            this.deleteStateButton.Name = "deleteStateButton";
            this.deleteStateButton.Size = new System.Drawing.Size(131, 23);
            this.deleteStateButton.TabIndex = 10;
            this.deleteStateButton.Text = "Delete State";
            this.deleteStateButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Global Property Value";
            // 
            // globalPropertyValueTextBox
            // 
            this.globalPropertyValueTextBox.Location = new System.Drawing.Point(6, 250);
            this.globalPropertyValueTextBox.Multiline = true;
            this.globalPropertyValueTextBox.Name = "globalPropertyValueTextBox";
            this.globalPropertyValueTextBox.Size = new System.Drawing.Size(206, 63);
            this.globalPropertyValueTextBox.TabIndex = 3;
            // 
            // reviewStateListBox
            // 
            this.reviewStateListBox.FormattingEnabled = true;
            this.reviewStateListBox.Location = new System.Drawing.Point(7, 21);
            this.reviewStateListBox.Name = "reviewStateListBox";
            this.reviewStateListBox.Size = new System.Drawing.Size(232, 186);
            this.reviewStateListBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "State Property Value";
            // 
            // statePropertyValueTextBox
            // 
            this.statePropertyValueTextBox.Location = new System.Drawing.Point(7, 253);
            this.statePropertyValueTextBox.Multiline = true;
            this.statePropertyValueTextBox.Name = "statePropertyValueTextBox";
            this.statePropertyValueTextBox.Size = new System.Drawing.Size(221, 63);
            this.statePropertyValueTextBox.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.sceneListBox);
            this.panel5.Controls.Add(this.addSceneButton);
            this.panel5.Controls.Add(this.deleteSceneButton);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Location = new System.Drawing.Point(12, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(492, 449);
            this.panel5.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Choose Scene";
            // 
            // sceneListBox
            // 
            this.sceneListBox.FormattingEnabled = true;
            this.sceneListBox.Location = new System.Drawing.Point(14, 36);
            this.sceneListBox.Name = "sceneListBox";
            this.sceneListBox.Size = new System.Drawing.Size(92, 342);
            this.sceneListBox.TabIndex = 1;
            // 
            // addSceneButton
            // 
            this.addSceneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addSceneButton.Location = new System.Drawing.Point(14, 390);
            this.addSceneButton.Name = "addSceneButton";
            this.addSceneButton.Size = new System.Drawing.Size(92, 23);
            this.addSceneButton.TabIndex = 0;
            this.addSceneButton.Text = "Add Scene";
            this.addSceneButton.UseVisualStyleBackColor = true;
            // 
            // deleteSceneButton
            // 
            this.deleteSceneButton.Location = new System.Drawing.Point(14, 414);
            this.deleteSceneButton.Name = "deleteSceneButton";
            this.deleteSceneButton.Size = new System.Drawing.Size(92, 23);
            this.deleteSceneButton.TabIndex = 0;
            this.deleteSceneButton.Text = "Delete Scene";
            this.deleteSceneButton.UseVisualStyleBackColor = true;
            // 
            // globalPropertiesPlusOneButton
            // 
            this.globalPropertiesPlusOneButton.Location = new System.Drawing.Point(6, 201);
            this.globalPropertiesPlusOneButton.Name = "globalPropertiesPlusOneButton";
            this.globalPropertiesPlusOneButton.Size = new System.Drawing.Size(89, 23);
            this.globalPropertiesPlusOneButton.TabIndex = 4;
            this.globalPropertiesPlusOneButton.Text = "+1";
            this.globalPropertiesPlusOneButton.UseVisualStyleBackColor = true;
            // 
            // globalPropertiesMinusOneButton
            // 
            this.globalPropertiesMinusOneButton.Location = new System.Drawing.Point(101, 200);
            this.globalPropertiesMinusOneButton.Name = "globalPropertiesMinusOneButton";
            this.globalPropertiesMinusOneButton.Size = new System.Drawing.Size(95, 23);
            this.globalPropertiesMinusOneButton.TabIndex = 5;
            this.globalPropertiesMinusOneButton.Text = "-1";
            this.globalPropertiesMinusOneButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "hold_ms";
            // 
            // globalPropertiesHoldMsTextBox
            // 
            this.globalPropertiesHoldMsTextBox.Location = new System.Drawing.Point(9, 337);
            this.globalPropertiesHoldMsTextBox.Name = "globalPropertiesHoldMsTextBox";
            this.globalPropertiesHoldMsTextBox.Size = new System.Drawing.Size(193, 20);
            this.globalPropertiesHoldMsTextBox.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "target";
            // 
            // globalPropertiesTargetTextBox
            // 
            this.globalPropertiesTargetTextBox.Location = new System.Drawing.Point(12, 381);
            this.globalPropertiesTargetTextBox.Name = "globalPropertiesTargetTextBox";
            this.globalPropertiesTargetTextBox.Size = new System.Drawing.Size(190, 20);
            this.globalPropertiesTargetTextBox.TabIndex = 9;
            // 
            // statePropertiesPlusOneButton
            // 
            this.statePropertiesPlusOneButton.Location = new System.Drawing.Point(7, 213);
            this.statePropertiesPlusOneButton.Name = "statePropertiesPlusOneButton";
            this.statePropertiesPlusOneButton.Size = new System.Drawing.Size(112, 23);
            this.statePropertiesPlusOneButton.TabIndex = 4;
            this.statePropertiesPlusOneButton.Text = "+1";
            this.statePropertiesPlusOneButton.UseVisualStyleBackColor = true;
            // 
            // statePropertiesMinusOneButton
            // 
            this.statePropertiesMinusOneButton.Location = new System.Drawing.Point(125, 213);
            this.statePropertiesMinusOneButton.Name = "statePropertiesMinusOneButton";
            this.statePropertiesMinusOneButton.Size = new System.Drawing.Size(103, 23);
            this.statePropertiesMinusOneButton.TabIndex = 5;
            this.statePropertiesMinusOneButton.Text = "-1";
            this.statePropertiesMinusOneButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 323);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "hold_ms";
            // 
            // statePropertiesHoldMsTextBox
            // 
            this.statePropertiesHoldMsTextBox.Location = new System.Drawing.Point(7, 339);
            this.statePropertiesHoldMsTextBox.Name = "statePropertiesHoldMsTextBox";
            this.statePropertiesHoldMsTextBox.Size = new System.Drawing.Size(227, 20);
            this.statePropertiesHoldMsTextBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 367);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "target";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 383);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(232, 20);
            this.textBox1.TabIndex = 9;
            // 
            // KaloScriptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 491);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel3);
            this.Name = "KaloScriptEdit";
            this.Text = "Kalo Script Editor";
            this.Load += new System.EventHandler(this.KaloScriptEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox propListBox;
        private System.Windows.Forms.Button deletePropButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox globalPropertiesListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addPropButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox stateListBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button deleteStateButton;
        private System.Windows.Forms.Button addStateButton;
        private System.Windows.Forms.Panel panel4;
        protected internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox globalPropertyValueTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox statePropertyValueTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox reviewStateListBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox sceneListBox;
        private System.Windows.Forms.Button addSceneButton;
        private System.Windows.Forms.Button deleteSceneButton;
        private System.Windows.Forms.TextBox globalPropertiesTargetTextBox;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox globalPropertiesHoldMsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button globalPropertiesMinusOneButton;
        private System.Windows.Forms.Button globalPropertiesPlusOneButton;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox statePropertiesHoldMsTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button statePropertiesMinusOneButton;
        private System.Windows.Forms.Button statePropertiesPlusOneButton;
    }
}

