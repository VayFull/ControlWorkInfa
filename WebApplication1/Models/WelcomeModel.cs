using System;

namespace WebApplication1.Models
{
    public class WelcomeModel //модель посетителей
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public bool isinbuilding { get; set; }
        public string profession { get; set; }
        public DateTime lastin { get; set; }
        public DateTime lastout { get; set; }
    }
    /*
     * create table welcomers(id int, cost int); команда для инициализации таблицы в datagrip
     */
}