namespace Game.Extra
{
    public class AIDuelLooker
    {
        private SwordsmanStateHandler _player;
        private SwordsmanStateHandler _ai;
        public AIDuelLooker(SwordsmanStateHandler player, SwordsmanStateHandler ai)
        {
            _player = player;
            _ai = ai;
        }
    }
}