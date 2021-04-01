using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleGame
{
    [Serializable]
    class LeaderBoardItem
    {
        private string playerName;
        private int numberMoves;
        private int totalSeconds;           //used for ranking purposes
        private string timeSolveFormatted;  // used for display purposes

        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }

        public int NumberMoves
        {
            get
            {
                return numberMoves;
            }
            set
            {
                numberMoves = value;
            }
        }

        public int TotalSeconds
        {
            get
            {
                return totalSeconds;
            }
            set
            {
                totalSeconds = value;
            }
        }

        public string TimeSolveFormatted
        {
            get
            {
                return timeSolveFormatted;
            }
            set
            {
                timeSolveFormatted = value;
            }
        }
    }
}
