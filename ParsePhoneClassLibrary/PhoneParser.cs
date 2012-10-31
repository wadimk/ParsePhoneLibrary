using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace PhoneParser
{
    public class mobilePhone
    {
        public static string convertDirection(string operatorDirection)
        {
            string explain = "";

            switch (operatorDirection)
            {
                case "O":
                explain += "Исх. ";
                break;

                case "Исходящие":
                explain += "Исх. ";
                break;

                case "Входящие":
                explain += "Вх. ";
                break;

                case "I":
                explain += "Вх. ";
                break;
            }
            explain += "моб.";

            return explain;
        }
    }

    public class Country
    {
        private string name;
        private int code;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public int cityCodeLength;
        public bool zeroHack;

        public int[] exceptions;

        public int exceptions_max;
        public int exceptions_min;

        public Country()
        { 
        }

        public Country(string name, int code)
        {
            this.Name = name;
            this.code = code;
        }
    }

    public class phone
    {
        public List<Country> countries; 

        public phone()
        {
            //countries = loadfromxml();
            //  new List<Country>();
        }

        public string convert(string phone)
        {
            return convert(phone, true, true);
        }

        public string convert(string phone, bool convert, bool trim)
        {

            if (phone.Length == 0) 
            {
                return "";
            }

            // очистка от лишнего мусора с сохранением информации о "плюсе" в начале номера
            phone = phone.Trim();
            bool plus = (phone[0].ToString() == "+") ? true : false;
            phone = Regex.Replace(phone, "[^0-9]", "");

            //добавить в регэксп если нужен анализ буквенных номеров: A-Za-z
            string OriginalPhone = phone;

            //// конвертируем буквенный номер в цифровой
            //if ($convert == true && !is_numeric($phone)) {
            //    $replace = array('2'=>array('a','b','c'),
            //    '3'=>array('d','e','f'),
            //    '4'=>array('g','h','i'),
            //    '5'=>array('j','k','l'),
            //    '6'=>array('m','n','o'),
            //    '7'=>array('p','q','r','s'),
            //    '8'=>array('t','u','v'),
            //    '9'=>array('w','x','y','z'));
            //    foreach($replace as $digit=>$letters) {
            //        $phone = str_ireplace($letters, $digit, $phone);
            //    }
            //}

            // заменяем 00 в начале номера на +
            if (phone.Substring(0, 2).ToString() == "00")
            {
                phone = phone.Substring(2, phone.Length-2);
                plus=true;
            }

            // если телефон длиннее 7 символов, начинаем поиск страны
            if (phone.Length > 7)
            {
                for (int i = 0; i < countries.Count(); i++)
                {
                    int countryCode = countries[i].Code;
                    int codeLen = countryCode.ToString().Length;
                    if (phone.Substring(0, codeLen) == countries[i].Code.ToString())
                    {
                        // как только страна обнаружена, урезаем телефон до уровня кода города
                        phone = phone.Substring(codeLen, phone.Length-codeLen);
                        bool zero=false;
                        
                        // проверяем на наличие нулей в коде города
                        if (countries[i].zeroHack && phone[0].Equals("0"))
                        {
                            zero=true;
                            phone = phone.Substring(1, phone.Length-1);
                        }

                        string cityCode=null;

                        // сначала сравниваем с городами-исключениями
                        if (countries[i].exceptions_max != 0)
                            for (int cityCodeLen = countries[i].exceptions_max; cityCodeLen >= countries[i].exceptions_min; cityCodeLen--)
                        {
                            if (phone.Length > cityCodeLen)
                            {
                                if (countries[i].exceptions.Contains(Convert.ToInt32(phone.Substring(0, cityCodeLen))))
                                {
                                    cityCode = (zero ? "0" : "") + phone.Substring(0, cityCodeLen);
                                    phone = phone.Substring(cityCodeLen, phone.Length - cityCodeLen);
                                    break;
                                }
                            }
                        }

                        // в случае неудачи с исключениями вырезаем код города в соответствии с длиной по умолчанию
                        if (cityCode == null)
                        {
                            cityCode = phone.Substring(0, countries[i].cityCodeLength);
                            phone = phone.Substring(countries[i].cityCodeLength, phone.Length - countries[i].cityCodeLength);
                        }

                        // возвращаем результат
                        return (plus ? "+" : "") + " CountryCode: " + countryCode + "( City: " + cityCode + ")" +phone;
                    }
                }
            }

            return (plus ? "+" : "") + phone;
        }

        public void savetoxml()
        {
            var xs = new XmlSerializer(typeof(List<Country>));
            var xml = new StringWriter();

            TextWriter WriteFileStream = new StreamWriter(Directory.GetCurrentDirectory()+"\\PhoneCodes.xml");
            xs.Serialize(WriteFileStream, countries);

            WriteFileStream.Close();
        }

        public void loadfromxml()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\PhoneCodes.xml"))
                throw new FileNotFoundException("PhoneCodes.xml");

            using (var textReader = new StreamReader(Directory.GetCurrentDirectory() + "\\PhoneCodes.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Country>));
                countries = (List<Country>)xmlSerializer.Deserialize(textReader);
            }

        }
    }
}
