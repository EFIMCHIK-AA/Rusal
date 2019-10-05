using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    public static class SystemArgs
    {
        public static String NameDB; //Название БД
        public static String OwnerDB; //Владелец БД
        public static String PortDB; //Порт БД
        public static String IPDB; //IP БД
        public static String PasswordDB; //Пароль БД

        public static String ConnectString; //Строка подключения к БД

        public static bool StatusConnect; //Статус подключения к БД

        public static List<Position> Positions = new List<Position>(); //Список позиций

        public static List<String> DefectLocProduction = new List<String>(); //Список мест дефектов в производственном процессе
        public static List<String> TypesDefect = new List<String>(); //Типы дефектов (устранимый или брак)
        public static List<String> TypesAlloy = new List<String>(); //Марки сплавов
        public static List<String> ProgressMark = new List<String>(); //Отметка о выполнении
        public static List<String> NumbersTS = new List<String>(); //Номера технических спецификаций
        public static List<String> Brigades = new List<String>(); //Список бригад
        public static List<String> Smeny = new List<String>(); //Список смен
        public static List<String> Descriptions = new List<String>(); //Список описаний дефекта
        public static List<Double> Diameters = new List<Double>(); // Диаметры слитков

        public static void PrintLog(String Message)
        {
            Log Temp = new Log(Message);
            Temp.Print();
        }
    }
}
