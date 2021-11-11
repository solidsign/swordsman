namespace Game.Inputs
{
    public class AIInput : ISwordsmanInput // TODO: don't forget to implement AI
    {
        private bool _startMoveRight = false;
        private bool _startMoveLeft = false;
        private bool _stopMove = false;
        private bool _blockUp = false;
        private bool _blockMiddle = false;
        private bool _blockBottom = false;
        private bool _attackUp = false;
        private bool _attackMiddle = false;
        private bool _attackBottom = false;

        #region Triggers

        public void TriggerStartMoveRight()
        {
            _startMoveRight = true;
        }

        public void TriggerStartMoveLeft()
        {
            _startMoveLeft = true;
        }

        public void TriggerStopMove()
        {
            _stopMove = true;
        }

        public void TriggerBlockUp()
        {
            _blockUp = true;
        }

        public void TriggerBlockMiddle()
        {
            _blockMiddle = true;
        }

        public void TriggerBlockBottom()
        {
            _blockBottom = true;
        }

        public void TriggerAttackUp()
        {
            _attackUp = true;
        }

        public void TriggerAttackMiddle()
        {
            _attackMiddle = true;
        }

        public void TriggerAttackBottom()
        {
            _attackBottom = true;
        }


        #endregion
        #region Getters
        
        public bool StartMoveRight()
        {
            if (!_startMoveRight) return false;
            _startMoveRight = false;
            return true;
        }

        public bool StartMoveLeft()
        {
            if (!_startMoveLeft) return false;
            _startMoveLeft = false;
            return true;
        }

        public bool StopMove()
        {
            if (!_stopMove) return false;
            _stopMove = false;
            return true;
        }

        public bool BlockUp()
        {
            if (!_blockUp) return false;
            _blockUp = false;
            return true;
        }

        public bool BlockMiddle()
        {
            if (!_blockMiddle) return false;
            _blockMiddle = false;
            return true;
        }

        public bool BlockBottom()
        {
            if (!_blockBottom) return false;
            _blockBottom = false;
            return true;
        }

        public bool AttackUp()
        {
            if (!_attackUp) return false;
            _attackUp = false;
            return true;
        }

        public bool AttackMiddle()
        {
            if (!_attackMiddle) return false;
            _attackMiddle = false;
            return true;
        }

        public bool AttackBottom()
        {
            if (!_attackBottom) return false;
            _attackBottom = false;
            return true;
        }
        
        #endregion
    }
}