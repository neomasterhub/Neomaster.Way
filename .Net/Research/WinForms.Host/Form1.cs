namespace WinForms.Host;

internal partial class Form1 : Form
{
    public Form1(IFoo foo)
    {
        MessageBox.Show(foo.Get(), "Foo");
    }
}
