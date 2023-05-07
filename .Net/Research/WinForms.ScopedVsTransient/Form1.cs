using Microsoft.Extensions.DependencyInjection;

namespace WinForms.ScopedVsTransient;

/// <summary>
/// Main form.
/// </summary>
internal partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void OpenScopedForms(object sender, EventArgs e)
    {
        var scope = Program.NextScopeServiceProvider;
        var clientForm1 = scope.GetRequiredService<ClientForm>();
        var clientForm2 = scope.GetRequiredService<ClientForm>();

        clientForm1.Show();
        clientForm2.Show();
    }
}
