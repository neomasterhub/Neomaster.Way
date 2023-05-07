namespace WinForms.ScopedVsTransient;

partial class ClientForm
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
            this.scopedLabel = new System.Windows.Forms.Label();
            this.transientLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scopedLabel
            // 
            this.scopedLabel.AutoSize = true;
            this.scopedLabel.Location = new System.Drawing.Point(12, 9);
            this.scopedLabel.Name = "scopedLabel";
            this.scopedLabel.Size = new System.Drawing.Size(45, 15);
            this.scopedLabel.TabIndex = 0;
            this.scopedLabel.Text = "scoped";
            // 
            // transientLabel
            // 
            this.transientLabel.AutoSize = true;
            this.transientLabel.Location = new System.Drawing.Point(12, 24);
            this.transientLabel.Name = "transientLabel";
            this.transientLabel.Size = new System.Drawing.Size(53, 15);
            this.transientLabel.TabIndex = 1;
            this.transientLabel.Text = "transient";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 50);
            this.Controls.Add(this.transientLabel);
            this.Controls.Add(this.scopedLabel);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label scopedLabel;
    private Label transientLabel;
}