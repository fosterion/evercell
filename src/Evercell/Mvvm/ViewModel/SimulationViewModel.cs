using Evercell.Core;
using Evercell.Interfaces;
using Evercell.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Data;

namespace Evercell.Mvvm.ViewModel
{
    class SimulationViewModel : ObservableObject, IContext
    {
        public Cell[,] Cells { get; set; }

        public DataView BiCells { get; set; }

        public SimulationViewModel()
        {
            Cells = new Cell[25, 25];

            for (int col = 0; col < 25; col++)
            {
                for (int row = 0; row < 25; row++)
                {
                    var rnd = new Random().Next(0, 1);

                    if (rnd == 0)
                    {
                        Cells[col, row] = new Cell(true);
                    }
                    else
                    {
                        Cells[col, row] = new Cell(false);
                    }
                }
            }

            BiCells = GetBindable2DArray(Cells);
        }

        public static DataView GetBindable2DArray<T>(T[,] array)
        {
            var table = new DataTable();
            for (var i = 0; i < array.GetLength(1); i++)
            {
                table.Columns.Add((i + 1).ToString(), typeof(bool))
                             .ExtendedProperties.Add("idx", i); // Save original column index
            }
            for (var i = 0; i < array.GetLength(0); i++)
            {
                table.Rows.Add(table.NewRow());
            }

            var view = new DataView(table);
            for (var ri = 0; ri < array.GetLength(0); ri++)
            {
                for (var ci = 0; ci < array.GetLength(1); ci++)
                {
                    view[ri][ci] = array[ri, ci];
                }
            }

            // Avoids writing an 'AutogeneratingColumn' handler
            table.ColumnChanged += (s, e) =>
            {
                var ci = (int)e.Column.ExtendedProperties["idx"]; // Retrieve original column index
                var ri = e.Row.Table.Rows.IndexOf(e.Row); // Retrieve row index

                array[ri, ci] = (T)view[ri][ci];
            };

            return view;
        }
    }
}
