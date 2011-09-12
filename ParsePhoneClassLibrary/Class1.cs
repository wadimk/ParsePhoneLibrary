using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParsePhoneClassLibrary
{
    public class Class1
    {
        public static string phone(string phone, bool convert, bool trim)
        {
            if (phone.Length == 0) 
            {
                return "";
            }

            // очистка от лишнего мусора с сохранением информации о "плюсе" в начале номера
            phone = phone.Trim();
            bool plus = (phone[0].ToString() == "+") ? true : false;
            phone = Regex.Replace(phone, "[^0-9A-Za-z]", "");
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

            }

            return (plus ? "+" : "") + phone;
        }

    }
}
