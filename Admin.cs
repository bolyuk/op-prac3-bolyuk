using System;
using System.Data;
using courseworkopbolyuk.kernel;

namespace opprac1bolyuk
{
    public partial class Admin : Gtk.Window
    {
        public string used;
        public Admin() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            generateColumns();
            refresh();
            treeview1.RowActivated += Treeview2_RowActivated;
        }

        void Treeview2_RowActivated(object o, Gtk.RowActivatedArgs args)
        {
           
            Gtk.TreeIter iter;
            treeview1.Model.GetIter(out iter, args.Path);
            String id = treeview1.Model.GetValue(iter, 0).ToString();
            try
            {
                used = id;
                DataRow t = SQLUtil.getTable($"SELECT * FROM users WHERE name = \'{id}\'").Rows[0];
                entry5.Text = (string)t[0];
                entry6.Text = (string)t[1];
                entry7.Text = (string)t[3];
                entry10.Text = (string)t[4];
            }
            catch (Exception e)
            {
               Util.not(e.ToString());
            }
           
        }

        public void refresh()
        {
            Gtk.ListStore list = new Gtk.ListStore(
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(string));

            DataTable table = SQLUtil.getTable("SELECT * FROM users");
            foreach (DataRow r in table.Rows)
                list.AppendValues(r.ItemArray);
            treeview1.Model = list;
        }
        protected void OnButton7Clicked(object sender, EventArgs e)
        {
            SQLUtil.exec($"INSERT INTO users VALUES(\'{entry5.Text}\'," +
            	$"\'{entry6.Text}\',\'user\'," +
            		$"\'{entry7.Text}\'," +
                        $"\'{entry10.Text}\')");
            refresh();
        }

        protected void OnButton8Clicked(object sender, EventArgs e)
        {
            SQLUtil.exec($"UPDATE users SET name =\'{entry5.Text}\'," +
             $"password = \'{entry6.Text}\'," +
                 $"use = \'{entry7.Text}\'," +
                     $"change = \'{entry10.Text}\') WHERE name =\'{used}\'");
            refresh();
        }

        private void generateColumns()
        {
            addColumn("Ім'я", 1);
            addColumn("Пароль", 2);
            addColumn("Статус", 3);
            addColumn("Вхід", 4);
            addColumn("Пароль", 5);
        }

        private void addColumn(String name, int i)
        {
            treeview1.AppendColumn(name, new Gtk.CellRendererText(), "text", i);
        }

        protected void OnButton11Clicked(object sender, EventArgs e)
        {
        }
    }
}
