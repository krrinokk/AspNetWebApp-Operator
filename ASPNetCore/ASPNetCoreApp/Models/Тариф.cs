using Microsoft.Extensions.Hosting;
using ASPNetCoreApp.Models;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreApp.Models
{
    public class Тариф
    {
        public decimal? Минута_межгород_стоимость { get; set; }
        public decimal Минута_международная_стоимость { get; set; }
        public string Название_тарифа { get; set; }
        public decimal Стоимость_перехода { get; set; }
      
        [Key]
        public int Код_тарифа { get; set; }
        public int? Год_начала { get; set; }
        public Тариф()
        {
            Dogovor = new HashSet<Dogovor>();
        }
        public virtual ICollection<Dogovor> Dogovor { get; set; }
    }
}
