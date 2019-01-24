using System.Windows.Forms;

namespace ConsoleApplication5 {
	public static class Calculus {
		//алфавиты
		private static char[] alph;
		private static char[] alphEng = {
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
			's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
		private static char[] alphUkr = {
			'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
			'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я'
		};
		//методы проверки на принадлежность языку
		private static bool IsUkr(string text) {
			bool isTextUkr = true;
			for (int i = 0; i < text.Length; i++) {
				bool isCharUkr = false;
				for (int j = 0; j < alphUkr.Length; j++) {
					if (text[i] == alphUkr[j] || text[i] == ' ' || text[i] == '\r' || text[i] == '\n' || text[i] == '.' || text[i] == ',') {
						isCharUkr = true;
					}
				}
				isTextUkr &= isCharUkr;
			}
			return isTextUkr;
		}

		private static bool IsEn(string text) {
			bool isTextEn = true;
			for (int i = 0; i < text.Length; i++) {
				bool isCharEn = false;
				for (int j = 0; j < alphEng.Length; j++) {
					if (text[i] == alphUkr[j] || text[i] == ' ' || text[i] == '\r' || text[i] == '\n' || text[i] == '.' || text[i] == ',') {
						isCharEn = true;
					}
				}
				isTextEn &= isCharEn;
			}
			return isTextEn;
		}
		//метод установки нужного для данного случая алфавита
		private static void SetAlph(string text) {
			if (IsUkr(text)) {
				alph = alphUkr;
			} 
			else if(IsEn(text)) {
				alph = alphEng;
			} else { //если введенный текст не соответствует алфавитам, которые есть 
				MessageBox.Show("Введіть слово або речення українською чи англійською мовою без спецсимволів");
				alph = null;
			}
		}
		//метод шифровки
		private static string CaesarEncr(string text, int value) {
			string outputText = "";
			for (int i = 0; i < text.Length; i++) {
				int temp = 0;
				//спецсимволы
				if (text[i] == ' ' || text[i] == '\r' || text[i] == '\n' || text[i] == '.' || text[i] == ',') {
					outputText += text[i];
				} else {//определения порядкового номера буквы
					for (int j = 0; j < alph.Length; j++) {
						if (text[i] == alph[j]) {
							temp = j;
						}
					}
					temp = (temp + value) % alph.Length; //сам шифр
					outputText += alph[temp];
				}
			}
			return outputText;
		}
		//метод расшифровки
		private static string CaesarDecr(string text, int value) {
			string outputText = "";
			for (int i = 0; i < text.Length; i++) {
				int temp = 0;
				//спецсимволы
				if (text[i] == ' ' || text[i] == '\r' || text[i] == '\n' || text[i] == '.' || text[i] == ',') {
					outputText += text[i];
				} else {
					for (int j = 0; j < alph.Length; j++) {
						if (text[i] == alph[j]) {
							temp = j;
						}
					}
					temp = (temp - value) % alph.Length;
					if (temp < 0) {
						//отрицательное число если юзать этот оператор становится не сразу (модуль - число),
						//так что выкручиваемся
						temp = alph.Length + temp;
					}
					outputText += alph[temp];
				}
			}
			return outputText;
		}
		//методы с порядком выполнения операций и проверок сразу после нажатия кнопки
		public static string Encrypt(string text, int value) {
			SetAlph(text);
			string output = "";
			if (!(alph is null)) {
				output = CaesarEncr(text, value);
			}
			return output;
		}

		public static string Decrypt(string text, int value) {
			SetAlph(text);
			string output = "";
			if (!(alph is null)) {
				output = CaesarDecr(text, value);
			}
			return output;
		}
	}
}
