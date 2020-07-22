namespace GreenVsRed.Core
{
    using System.Linq;
    using Models;
    using Interfaces;
    using IO.Interfaces;

    public class Engine : IRunnable
    {
        // Application reader and writer 
        private readonly IReader reader;
        private readonly IWriter writer;
        
        // 
        private int numberOfInputLines;

        private int currentGeneration;
        private Grid grid;

        private int cellX;
        private int cellY;
        private int generationRotations;
        private int cellGreenCounter = 0;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            // Creating the grid
            this.CreateGrid();
            // Filling the grid
            this.FillGrid();
            // Getting cell coordinates
            this.GetCellCoordinatesAndGenerationRotations();

            while(true)
            {
                // Checking if the cell is green
                if(this.grid.CheckIfCellIsGreen(this.cellX, this.cellY)) this.cellGreenCounter++;

                // End the program 
                if(this.currentGeneration == this.generationRotations) break;

                // Preparing cells for the next generation
                this.grid.Prepare();

                // Updating the grid with the new generation
                this.grid.Update();

                // Increase the the generation
                this.currentGeneration++;
            }

            // Print the result
            this.writer.WriteLine($"The cell at {this.cellX}-{this.cellY} has been green for {this.cellGreenCounter}");
        }

        private void CreateGrid()
        {
            int[] parameters = this.reader.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int width = parameters[0];
            int height = parameters[1];

            this.numberOfInputLines = height;
            this.grid = new Grid(height, width);
        }

        private void FillGrid()
        {
            for(int i = 0; i < this.numberOfInputLines; i++)
            {
                int[] rowValues = this.reader.ReadLine().Select(d => int.Parse(new string(d, 1))).ToArray();
                this.grid.FillGridRow(i, rowValues);
            }
        }

        private void GetCellCoordinatesAndGenerationRotations()
        {
            int[] parameters = this.reader.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int x = parameters[0];
            int y = parameters[1];
            int generationRotations = parameters[2];

            this.cellX = x;
            this.cellY = y;
            this.generationRotations = generationRotations;
        }
    }
}