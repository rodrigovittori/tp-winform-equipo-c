namespace tp_winform_equipo_c
{
    partial class FormPrincipal
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonPrevImg = new System.Windows.Forms.Button();
            this.buttonNextImg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.brandLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.chkDeleteUnusued = new System.Windows.Forms.CheckBox();
            this.chkHideInvalids = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.articlesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.articlesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(20, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 200);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonPrevImg
            // 
            this.buttonPrevImg.Location = new System.Drawing.Point(20, 230);
            this.buttonPrevImg.Name = "buttonPrevImg";
            this.buttonPrevImg.Size = new System.Drawing.Size(30, 30);
            this.buttonPrevImg.TabIndex = 1;
            this.buttonPrevImg.Text = "<";
            this.buttonPrevImg.UseVisualStyleBackColor = true;
            // 
            // buttonNextImg
            // 
            this.buttonNextImg.Location = new System.Drawing.Point(190, 230);
            this.buttonNextImg.Name = "buttonNextImg";
            this.buttonNextImg.Size = new System.Drawing.Size(30, 30);
            this.buttonNextImg.TabIndex = 2;
            this.buttonNextImg.Text = ">";
            this.buttonNextImg.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 260);
            this.panel1.TabIndex = 3;
            // 
            // idLabel
            // 
            this.idLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idLabel.Location = new System.Drawing.Point(230, 20);
            this.idLabel.Margin = new System.Windows.Forms.Padding(0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(170, 32);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID: ";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nameLabel.Location = new System.Drawing.Point(230, 55);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(170, 32);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Nombre: ";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceLabel
            // 
            this.priceLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.priceLabel.Location = new System.Drawing.Point(230, 196);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(170, 32);
            this.priceLabel.TabIndex = 5;
            this.priceLabel.Text = "Precio: ";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // categoryLabel
            // 
            this.categoryLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categoryLabel.Location = new System.Drawing.Point(230, 161);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(170, 32);
            this.categoryLabel.TabIndex = 6;
            this.categoryLabel.Text = "Categoría: ";
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // brandLabel
            // 
            this.brandLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brandLabel.Location = new System.Drawing.Point(230, 126);
            this.brandLabel.Margin = new System.Windows.Forms.Padding(0);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(170, 32);
            this.brandLabel.TabIndex = 7;
            this.brandLabel.Text = "Marca:  ";
            this.brandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.descriptionLabel.Location = new System.Drawing.Point(230, 90);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(170, 32);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Desc: ";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(480, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 260);
            this.panel2.TabIndex = 9;
            // 
            // filterLabel
            // 
            this.filterLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.filterLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filterLabel.Location = new System.Drawing.Point(500, 90);
            this.filterLabel.Margin = new System.Windows.Forms.Padding(0);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(170, 32);
            this.filterLabel.TabIndex = 13;
            this.filterLabel.Text = "Búsqueda por filtro:";
            this.filterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(750, 120);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(120, 40);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Resetear Filtro";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(490, 30);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(120, 40);
            this.newButton.TabIndex = 10;
            this.newButton.Text = "Nuevo Artículo";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(620, 30);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(120, 40);
            this.editButton.TabIndex = 11;
            this.editButton.Text = "Editar Existente";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(750, 30);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(120, 40);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Eliminar Actual";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterTextBox.Location = new System.Drawing.Point(490, 130);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(250, 27);
            this.filterTextBox.TabIndex = 0;
            // 
            // chkDeleteUnusued
            // 
            this.chkDeleteUnusued.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteUnusued.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chkDeleteUnusued.Location = new System.Drawing.Point(500, 220);
            this.chkDeleteUnusued.Name = "chkDeleteUnusued";
            this.chkDeleteUnusued.Size = new System.Drawing.Size(260, 32);
            this.chkDeleteUnusued.TabIndex = 14;
            this.chkDeleteUnusued.Text = "Eliminar registros inactivos";
            this.chkDeleteUnusued.UseVisualStyleBackColor = true;
            // 
            // chkHideInvalids
            // 
            this.chkHideInvalids.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHideInvalids.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chkHideInvalids.Location = new System.Drawing.Point(500, 180);
            this.chkHideInvalids.Name = "chkHideInvalids";
            this.chkHideInvalids.Size = new System.Drawing.Size(260, 32);
            this.chkHideInvalids.TabIndex = 15;
            this.chkHideInvalids.Text = "Ocultar registros no válidos";
            this.chkHideInvalids.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.articlesDataGridView);
            this.panel3.Location = new System.Drawing.Point(10, 280);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 280);
            this.panel3.TabIndex = 16;
            // 
            // articlesDataGridView
            // 
            this.articlesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.articlesDataGridView.Location = new System.Drawing.Point(5, 5);
            this.articlesDataGridView.Name = "articlesDataGridView";
            this.articlesDataGridView.Size = new System.Drawing.Size(860, 270);
            this.articlesDataGridView.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.chkHideInvalids);
            this.Controls.Add(this.chkDeleteUnusued);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.buttonNextImg);
            this.Controls.Add(this.buttonPrevImg);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel1);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.articlesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonPrevImg;
        private System.Windows.Forms.Button buttonNextImg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.CheckBox chkDeleteUnusued;
        private System.Windows.Forms.CheckBox chkHideInvalids;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView articlesDataGridView;
    }
}