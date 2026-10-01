using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._1_Zimina_BPI_24_01
{
    public class Book
    {
        public string Name { get; set; }
        public int PagesCnt { get; set; }
        public int Cost { get; set; }

        public Book(string name, int pagesCnt, int cost)
        {
            Name = name;
            PagesCnt = pagesCnt;
            Cost = cost;
        }

        public void EditData(string name, int pagesCnt, int cost)
        {
            this.Name = name;
            this.PagesCnt = pagesCnt;
            this.Cost = cost;
        }

        public (int, int) CalculateMediumCost()
        {
            if (PagesCnt == 0) return (0, 0); // Защита от деления на ноль

            int mainMediumCost = this.Cost / this.PagesCnt;
            int editMediumCost = this.Cost / this.PagesCnt;

            if (this.Name.ToLower().Contains("программирование"))
            {
                editMediumCost = (this.Cost * 2) / this.PagesCnt;
            }

            return (mainMediumCost, editMediumCost);
        }
    }
}