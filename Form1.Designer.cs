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
            personsDataGrid = new DataGridView();
            fileLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)personsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // selectButton
            // 
            selectButton.Location = new Point(12, 12);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(150, 23);
            selectButton.TabIndex = 0;
            selectButton.Text = "Sélectionner un fichier";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += SelectButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(168, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(150, 23);
            saveButton.TabIndex = 1;
            saveButton.Text = "Enregistrer";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // personsDataGrid
            // 
            personsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personsDataGrid.Location = new Point(12, 56);
            personsDataGrid.Name = "personsDataGrid";
            personsDataGrid.RowTemplate.Height = 25;
            personsDataGrid.Size = new Size(776, 382);
            personsDataGrid.TabIndex = 2;
            // 
            // fileLabel
            // 
            fileLabel.AutoSize = true;
            fileLabel.Location = new Point(12, 38);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(85, 15);
            fileLabel.TabIndex = 3;
            fileLabel.Text = "Pas de fichier sélectionné";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(fileLabel);
            Controls.Add(personsDataGrid);
            Controls.Add(saveButton);
            Controls.Add(selectButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)personsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectButton;
        private Button saveButton;
        private DataGridView personsDataGrid;
        private Label fileLabel;
    }
}