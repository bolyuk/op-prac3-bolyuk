using System;
using System.Data;
using courseworkopbolyuk.kernel;

namespace opprac1bolyuk
{
    public partial class User : Gtk.Window
    {
        private string name;
        public User(string name) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.name = name;
        }

        protected void OnButton9Clicked(object sender, EventArgs e)
        {
            DataTable t = SQLUtil.getTable($"SELECT * FROM users WHERE name = \'{name}\'");
            if (entry8.Text == entry9.Text && entry9.Text != "")
            {
                if ((string)t.Rows[0][4] == "true")
                    SQLUtil.exec($"UPDATE users SET name =\'{name}\'," +
                $"password = \'{entry9.Text}\'");
                else
                    Util.not("Вам заборонено змінювати пароль");
            }
            else
            {
                Util.not("Паролі повинні бути однаковими та не порожніми");
            }
        }

        protected void OnButton10Clicked(object sender, EventArgs e)
        {

        }
    }
}
