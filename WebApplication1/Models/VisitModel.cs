using System;

namespace WebApplication1.Models
{
    public class VisitModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public DateTime timein { get; set; }
        public DateTime timeout { get; set; }
    }
}