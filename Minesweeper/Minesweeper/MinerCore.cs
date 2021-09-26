using System;
using System.Collections.Generic;

namespace Minesweeper
{
    using TCells = List<TPoint>;
    using TChangedCells = List<TChangedCell>;    

    public class MinerField : object
    {
        private int FHeight;
        private int FWidth;
        private int FMineCount;
        
        List<List<TCellStateRec>> FCellState = new List<List<TCellStateRec>>();
        TGameDifficulty FGameDifficulty = new TGameDifficulty();
        TGameStatus FGameStatus;

        private int FCellsBombMarkedCount;

        TCells FRedCells;        

        private delegate void TSrcMinerFieldChangedEvent(object sender, TChangedCells changed, TCells redCells);
        private delegate void TSrcGameStatusChangedEvent(object sender, TGameStatus aGameStatus, TGameDifficulty aGameDifficulty, TChangedCells aChangedCells, TCells aRedCells);
        
        TSrcMinerFieldChangedEvent FMinerFieldChanged;
        TSrcGameStatusChangedEvent FGameStatusChanged;

        private bool CheckFieldBounds(int xPos, int yPos)
        {
            return (xPos >= 0) && (yPos >= 0) && (xPos < FCellState.Count) && (yPos < FCellState[0].Count);
        }
        
        private int Get_Height()
        {
            return FHeight;
        }
        
        private void Set_Height(int value)
        {
            if (value < 9)
            {
                FHeight = 9;
            }
            if (value is >= 9 and <= 24)
            {
                FHeight = value;
            }
            if (value > 24)
            {
                FHeight = 24;
            }
        }
        
        private int Get_Width()
        {
            return FWidth;
        }

        private void Set_Width(int value)
        {
            if (value < 9)
            {
                FWidth = 9;
            }
            if (value is >= 9 and <= 30)
            {
                FWidth = value;
            }
            if (value > 30)
            {
                FWidth = 30;
            }
        }
        
        private int Get_MineCount()
        {
            return FMineCount;
        }

        private void Set_MineCount(int value)
        {
            if (value < 10)
            {
                FMineCount = 10;
            }
            if (value >= 10 && (value <= (FHeight - 1) * (FWidth - 1)))
            {
                FMineCount = value;
            }
            if ((FHeight - 1) * (FWidth - 1) < value)
            {
                FMineCount = (FHeight - 1)*(FWidth - 1);
            }
        }

        private TCellStateRec Get_CellState(int xIndex, int yIndex)
        {
            return FCellState[xIndex][yIndex];
        }
        
        private void Set_CellState(int xIndex, int yIndex, TCellStateRec value)
        {
            if (FCellState[xIndex][yIndex].SurroundNumber != value.SurroundNumber ||
                FCellState[xIndex][yIndex].CellState != value.CellState)
            {
                if (FCellState[xIndex][yIndex].CellState == TCellState.BombMarked)
                {
                    FCellsBombMarkedCount--;
                }

                FCellState[xIndex][yIndex] = value;

                if (value.CellState == TCellState.BombMarked)
                {
                    FCellsBombMarkedCount++;
                }
            }
        }
        
        private TGameDifficulty Get_GameDifficulty()
        {
            return FGameDifficulty;
        }

        private void SetThisDifficulty()
        {
            FGameDifficulty.Height = FHeight;
            FGameDifficulty.Width = FWidth;
            FGameDifficulty.MineCount = FMineCount;
        }

        private void Set_GameDifficulty(TGameDifficulty value)
        {
            TCells cells = new TCells();

            FGameDifficulty.DifficultyType = value.DifficultyType;

            switch (value.DifficultyType)
            {
                case TDifficultyType.Beginner:
                {
                    FHeight = 9;
                    FWidth = 9;
                    FMineCount = 10;
                }
                break;
                
                case TDifficultyType.Intermediate:
                {
                    FHeight = 16;
                    FWidth = 16;
                    FMineCount = 40;
                }
                break;

                case TDifficultyType.Expert:
                {
                    FHeight = 16;
                    FWidth = 30;
                    FMineCount = 99;
                }
                break;

                case TDifficultyType.Custom:
                {
                    FHeight = value.Height;
                    FWidth = value.Width;
                    FMineCount = value.MineCount;
                }
                break;
            }

            SetThisDifficulty();
            FGameStatus = TGameStatus.New;
            FireEvGameStatusChanged(TGameStatus.New, ref cells);
        }
        
        private void FireEvGameStatusChanged(TGameStatus gameStatus, ref TCells changedCells)
        {
            var cells = new TChangedCells();
            var redCells = new TCells();
            
            if (FGameStatusChanged != null)
            {
                for (int i=0; i < changedCells.Count; i++)
                {
                    cells.Add(new TChangedCell{Pos = changedCells[i], CellState = FCellState[changedCells[i].X][changedCells[i].Y]});
                }
                
                for (int i=0; i < FRedCells.Count; i++)
                {
                    redCells.Add(new TPoint{X = FRedCells[i].X, Y = FRedCells[i].Y});
                }
                FGameStatusChanged(this, gameStatus, FGameDifficulty, cells, redCells);
            }
            changedCells.Capacity = 0;
        }
    }    
}// End of Minerfield