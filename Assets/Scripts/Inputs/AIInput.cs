namespace Game.Inputs
{
    public class AIInput : ISwordsmanInput // TODO: don't forget to implement AI
    {
        private AccessToComponentsNeededForAI _components;
        public AIInput(AccessToComponentsNeededForAI components)
        {
            _components = components;
        }
        
        public bool StartMoveRight()
        {
            throw new System.NotImplementedException();
        }

        public bool StartMoveLeft()
        {
            throw new System.NotImplementedException();
        }

        public bool StopMoveRight()
        {
            throw new System.NotImplementedException();
        }

        public bool StopMoveLeft()
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