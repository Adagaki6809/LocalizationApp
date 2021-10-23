using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationApp.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Key { get; set; }     // ключ
        public string Value { get; set; }   // значение
        public Culture Culture { get; set; }
    }
}
