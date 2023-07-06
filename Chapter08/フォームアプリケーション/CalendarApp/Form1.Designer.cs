
namespace CalendarApp {
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btDayCalc = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.minusMonth = new System.Windows.Forms.Button();
            this.plusMonth = new System.Windows.Forms.Button();
            this.plusDay = new System.Windows.Forms.Button();
            this.minusDay = new System.Windows.Forms.Button();
            this.minusYear = new System.Windows.Forms.Button();
            this.plusYear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNowTime = new System.Windows.Forms.TextBox();
            this.btAge = new System.Windows.Forms.Button();
            this.tmTimeDisp = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "日付:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate.Location = new System.Drawing.Point(78, 10);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 31);
            this.dtpDate.TabIndex = 1;
            // 
            // btDayCalc
            // 
            this.btDayCalc.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btDayCalc.Location = new System.Drawing.Point(22, 87);
            this.btDayCalc.Name = "btDayCalc";
            this.btDayCalc.Size = new System.Drawing.Size(106, 41);
            this.btDayCalc.TabIndex = 2;
            this.btDayCalc.Text = "日数計算";
            this.btDayCalc.UseVisualStyleBackColor = true;
            this.btDayCalc.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(284, 9);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(324, 233);
            this.tbMessage.TabIndex = 3;
            // 
            // minusMonth
            // 
            this.minusMonth.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.minusMonth.Location = new System.Drawing.Point(151, 113);
            this.minusMonth.Name = "minusMonth";
            this.minusMonth.Size = new System.Drawing.Size(50, 50);
            this.minusMonth.TabIndex = 4;
            this.minusMonth.Text = "-月";
            this.minusMonth.UseVisualStyleBackColor = true;
            this.minusMonth.Click += new System.EventHandler(this.minusMonth_Click);
            // 
            // plusMonth
            // 
            this.plusMonth.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.plusMonth.Location = new System.Drawing.Point(207, 113);
            this.plusMonth.Name = "plusMonth";
            this.plusMonth.Size = new System.Drawing.Size(50, 50);
            this.plusMonth.TabIndex = 4;
            this.plusMonth.Text = "+月";
            this.plusMonth.UseVisualStyleBackColor = true;
            this.plusMonth.Click += new System.EventHandler(this.plusMonth_Click);
            // 
            // plusDay
            // 
            this.plusDay.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.plusDay.Location = new System.Drawing.Point(207, 169);
            this.plusDay.Name = "plusDay";
            this.plusDay.Size = new System.Drawing.Size(50, 50);
            this.plusDay.TabIndex = 4;
            this.plusDay.Text = "+日";
            this.plusDay.UseVisualStyleBackColor = true;
            this.plusDay.Click += new System.EventHandler(this.plusDay_Click);
            // 
            // minusDay
            // 
            this.minusDay.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.minusDay.Location = new System.Drawing.Point(151, 169);
            this.minusDay.Name = "minusDay";
            this.minusDay.Size = new System.Drawing.Size(50, 50);
            this.minusDay.TabIndex = 4;
            this.minusDay.Text = "-日";
            this.minusDay.UseVisualStyleBackColor = true;
            this.minusDay.Click += new System.EventHandler(this.minusDay_Click);
            // 
            // minusYear
            // 
            this.minusYear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.minusYear.Location = new System.Drawing.Point(151, 57);
            this.minusYear.Name = "minusYear";
            this.minusYear.Size = new System.Drawing.Size(50, 50);
            this.minusYear.TabIndex = 4;
            this.minusYear.Text = "-年";
            this.minusYear.UseVisualStyleBackColor = true;
            this.minusYear.Click += new System.EventHandler(this.minusYear_Click);
            // 
            // plusYear
            // 
            this.plusYear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.plusYear.Location = new System.Drawing.Point(207, 57);
            this.plusYear.Name = "plusYear";
            this.plusYear.Size = new System.Drawing.Size(50, 50);
            this.plusYear.TabIndex = 4;
            this.plusYear.Text = "+年";
            this.plusYear.UseVisualStyleBackColor = true;
            this.plusYear.Click += new System.EventHandler(this.plusYear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(17, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "現在時刻：";
            // 
            // tbNowTime
            // 
            this.tbNowTime.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNowTime.Location = new System.Drawing.Point(151, 253);
            this.tbNowTime.Multiline = true;
            this.tbNowTime.Name = "tbNowTime";
            this.tbNowTime.Size = new System.Drawing.Size(457, 33);
            this.tbNowTime.TabIndex = 3;
            this.tbNowTime.TextChanged += new System.EventHandler(this.tbNowTime_TextChanged);
            // 
            // btAge
            // 
            this.btAge.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btAge.Location = new System.Drawing.Point(22, 147);
            this.btAge.Name = "btAge";
            this.btAge.Size = new System.Drawing.Size(106, 41);
            this.btAge.TabIndex = 2;
            this.btAge.Text = "年齢";
            this.btAge.UseVisualStyleBackColor = true;
            this.btAge.Click += new System.EventHandler(this.btAge_Click);
            // 
            // tmTimeDisp
            // 
            this.tmTimeDisp.Interval = 500;
            this.tmTimeDisp.Tick += new System.EventHandler(this.tmTimeDisp_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 300);
            this.Controls.Add(this.minusDay);
            this.Controls.Add(this.plusDay);
            this.Controls.Add(this.plusYear);
            this.Controls.Add(this.minusYear);
            this.Controls.Add(this.plusMonth);
            this.Controls.Add(this.minusMonth);
            this.Controls.Add(this.tbNowTime);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btAge);
            this.Controls.Add(this.btDayCalc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "カレンダーアプリ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btDayCalc;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button minusMonth;
        private System.Windows.Forms.Button plusMonth;
        private System.Windows.Forms.Button plusDay;
        private System.Windows.Forms.Button minusDay;
        private System.Windows.Forms.Button minusYear;
        private System.Windows.Forms.Button plusYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNowTime;
        private System.Windows.Forms.Button btAge;
        private System.Windows.Forms.Timer tmTimeDisp;
    }
}

