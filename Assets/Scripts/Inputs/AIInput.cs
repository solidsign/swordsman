namespace Game.Inputs
{
    public class AIInput : ISwordsmanInput // TODO: don't forget to implement AI
    {
        private DuelController _duel;
        public AIInput(DuelController duelController)
        {
            _duel = duelController;
        }
        
        public bool StartMoveRight()
        {
            return false;
        }

        public bool StartMoveLeft()
        {
            return false;
        }

        public bool StopMove()
        {
            return false;
        }

        public bool BlockUp()
        {
            return false;
        }

        public bool BlockMiddle()
        {
            return false;
        }

        public bool BlockBottom()
        {
            return false;
        }

        public bool AttackUp()
        {
            return false;
        }

        public bool AttackMiddle()
        {
            return false;
        }

        public bool AttackBottom()
        {
            return false;
        }
    }
}