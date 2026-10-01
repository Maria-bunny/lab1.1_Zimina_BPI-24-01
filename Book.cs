using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_1_Zimina_BPI_24_01
{
    public class Book
    {
        string Name { get; set; }
        int PagesCnt { get; set; }
        int Cost { get; set; }

        public Book(string name, int pagesCnt, int cost)
        {

            Name = name;
            PagesCnt = pagesCnt;
            Cost = cost;
        }

        public void editData(string name, int pagesCnt, int cost)
        {
            this.Name = name;
            this.PagesCnt = pagesCnt;
            this.Cost = cost;
        }

        public (int, int) calcluateMediumCost()
        {
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