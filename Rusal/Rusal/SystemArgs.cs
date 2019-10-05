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

        public static List<DefectProduction> DefectLocProduction = new List<DefectProduction>(); //Список мест дефектов в производственном процессе
        public static List<TypesDefect> TypesDefect = new List<TypesDefect>(); //Типы дефектов (устранимый или брак)
        public static List<TypesAlloy> TypesAlloy = new List<TypesAlloy>(); //Марки сплавов
        public static List<ProgressMark> ProgressMark = new List<ProgressMark>(); //Отметка о выполнении
        public static List<TSN> TSN = new List<TSN>(); //Номера технических спецификаций
        public static List<ListBrigades> Brigades = new List<ListBrigades>(); //Список бригад
        public static List<ListSmen> Smeny = new List<ListSmen>(); //Список смен
        public static List<DescriptionDefect> Descriptions = new List<DescriptionDefect>(); //Список описаний дефекта
        public static List<DiameterIngot> Diameters = new List<DiameterIngot>(); // Диаметры слитков

        public static void PrintLog(String Message)
        {
            Log Temp = new Log(Message);
            Temp.Print();
        }
    }
}
