namespace EconomicWFApp
{
    partial class EconomicApp
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
            this.incomeDG = new System.Windows.Forms.DataGridView();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblErrorIncome = new System.Windows.Forms.Label();
            this.refIncomeBtn = new System.Windows.Forms.Button();
            this.refCostBtn = new System.Windows.Forms.Button();
            this.lblErrorCost = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.costDG = new System.Windows.Forms.DataGridView();
            this.lblLoadIncome = new System.Windows.Forms.Label();
            this.lblLoadCost = new System.Windows.Forms.Label();
            this.incomeNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.incomeAmountInput = new System.Windows.Forms.NumericUpDown();
            this.addIncomeBtn = new System.Windows.Forms.Button();
            this.addCostBtn = new System.Windows.Forms.Button();
            this.costAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.costNameInput = new System.Windows.Forms.TextBox();
            this.costTypeInput = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.vilidationErrorIncome = new System.Windows.Forms.Label();
            this.vilidationErrorCost = new System.Windows.Forms.Label();
            this.openCostFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddFileBtn = new System.Windows.Forms.Button();
            this.fileLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.incomeDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incomeAmountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // incomeDG
            // 
            this.incomeDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incomeDG.Location = new System.Drawing.Point(12, 137);
            this.incomeDG.Name = "incomeDG";
            this.incomeDG.RowHeadersWidth = 51;
            this.incomeDG.RowTemplate.Height = 24;
            this.incomeDG.Size = new System.Drawing.Size(350, 301);
            this.incomeDG.TabIndex = 0;
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncome.Location = new System.Drawing.Point(7, 109);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(86, 25);
            this.lblIncome.TabIndex = 1;
            this.lblIncome.Text = "Incomes";
            // 
            // lblErrorIncome
            // 
            this.lblErrorIncome.AutoSize = true;
            this.lblErrorIncome.BackColor = System.Drawing.SystemColors.Control;
            this.lblErrorIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorIncome.ForeColor = System.Drawing.Color.Crimson;
            this.lblErrorIncome.Location = new System.Drawing.Point(136, 260);
            this.lblErrorIncome.Name = "lblErrorIncome";
            this.lblErrorIncome.Size = new System.Drawing.Size(92, 39);
            this.lblErrorIncome.TabIndex = 2;
            this.lblErrorIncome.Text = "Error";
            // 
            // refIncomeBtn
            // 
            this.refIncomeBtn.Location = new System.Drawing.Point(245, 109);
            this.refIncomeBtn.Name = "refIncomeBtn";
            this.refIncomeBtn.Size = new System.Drawing.Size(117, 25);
            this.refIncomeBtn.TabIndex = 3;
            this.refIncomeBtn.Text = "Refresh";
            this.refIncomeBtn.UseVisualStyleBackColor = true;
            this.refIncomeBtn.Click += new System.EventHandler(this.RefIncomeBtn_Click);
            // 
            // refCostBtn
            // 
            this.refCostBtn.Location = new System.Drawing.Point(947, 109);
            this.refCostBtn.Name = "refCostBtn";
            this.refCostBtn.Size = new System.Drawing.Size(99, 25);
            this.refCostBtn.TabIndex = 7;
            this.refCostBtn.Text = "Refresh";
            this.refCostBtn.UseVisualStyleBackColor = true;
            this.refCostBtn.Click += new System.EventHandler(this.RefCostBtn_Click);
            // 
            // lblErrorCost
            // 
            this.lblErrorCost.AutoSize = true;
            this.lblErrorCost.BackColor = System.Drawing.SystemColors.Control;
            this.lblErrorCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCost.ForeColor = System.Drawing.Color.Crimson;
            this.lblErrorCost.Location = new System.Drawing.Point(691, 260);
            this.lblErrorCost.Name = "lblErrorCost";
            this.lblErrorCost.Size = new System.Drawing.Size(92, 39);
            this.lblErrorCost.TabIndex = 6;
            this.lblErrorCost.Text = "Error";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(429, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Costs";
            // 
            // costDG
            // 
            this.costDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.costDG.Location = new System.Drawing.Point(434, 137);
            this.costDG.Name = "costDG";
            this.costDG.RowHeadersWidth = 51;
            this.costDG.RowTemplate.Height = 24;
            this.costDG.Size = new System.Drawing.Size(607, 301);
            this.costDG.TabIndex = 4;
            // 
            // lblLoadIncome
            // 
            this.lblLoadIncome.AutoSize = true;
            this.lblLoadIncome.BackColor = System.Drawing.SystemColors.Control;
            this.lblLoadIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadIncome.ForeColor = System.Drawing.Color.Black;
            this.lblLoadIncome.Location = new System.Drawing.Point(115, 260);
            this.lblLoadIncome.Name = "lblLoadIncome";
            this.lblLoadIncome.Size = new System.Drawing.Size(134, 31);
            this.lblLoadIncome.TabIndex = 8;
            this.lblLoadIncome.Text = "Loading...";
            // 
            // lblLoadCost
            // 
            this.lblLoadCost.AutoSize = true;
            this.lblLoadCost.BackColor = System.Drawing.SystemColors.Control;
            this.lblLoadCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadCost.ForeColor = System.Drawing.Color.Black;
            this.lblLoadCost.Location = new System.Drawing.Point(671, 260);
            this.lblLoadCost.Name = "lblLoadCost";
            this.lblLoadCost.Size = new System.Drawing.Size(134, 31);
            this.lblLoadCost.TabIndex = 9;
            this.lblLoadCost.Text = "Loading...";
            // 
            // incomeNameInput
            // 
            this.incomeNameInput.Location = new System.Drawing.Point(85, 12);
            this.incomeNameInput.Name = "incomeNameInput";
            this.incomeNameInput.Size = new System.Drawing.Size(250, 22);
            this.incomeNameInput.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "price:";
            // 
            // incomeAmountInput
            // 
            this.incomeAmountInput.Location = new System.Drawing.Point(85, 46);
            this.incomeAmountInput.Name = "incomeAmountInput";
            this.incomeAmountInput.Size = new System.Drawing.Size(105, 22);
            this.incomeAmountInput.TabIndex = 14;
            // 
            // addIncomeBtn
            // 
            this.addIncomeBtn.Location = new System.Drawing.Point(197, 43);
            this.addIncomeBtn.Name = "addIncomeBtn";
            this.addIncomeBtn.Size = new System.Drawing.Size(138, 25);
            this.addIncomeBtn.TabIndex = 17;
            this.addIncomeBtn.Text = "add income";
            this.addIncomeBtn.UseVisualStyleBackColor = true;
            this.addIncomeBtn.Click += new System.EventHandler(this.AddIncomeBtn_Click);
            // 
            // addCostBtn
            // 
            this.addCostBtn.Location = new System.Drawing.Point(804, 48);
            this.addCostBtn.Name = "addCostBtn";
            this.addCostBtn.Size = new System.Drawing.Size(55, 26);
            this.addCostBtn.TabIndex = 22;
            this.addCostBtn.Text = "add cost";
            this.addCostBtn.UseVisualStyleBackColor = true;
            this.addCostBtn.Click += new System.EventHandler(this.AddCostBtn_Click);
            // 
            // costAmountInput
            // 
            this.costAmountInput.Location = new System.Drawing.Point(505, 48);
            this.costAmountInput.Name = "costAmountInput";
            this.costAmountInput.Size = new System.Drawing.Size(105, 22);
            this.costAmountInput.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(432, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "price:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(432, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "name:";
            // 
            // costNameInput
            // 
            this.costNameInput.Location = new System.Drawing.Point(505, 13);
            this.costNameInput.Name = "costNameInput";
            this.costNameInput.Size = new System.Drawing.Size(105, 22);
            this.costNameInput.TabIndex = 18;
            // 
            // costTypeInput
            // 
            this.costTypeInput.FormattingEnabled = true;
            this.costTypeInput.Location = new System.Drawing.Point(677, 9);
            this.costTypeInput.Name = "costTypeInput";
            this.costTypeInput.Size = new System.Drawing.Size(182, 24);
            this.costTypeInput.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(616, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "type:";
            // 
            // vilidationErrorIncome
            // 
            this.vilidationErrorIncome.AutoSize = true;
            this.vilidationErrorIncome.BackColor = System.Drawing.SystemColors.Control;
            this.vilidationErrorIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vilidationErrorIncome.ForeColor = System.Drawing.Color.Crimson;
            this.vilidationErrorIncome.Location = new System.Drawing.Point(13, 71);
            this.vilidationErrorIncome.Name = "vilidationErrorIncome";
            this.vilidationErrorIncome.Size = new System.Drawing.Size(0, 20);
            this.vilidationErrorIncome.TabIndex = 25;
            // 
            // vilidationErrorCost
            // 
            this.vilidationErrorCost.AutoSize = true;
            this.vilidationErrorCost.BackColor = System.Drawing.SystemColors.Control;
            this.vilidationErrorCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vilidationErrorCost.ForeColor = System.Drawing.Color.Crimson;
            this.vilidationErrorCost.Location = new System.Drawing.Point(433, 71);
            this.vilidationErrorCost.Name = "vilidationErrorCost";
            this.vilidationErrorCost.Size = new System.Drawing.Size(0, 20);
            this.vilidationErrorCost.TabIndex = 26;
            // 
            // openCostFileDialog
            // 
            this.openCostFileDialog.FileName = "openFileDialog1";
            this.openCostFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|" +
    "*.png";
            // 
            // AddFileBtn
            // 
            this.AddFileBtn.Location = new System.Drawing.Point(677, 48);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(121, 24);
            this.AddFileBtn.TabIndex = 27;
            this.AddFileBtn.Text = "choose a file";
            this.AddFileBtn.UseVisualStyleBackColor = true;
            this.AddFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // fileLbl
            // 
            this.fileLbl.AutoSize = true;
            this.fileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLbl.Location = new System.Drawing.Point(616, 45);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(42, 25);
            this.fileLbl.TabIndex = 28;
            this.fileLbl.Text = "file:";
            // 
            // EconomicApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 450);
            this.Controls.Add(this.fileLbl);
            this.Controls.Add(this.AddFileBtn);
            this.Controls.Add(this.vilidationErrorCost);
            this.Controls.Add(this.vilidationErrorIncome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.costTypeInput);
            this.Controls.Add(this.addCostBtn);
            this.Controls.Add(this.costAmountInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.costNameInput);
            this.Controls.Add(this.addIncomeBtn);
            this.Controls.Add(this.incomeAmountInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.incomeNameInput);
            this.Controls.Add(this.lblLoadCost);
            this.Controls.Add(this.lblLoadIncome);
            this.Controls.Add(this.refCostBtn);
            this.Controls.Add(this.lblErrorCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.costDG);
            this.Controls.Add(this.refIncomeBtn);
            this.Controls.Add(this.lblErrorIncome);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.incomeDG);
            this.Name = "EconomicApp";
            this.Text = "EconomicApp";
            this.Load += new System.EventHandler(this.EconomicApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.incomeDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incomeAmountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costAmountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView incomeDG;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblErrorIncome;
        private System.Windows.Forms.Button refIncomeBtn;
        private System.Windows.Forms.Button refCostBtn;
        private System.Windows.Forms.Label lblErrorCost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView costDG;
        private System.Windows.Forms.Label lblLoadIncome;
        private System.Windows.Forms.Label lblLoadCost;
        private System.Windows.Forms.TextBox incomeNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown incomeAmountInput;
        private System.Windows.Forms.Button addIncomeBtn;
        private System.Windows.Forms.Button addCostBtn;
        private System.Windows.Forms.NumericUpDown costAmountInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox costNameInput;
        private System.Windows.Forms.ComboBox costTypeInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label vilidationErrorIncome;
        private System.Windows.Forms.Label vilidationErrorCost;
        private System.Windows.Forms.OpenFileDialog openCostFileDialog;
        private System.Windows.Forms.Button AddFileBtn;
        private System.Windows.Forms.Label fileLbl;
    }
}

