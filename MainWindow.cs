using System;
using Gtk;
using opprac1bolyuk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnButton3Clicked(object sender, EventArgs e)
    {
        new Login(1).Show();
    }

    protected void OnButton4Clicked(object sender, EventArgs e)
    {
        new Login(0).Show();
    }

    protected void OnButton5Clicked(object sender, EventArgs e)
    {
        Util.not("Розробник Болюк Данііл Віталійович КП-12");
    }
}
