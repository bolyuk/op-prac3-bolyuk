using System;
using System.Data;
using courseworkopbolyuk.kernel;

namespace opprac1bolyuk
{
    public partial class Login : Gtk.Window
    {
        public int type;
        public Login(int t) :
                base(Gtk.WindowType.Toplevel)

        {
            this.Build();
            this.type = t;
            }

        protected void OnButton6Clicked(object sender, EventArgs e)
        {
            if(entry3.Text == null || entry4.Text == null){
                Util.not("Пароль та ім'я користувача не можуть бути порожніми");
                return;
            }
            DataTable t = SQLUtil.getTable($"SELECT * FROM users WHERE name = \'{entry3.Text}\' AND password = \'{entry4.Text}\'");
            if (t.Rows.Count == 0)
            {
                Util.not("Не знайдено жодного аккаунта, перевірте правильність данних");
                return;
            }
            if ((string)t.Rows[0][2] == "admin")
                new Admin().Show();
            else
                if ((string)t.Rows[0][3] == "true")
                new User((string)t.Rows[0][0]).Show();
            else
            {
                Util.not("Вам заблокований доступ до програми");
                return;
            }
            this.Dispose();
        }
    }
}
