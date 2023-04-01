using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using ASPNetCoreApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreApp.Models
{
    public class Клиент
    {
        public Клиент()
        {
            Dogovor = new HashSet<Dogovor>();
        }
     [Key]
        public int Номер_клиента { get; set; }

        public string? ФИО { get; set; }

        public decimal? Баланс { get; set; }

        public virtual ICollection<Dogovor>? Dogovor { get; set; }
    }
}
