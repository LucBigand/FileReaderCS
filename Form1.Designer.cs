namespace FileReaderCS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            selectButton = new Button();
            saveButton = new Button();
            SuspendLayout();
            // 
            // selectButton
            // 
            selectButton.Location = new Point(38, 21);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(150, 23);
            selectButton.TabIndex = 0;
            selectButton.Text = "Sélectionner un fichier";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += SelectButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(211, 22);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(150, 23);
            saveButton.TabIndex = 1;
            saveButton.Text = "Enregistrer";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveButton);
            Controls.Add(selectButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button selectButton;
        private Button saveButton;
    }
}