﻿HeaderTooltips
-----------------------------------------------------------------------------------
Shows how you can attach tooltips to column headers.

The sample shows how you can use a custom cell factory to attach tooltips to
cells after they are created.

Here is the implementation:

<code>
    /// <summary>
    /// Class factory that attaches a tooltip to column headers.
    /// </summary>
    class TooltipCellFactory : CellFactory
    {
        public override FrameworkElement CreateCell(C1FlexGrid grid, CellType cellType, CellRange range)
        {
			// allow base class to create the cell
            var cell = base.CreateCell(grid, cellType, range);

			// add tooltip to column headers
            if (cellType == CellType.ColumnHeader)
            {
                var tip = string.Format("This is the tooltip for {0}", 
                    grid.Columns[range.Column].ColumnName);
                cell.ToolTip = tip;
            }

			// return the cell
            return cell;
        }
    }
</code>
