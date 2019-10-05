using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal
{
    class Log
    {
        private readonly String _StringData; //Сообщение для записи
        private DateTime _CurrentDate;

        public Log(String StringData)
        {
            if (StringData.Trim() != "")
            {
                _StringData = StringData;
            }

            _CurrentDate = DateTime.Now;

            if (!Directory.Exists($@"{Files.LogPath}\{_CurrentDate.ToShortDateString()}"))
            {
                Directory.CreateDirectory($@"{Files.LogPath}\{_CurrentDate.ToShortDateString()}");
            }

            if (!File.Exists($@"{Files.LogPath}\{_CurrentDate.ToShortDateString()}\{_CurrentDate.ToShortDateString()}.log"))
            {
                using (FileStream fs = File.Create($@"{Files.LogPath}\{_CurrentDate.ToShortDateString()}\{_CurrentDate.ToShortDateString()}.log")) { }
            }
        }

        public Log() : this("Нет информации") { }

        public String StringData
        {
            get
            {
                return _StringData;
            }
        }

        public void Print()
        {
            String TempString = $@"{_CurrentDate.ToString()} : {_StringData}" + Environment.NewLine;

            File.AppendAllText($@"{Files.LogPath}\{_CurrentDate.ToShortDateString()}\{_CurrentDate.ToShortDateString()}.log", TempString);
        }
    }
}
