namespace GreenVsRed.Models
{
    using System;

    public class Grid
    {
        private Cell[,] cells;

        public Grid(int height, int width)
        {
            this.cells = new Cell[height, width];
        }

        public void FillGridRow(int row, int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                this.cells[row, i] = new Cell(values[i]);
            }
        }

        public bool CheckIfCellIsGreen(int width, int height) => this.cells[height, width].Value == 1 ? true : false;

        public void Update()
        {
            for (int row = 0; row < this.cells.GetLength(0); row++)
            {
                for (int col = 0; col < this.cells.GetLength(1); col++)
                {
                    if (this.cells[row, col].ShouldChange)
                    {
                        this.cells[row, col].ChangeValue();
                        this.cells[row, col].ChangeDone();
                    }
                }
            }
        }

        public void Prepare()
        {
            int rowLength = this.cells.GetLength(0);
            int colLength = this.cells.GetLength(1);

            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    int greenCellsNeighbours = 0;

                    ///
                    int rowMinimum = row - 1 < 0 ? row : row - 1;
                    int rowMaximum = row + 1 >= rowLength ? row : row + 1;
                    int colMinimum = col - 1 < 0 ? col : col - 1;
                    int colMaximum = col + 1 >= colLength ? col : col + 1;
                    for (int i = rowMinimum; i <= rowMaximum; i++)
                    {
                        for (int j = colMinimum; j <= colMaximum; j++)
                        {
                            if (i != row || j != col)
                            {
                                if (this.cells[i, j].Value == 1)
                                {
                                    greenCellsNeighbours++;
                                }
                            }
                        }
                    }

                    ///

                    if (this.cells[row, col].Value == 0)
                    {
                        if (greenCellsNeighbours == 3 || greenCellsNeighbours == 6)
                            this.cells[row, col].AskForChange();
                    }
                    else
                    {
                        if (greenCellsNeighbours != 2 && greenCellsNeighbours != 3 && greenCellsNeighbours != 6)
                            this.cells[row, col].AskForChange();
                    }
                }
            }
        }
    }
}