using Microsoft.Extensions.DependencyInjection;

namespace WinForms.ScopedVsTransient;

internal partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var clientForm = Program.ServiceProvider.GetRequiredService<ClientForm>();

        clientForm.Show();
    }
}
