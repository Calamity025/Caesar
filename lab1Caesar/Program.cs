using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApplication5 {
	class Program { 
		public static void Main(string[] args) { 
			//запуск и настройка формы
			CipherForm start = new CipherForm();
			start.Text = "Шифр Цезаря";
			start.BackColor = Color.LightGray;
			Application.Run(start);
		}
	}
}
