using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    internal static class DataGridHelper
    {
        public static int GetSelectedColumnIndex(DataGrid grid)
        {
            return grid.CurrentCell.Column.DisplayIndex;
        }

        public static int GetSelectedRowIndex(DataGrid grid)
        {
            return grid.Items.IndexOf(grid.CurrentItem);
        }

        public static DataGridCell? GetCellAtMousePosition(object sender, MouseButtonEventArgs e)
        {
            var hit = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
            DependencyObject cell = VisualTreeHelper.GetParent(hit.VisualHit);
            while (cell != null && !(cell is System.Windows.Controls.DataGridCell)) cell = VisualTreeHelper.GetParent(cell);
            System.Windows.Controls.DataGridCell? targetCell = cell as System.Windows.Controls.DataGridCell;
            return targetCell;
        }

        public static List<RowColumnIndex> GetSelectedCellsIndex(DataGrid grid)
        {
            var ret = new List<RowColumnIndex>();

            var cells = grid.SelectedCells;
            foreach ( var cell in cells )
            {
                ret.Add(new(grid.Items.IndexOf(cell.Item), cell.Column.DisplayIndex));
            }

            return ret;
        }

        public class RowColumnIndex(int rowIndex, int columnIndex)
        {
            public int RowIndex { get; } = rowIndex;
            public int ColumnIndex { get; } = columnIndex;
        }
    }
}
