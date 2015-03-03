namespace SendEmailManager.MyControls
{
    partial class Send_Template
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_countryCode = new System.Windows.Forms.Label();
            this.textBox_subject = new System.Windows.Forms.TextBox();
            this.dateTimePicker_sendDate = new System.Windows.Forms.DateTimePicker();
            this.button_editHtml = new System.Windows.Forms.Button();
            this.button_view = new System.Windows.Forms.Button();
            this.button_modifyInfo = new System.Windows.Forms.Button();
            this.button_submit = new System.Windows.Forms.Button();
            this.label_comment = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.button_stopTask = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label_countryCode
            // 
            this.label_countryCode.AutoSize = true;
            this.label_countryCode.Location = new System.Drawing.Point(11, 21);
            this.label_countryCode.Name = "label_countryCode";
            this.label_countryCode.Size = new System.Drawing.Size(17, 12);
            this.label_countryCode.TabIndex = 0;
            this.label_countryCode.Text = "AU";
            // 
            // textBox_subject
            // 
            this.textBox_subject.BackColor = System.Drawing.Color.Red;
            this.textBox_subject.Location = new System.Drawing.Point(34, 17);
            this.textBox_subject.Name = "textBox_subject";
            this.textBox_subject.Size = new System.Drawing.Size(235, 21);
            this.textBox_subject.TabIndex = 1;
            this.textBox_subject.TextChanged += new System.EventHandler(this.textBox_subject_TextChanged);
            // 
            // dateTimePicker_sendDate
            // 
            this.dateTimePicker_sendDate.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker_sendDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_sendDate.Location = new System.Drawing.Point(275, 17);
            this.dateTimePicker_sendDate.Name = "dateTimePicker_sendDate";
            this.dateTimePicker_sendDate.Size = new System.Drawing.Size(153, 21);
            this.dateTimePicker_sendDate.TabIndex = 2;
            this.dateTimePicker_sendDate.ValueChanged += new System.EventHandler(this.dateTimePicker_sendDate_ValueChanged);
            // 
            // button_editHtml
            // 
            this.button_editHtml.Location = new System.Drawing.Point(434, 16);
            this.button_editHtml.Name = "button_editHtml";
            this.button_editHtml.Size = new System.Drawing.Size(75, 23);
            this.button_editHtml.TabIndex = 3;
            this.button_editHtml.Text = "编辑HTML";
            this.button_editHtml.UseVisualStyleBackColor = true;
            this.button_editHtml.Click += new System.EventHandler(this.button_editHtml_Click);
            // 
            // button_view
            // 
            this.button_view.Enabled = false;
            this.button_view.Location = new System.Drawing.Point(851, 16);
            this.button_view.Name = "button_view";
            this.button_view.Size = new System.Drawing.Size(60, 23);
            this.button_view.TabIndex = 4;
            this.button_view.Text = "预览";
            this.button_view.UseVisualStyleBackColor = true;
            this.button_view.Click += new System.EventHandler(this.button_view_Click);
            // 
            // button_modifyInfo
            // 
            this.button_modifyInfo.Location = new System.Drawing.Point(711, 16);
            this.button_modifyInfo.Name = "button_modifyInfo";
            this.button_modifyInfo.Size = new System.Drawing.Size(119, 23);
            this.button_modifyInfo.TabIndex = 5;
            this.button_modifyInfo.Text = "修改信息";
            this.button_modifyInfo.UseVisualStyleBackColor = true;
            this.button_modifyInfo.Click += new System.EventHandler(this.button_modifyInfo_Click);
            // 
            // button_submit
            // 
            this.button_submit.Enabled = false;
            this.button_submit.Location = new System.Drawing.Point(711, 16);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(119, 23);
            this.button_submit.TabIndex = 6;
            this.button_submit.Text = "确认发送";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // label_comment
            // 
            this.label_comment.AutoSize = true;
            this.label_comment.ForeColor = System.Drawing.Color.Blue;
            this.label_comment.Location = new System.Drawing.Point(515, 21);
            this.label_comment.Name = "label_comment";
            this.label_comment.Size = new System.Drawing.Size(95, 12);
            this.label_comment.TabIndex = 7;
            this.label_comment.Text = "请填写发送信息.";
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(711, 16);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(41, 23);
            this.button_update.TabIndex = 8;
            this.button_update.Text = "更新";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_stopTask
            // 
            this.button_stopTask.Location = new System.Drawing.Point(758, 16);
            this.button_stopTask.Name = "button_stopTask";
            this.button_stopTask.Size = new System.Drawing.Size(72, 23);
            this.button_stopTask.TabIndex = 9;
            this.button_stopTask.Text = "终止任务";
            this.button_stopTask.UseVisualStyleBackColor = true;
            this.button_stopTask.Click += new System.EventHandler(this.button_stopTask_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Send_Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_view);
            this.Controls.Add(this.button_editHtml);
            this.Controls.Add(this.dateTimePicker_sendDate);
            this.Controls.Add(this.textBox_subject);
            this.Controls.Add(this.label_countryCode);
            this.Controls.Add(this.label_comment);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.button_modifyInfo);
            this.Controls.Add(this.button_stopTask);
            this.Controls.Add(this.button_update);
            this.Name = "Send_Template";
            this.Size = new System.Drawing.Size(926, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_countryCode;
        private System.Windows.Forms.TextBox textBox_subject;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sendDate;
        private System.Windows.Forms.Button button_editHtml;
        private System.Windows.Forms.Button button_view;
        private System.Windows.Forms.Button button_modifyInfo;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Label label_comment;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_stopTask;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
