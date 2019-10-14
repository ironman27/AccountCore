using System;
using System.Collections.Generic;
using System.Text;

namespace AccountCore.Contract.Models
{
    public class GridData<T>
    {
        public GridData()
        {
            Data = new List<T>();
        }

        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IList<T> Data { get; set; }
    }
}
