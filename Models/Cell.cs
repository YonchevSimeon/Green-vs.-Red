namespace GreenVsRed.Models
{
    public class Cell
    {
        private const int ValueZero = 0;
        private const int ValueOne = 1;

        private int value;
        private bool shouldChange;

        public Cell(int value)
        {
            this.value = value;
            this.shouldChange = false;
        }

        public int Value => this.value;
        public bool ShouldChange => this.shouldChange;

        public void ChangeValue() => this.value = this.value == ValueZero ? ValueOne : ValueZero;

        public void AskForChange() => this.shouldChange = true;

        public void ChangeDone() => this.shouldChange = false;
    }
}