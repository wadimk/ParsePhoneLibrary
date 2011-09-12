using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace ParsePhoneLibrary
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
        protected string name;
        public string Name
        {
            get { return name; }
        }

        protected int code;
        public int Code
        {
            get { return code; }
        }

        public int cityCodeLength;
        public bool zeroHack;

        public int[] exceptions;

        public int exceptions_max;
        public int exceptions_min;

        public Country(string name, int code)
        {
            this.name = name;
            this.code = code;
        }
    }

    public class phone
    {


        public static string convert(string phone)
        {
            return convert(phone, true, true);
        }

        public static string convert(string phone, bool convert, bool trim)
        {
            Country[] phoneCodes = new Country[233];

            phoneCodes[231] = new Country("Switzerland", 41);
            phoneCodes[231].cityCodeLength = 2;
            phoneCodes[231].zeroHack = false;
            phoneCodes[231].exceptions = new int[] { 1 };
            phoneCodes[231].exceptions_max = 1;
            phoneCodes[231].exceptions_min = 1;

            phoneCodes[230] = new Country("Cocos", 9162);
            phoneCodes[230].cityCodeLength = 0;
            phoneCodes[230].zeroHack = false;
            phoneCodes[230].exceptions_max = 0;
            phoneCodes[230].exceptions_min = 0;

            phoneCodes[229] = new Country("Norfolk", 96723);
            phoneCodes[229].cityCodeLength = 0;
            phoneCodes[229].zeroHack = false;
            phoneCodes[229].exceptions_max = 0;
            phoneCodes[229].exceptions_min = 0;

            phoneCodes[228] = new Country("Liechtenstein", 4175);
            phoneCodes[228].cityCodeLength = 0;
            phoneCodes[228].zeroHack = false;
            phoneCodes[228].exceptions_max = 0;
            phoneCodes[228].exceptions_min = 0;

            phoneCodes[227] = new Country("Canary", 3428);
            phoneCodes[227].cityCodeLength = 0;
            phoneCodes[227].zeroHack = false;
            phoneCodes[227].exceptions_max = 0;
            phoneCodes[227].exceptions_min = 0;

            phoneCodes[226] = new Country("Corsica", 3395);
            phoneCodes[226].cityCodeLength = 0;
            phoneCodes[226].zeroHack = false;
            phoneCodes[226].exceptions_max = 0;
            phoneCodes[226].exceptions_min = 0;

            phoneCodes[225] = new Country("Alaska", 1907);
            phoneCodes[225].cityCodeLength = 0;
            phoneCodes[225].zeroHack = false;
            phoneCodes[225].exceptions_max = 0;
            phoneCodes[225].exceptions_min = 0;

            phoneCodes[224] = new Country("Jamaica", 1876);
            phoneCodes[224].cityCodeLength = 0;
            phoneCodes[224].zeroHack = false;
            phoneCodes[224].exceptions_max = 0;
            phoneCodes[224].exceptions_min = 0;

            phoneCodes[223] = new Country("St.KittsAndNevis", 1869);
            phoneCodes[223].cityCodeLength = 0;
            phoneCodes[223].zeroHack = false;
            phoneCodes[223].exceptions_max = 0;
            phoneCodes[223].exceptions_min = 0;

            phoneCodes[222] = new Country("TrinidadAndTobago", 1868);
            phoneCodes[222].cityCodeLength = 0;
            phoneCodes[222].zeroHack = false;
            phoneCodes[222].exceptions_max = 0;
            phoneCodes[222].exceptions_min = 0;

            phoneCodes[221] = new Country("Dominican", 1809);
            phoneCodes[221].cityCodeLength = 0;
            phoneCodes[221].zeroHack = false;
            phoneCodes[221].exceptions_max = 0;
            phoneCodes[221].exceptions_min = 0;

            phoneCodes[220] = new Country("PuertoRico", 1787);
            phoneCodes[220].cityCodeLength = 0;
            phoneCodes[220].zeroHack = false;
            phoneCodes[220].exceptions_max = 0;
            phoneCodes[220].exceptions_min = 0;

            phoneCodes[219] = new Country("St.VincentAndTheGrenadines", 1784);
            phoneCodes[219].cityCodeLength = 0;
            phoneCodes[219].zeroHack = false;
            phoneCodes[219].exceptions_max = 0;
            phoneCodes[219].exceptions_min = 0;

            phoneCodes[218] = new Country("Dominica", 1767);
            phoneCodes[218].cityCodeLength = 0;
            phoneCodes[218].zeroHack = false;
            phoneCodes[218].exceptions_max = 0;
            phoneCodes[218].exceptions_min = 0;

            phoneCodes[217] = new Country("St.Lucia", 1758);
            phoneCodes[217].cityCodeLength = 0;
            phoneCodes[217].zeroHack = false;
            phoneCodes[217].exceptions_max = 0;
            phoneCodes[217].exceptions_min = 0;

            phoneCodes[216] = new Country("Liechtenstein", 1671);
            phoneCodes[216].cityCodeLength = 0;
            phoneCodes[216].zeroHack = false;
            phoneCodes[216].exceptions_max = 0;
            phoneCodes[216].exceptions_min = 0;

            phoneCodes[215] = new Country("CommonwealthOfTheNorthernMarianaIslands", 1670);
            phoneCodes[215].cityCodeLength = 0;
            phoneCodes[215].zeroHack = false;
            phoneCodes[215].exceptions_max = 0;
            phoneCodes[215].exceptions_min = 0;

            phoneCodes[214] = new Country("Montserrat", 1664);
            phoneCodes[214].cityCodeLength = 0;
            phoneCodes[214].zeroHack = false;
            phoneCodes[214].exceptions_max = 0;
            phoneCodes[214].exceptions_min = 0;

            phoneCodes[213] = new Country("Turks&Caicos", 1649);
            phoneCodes[213].cityCodeLength = 0;
            phoneCodes[213].zeroHack = false;
            phoneCodes[213].exceptions_max = 0;
            phoneCodes[213].exceptions_min = 0;

            phoneCodes[212] = new Country("Grenada", 1473);
            phoneCodes[212].cityCodeLength = 0;
            phoneCodes[212].zeroHack = false;
            phoneCodes[212].exceptions_max = 0;
            phoneCodes[212].exceptions_min = 0;

            phoneCodes[211] = new Country("Bermuda", 1441);
            phoneCodes[211].cityCodeLength = 0;
            phoneCodes[211].zeroHack = false;
            phoneCodes[211].exceptions_max = 0;
            phoneCodes[211].exceptions_min = 0;

            phoneCodes[210] = new Country("CaymanIslands", 1345);
            phoneCodes[210].cityCodeLength = 0;
            phoneCodes[210].zeroHack = false;
            phoneCodes[210].exceptions_max = 0;
            phoneCodes[210].exceptions_min = 0;

            phoneCodes[209] = new Country("USVirginIslands", 1340);
            phoneCodes[209].cityCodeLength = 0;
            phoneCodes[209].zeroHack = false;
            phoneCodes[209].exceptions_max = 0;
            phoneCodes[209].exceptions_min = 0;

            phoneCodes[208] = new Country("Bahamas", 1284);
            phoneCodes[208].cityCodeLength = 0;
            phoneCodes[208].zeroHack = false;
            phoneCodes[208].exceptions_max = 0;
            phoneCodes[208].exceptions_min = 0;;

            phoneCodes[207] = new Country("AntiguaAndBarbuda", 1268);
            phoneCodes[207].cityCodeLength = 0;
            phoneCodes[207].zeroHack = false;
            phoneCodes[207].exceptions_max = 0;
            phoneCodes[207].exceptions_min = 0;

            phoneCodes[206] = new Country("Anguilla", 1264);
            phoneCodes[206].cityCodeLength = 0;
            phoneCodes[206].zeroHack = false;
            phoneCodes[206].exceptions_max = 0;
            phoneCodes[206].exceptions_min = 0;

            phoneCodes[205] = new Country("Barbados", 1246);
            phoneCodes[205].cityCodeLength = 0;
            phoneCodes[205].zeroHack = false;
            phoneCodes[205].exceptions_max = 0;
            phoneCodes[205].exceptions_min = 0;

            phoneCodes[204] = new Country("Uzbekistan", 998);
            phoneCodes[204].cityCodeLength = 4;
            phoneCodes[204].zeroHack = false;
            phoneCodes[204].exceptions = new int [] { 71, 74,65,67, 72, 75, 79, 69, 61, 66,76,62,73,677,673 };
            phoneCodes[204].exceptions_max = 3;
            phoneCodes[204].exceptions_min = 2;

            phoneCodes[203] = new Country("Kyrgyzstan", 996);
            phoneCodes[203].cityCodeLength = 4;
            phoneCodes[203].zeroHack = false;
            phoneCodes[203].exceptions = new int[] { 31 ,37,313,39,35,32,34 };
            phoneCodes[203].exceptions_max = 3;
            phoneCodes[203].exceptions_min = 2;

            phoneCodes[202] = new Country("Georgia", 995);
            phoneCodes[202].cityCodeLength = 3;
            phoneCodes[202].zeroHack = false;
            phoneCodes[202].exceptions = new int[] { 32, 34 };
            phoneCodes[202].exceptions_max = 2;
            phoneCodes[202].exceptions_min = 2;

            phoneCodes[201] = new Country("Azerbaijan", 994);
            phoneCodes[201].cityCodeLength = 3;
            phoneCodes[201].zeroHack = false;
            phoneCodes[201].exceptions = new int[] { 12,1445,1302 };
            phoneCodes[201].exceptions_max = 4;
            phoneCodes[201].exceptions_min = 2;

            phoneCodes[200] = new Country("Turkmenistan", 993);
            phoneCodes[200].cityCodeLength = 1;
            phoneCodes[200].zeroHack = false;
            phoneCodes[200].exceptions_max = 0;
            phoneCodes[200].exceptions_min = 0;

            phoneCodes[199] = new Country("Tajikistan", 992);
            phoneCodes[199].cityCodeLength = 0;
            phoneCodes[199].zeroHack = false;
            phoneCodes[199].exceptions_max = 0;
            phoneCodes[199].exceptions_min = 0;

            phoneCodes[198] = new Country("Nepal", 977);
            phoneCodes[198].cityCodeLength = 2;
            phoneCodes[198].zeroHack = false;
            phoneCodes[198].exceptions = new int[] { 1 };
            phoneCodes[198].exceptions_max = 1;
            phoneCodes[198].exceptions_min = 1;

            phoneCodes[197] = new Country("Mongolia", 976);
            phoneCodes[197].cityCodeLength = 2;
            phoneCodes[197].zeroHack = false;
            phoneCodes[197].exceptions_max = 1;
            phoneCodes[197].exceptions_min = 1;

            phoneCodes[196] = new Country("Bhutan", 975);
            phoneCodes[196].cityCodeLength = 0;
            phoneCodes[196].zeroHack = false;
            phoneCodes[196].exceptions_max = 0;
            phoneCodes[196].exceptions_min = 0;

            phoneCodes[195] = new Country("Qatar", 974);
            phoneCodes[195].cityCodeLength = 0;
            phoneCodes[195].zeroHack = false;
            phoneCodes[195].exceptions = new int[] {48,59,550,551,552,553,554,555,556,557,558,559,222,223,224,225,226,227 };
            phoneCodes[195].exceptions_max = 3;
            phoneCodes[195].exceptions_min = 2;

            phoneCodes[194] = new Country("Bahrain", 973);
            phoneCodes[194].cityCodeLength = 0;
            phoneCodes[194].zeroHack = false;
            phoneCodes[194].exceptions_max = 0;
            phoneCodes[194].exceptions_min = 0;

            phoneCodes[193] = new Country("Israel", 972);
            phoneCodes[193].cityCodeLength = 1;
            phoneCodes[193].zeroHack = false;
            phoneCodes[193].exceptions = new int[] { 50,51,5,53,58 };
            phoneCodes[193].exceptions_max = 2;
            phoneCodes[193].exceptions_min = 2;

            phoneCodes[192] = new Country("UnitedArabEmirates", 971);
            phoneCodes[192].cityCodeLength = 1;
            phoneCodes[192].zeroHack = false;
            phoneCodes[192].exceptions = new int[] { 5079 };
            phoneCodes[192].exceptions_max = 4;
            phoneCodes[192].exceptions_min = 4;

            phoneCodes[191] = new Country("Yemen-South", 969);
            phoneCodes[191].cityCodeLength = 2;
            phoneCodes[191].zeroHack = false;
            phoneCodes[191].exceptions = new int[] { 8 };
            phoneCodes[191].exceptions_max = 1;
            phoneCodes[191].exceptions_min = 1;

            phoneCodes[190] = new Country("Oman", 968);
            phoneCodes[190].cityCodeLength = 0;
            phoneCodes[190].zeroHack = false;
            phoneCodes[190].exceptions_max = 0;
            phoneCodes[190].exceptions_min = 0;

            phoneCodes[189] = new Country("Yemen-North", 967);
            phoneCodes[189].cityCodeLength = 1;
            phoneCodes[189].zeroHack = false;
            phoneCodes[189].exceptions_max = 0;
            phoneCodes[189].exceptions_min = 0;

            phoneCodes[188] = new Country("SaudiArabia", 966);
            phoneCodes[188].cityCodeLength = 1;
            phoneCodes[188].zeroHack = false;
            phoneCodes[188].exceptions_max = 0;
            phoneCodes[188].exceptions_min = 0;

            phoneCodes[187] = new Country("Kuwait", 965);
            phoneCodes[187].cityCodeLength = 0;
            phoneCodes[187].zeroHack = false;
            phoneCodes[187].exceptions_max = 0;
            phoneCodes[187].exceptions_min = 0;

            phoneCodes[186] = new Country("Iraq", 964);
            phoneCodes[186].cityCodeLength = 3;
            phoneCodes[186].zeroHack = false;
            phoneCodes[186].exceptions = new int[] {1,43,49,25,62,36,32,50,23,60,42,33,24,37,53,21,30,66 };
            phoneCodes[186].exceptions_max = 2;
            phoneCodes[186].exceptions_min = 1;

            phoneCodes[185] = new Country("Syria", 963);
            phoneCodes[185].cityCodeLength = 2;
            phoneCodes[185].zeroHack = false;
            phoneCodes[185].exceptions_max = 0;
            phoneCodes[185].exceptions_min = 0;

            phoneCodes[184] = new Country("Jordan", 962);
            phoneCodes[184].cityCodeLength = 1;
            phoneCodes[184].zeroHack = false;
            phoneCodes[184].exceptions = new int[] { 59,79,73,74,17 };
            phoneCodes[184].exceptions_max = 2;
            phoneCodes[184].exceptions_min = 2;

            phoneCodes[183] = new Country("Lebanon", 961);
            phoneCodes[183].cityCodeLength = 1;
            phoneCodes[183].zeroHack = false;
            phoneCodes[183].exceptions_max = 0;
            phoneCodes[183].exceptions_min = 0;

            phoneCodes[182] = new Country("Maldives", 960);
            phoneCodes[182].cityCodeLength = 0;
            phoneCodes[182].zeroHack = false;
            phoneCodes[182].exceptions_max = 0;
            phoneCodes[182].exceptions_min = 0;

            phoneCodes[181] = new Country("Taiwan", 886);
            phoneCodes[181].cityCodeLength = 1;
            phoneCodes[181].zeroHack = false;
            phoneCodes[181].exceptions = new int[] { 89,90,91,92,93,96,60,70,94,95 };
            phoneCodes[181].exceptions_max = 2;
            phoneCodes[181].exceptions_min = 2;

            phoneCodes[180] = new Country("Bangladesh", 880);
            phoneCodes[180].cityCodeLength = 3;
            phoneCodes[180].zeroHack = false;
            phoneCodes[180].exceptions = new int[] {51,2,41,81,91,31 };
            phoneCodes[180].exceptions_max = 2;
            phoneCodes[180].exceptions_min = 1;

            phoneCodes[179] = new Country("Laos", 856);
            phoneCodes[179].cityCodeLength = 2;
            phoneCodes[179].zeroHack = false;
            phoneCodes[179].exceptions = new int[] { 9 };
            phoneCodes[179].exceptions_max = 1;
            phoneCodes[179].exceptions_min = 1;

            phoneCodes[178] = new Country("Cambodia", 855);
            phoneCodes[178].cityCodeLength = 2;
            phoneCodes[178].zeroHack = false;
            phoneCodes[178].exceptions = new int[] {1881,1591,1720 };
            phoneCodes[178].exceptions_max = 4;
            phoneCodes[178].exceptions_min = 4;

            phoneCodes[177] = new Country("Macau", 853);
            phoneCodes[177].cityCodeLength = 0;
            phoneCodes[177].zeroHack = false;
            phoneCodes[177].exceptions_max = 0;
            phoneCodes[177].exceptions_min = 0;

            phoneCodes[176] = new Country("HongKong", 852);
            phoneCodes[176].cityCodeLength = 0;
            phoneCodes[176].zeroHack = false;
            phoneCodes[176].exceptions_max = 0;
            phoneCodes[176].exceptions_min = 0;

            phoneCodes[175] = new Country("Korea,Dem.PeoplesRepublic", 850);
            phoneCodes[175].cityCodeLength = 4;
            phoneCodes[175].zeroHack = false;
            phoneCodes[175].exceptions_max = 0;
            phoneCodes[175].exceptions_min = 0;

            phoneCodes[174] = new Country("MarshallIslands", 692);
            phoneCodes[174].cityCodeLength = 1;
            phoneCodes[174].zeroHack = false;
            phoneCodes[174].exceptions = new int[] { 873 };
            phoneCodes[174].exceptions_max = 3;
            phoneCodes[174].exceptions_min = 3;

            phoneCodes[173] = new Country("Micronesia", 691);
            phoneCodes[173].cityCodeLength = 0;
            phoneCodes[173].zeroHack = false;
            phoneCodes[173].exceptions_max = 0;
            phoneCodes[173].exceptions_min = 0;

            phoneCodes[172] = new Country("Tokelau", 690);
            phoneCodes[172].cityCodeLength = 0;
            phoneCodes[172].zeroHack = false;
            phoneCodes[172].exceptions_max = 0;
            phoneCodes[172].exceptions_min = 0;

            phoneCodes[171] = new Country("FrenchPolynesia", 689);
            phoneCodes[171].cityCodeLength = 0;
            phoneCodes[171].zeroHack = false;
            phoneCodes[171].exceptions_max = 0;
            phoneCodes[171].exceptions_min = 0;

            phoneCodes[170] = new Country("Tuvalu", 688);
            phoneCodes[170].cityCodeLength = 0;
            phoneCodes[170].zeroHack = false;
            phoneCodes[170].exceptions_max = 0;
            phoneCodes[170].exceptions_min = 0;

            phoneCodes[169] = new Country("NewCaledonia", 687);
            phoneCodes[169].cityCodeLength = 0;
            phoneCodes[169].zeroHack = false;
            phoneCodes[169].exceptions_max = 0;
            phoneCodes[169].exceptions_min = 0;

            phoneCodes[168] = new Country("Kiribati", 686);
            phoneCodes[168].cityCodeLength = 0;
            phoneCodes[168].zeroHack = false;
            phoneCodes[168].exceptions_max = 0;
            phoneCodes[168].exceptions_min = 0;

            phoneCodes[167] = new Country("WesternSamoa", 685);
            phoneCodes[167].cityCodeLength = 0;
            phoneCodes[167].zeroHack = false;
            phoneCodes[167].exceptions_max = 0;
            phoneCodes[167].exceptions_min = 0;

            phoneCodes[166] = new Country("AmericanSamoa", 684);
            phoneCodes[166].cityCodeLength = 0;
            phoneCodes[166].zeroHack = false;
            phoneCodes[166].exceptions_max = 0;
            phoneCodes[166].exceptions_min = 0;

            phoneCodes[165] = new Country("NiueIslands", 683);
            phoneCodes[165].cityCodeLength = 0;
            phoneCodes[165].zeroHack = false;
            phoneCodes[165].exceptions_max = 0;
            phoneCodes[165].exceptions_min = 0;

            phoneCodes[164] = new Country("CookIslands", 682);
            phoneCodes[164].cityCodeLength = 0;
            phoneCodes[164].zeroHack = false;
            phoneCodes[164].exceptions_max = 0;
            phoneCodes[164].exceptions_min = 0;

            phoneCodes[163] = new Country("WallisAndFutuna", 681);
            phoneCodes[163].cityCodeLength = 0;
            phoneCodes[163].zeroHack = false;
            phoneCodes[163].exceptions_max = 0;
            phoneCodes[163].exceptions_min = 0;

            phoneCodes[162] = new Country("Palau", 680);
            phoneCodes[162].cityCodeLength = 0;
            phoneCodes[162].zeroHack = false;
            phoneCodes[162].exceptions_max = 0;
            phoneCodes[162].exceptions_min = 0;

            phoneCodes[161] = new Country("Fiji", 679);
            phoneCodes[161].cityCodeLength = 0;
            phoneCodes[161].zeroHack = false;
            phoneCodes[161].exceptions_max = 0;
            phoneCodes[161].exceptions_min = 0;

            phoneCodes[160] = new Country("Vanuatu", 678);
            phoneCodes[160].cityCodeLength = 0;
            phoneCodes[160].zeroHack = false;
            phoneCodes[160].exceptions_max = 0;
            phoneCodes[160].exceptions_min = 0;

            phoneCodes[159] = new Country("SolomonIslands", 677);
            phoneCodes[159].cityCodeLength = 0;
            phoneCodes[159].zeroHack = false;
            phoneCodes[159].exceptions_max = 0;
            phoneCodes[159].exceptions_min = 0;

            phoneCodes[158] = new Country("Tonga", 676);
            phoneCodes[158].cityCodeLength = 0;
            phoneCodes[158].zeroHack = false;
            phoneCodes[158].exceptions_max = 0;
            phoneCodes[158].exceptions_min = 0;

            phoneCodes[157] = new Country("PapuaNewGuinea", 675);
            phoneCodes[157].cityCodeLength = 0;
            phoneCodes[157].zeroHack = false;
            phoneCodes[157].exceptions_max = 0;
            phoneCodes[157].exceptions_min = 0;

            phoneCodes[156] = new Country("Nauru", 674);
            phoneCodes[156].cityCodeLength = 0;
            phoneCodes[156].zeroHack = false;
            phoneCodes[156].exceptions_max = 0;
            phoneCodes[156].exceptions_min = 0;

            phoneCodes[155] = new Country("Brunei", 673);
            phoneCodes[155].cityCodeLength = 1;
            phoneCodes[155].zeroHack = false;
            phoneCodes[155].exceptions_max = 0;
            phoneCodes[155].exceptions_min = 0;

            phoneCodes[154] = new Country("ChristmasIsland", 672);
            phoneCodes[154].cityCodeLength = 0;
            phoneCodes[154].zeroHack = false;
            phoneCodes[154].exceptions_max = 0;
            phoneCodes[154].exceptions_min = 0;

            phoneCodes[153] = new Country("Guam", 671);
            phoneCodes[153].cityCodeLength = 0;
            phoneCodes[153].zeroHack = false;
            phoneCodes[153].exceptions_max = 0;
            phoneCodes[153].exceptions_min = 0;

            phoneCodes[152] = new Country("NorthernMarianaIslands", 670);
            phoneCodes[152].cityCodeLength = 0;
            phoneCodes[152].zeroHack = false;
            phoneCodes[152].exceptions = new int[] { 2348 };
            phoneCodes[152].exceptions_max = 4;
            phoneCodes[152].exceptions_min = 4;

            phoneCodes[151] = new Country("NetherlandsAntilles", 599);
            phoneCodes[151].cityCodeLength = 1;
            phoneCodes[151].zeroHack = false;
            phoneCodes[151].exceptions = new int[] { 46 };
            phoneCodes[151].exceptions_max = 2;
            phoneCodes[151].exceptions_min = 2;

            phoneCodes[150] = new Country("Uruguay", 598);
            phoneCodes[150].cityCodeLength = 3;
            phoneCodes[150].zeroHack = false;
            phoneCodes[150].exceptions = new int[] { 42,2 };
            phoneCodes[150].exceptions_max = 2;
            phoneCodes[150].exceptions_min = 1;

            phoneCodes[149] = new Country("Suriname", 597);
            phoneCodes[149].cityCodeLength = 0;
            phoneCodes[149].zeroHack = false;
            phoneCodes[149].exceptions_max = 0;
            phoneCodes[149].exceptions_min = 0;

            phoneCodes[148] = new Country("Martinique", 596);
            phoneCodes[148].cityCodeLength = 0;
            phoneCodes[148].zeroHack = false;
            phoneCodes[148].exceptions = new int[] { 20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79 };
            phoneCodes[148].exceptions_max = 2;
            phoneCodes[148].exceptions_min = 2;

            phoneCodes[147] = new Country("Paraguay", 595);
            phoneCodes[147].cityCodeLength = 2;
            phoneCodes[147].zeroHack = false;
            phoneCodes[147].exceptions = new int[] { 541 , 521 };
            phoneCodes[147].exceptions_max = 3;
            phoneCodes[147].exceptions_min = 3;

            phoneCodes[146] = new Country("FrenchGuiana", 594);
            phoneCodes[146].cityCodeLength = 0;
            phoneCodes[146].zeroHack = false;
            phoneCodes[146].exceptions_max = 0;
            phoneCodes[146].exceptions_min = 0;

            phoneCodes[145] = new Country("Ecuador", 593);
            phoneCodes[145].cityCodeLength = 1;
            phoneCodes[145].zeroHack = false;
            phoneCodes[145].exceptions_max = 0;
            phoneCodes[145].exceptions_min = 0;

            phoneCodes[144] = new Country("Guyana", 592);
            phoneCodes[144].cityCodeLength = 0;
            phoneCodes[144].zeroHack = false;
            phoneCodes[144].exceptions_max = 0;
            phoneCodes[144].exceptions_min = 0;

            phoneCodes[143] = new Country("Bolivia", 591);
            phoneCodes[143].cityCodeLength = 3;
            phoneCodes[143].zeroHack = false;
            phoneCodes[143].exceptions = new int[] { 69,4,2,92,52,3,46 };
            phoneCodes[143].exceptions_max = 2;
            phoneCodes[143].exceptions_min = 1;

            phoneCodes[142] = new Country("FrenchAntilles", 590);
            phoneCodes[142].cityCodeLength = 0;
            phoneCodes[142].zeroHack = false;
            phoneCodes[142].exceptions_max = 0;
            phoneCodes[142].exceptions_min = 0;

            phoneCodes[141] = new Country("Haiti", 509);
            phoneCodes[141].cityCodeLength = 1;
            phoneCodes[141].zeroHack = false;
            phoneCodes[141].exceptions = new int[] { 330,420,510,851 };
            phoneCodes[141].exceptions_max = 3;
            phoneCodes[141].exceptions_min = 3;

            phoneCodes[140] = new Country("SaintPierreEtMiquelon", 508);
            phoneCodes[140].cityCodeLength = 0;
            phoneCodes[140].zeroHack = false;
            phoneCodes[140].exceptions_max = 0;
            phoneCodes[140].exceptions_min = 0;

            phoneCodes[139] = new Country("Panama", 507);
            phoneCodes[139].cityCodeLength = 1;
            phoneCodes[139].zeroHack = false;
            phoneCodes[139].exceptions_max = 0;
            phoneCodes[139].exceptions_min = 0;

            phoneCodes[138] = new Country("Costa", 506);
            phoneCodes[138].cityCodeLength = 0;
            phoneCodes[138].zeroHack = false;
            phoneCodes[138].exceptions_max = 0;
            phoneCodes[138].exceptions_min = 0;

            phoneCodes[137] = new Country("Nicaragua", 505);
            phoneCodes[137].cityCodeLength = 3;
            phoneCodes[137].zeroHack = false;
            phoneCodes[137].exceptions = new int[] { 2 };
            phoneCodes[137].exceptions_max = 1;
            phoneCodes[137].exceptions_min = 1;

            phoneCodes[136] = new Country("Honduras", 504);
            phoneCodes[136].cityCodeLength = 0;
            phoneCodes[136].zeroHack = false;
            phoneCodes[136].exceptions_max = 0;
            phoneCodes[136].exceptions_min = 0;

            phoneCodes[135] = new Country("ElSalvador", 503);
            phoneCodes[135].cityCodeLength = 0;
            phoneCodes[135].zeroHack = false;
            phoneCodes[135].exceptions_max = 0;
            phoneCodes[135].exceptions_min = 0;

            phoneCodes[134] = new Country("Guatemala", 502);
            phoneCodes[134].cityCodeLength = 1;
            phoneCodes[134].zeroHack = false;
            phoneCodes[134].exceptions_max = 0;
            phoneCodes[134].exceptions_min = 0;

            phoneCodes[133] = new Country("Belize", 501);
            phoneCodes[133].cityCodeLength = 1;
            phoneCodes[133].zeroHack = false;
            phoneCodes[133].exceptions_max = 0;
            phoneCodes[133].exceptions_min = 0;

            phoneCodes[132] = new Country("Falkland", 500);
            phoneCodes[132].cityCodeLength = 0;
            phoneCodes[132].zeroHack = false;
            phoneCodes[132].exceptions_max = 0;
            phoneCodes[132].exceptions_min = 0;

            phoneCodes[131] = new Country("SlovakRepublic", 421);
            phoneCodes[131].cityCodeLength = 3;
            phoneCodes[131].zeroHack = false;
            phoneCodes[131].exceptions = new int[] { 7,89,95,92,91 };
            phoneCodes[131].exceptions_max = 2;
            phoneCodes[131].exceptions_min = 1;

            phoneCodes[130] = new Country("CzechRepublic", 420);
            phoneCodes[130].cityCodeLength = 3;
            phoneCodes[130].zeroHack = false;
            phoneCodes[130].exceptions = new int[] {5,49,67,66,17,48,35,68,69,40,19,2,47,38 };
            phoneCodes[130].exceptions_max = 2;
            phoneCodes[130].exceptions_min = 1;

            phoneCodes[129] = new Country("Macedonia", 389);
            phoneCodes[129].cityCodeLength = 2;
            phoneCodes[129].zeroHack = false;
            phoneCodes[129].exceptions = new int[] { 903,901,902 };
            phoneCodes[129].exceptions_max = 3;
            phoneCodes[129].exceptions_min = 3;

            phoneCodes[128] = new Country("BosniaAndHerzegovina", 387);
            phoneCodes[128].cityCodeLength = 2;
            phoneCodes[128].zeroHack = false;
            phoneCodes[128].exceptions_max = 0;
            phoneCodes[128].exceptions_min = 0;

            phoneCodes[127] = new Country("Slovenia", 386);
            phoneCodes[127].cityCodeLength = 2;
            phoneCodes[127].zeroHack = false;
            phoneCodes[127].exceptions = new int[] { 608,602,601 };
            phoneCodes[127].exceptions_max = 3;
            phoneCodes[127].exceptions_min = 3;

            phoneCodes[126] = new Country("Croatia", 385);
            phoneCodes[126].cityCodeLength = 2;
            phoneCodes[126].zeroHack = false;
            phoneCodes[126].exceptions = new int[] { 1 };
            phoneCodes[126].exceptions_max = 1;
            phoneCodes[126].exceptions_min = 1;

            phoneCodes[125] = new Country("Yugoslavia", 381);
            phoneCodes[125].cityCodeLength = 2;
            phoneCodes[125].zeroHack = false;
            phoneCodes[125].exceptions = new int[] { 230 };
            phoneCodes[125].exceptions_max = 3;
            phoneCodes[125].exceptions_min = 3;

            phoneCodes[124] = new Country("Ukraine", 380);
            phoneCodes[124].cityCodeLength = 4;
            phoneCodes[124].zeroHack = true;
            phoneCodes[124].exceptions = new int[] { 44,432,1762,562,622,412,522,564,53615,642,322,448,629,512,482,532,3355,1821,403,222,1852,356,3371,267,3443,1694,1965,3058,1627,3385,3356,2718,3370,3260,3231,2785,309,2857,2957,2911,294,1705,3,295,3250,3387,2523,3246,2674,1854,3433,1711,251,2958,2477,2984,307,542,352,572,552,382,472,462,654 };
            phoneCodes[124].exceptions_max = 5;
            phoneCodes[124].exceptions_min = 1;

            phoneCodes[123] = new Country("RepublicOfSanMarino", 378);
            phoneCodes[123].cityCodeLength = 0;
            phoneCodes[123].zeroHack = false;
            phoneCodes[123].exceptions_max = 0;
            phoneCodes[123].exceptions_min = 0;

            phoneCodes[122] = new Country("Monaco", 377);
            phoneCodes[122].cityCodeLength = 1;
            phoneCodes[122].zeroHack = false;
            phoneCodes[122].exceptions_max = 0;
            phoneCodes[122].exceptions_min = 0;

            phoneCodes[121] = new Country("Andorra", 376);
            phoneCodes[121].cityCodeLength = 0;
            phoneCodes[121].zeroHack = false;
            phoneCodes[121].exceptions_max = 0;
            phoneCodes[121].exceptions_min = 0;

            phoneCodes[120] = new Country("Belarus", 375);
            phoneCodes[120].cityCodeLength = 4;
            phoneCodes[120].zeroHack = false;
            phoneCodes[120].exceptions = new int[] { 17,163,162,232,222 };
            phoneCodes[120].exceptions_max = 3;
            phoneCodes[120].exceptions_min = 2;

            phoneCodes[119] = new Country("Armenia", 374);
            phoneCodes[119].cityCodeLength = 2;
            phoneCodes[119].zeroHack = false;
            phoneCodes[119].exceptions = new int[] { 1,460,520,4300,680,860,830,550,490,570 };
            phoneCodes[119].exceptions_max = 4;
            phoneCodes[119].exceptions_min = 1;

            phoneCodes[118] = new Country("Moldova", 373);
            phoneCodes[118].cityCodeLength = 2;
            phoneCodes[118].zeroHack = false;
            phoneCodes[118].exceptions = new int[] { 2 };
            phoneCodes[118].exceptions_max = 1;
            phoneCodes[118].exceptions_min = 1;

            phoneCodes[117] = new Country("Estonia", 372);
            phoneCodes[117].cityCodeLength = 2;
            phoneCodes[117].zeroHack = false;
            phoneCodes[117].exceptions = new int [] { 2,7 };
            phoneCodes[117].exceptions_max = 1;
            phoneCodes[117].exceptions_min = 1;

            phoneCodes[116] = new Country("Latvia", 371);
            phoneCodes[116].cityCodeLength = 2;
            phoneCodes[116].zeroHack = false;
            phoneCodes[116].exceptions_max = 0;
            phoneCodes[116].exceptions_min = 0;

            phoneCodes[115] = new Country("Lithuania", 370);
            phoneCodes[115].cityCodeLength = 3;
            phoneCodes[115].zeroHack = false;
            phoneCodes[115].exceptions = new int[] { 5,37,46,45,41 };
            phoneCodes[115].exceptions_max = 2;
            phoneCodes[115].exceptions_min = 1;

            phoneCodes[114] = new Country("Bulgaria", 359);
            phoneCodes[114].cityCodeLength = 3;
            phoneCodes[114].zeroHack = false;
            phoneCodes[114].exceptions = new int[] { 2,56,62,94,92,52,32,76,64,84,82,44,42,38,46,5722,73,66,58,68,34,86,54,6071,7443,5152,7112,7128,9744,9527,5731,8141,3041,6514,6151,3071,9131,7142,3145,8362,3751,6191,9171,2031,7181,6141,7133,5561,3542,3151,3561,7481,3181,5514,3134,6161,4761,5751,3051 };
            phoneCodes[114].exceptions_max = 4;
            phoneCodes[114].exceptions_min = 1;

            phoneCodes[113] = new Country("Finland", 358);
            phoneCodes[113].cityCodeLength = 2;
            phoneCodes[113].zeroHack = false;
            phoneCodes[113].exceptions = new int[] { 6,5,2,8,9,3 };
            phoneCodes[113].exceptions_max = 1;
            phoneCodes[113].exceptions_min = 1;

            phoneCodes[112] = new Country("Cyprus", 357);
            phoneCodes[112].cityCodeLength = 2;
            phoneCodes[112].zeroHack = false;
            phoneCodes[112].exceptions = new int[] { 2,3,91,92,93,94,95,96,98 };
            phoneCodes[112].exceptions_max = 2;
            phoneCodes[112].exceptions_min = 1;

            phoneCodes[111] = new Country("Malta", 356);
            phoneCodes[111].cityCodeLength = 0;
            phoneCodes[111].zeroHack = false;
            phoneCodes[111].exceptions_max = 0;
            phoneCodes[111].exceptions_min = 0;

            phoneCodes[110] = new Country("Albania", 355);
            phoneCodes[110].cityCodeLength = 3;
            phoneCodes[110].zeroHack = false;
            phoneCodes[110].exceptions = new int[] { 65,62,52,64,82,7426,42,63 };
            phoneCodes[110].exceptions_max = 4;
            phoneCodes[110].exceptions_min = 2;

            phoneCodes[109] = new Country("Iceland", 354);
            phoneCodes[109].cityCodeLength = 3;
            phoneCodes[109].zeroHack = false;
            phoneCodes[109].exceptions_max = 0;
            phoneCodes[109].exceptions_min = 0;

            phoneCodes[108] = new Country("IrishRepublic", 353);
            phoneCodes[108].cityCodeLength = 2;
            phoneCodes[108].zeroHack = false;
            phoneCodes[108].exceptions = new int[] { 1,402,507,902,905,509,502,903,506,504,404,405 };
            phoneCodes[108].exceptions_max = 3;
            phoneCodes[108].exceptions_min = 1;

            phoneCodes[107] = new Country("Luxembourg", 352);
            phoneCodes[107].cityCodeLength = 2;
            phoneCodes[107].zeroHack = true;
            phoneCodes[107].exceptions_max = 0;
            phoneCodes[107].exceptions_min = 0;

            phoneCodes[106] = new Country("Azores", 351);
            phoneCodes[106].cityCodeLength = 2;
            phoneCodes[106].zeroHack = false;
            phoneCodes[106].exceptions = new int[] { 1,2,96,676,765,96765 };
            phoneCodes[106].exceptions_max = 5;
            phoneCodes[106].exceptions_min = 1;

            phoneCodes[105] = new Country("Gibraltar", 350);
            phoneCodes[105].cityCodeLength = 0;
            phoneCodes[105].zeroHack = false;
            phoneCodes[105].exceptions_max = 0;
            phoneCodes[105].exceptions_min = 0;

            phoneCodes[104] = new Country("Greenland", 299);
            phoneCodes[104].cityCodeLength = 0;
            phoneCodes[104].zeroHack = false;
            phoneCodes[104].exceptions_max = 0;
            phoneCodes[104].exceptions_min = 0;

            phoneCodes[103] = new Country("FaeroeIslands", 298);
            phoneCodes[103].cityCodeLength = 0;
            phoneCodes[103].zeroHack = false;
            phoneCodes[103].exceptions = new int[] { 2 };
            phoneCodes[103].exceptions_max = 1;
            phoneCodes[103].exceptions_min = 1;

            phoneCodes[102] = new Country("Aruba", 297);
            phoneCodes[102].cityCodeLength = 1;
            phoneCodes[102].zeroHack = false;
            phoneCodes[102].exceptions_max = 0;
            phoneCodes[102].exceptions_min = 0;

            phoneCodes[101] = new Country("Eritrea", 291);
            phoneCodes[101].cityCodeLength = 2;
            phoneCodes[101].zeroHack = false;
            phoneCodes[101].exceptions = new int[] { 1 };
            phoneCodes[101].exceptions_max = 1;
            phoneCodes[101].exceptions_min = 1;

            phoneCodes[100] = new Country("St.Helena", 290);
            phoneCodes[100].cityCodeLength = 0;
            phoneCodes[100].zeroHack = false;
            phoneCodes[100].exceptions_max = 0;
            phoneCodes[100].exceptions_min = 0;

            phoneCodes[99] = new Country("ComorosAndMayotteIsland", 269);
            phoneCodes[99].cityCodeLength = 0;
            phoneCodes[99].zeroHack = false;
            phoneCodes[99].exceptions_max = 0;
            phoneCodes[99].exceptions_min = 0;

            phoneCodes[98] = new Country("Swaziland", 268);
            phoneCodes[98].cityCodeLength = 0;
            phoneCodes[98].zeroHack = false;
            phoneCodes[98].exceptions_max = 0;
            phoneCodes[98].exceptions_min = 0;

            phoneCodes[97] = new Country("Botswana", 267);

            phoneCodes[97].cityCodeLength = 2;
            phoneCodes[97].zeroHack = false;
            phoneCodes[97].exceptions_max = 0;
            phoneCodes[97].exceptions_min = 0;

            phoneCodes[96] = new Country("Lesotho", 266);
            phoneCodes[96].cityCodeLength = 0;
            phoneCodes[96].zeroHack = false;
            phoneCodes[96].exceptions_max = 0;
            phoneCodes[96].exceptions_min = 0;

            phoneCodes[95] = new Country("Malawi", 265);
            phoneCodes[95].cityCodeLength = 1;
            phoneCodes[95].zeroHack = false;
            phoneCodes[95].exceptions_max = 0;
            phoneCodes[95].exceptions_min = 0;

            phoneCodes[94] = new Country("Namibia", 264);
            phoneCodes[94].cityCodeLength = 2;
            phoneCodes[94].zeroHack = false;
            phoneCodes[94].exceptions = new int[] { 811,812,813 };
            phoneCodes[94].exceptions_max = 3;
            phoneCodes[94].exceptions_min = 3;

            phoneCodes[93] = new Country("Zimbabwe", 263);
            phoneCodes[93].cityCodeLength = 2;
            phoneCodes[93].zeroHack = false;
            phoneCodes[93].exceptions = new int[] { 9,4,637,718 };
            phoneCodes[93].exceptions_max = 3;
            phoneCodes[93].exceptions_min = 1;

            phoneCodes[92] = new Country("ReunionIslands", 262);
            phoneCodes[92].cityCodeLength = 0;
            phoneCodes[92].zeroHack = false;
            phoneCodes[92].exceptions_max = 0;
            phoneCodes[92].exceptions_min = 0;

            phoneCodes[91] = new Country("Madagascar", 261);
            phoneCodes[91].cityCodeLength = 3;
            phoneCodes[91].zeroHack = false;
            phoneCodes[91].exceptions_max = 0;
            phoneCodes[91].exceptions_min = 0;

            phoneCodes[90] = new Country("Zambia", 260);
            phoneCodes[90].cityCodeLength = 1;
            phoneCodes[90].zeroHack = false;
            phoneCodes[90].exceptions = new int[] { 26 };
            phoneCodes[90].exceptions_max = 2;
            phoneCodes[90].exceptions_min = 2;

            phoneCodes[89] = new Country("Zanzibar", 259);
            phoneCodes[89].cityCodeLength = 0;
            phoneCodes[89].zeroHack = false;
            phoneCodes[89].exceptions_max = 0;
            phoneCodes[89].exceptions_min = 0;

            phoneCodes[88] = new Country("Mozambique", 258);
            phoneCodes[88].cityCodeLength = 0;
            phoneCodes[88].zeroHack = false;
            phoneCodes[88].exceptions_max = 0;
            phoneCodes[88].exceptions_min = 0;

            phoneCodes[87] = new Country("Burundi", 257);
            phoneCodes[87].cityCodeLength = 2;
            phoneCodes[87].zeroHack = false;
            phoneCodes[87].exceptions = new int[] { 2 };
            phoneCodes[87].exceptions_max = 1;
            phoneCodes[87].exceptions_min = 1;

            phoneCodes[86] = new Country("Uganda", 256);
            phoneCodes[86].cityCodeLength = 2;
            phoneCodes[86].zeroHack = false;
            phoneCodes[86].exceptions = new int[] { 481,485,493 };
            phoneCodes[86].exceptions_max = 3;
            phoneCodes[86].exceptions_min = 3;

            phoneCodes[85] = new Country("Tanzania", 255);
            phoneCodes[85].cityCodeLength = 2;
            phoneCodes[85].zeroHack = false;
            phoneCodes[85].exceptions_max = 0;
            phoneCodes[85].exceptions_min = 0;

            phoneCodes[84] = new Country("Kenya", 254);
            phoneCodes[84].cityCodeLength = 3;
            phoneCodes[84].zeroHack = false;
            phoneCodes[84].exceptions = new int[] { 11,2,37 };
            phoneCodes[84].exceptions_max = 2;
            phoneCodes[84].exceptions_min = 1;

            phoneCodes[83] = new Country("Djibouti", 253);
            phoneCodes[83].cityCodeLength = 0;
            phoneCodes[83].zeroHack = false;
            phoneCodes[83].exceptions_max = 0;
            phoneCodes[83].exceptions_min = 0;

            phoneCodes[82] = new Country("Somalia", 252);
            phoneCodes[82].cityCodeLength = 1;
            phoneCodes[82].zeroHack = false;
            phoneCodes[82].exceptions_max = 0;
            phoneCodes[82].exceptions_min = 0;

            phoneCodes[81] = new Country("Ethiopia", 251);
            phoneCodes[81].cityCodeLength = 1;
            phoneCodes[81].zeroHack = false;
            phoneCodes[81].exceptions_max = 0;
            phoneCodes[81].exceptions_min = 0;

            phoneCodes[80] = new Country("RwandeseRepublic", 250);
            phoneCodes[80].cityCodeLength = 0;
            phoneCodes[80].zeroHack = false;
            phoneCodes[80].exceptions_max = 0;
            phoneCodes[80].exceptions_min = 0;

            phoneCodes[79] = new Country("Sudan", 249);
            phoneCodes[79].cityCodeLength = 3;
            phoneCodes[79].zeroHack = false;
            phoneCodes[79].exceptions = new int[] { 21,51,41,31,61,11 };
            phoneCodes[79].exceptions_max = 2;
            phoneCodes[79].exceptions_min = 2;

            phoneCodes[78] = new Country("Seychelles", 248);
            phoneCodes[78].cityCodeLength = 0;
            phoneCodes[78].zeroHack = false;
            phoneCodes[78].exceptions_max = 0;
            phoneCodes[78].exceptions_min = 0;

            phoneCodes[77] = new Country("Ascension", 247);
            phoneCodes[77].cityCodeLength = 0;
            phoneCodes[77].zeroHack = false;
            phoneCodes[77].exceptions_max = 0;
            phoneCodes[77].exceptions_min = 0;

            phoneCodes[76] = new Country("DiegoGarcia", 246);
            phoneCodes[76].cityCodeLength = 0;
            phoneCodes[76].zeroHack = false;
            phoneCodes[76].exceptions_max = 0;
            phoneCodes[76].exceptions_min = 0;

            phoneCodes[75] = new Country("Guinea-Bissau", 245);
            phoneCodes[75].cityCodeLength = 0;
            phoneCodes[75].zeroHack = false;
            phoneCodes[75].exceptions_max = 0;
            phoneCodes[75].exceptions_min = 0;

            phoneCodes[74] = new Country("Angola", 244);
            phoneCodes[74].cityCodeLength = 2;
            phoneCodes[74].zeroHack = false;
            phoneCodes[74].exceptions = new int[] { 9 };
            phoneCodes[74].exceptions_max = 1;
            phoneCodes[74].exceptions_min = 1;

            phoneCodes[73] = new Country("DemocraticRepublic(ex.Zaire)", 243);
            phoneCodes[73].cityCodeLength = 2;
            phoneCodes[73].zeroHack = false;
            phoneCodes[73].exceptions = new int[] { 2 };
            phoneCodes[73].exceptions_max = 1;
            phoneCodes[73].exceptions_min = 1;

            phoneCodes[72] = new Country("Congo", 242);
            phoneCodes[72].cityCodeLength = 2;
            phoneCodes[72].zeroHack = false;
            phoneCodes[72].exceptions = new int[] { 1 };
            phoneCodes[72].exceptions_max = 1;
            phoneCodes[72].exceptions_min = 1;

            phoneCodes[71] = new Country("GaboneseRepublic", 241);
            phoneCodes[71].cityCodeLength = 2;
            phoneCodes[71].zeroHack = false;
            phoneCodes[71].exceptions_max = 0;
            phoneCodes[71].exceptions_min = 0;

            phoneCodes[70] = new Country("EquatorialGuinea", 240);
            phoneCodes[70].cityCodeLength = 1;
            phoneCodes[70].zeroHack = false;
            phoneCodes[70].exceptions_max = 0;
            phoneCodes[70].exceptions_min = 0;

            phoneCodes[69] = new Country("SaoTome-e-Principe", 239);
            phoneCodes[69].cityCodeLength = 0;
            phoneCodes[69].zeroHack = false;
            phoneCodes[69].exceptions_max = 0;
            phoneCodes[69].exceptions_min = 0;

            phoneCodes[68] = new Country("CapeVerde", 238);
            phoneCodes[68].cityCodeLength = 0;
            phoneCodes[68].zeroHack = false;
            phoneCodes[68].exceptions_max = 0;
            phoneCodes[68].exceptions_min = 0;

            phoneCodes[67] = new Country("Cameroon", 237);
            phoneCodes[67].cityCodeLength = 0;
            phoneCodes[67].zeroHack = false;
            phoneCodes[67].exceptions_max = 0;
            phoneCodes[67].exceptions_min = 0;

            phoneCodes[66] = new Country("CentralAfricanRepublic", 236);
            phoneCodes[66].cityCodeLength = 0;
            phoneCodes[66].zeroHack = false;
            phoneCodes[66].exceptions_max = 0;
            phoneCodes[66].exceptions_min = 0;

            phoneCodes[65] = new Country("Chad", 235);
            phoneCodes[65].cityCodeLength = 2;
            phoneCodes[65].zeroHack = false;
            phoneCodes[65].exceptions_max = 0;
            phoneCodes[65].exceptions_min = 0;

            phoneCodes[64] = new Country("Nigeria", 234);
            phoneCodes[64].cityCodeLength = 2;
            phoneCodes[64].zeroHack = false;
            phoneCodes[64].exceptions = new int[] { 1,2 };
            phoneCodes[64].exceptions_max = 1;
            phoneCodes[64].exceptions_min = 1;

            phoneCodes[63] = new Country("Ghana", 233);
            phoneCodes[63].cityCodeLength = 2;
            phoneCodes[63].zeroHack = false;
            phoneCodes[63].exceptions_max = 0;
            phoneCodes[63].exceptions_min = 0;

            phoneCodes[62] = new Country("SierraLeone", 232);
            phoneCodes[62].cityCodeLength = 1;
            phoneCodes[62].zeroHack = false;
            phoneCodes[62].exceptions_max = 0;
            phoneCodes[62].exceptions_min = 0;

            phoneCodes[61] = new Country("Liberia", 231);
            phoneCodes[61].cityCodeLength = 0;
            phoneCodes[61].zeroHack = false;
            phoneCodes[61].exceptions_max = 0;
            phoneCodes[61].exceptions_min = 0;

            phoneCodes[60] = new Country("Mauritius", 230);
            phoneCodes[60].cityCodeLength = 3;
            phoneCodes[60].zeroHack = false;
            phoneCodes[60].exceptions_max = 0;
            phoneCodes[60].exceptions_min = 0;

            phoneCodes[59] = new Country("Benin", 229);
            phoneCodes[59].cityCodeLength = 0;
            phoneCodes[59].zeroHack = false;
            phoneCodes[59].exceptions_max = 0;
            phoneCodes[59].exceptions_min = 0;

            phoneCodes[58] = new Country("Togolese", 228);
            phoneCodes[58].cityCodeLength = 0;
            phoneCodes[58].zeroHack = false;
            phoneCodes[58].exceptions_max = 0;
            phoneCodes[58].exceptions_min = 0;

            phoneCodes[57] = new Country("Niger", 227);
            phoneCodes[57].cityCodeLength = 0;
            phoneCodes[57].zeroHack = false;
            phoneCodes[57].exceptions_max = 0;
            phoneCodes[57].exceptions_min = 0;

            phoneCodes[56] = new Country("BurkinaFaso", 226);
            phoneCodes[56].cityCodeLength = 2;
            phoneCodes[56].zeroHack = false;
            phoneCodes[56].exceptions_max = 0;
            phoneCodes[56].exceptions_min = 0;

            phoneCodes[55] = new Country("Ivory", 225);
            phoneCodes[55].cityCodeLength = 0;
            phoneCodes[55].zeroHack = false;
            phoneCodes[55].exceptions_max = 0;
            phoneCodes[55].exceptions_min = 0;

            phoneCodes[54] = new Country("Guinea", 224);
            phoneCodes[54].cityCodeLength = 2;
            phoneCodes[54].zeroHack = false;
            phoneCodes[54].exceptions = new int[] { 4 };
            phoneCodes[54].exceptions_max = 1;
            phoneCodes[54].exceptions_min = 1;

            phoneCodes[53] = new Country("Mali", 223);
            phoneCodes[53].cityCodeLength = 2;
            phoneCodes[53].zeroHack = false;
            phoneCodes[53].exceptions_max = 0;
            phoneCodes[53].exceptions_min = 0;

            phoneCodes[52] = new Country("Mauritania", 222);
            phoneCodes[52].cityCodeLength = 1;
            phoneCodes[52].zeroHack = false;
            phoneCodes[52].exceptions_max = 0;
            phoneCodes[52].exceptions_min = 0;

            phoneCodes[51] = new Country("Senegal", 221);
            phoneCodes[51].cityCodeLength = 3;
            phoneCodes[51].zeroHack = false;
            phoneCodes[51].exceptions = new int[] { 63,64,67,68,82,83,84,85,86,87,90,93,94,95,96,97,98,99 };
            phoneCodes[51].exceptions_max = 2;
            phoneCodes[51].exceptions_min = 2;

            phoneCodes[50] = new Country("Gambia", 220);
            phoneCodes[50].cityCodeLength = 0;
            phoneCodes[50].zeroHack = false;
            phoneCodes[50].exceptions_max = 0;
            phoneCodes[50].exceptions_min = 0;

            phoneCodes[49] = new Country("Libya", 218);
            phoneCodes[49].cityCodeLength = 2;
            phoneCodes[49].zeroHack = false;
            phoneCodes[49].exceptions_max = 0;
            phoneCodes[49].exceptions_min = 0;

            phoneCodes[48] = new Country("Tunisia", 216);
            phoneCodes[48].cityCodeLength = 1;
            phoneCodes[48].zeroHack = false;
            phoneCodes[48].exceptions_max = 0;
            phoneCodes[48].exceptions_min = 0;

            phoneCodes[47] = new Country("Morocco", 212);
            phoneCodes[47].cityCodeLength = 1;
            phoneCodes[47].zeroHack = false;
            phoneCodes[47].exceptions_max = 0;
            phoneCodes[47].exceptions_min = 0;

            phoneCodes[46] = new Country("Iran", 98);
            phoneCodes[46].cityCodeLength = 3;
            phoneCodes[46].zeroHack = false;
            phoneCodes[46].exceptions = new int[] { 61,11,31,51,41,21,81,71 };
            phoneCodes[46].exceptions_max = 2;
            phoneCodes[46].exceptions_min = 2;

            phoneCodes[45] = new Country("Myanmar", 95);
            phoneCodes[45].cityCodeLength = 2;
            phoneCodes[45].zeroHack = false;
            phoneCodes[45].exceptions = new int[] { 1,2 };
            phoneCodes[45].exceptions_max = 1;
            phoneCodes[45].exceptions_min = 1;

            phoneCodes[44] = new Country("SriLanka", 94);
            phoneCodes[44].cityCodeLength = 2;
            phoneCodes[44].zeroHack = false;
            phoneCodes[44].exceptions = new int[] { 1,9,8 };
            phoneCodes[44].exceptions_max = 1;
            phoneCodes[44].exceptions_min = 1;

            phoneCodes[43] = new Country("Afganistan", 93);
            phoneCodes[43].cityCodeLength = 1;
            phoneCodes[43].zeroHack = false;
            phoneCodes[43].exceptions_max = 0;
            phoneCodes[43].exceptions_min = 0;

            phoneCodes[42] = new Country("Pakistan", 92);
            phoneCodes[42].cityCodeLength = 3;
            phoneCodes[42].zeroHack = false;
            phoneCodes[42].exceptions = new int[] { 8288,4521,4331,51,21,42,61,91,71 };
            phoneCodes[42].exceptions_max = 4;
            phoneCodes[42].exceptions_min = 2;

            phoneCodes[41] = new Country("India", 91);
            phoneCodes[41].cityCodeLength = 3;
            phoneCodes[41].zeroHack = false;
            phoneCodes[41].exceptions = new int[] { 11,22,33,44,40 };
            phoneCodes[41].exceptions_max = 2;
            phoneCodes[41].exceptions_min = 2;

            phoneCodes[40] = new Country("Turkey", 90);
            phoneCodes[40].cityCodeLength = 3;
            phoneCodes[40].zeroHack = false;
            phoneCodes[40].exceptions_max = 0;
            phoneCodes[40].exceptions_min = 0;

            phoneCodes[39] = new Country("China", 86);
            phoneCodes[39].cityCodeLength = 3;
            phoneCodes[39].zeroHack = false;
            phoneCodes[39].exceptions = new int[] { 20,29,10,22,27,28,21,24,1350,1351,1352,1353,1354,1355,1356,1357,1358,1359,1360,1361,1362,1363,1364,1365,1366,1367,1368,1369,1370,1371,1372,1373,1374,1375,1376,1377,1378,1379,1380,1381,1382,1383,1384,1385,1386,1387,1388,1389,1390 };
            phoneCodes[39].exceptions_max = 4;
            phoneCodes[39].exceptions_min = 2;

            phoneCodes[38] = new Country("Vietnam", 84);
            phoneCodes[38].cityCodeLength = 2;
            phoneCodes[38].zeroHack = false;
            phoneCodes[38].exceptions = new int[] { 511,350,4,8 };
            phoneCodes[38].exceptions_max = 3;
            phoneCodes[38].exceptions_min = 1;

            phoneCodes[37] = new Country("Korea,Republic", 82);
            phoneCodes[37].cityCodeLength = 3;
            phoneCodes[37].zeroHack = false;
            phoneCodes[37].exceptions = new int[] { 32,62,51,2,53,42,64,16,17,18,19 };
            phoneCodes[37].exceptions_max = 2;
            phoneCodes[37].exceptions_min = 1;

            phoneCodes[36] = new Country("Japan", 81);
            phoneCodes[36].cityCodeLength = 3;
            phoneCodes[36].zeroHack = false;
            phoneCodes[36].exceptions = new int[] { 78,45,44,75,93,52,25,6,11,22,54,3,48,92,53,82,1070,3070,4070 };
            phoneCodes[36].exceptions_max = 4;
            phoneCodes[36].exceptions_min = 1;

            phoneCodes[35] = new Country("Thailand", 66);
            phoneCodes[35].cityCodeLength = 2;
            phoneCodes[35].zeroHack = false;
            phoneCodes[35].exceptions = new int[] { 2 };
            phoneCodes[35].exceptions_max = 1;
            phoneCodes[35].exceptions_min = 1;

            phoneCodes[34] = new Country("Singapore", 65);
            phoneCodes[34].cityCodeLength = 0;
            phoneCodes[34].zeroHack = false;
            phoneCodes[34].exceptions_max = 0;
            phoneCodes[34].exceptions_min = 0;

            phoneCodes[33] = new Country("NewZealand", 64);
            phoneCodes[33].cityCodeLength = 1;
            phoneCodes[33].zeroHack = false;
            phoneCodes[33].exceptions = new int[] { 20,21,25,26,29 };
            phoneCodes[33].exceptions_max = 2;
            phoneCodes[33].exceptions_min = 2;

            phoneCodes[32] = new Country("Philippines", 63);
            phoneCodes[32].cityCodeLength = 2;
            phoneCodes[32].zeroHack = false;
            phoneCodes[32].exceptions = new int[] { 455,4661,2150,2155,452,2 };
            phoneCodes[32].exceptions_max = 4;
            phoneCodes[32].exceptions_min = 1;

            phoneCodes[31] = new Country("Indonesia", 62);
            phoneCodes[31].cityCodeLength = 3;
            phoneCodes[31].zeroHack = false;
            phoneCodes[31].exceptions = new int[] { 22,61,21,33,36,39,35,34,24,31,81,82 };
            phoneCodes[31].exceptions_max = 2;
            phoneCodes[31].exceptions_min = 2;

            phoneCodes[30] = new Country("Australia", 61);
            phoneCodes[30].cityCodeLength = 1;
            phoneCodes[30].zeroHack = false;
            phoneCodes[30].exceptions = new int[] { 14,15,16,17,18,19,41 };
            phoneCodes[30].exceptions_max = 2;
            phoneCodes[30].exceptions_min = 2;

            phoneCodes[29] = new Country("Malaysia", 60);
            phoneCodes[29].cityCodeLength = 1;
            phoneCodes[29].zeroHack = false;
            phoneCodes[29].exceptions = new int[] { 86,88,82,85,10,18 };
            phoneCodes[29].exceptions_max = 2;
            phoneCodes[29].exceptions_min = 2;

            phoneCodes[28] = new Country("Venezuela", 58);
            phoneCodes[28].cityCodeLength = 2;
            phoneCodes[28].zeroHack = false;
            phoneCodes[28].exceptions = new int[] { 2 };
            phoneCodes[28].exceptions_max = 1;
            phoneCodes[28].exceptions_min = 1;

            phoneCodes[27] = new Country("Colombia", 57);
            phoneCodes[27].cityCodeLength = 2;
            phoneCodes[27].zeroHack = false;
            phoneCodes[27].exceptions = new int[] { 1,5,7,2,4,816 };
            phoneCodes[27].exceptions_max = 3;
            phoneCodes[27].exceptions_min = 1;

            phoneCodes[26] = new Country("Chile", 56);
            phoneCodes[26].cityCodeLength = 2;
            phoneCodes[26].zeroHack = false;
            phoneCodes[26].exceptions = new int[] { 2 };
            phoneCodes[26].exceptions_max = 1;
            phoneCodes[26].exceptions_min = 1;

            phoneCodes[25] = new Country("Brazil", 55);
            phoneCodes[25].cityCodeLength = 2;
            phoneCodes[25].zeroHack = false;
            phoneCodes[25].exceptions = new int[] { 243,187,485,186,246,533,173,142,473,125,495,138,482,424,192,247,484,144,442,532,242,245,194,182,123,474,486 };
            phoneCodes[25].exceptions_max = 3;
            phoneCodes[25].exceptions_min = 3;

            phoneCodes[24] = new Country("Argentina", 54);
            phoneCodes[24].cityCodeLength = 4;
            phoneCodes[24].zeroHack = false;
            phoneCodes[24].exceptions = new int[] { 291,11,297,223,261,299,358,341,387,381,342 };
            phoneCodes[24].exceptions_max = 3;
            phoneCodes[24].exceptions_min = 2;

            phoneCodes[23] = new Country("Cuba", 53);
            phoneCodes[23].cityCodeLength = 2;
            phoneCodes[23].zeroHack = false;
            phoneCodes[23].exceptions = new int[] { 680,5,8,7,686,322,419,433,335,422,692,516,226 };
            phoneCodes[23].exceptions_max = 3;
            phoneCodes[23].exceptions_min = 1;

            phoneCodes[22] = new Country("Mexico", 52);
            phoneCodes[22].cityCodeLength = 2;
            phoneCodes[22].zeroHack = false;
            phoneCodes[22].exceptions = new int[] { 473,181,981,112,331,5,8,951,771,492,131,246,961,459,747 };
            phoneCodes[22].exceptions_max = 3;
            phoneCodes[22].exceptions_min = 1;

            phoneCodes[21] = new Country("Peru", 51);
            phoneCodes[21].cityCodeLength = 2;
            phoneCodes[21].zeroHack = false;
            phoneCodes[21].exceptions = new int[] { 1,194,198,193,190,1877,1878,1879 };
            phoneCodes[21].exceptions_max = 4;
            phoneCodes[21].exceptions_min = 1;

            phoneCodes[20] = new Country("Germany", 49);
            phoneCodes[20].cityCodeLength = 4;
            phoneCodes[20].zeroHack = false;
            phoneCodes[20].exceptions = new int[] { 651,241,711,981,821,30,971,671,921,951,521,228,234,531,421,471,961,281,611,365,40,511,209,551,641,34202,340,351,991,771,906,231,203,211,271,911,212,841,631,721,561,221,831,261,341,871,491,591,451,621,391,291,89,395,5021,571,441,781,208,541,69,331,851,34901,381,33638,751,681,861,581,731,335,741,461,761,661,345,481,34203,375,385,34204,361,201,33608,161,171,172,173,177,178,179 };
            phoneCodes[20].exceptions_max = 5;
            phoneCodes[20].exceptions_min = 2;

            phoneCodes[19] = new Country("Poland", 48);
            phoneCodes[19].cityCodeLength = 2;
            phoneCodes[19].zeroHack = false;
            phoneCodes[19].exceptions = new int[] { 192,795,862,131,135,836,115,604,641,417,601,602,603,605,606,501,885 };
            phoneCodes[19].exceptions_max = 3;
            phoneCodes[19].exceptions_min = 3;

            phoneCodes[18] = new Country("Norway", 47);
            phoneCodes[18].cityCodeLength = 1;
            phoneCodes[18].zeroHack = false;
            phoneCodes[18].exceptions = new int[] { 43,83,62 };
            phoneCodes[18].exceptions_max = 2;
            phoneCodes[18].exceptions_min = 2;

            phoneCodes[17] = new Country("Sweden", 46);
            phoneCodes[17].cityCodeLength = 3;
            phoneCodes[17].zeroHack = false;
            phoneCodes[17].exceptions = new int[] { 33,21,31,54,44,13,46,40,19,63,8,60,90,18,42 };
            phoneCodes[17].exceptions_max = 2;
            phoneCodes[17].exceptions_min = 1;

            phoneCodes[16] = new Country("Denmark", 45);
            phoneCodes[16].cityCodeLength = 2;
            phoneCodes[16].zeroHack = false;
            phoneCodes[16].exceptions = new int[] { 9,6,7,8,1,5,3,4,251,243,249,276,70777,80827,90107,90207,90417,90517 };
            phoneCodes[16].exceptions_max = 5;
            phoneCodes[16].exceptions_min = 1;

            phoneCodes[15] = new Country("UnitedKingdom", 44);
            phoneCodes[15].cityCodeLength = 4;
            phoneCodes[15].zeroHack = false;
            phoneCodes[15].exceptions = new int[] { 21,91,44,41,51,61,31,121,117,141,185674,18383,15932,116,151,113,171,181,161,207,208,158681,115,191,177681,114,131,18645 };
            phoneCodes[15].exceptions_max = 6;
            phoneCodes[15].exceptions_min = 2;

            phoneCodes[14] = new Country("Austria", 43);
            phoneCodes[14].cityCodeLength = 4;
            phoneCodes[14].zeroHack = false;
            phoneCodes[14].exceptions = new int[] { 1,662,732,316,512,463 };
            phoneCodes[14].exceptions_max = 3;
            phoneCodes[14].exceptions_min = 1;

            phoneCodes[13] = new Country("Romania", 40);
            phoneCodes[13].cityCodeLength = 2;
            phoneCodes[13].zeroHack = false;
            phoneCodes[13].exceptions = new int[] { 1,941,916,981 };
            phoneCodes[13].exceptions_max = 3;
            phoneCodes[13].exceptions_min = 1;

            phoneCodes[12] = new Country("Italy", 39);
            phoneCodes[12].cityCodeLength = 3;
            phoneCodes[12].zeroHack = true;
            phoneCodes[12].exceptions = new int[] { 71,80,35,51,30,15,41,45,33,70,74,95,31,90,2,59,39,81,49,75,85,50,6,19,79,55,330,333,335,339,360,347,348,349 };
            phoneCodes[12].exceptions_min = 1;
            phoneCodes[12].exceptions_max = 3;

            phoneCodes[11] = new Country("Hungary", 36);
            phoneCodes[11].cityCodeLength = 2;
            phoneCodes[11].zeroHack = false;
            phoneCodes[11].exceptions = new int[] { 1 };
            phoneCodes[11].exceptions_max = 1;
            phoneCodes[11].exceptions_min = 1;

            phoneCodes[10] = new Country("Spain", 34);
            phoneCodes[10].cityCodeLength = 3;
            phoneCodes[10].zeroHack = false;
            phoneCodes[10].exceptions = new int[] { 4,6,3,5,96,93,94,91,95,98 };
            phoneCodes[10].exceptions_max = 2;
            phoneCodes[10].exceptions_min = 1;

            phoneCodes[9] = new Country("France", 33);
            phoneCodes[9].cityCodeLength = 3;
            phoneCodes[9].zeroHack = false;
            phoneCodes[9].exceptions = new int[] { 32, 14, 38, 59, 55, 88, 96, 28, 97, 42, 61 };
            phoneCodes[9].exceptions_max = 2;
            phoneCodes[9].exceptions_min = 2;

            phoneCodes[8] = new Country("Belgium", 32);
            phoneCodes[8].cityCodeLength = 2;
            phoneCodes[8].zeroHack = false;
            phoneCodes[8].exceptions = new int[] { 2, 9, 7, 3, 476, 477, 478, 495, 496 };
            phoneCodes[8].exceptions_max = 3;
            phoneCodes[8].exceptions_min = 1;

            phoneCodes[7] = new Country("Netherlands", 31);
            phoneCodes[7].cityCodeLength = 3;
            phoneCodes[7].zeroHack = false;
            phoneCodes[7].exceptions = new int[] { 4160, 2268, 2208, 5253, 78, 72, 33, 20, 55, 26, 35, 74, 76, 40, 77, 10, 70, 75, 73, 38, 50, 15, 30, 58, 43, 24, 46, 13, 23, 45, 53, 61, 62, 65 };
            phoneCodes[7].exceptions_max = 4;
            phoneCodes[7].exceptions_min = 2;

            phoneCodes[6] = new Country("Greece", 30);
            phoneCodes[6].cityCodeLength = 3;
            phoneCodes[6].zeroHack = false;
            phoneCodes[6].exceptions = new int[] { 1, 41, 81, 51, 61, 31, 71, 93, 94, 95, 97556, 97557 };
            phoneCodes[6].exceptions_max = 5;
            phoneCodes[6].exceptions_min = 1;

            phoneCodes[5] = new Country("SouthAfrica", 27);
            phoneCodes[5].cityCodeLength = 2;
            phoneCodes[5].zeroHack = false;
            phoneCodes[5].exceptions = new int[] { 149, 1782, 1773, 444 };
            phoneCodes[5].exceptions_max = 4;
            phoneCodes[5].exceptions_min = 3;

            phoneCodes[4] = new Country("Algeria", 21);
            phoneCodes[4].cityCodeLength = 1;
            phoneCodes[4].zeroHack = false;
            phoneCodes[4].exceptions_max = 0;
            phoneCodes[4].exceptions_min = 0;

            phoneCodes[3] = new Country("Egypt", 20);
            phoneCodes[3].cityCodeLength = 2;
            phoneCodes[3].zeroHack = false;
            phoneCodes[3].exceptions = new int[] { 2, 3, 1221 };
            phoneCodes[3].exceptions_max = 0;
            phoneCodes[3].exceptions_min = 0;

            phoneCodes[2] = new Country("Russia", 8);
            phoneCodes[2].cityCodeLength = 5;
            phoneCodes[2].zeroHack = false;
            phoneCodes[2].exceptions = new int[] { 4162, 416332, 8512, 851111, 4722, 4725, 391379, 8442, 4732, 4152, 4154451, 4154459, 4154455, 41544513, 8142, 8332, 8612, 8622, 3525, 812, 8342, 8152, 3812, 4862, 3422, 342633, 8112, 9142, 8452, 3432, 3434, 3435, 4812, 3919, 8432, 8439, 3822, 4872, 3412, 3511, 3512, 3022, 4112, 4852, 4855, 3852, 3854, 8182, 818, 90, 3472, 4741, 4764, 4832, 4922, 8172, 8202, 8722, 4932, 493, 3952, 3951, 3953, 411533, 4842, 3842, 3843, 8212, 4942, 3912, 4712, 4742, 8362, 495, 499, 4966, 4964, 4967, 498, 8312, 8313, 3832, 383612, 3532, 8412, 4232, 423370, 423630, 8632, 8642, 8482, 4242, 8672, 8652, 4752, 4822, 482502, 4826300, 3452, 8422, 4212, 3466, 3462, 8712, 8352, 997, 901, 902, 903, 904, 905, 906, 908, 909, 910, 911, 912, 913, 914, 915, 916, 917, 918, 919, 920, 921, 922, 923, 924, 925, 926, 927, 928, 929, 930, 931, 932, 933, 934, 936, 937, 938, 950, 951, 952, 953, 960, 961, 962, 963, 964, 965, 967, 968, 980, 981, 982, 983, 984, 985, 987, 988, 989 };
            phoneCodes[2].exceptions_max = 8;
            phoneCodes[2].exceptions_min = 2;

            phoneCodes[1] = new Country("Russia", 7);
            phoneCodes[1].cityCodeLength = 5;
            phoneCodes[1].zeroHack = false;
            phoneCodes[1].exceptions = new int[] { 4162, 416332, 8512, 851111, 4722, 4725, 391379, 8442, 4732, 4152, 4154451, 4154459, 4154455, 41544513, 8142, 8332, 8612, 8622, 3525, 812, 8342, 8152, 3812, 4862, 3422, 342633, 8112, 9142, 8452, 3432, 3434, 3435, 4812, 3919, 8432, 8439, 3822, 4872, 3412, 3511, 3512, 3022, 4112, 4852, 4855, 3852, 3854, 8182, 818, 90, 3472, 4741, 4764, 4832, 4922, 8172, 8202, 8722, 4932, 493, 3952, 3951, 3953, 411533, 4842, 3842, 3843, 8212, 4942, 3912, 4712, 4742, 8362, 495, 499, 4966, 4964, 4967, 498, 8312, 8313, 3832, 383612, 3532, 8412, 4232, 423370, 423630, 8632, 8642, 8482, 4242, 8672, 8652, 4752, 4822, 482502, 4826300, 3452, 8422, 4212, 3466, 3462, 8712, 8352, 997, 901, 902, 903, 904, 905, 906, 908, 909, 910, 911, 912, 913, 914, 915, 916, 917, 918, 919, 920, 921, 922, 923, 924, 925, 926, 927, 928, 929, 930, 931, 932, 933, 934, 936, 937, 938, 950, 951, 952, 953, 960, 961, 962, 963, 964, 965, 967, 968, 980, 981, 982, 983, 984, 985, 987, 988, 989 };
            phoneCodes[1].exceptions_max = 8;
            phoneCodes[1].exceptions_min = 2;

            phoneCodes[0] = new Country("USA", 1);
            phoneCodes[0].cityCodeLength = 5;
            phoneCodes[0].zeroHack = false;
            phoneCodes[0].exceptions_max = 0;
            phoneCodes[0].exceptions_min = 0;

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
                for (int i = 0; i < phoneCodes.Count(); i++)
                {   
                    int countryCode = phoneCodes[i].Code;
                    int codeLen = countryCode.ToString().Length;
                    if (phone.Substring(0, codeLen) == phoneCodes[i].Code.ToString())
                    {
                        // как только страна обнаружена, урезаем телефон до уровня кода города
                        phone = phone.Substring(codeLen, phone.Length-codeLen);
                        bool zero=false;
                        
                        // проверяем на наличие нулей в коде города
                        if (phoneCodes[i].zeroHack && phone[0].Equals("0"))
                        {
                            zero=true;
                            phone = phone.Substring(1, phone.Length-1);
                        }

                        string cityCode=null;

                        // сначала сравниваем с городами-исключениями
                        if (phoneCodes[i].exceptions_max !=0)
                        for (int cityCodeLen = phoneCodes[i].exceptions_max; cityCodeLen >= phoneCodes[i].exceptions_min; cityCodeLen--)
                        {
                            if (phone.Length > cityCodeLen)
                            {
                                if (phoneCodes[i].exceptions.Contains(Convert.ToInt32(phone.Substring(0, cityCodeLen))))
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
                            cityCode = phone.Substring(0, phoneCodes[i].cityCodeLength);
                            phone = phone.Substring(phoneCodes[i].cityCodeLength, phone.Length-phoneCodes[i].cityCodeLength);
                        }

                        // возвращаем результат
                        return (plus ? "+" : "") + " CountryCode: " + countryCode + "( City: " + cityCode + ")" +phone;
                    }
                }
            }

            return (plus ? "+" : "") + phone;
        }
    }
}
