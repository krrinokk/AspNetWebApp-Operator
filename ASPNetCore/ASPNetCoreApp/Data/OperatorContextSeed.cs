using ASPNetCoreApp.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;
using ASPNetCoreApp.Models;using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using static System.Net.Mime.MediaTypeNames;

using System.Reflection.Metadata;

namespace ASPNetCoreApp.Data
{
    public static class OperatorContextSeed
    {
        public static async Task SeedAsync(OperatorContext context)
        {
            try
            {


                context.Database.EnsureCreated();
                if (context.Dogovor.Any())
                {
                    return;
                }
                var тарифs = new Тариф[]
                {
new Тариф {    Дата_открытия=DateTime.Today,
               //     Код_тарифа=1,
                     Код_типа_тарифа_FK=1,
                      Минута_межгород_стоимость=1,
                       Минута_международная_стоимость=10,
                        Название_тарифа="Black",
                         Статус="Locked",
                          Стоимость_перехода=100, },

                };
                foreach (Тариф т in тарифs)
                {
                    context.Тариф.Add(т);
                }
                await context.SaveChangesAsync();
                var клиентs = new Клиент[]
              {
new Клиент {     Баланс=1,
                //    Номер_клиента = 1,
                     ФИО = "Иванов И.И." },

              };
                foreach (Клиент к in клиентs)
                {
                    context.Клиент.Add(к);
                }
                await context.SaveChangesAsync();
                var dogovors = new Dogovor[]
                {
new Dogovor {  Дата_расторжения=DateTime.Today,
                      Дата_заключения = DateTime.Today,
                      Код_тарифа_FK=1,
                    //   Номер_договора=1,
                        Номер_клиента_FK=1,
                         Номер_телефона="1111",
                          Серийный_номер_сим_карты="1111"
    }
            };
                foreach (Dogovor d in dogovors)
                {
                    context.Dogovor.Add(d);
                }
                await context.SaveChangesAsync();
            }

            catch

        {
                throw;
        }
        }
    }
}