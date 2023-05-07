using Microsoft.Extensions.DependencyInjection;

namespace WinForms.ScopedVsTransient;

/// <summary>
/// Main form.
/// </summary>
internal partial class Form1 : Form
{
    private static int _scopeIndex = 0;

    public Form1()
    {
        InitializeComponent();
    }

    private void OpenScopedForms(object sender, EventArgs e)
    {
        var scope = Program.NextScopeServiceProvider;
        var clientForm1 = scope.GetRequiredService<ClientForm>();
        var clientForm2 = scope.GetRequiredService<ClientForm>();

        _scopeIndex++;
        clientForm1.Text = $"Scope {_scopeIndex}, Client 1";
        clientForm2.Text = $"Scope {_scopeIndex}, Client 2";

        clientForm1.Show();
        clientForm2.Show();
    }
}
