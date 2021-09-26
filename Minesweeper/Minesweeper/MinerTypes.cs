namespace Minesweeper
{
    struct TPoint
    {
        public int X;
        public int Y;
    }

    enum TCellState
    {
        Closed, Opened, BombMarked, QuestionMarked
    };

    struct TCellStateRec
    {
        public int SurroundNumber;
        public TCellState CellState;
    }

    struct TChangedCell
    {
        public TPoint Pos;
        public TCellStateRec CellState;
    }

    enum TDifficultyType
    {
        Beginner, Intermediate, Expert, Custom
    }

    struct TGameDifficulty
    {
        public TDifficultyType DifficultyType;
        public int Height;
        public int Width;
        public int MineCount;
    }

    enum TGameStatus
    {
        New, Run, Lost, Won
    }  
}
