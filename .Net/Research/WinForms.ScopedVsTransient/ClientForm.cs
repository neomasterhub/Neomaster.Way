namespace WinForms.ScopedVsTransient;

/// <summary>
/// Scoped form.
/// </summary>
internal partial class ClientForm : Form
{
    public ClientForm(Client client)
    {
        InitializeComponent();

        client.PrintServicesInfo(scopedLabel, transientLabel);
    }
}
