namespace Fluxx
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
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonTakeTurn = new System.Windows.Forms.Button();
            this.buttonPlayCard = new System.Windows.Forms.Button();
            this.pictureBoxHand = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayedCards = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxCompHand = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEndTurn = new System.Windows.Forms.Button();
            this.pictureBoxCompPlayedKeepers = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayedCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompPlayedKeepers)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(1, 411);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(75, 23);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click_1);
            // 
            // buttonTakeTurn
            // 
            this.buttonTakeTurn.Location = new System.Drawing.Point(1, 440);
            this.buttonTakeTurn.Name = "buttonTakeTurn";
            this.buttonTakeTurn.Size = new System.Drawing.Size(75, 23);
            this.buttonTakeTurn.TabIndex = 2;
            this.buttonTakeTurn.Text = "Take Turn";
            this.buttonTakeTurn.UseVisualStyleBackColor = true;
            this.buttonTakeTurn.Visible = false;
            this.buttonTakeTurn.Click += new System.EventHandler(this.buttonTakeTurn_Click_1);
            // 
            // buttonPlayCard
            // 
            this.buttonPlayCard.Location = new System.Drawing.Point(1, 469);
            this.buttonPlayCard.Name = "buttonPlayCard";
            this.buttonPlayCard.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayCard.TabIndex = 3;
            this.buttonPlayCard.Text = "Play Card";
            this.buttonPlayCard.UseVisualStyleBackColor = true;
            this.buttonPlayCard.Visible = false;
            this.buttonPlayCard.Click += new System.EventHandler(this.buttonPlayCard_Click);
            // 
            // pictureBoxHand
            // 
            this.pictureBoxHand.Location = new System.Drawing.Point(12, 712);
            this.pictureBoxHand.Name = "pictureBoxHand";
            this.pictureBoxHand.Size = new System.Drawing.Size(1275, 122);
            this.pictureBoxHand.TabIndex = 4;
            this.pictureBoxHand.TabStop = false;
            this.pictureBoxHand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // pictureBoxPlayedCards
            // 
            this.pictureBoxPlayedCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPlayedCards.Location = new System.Drawing.Point(93, 567);
            this.pictureBoxPlayedCards.Name = "pictureBoxPlayedCards";
            this.pictureBoxPlayedCards.Size = new System.Drawing.Size(1179, 123);
            this.pictureBoxPlayedCards.TabIndex = 6;
            this.pictureBoxPlayedCards.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(534, 693);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Your Hand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 548);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Your Played Keepers";
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTable.Location = new System.Drawing.Point(82, 310);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.Size = new System.Drawing.Size(482, 235);
            this.pictureBoxTable.TabIndex = 9;
            this.pictureBoxTable.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(438, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Table";
            // 
            // pictureBoxCompHand
            // 
            this.pictureBoxCompHand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCompHand.Location = new System.Drawing.Point(12, 19);
            this.pictureBoxCompHand.Name = "pictureBoxCompHand";
            this.pictureBoxCompHand.Size = new System.Drawing.Size(1268, 124);
            this.pictureBoxCompHand.TabIndex = 11;
            this.pictureBoxCompHand.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(466, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Computer\'s Hand";
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.Location = new System.Drawing.Point(1, 498);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(75, 23);
            this.buttonEndTurn.TabIndex = 13;
            this.buttonEndTurn.Text = "End Turn";
            this.buttonEndTurn.UseVisualStyleBackColor = true;
            this.buttonEndTurn.Visible = false;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // pictureBoxCompPlayedKeepers
            // 
            this.pictureBoxCompPlayedKeepers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCompPlayedKeepers.Location = new System.Drawing.Point(93, 165);
            this.pictureBoxCompPlayedKeepers.Name = "pictureBoxCompPlayedKeepers";
            this.pictureBoxCompPlayedKeepers.Size = new System.Drawing.Size(1187, 123);
            this.pictureBoxCompPlayedKeepers.TabIndex = 14;
            this.pictureBoxCompPlayedKeepers.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(496, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Computer\'s played Keepers";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(570, 307);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(196, 238);
            this.listBox1.TabIndex = 16;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(772, 307);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(524, 225);
            this.listBox2.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 835);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxCompPlayedKeepers);
            this.Controls.Add(this.buttonEndTurn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBoxCompHand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPlayedCards);
            this.Controls.Add(this.pictureBoxHand);
            this.Controls.Add(this.buttonPlayCard);
            this.Controls.Add(this.buttonTakeTurn);
            this.Controls.Add(this.buttonStartGame);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayedCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompPlayedKeepers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonTakeTurn;
        private System.Windows.Forms.Button buttonPlayCard;
        private System.Windows.Forms.PictureBox pictureBoxHand;
        private System.Windows.Forms.PictureBox pictureBoxPlayedCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxCompHand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEndTurn;
        private System.Windows.Forms.PictureBox pictureBoxCompPlayedKeepers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}

