
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.btRegister = new System.Windows.Forms.Button();
            this.lbUrlTitle = new System.Windows.Forms.ListBox();
            this.gbRssTitle = new System.Windows.Forms.GroupBox();
            this.rbWorld = new System.Windows.Forms.RadioButton();
            this.rbScience = new System.Windows.Forms.RadioButton();
            this.rbSports = new System.Windows.Forms.RadioButton();
            this.rbIT = new System.Windows.Forms.RadioButton();
            this.lNumberOfRegistrations = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btDeleteFavorite = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbRssTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbUrl.Location = new System.Drawing.Point(108, 13);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(675, 31);
            this.tbUrl.TabIndex = 0;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(789, 12);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(92, 32);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(108, 51);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(871, 112);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.Click += new System.EventHandler(this.lbRssTitle_Click);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(108, 170);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(871, 464);
            this.wbBrowser.TabIndex = 3;
            // 
            // btRegister
            // 
            this.btRegister.Location = new System.Drawing.Point(887, 13);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(92, 32);
            this.btRegister.TabIndex = 4;
            this.btRegister.Text = "登録";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // lbUrlTitle
            // 
            this.lbUrlTitle.FormattingEnabled = true;
            this.lbUrlTitle.ItemHeight = 12;
            this.lbUrlTitle.Location = new System.Drawing.Point(108, 640);
            this.lbUrlTitle.Name = "lbUrlTitle";
            this.lbUrlTitle.Size = new System.Drawing.Size(871, 88);
            this.lbUrlTitle.TabIndex = 5;
            this.lbUrlTitle.Click += new System.EventHandler(this.lbUrlTitle_Click);
            // 
            // gbRssTitle
            // 
            this.gbRssTitle.Controls.Add(this.rbWorld);
            this.gbRssTitle.Controls.Add(this.rbScience);
            this.gbRssTitle.Controls.Add(this.rbSports);
            this.gbRssTitle.Controls.Add(this.rbIT);
            this.gbRssTitle.Location = new System.Drawing.Point(989, 13);
            this.gbRssTitle.Name = "gbRssTitle";
            this.gbRssTitle.Size = new System.Drawing.Size(191, 70);
            this.gbRssTitle.TabIndex = 6;
            this.gbRssTitle.TabStop = false;
            this.gbRssTitle.Text = "RSSタイトル";
            // 
            // rbWorld
            // 
            this.rbWorld.AutoSize = true;
            this.rbWorld.Location = new System.Drawing.Point(100, 48);
            this.rbWorld.Name = "rbWorld";
            this.rbWorld.Size = new System.Drawing.Size(47, 16);
            this.rbWorld.TabIndex = 3;
            this.rbWorld.TabStop = true;
            this.rbWorld.Tag = "3";
            this.rbWorld.Text = "国際";
            this.rbWorld.UseVisualStyleBackColor = true;
            this.rbWorld.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbScience
            // 
            this.rbScience.AutoSize = true;
            this.rbScience.Location = new System.Drawing.Point(6, 48);
            this.rbScience.Name = "rbScience";
            this.rbScience.Size = new System.Drawing.Size(47, 16);
            this.rbScience.TabIndex = 2;
            this.rbScience.TabStop = true;
            this.rbScience.Tag = "2";
            this.rbScience.Text = "科学";
            this.rbScience.UseVisualStyleBackColor = true;
            this.rbScience.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbSports
            // 
            this.rbSports.AutoSize = true;
            this.rbSports.Location = new System.Drawing.Point(100, 26);
            this.rbSports.Name = "rbSports";
            this.rbSports.Size = new System.Drawing.Size(61, 16);
            this.rbSports.TabIndex = 1;
            this.rbSports.TabStop = true;
            this.rbSports.Tag = "1";
            this.rbSports.Text = "スポーツ";
            this.rbSports.UseVisualStyleBackColor = true;
            this.rbSports.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbIT
            // 
            this.rbIT.AutoSize = true;
            this.rbIT.Location = new System.Drawing.Point(6, 26);
            this.rbIT.Name = "rbIT";
            this.rbIT.Size = new System.Drawing.Size(33, 16);
            this.rbIT.TabIndex = 0;
            this.rbIT.TabStop = true;
            this.rbIT.Tag = "0";
            this.rbIT.Text = "IT";
            this.rbIT.UseVisualStyleBackColor = true;
            this.rbIT.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lNumberOfRegistrations
            // 
            this.lNumberOfRegistrations.Location = new System.Drawing.Point(993, 652);
            this.lNumberOfRegistrations.Name = "lNumberOfRegistrations";
            this.lNumberOfRegistrations.Size = new System.Drawing.Size(187, 28);
            this.lNumberOfRegistrations.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(993, 640);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "現在保存されているURLの数は、";
            // 
            // btDeleteFavorite
            // 
            this.btDeleteFavorite.Location = new System.Drawing.Point(995, 695);
            this.btDeleteFavorite.Name = "btDeleteFavorite";
            this.btDeleteFavorite.Size = new System.Drawing.Size(185, 33);
            this.btDeleteFavorite.TabIndex = 9;
            this.btDeleteFavorite.Text = "お気に入り削除";
            this.btDeleteFavorite.UseVisualStyleBackColor = true;
            this.btDeleteFavorite.Click += new System.EventHandler(this.btDeleteFavorite_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "URL：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "記事一覧：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Webサイト：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 640);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "お気に入りのURL：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 740);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btDeleteFavorite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lNumberOfRegistrations);
            this.Controls.Add(this.gbRssTitle);
            this.Controls.Add(this.lbUrlTitle);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.tbUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RssReader";
            this.gbRssTitle.ResumeLayout(false);
            this.gbRssTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.ListBox lbUrlTitle;
        private System.Windows.Forms.GroupBox gbRssTitle;
        private System.Windows.Forms.RadioButton rbWorld;
        private System.Windows.Forms.RadioButton rbScience;
        private System.Windows.Forms.RadioButton rbSports;
        private System.Windows.Forms.RadioButton rbIT;
        private System.Windows.Forms.Label lNumberOfRegistrations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDeleteFavorite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

