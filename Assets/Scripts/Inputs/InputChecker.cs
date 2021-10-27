namespace Game.Inputs
{
    public class InputChecker
    {
        private static InputChecker _instance;
        private InputChecker() { }
        public static InputChecker GetInstance()
        {
            if (_instance == null) _instance = new InputChecker();
            return _instance;
        }
    }
}