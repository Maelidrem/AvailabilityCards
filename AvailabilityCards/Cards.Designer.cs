namespace AvailabilityCards
{
    partial class Cards
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbGreenA = new System.Windows.Forms.TextBox();
            this.tbGreenB = new System.Windows.Forms.TextBox();
            this.tbGreenC = new System.Windows.Forms.TextBox();
            this.tbFooterGreen = new System.Windows.Forms.TextBox();
            this.tbFooterOrange = new System.Windows.Forms.TextBox();
            this.tbRedA = new System.Windows.Forms.TextBox();
            this.tbRedB = new System.Windows.Forms.TextBox();
            this.tbRedC = new System.Windows.Forms.TextBox();
            this.tbFooterRed = new System.Windows.Forms.TextBox();
            this.tbOrangeC = new System.Windows.Forms.TextBox();
            this.tbOrangeB = new System.Windows.Forms.TextBox();
            this.tbOrangeA = new System.Windows.Forms.TextBox();
            this.pctCards = new System.Windows.Forms.PictureBox();
            this.btnSaveJson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctCards)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(243, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load card configuration";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.OnLoad);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(510, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(339, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save card image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 41);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(492, 20);
            this.tbName.TabIndex = 4;
            // 
            // tbGreenA
            // 
            this.tbGreenA.Location = new System.Drawing.Point(12, 67);
            this.tbGreenA.Multiline = true;
            this.tbGreenA.Name = "tbGreenA";
            this.tbGreenA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbGreenA.Size = new System.Drawing.Size(160, 140);
            this.tbGreenA.TabIndex = 5;
            // 
            // tbGreenB
            // 
            this.tbGreenB.Location = new System.Drawing.Point(178, 67);
            this.tbGreenB.Multiline = true;
            this.tbGreenB.Name = "tbGreenB";
            this.tbGreenB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbGreenB.Size = new System.Drawing.Size(160, 140);
            this.tbGreenB.TabIndex = 6;
            // 
            // tbGreenC
            // 
            this.tbGreenC.Location = new System.Drawing.Point(344, 67);
            this.tbGreenC.Multiline = true;
            this.tbGreenC.Name = "tbGreenC";
            this.tbGreenC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbGreenC.Size = new System.Drawing.Size(160, 140);
            this.tbGreenC.TabIndex = 7;
            // 
            // tbFooterGreen
            // 
            this.tbFooterGreen.Location = new System.Drawing.Point(12, 213);
            this.tbFooterGreen.Name = "tbFooterGreen";
            this.tbFooterGreen.Size = new System.Drawing.Size(492, 20);
            this.tbFooterGreen.TabIndex = 8;
            // 
            // tbFooterOrange
            // 
            this.tbFooterOrange.Location = new System.Drawing.Point(12, 385);
            this.tbFooterOrange.Name = "tbFooterOrange";
            this.tbFooterOrange.Size = new System.Drawing.Size(492, 20);
            this.tbFooterOrange.TabIndex = 14;
            // 
            // tbRedA
            // 
            this.tbRedA.Location = new System.Drawing.Point(12, 411);
            this.tbRedA.Multiline = true;
            this.tbRedA.Name = "tbRedA";
            this.tbRedA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRedA.Size = new System.Drawing.Size(160, 140);
            this.tbRedA.TabIndex = 17;
            // 
            // tbRedB
            // 
            this.tbRedB.Location = new System.Drawing.Point(178, 411);
            this.tbRedB.Multiline = true;
            this.tbRedB.Name = "tbRedB";
            this.tbRedB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRedB.Size = new System.Drawing.Size(160, 140);
            this.tbRedB.TabIndex = 18;
            // 
            // tbRedC
            // 
            this.tbRedC.Location = new System.Drawing.Point(344, 411);
            this.tbRedC.Multiline = true;
            this.tbRedC.Name = "tbRedC";
            this.tbRedC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRedC.Size = new System.Drawing.Size(160, 140);
            this.tbRedC.TabIndex = 19;
            // 
            // tbFooterRed
            // 
            this.tbFooterRed.Location = new System.Drawing.Point(12, 557);
            this.tbFooterRed.Name = "tbFooterRed";
            this.tbFooterRed.Size = new System.Drawing.Size(492, 20);
            this.tbFooterRed.TabIndex = 20;
            // 
            // tbOrangeC
            // 
            this.tbOrangeC.Location = new System.Drawing.Point(344, 239);
            this.tbOrangeC.Multiline = true;
            this.tbOrangeC.Name = "tbOrangeC";
            this.tbOrangeC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOrangeC.Size = new System.Drawing.Size(160, 140);
            this.tbOrangeC.TabIndex = 13;
            // 
            // tbOrangeB
            // 
            this.tbOrangeB.Location = new System.Drawing.Point(178, 239);
            this.tbOrangeB.Multiline = true;
            this.tbOrangeB.Name = "tbOrangeB";
            this.tbOrangeB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOrangeB.Size = new System.Drawing.Size(160, 140);
            this.tbOrangeB.TabIndex = 12;
            // 
            // tbOrangeA
            // 
            this.tbOrangeA.Location = new System.Drawing.Point(12, 239);
            this.tbOrangeA.Multiline = true;
            this.tbOrangeA.Name = "tbOrangeA";
            this.tbOrangeA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOrangeA.Size = new System.Drawing.Size(160, 140);
            this.tbOrangeA.TabIndex = 11;
            // 
            // pctCards
            // 
            this.pctCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctCards.Location = new System.Drawing.Point(510, 41);
            this.pctCards.Name = "pctCards";
            this.pctCards.Size = new System.Drawing.Size(339, 536);
            this.pctCards.TabIndex = 21;
            this.pctCards.TabStop = false;
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveJson.Location = new System.Drawing.Point(261, 12);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(243, 23);
            this.btnSaveJson.TabIndex = 22;
            this.btnSaveJson.Text = "Save card configuration";
            this.btnSaveJson.UseVisualStyleBackColor = true;
            this.btnSaveJson.Click += new System.EventHandler(this.OnSaveJson);
            // 
            // Cards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 589);
            this.Controls.Add(this.btnSaveJson);
            this.Controls.Add(this.pctCards);
            this.Controls.Add(this.tbFooterRed);
            this.Controls.Add(this.tbRedC);
            this.Controls.Add(this.tbRedB);
            this.Controls.Add(this.tbRedA);
            this.Controls.Add(this.tbFooterOrange);
            this.Controls.Add(this.tbOrangeC);
            this.Controls.Add(this.tbOrangeB);
            this.Controls.Add(this.tbOrangeA);
            this.Controls.Add(this.tbFooterGreen);
            this.Controls.Add(this.tbGreenC);
            this.Controls.Add(this.tbGreenB);
            this.Controls.Add(this.tbGreenA);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.MaximumSize = new System.Drawing.Size(877, 627);
            this.MinimumSize = new System.Drawing.Size(877, 627);
            this.Name = "Cards";
            this.Text = "Card Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pctCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbGreenA;
        private System.Windows.Forms.TextBox tbGreenB;
        private System.Windows.Forms.TextBox tbGreenC;
        private System.Windows.Forms.TextBox tbFooterGreen;
        private System.Windows.Forms.TextBox tbFooterOrange;
        private System.Windows.Forms.TextBox tbRedA;
        private System.Windows.Forms.TextBox tbRedB;
        private System.Windows.Forms.TextBox tbRedC;
        private System.Windows.Forms.TextBox tbFooterRed;
        private System.Windows.Forms.TextBox tbOrangeC;
        private System.Windows.Forms.TextBox tbOrangeB;
        private System.Windows.Forms.TextBox tbOrangeA;
        private System.Windows.Forms.PictureBox pctCards;
        private System.Windows.Forms.Button btnSaveJson;
    }
}

