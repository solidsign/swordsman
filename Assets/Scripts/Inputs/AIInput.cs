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
            throw new System.NotImplementedException();
        }

        public bool StartMoveLeft()
        {
            throw new System.NotImplementedException();
        }

        public bool StopMove()
        {
            throw new System.NotImplementedException();
        }

        public bool BlockUp()
        {
            throw new System.NotImplementedException();
        }

        public bool BlockMiddle()
        {
            throw new System.NotImplementedException();
        }

        public bool BlockBottom()
        {
            throw new System.NotImplementedException();
        }

        public bool AttackUp()
        {
            throw new System.NotImplementedException();
        }

        public bool AttackMiddle()
        {
            throw new System.NotImplementedException();
        }

        public bool AttackBottom()
        {
            throw new System.NotImplementedException();
        }
    }
}