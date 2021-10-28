using UnityEngine;

namespace Game.Inputs
{
    public class PlayerInputChecker : ISwordsmanInput
    {
        private static PlayerInputChecker _instance;
        private PlayerInputChecker() { }
        public static PlayerInputChecker GetInstance()
        {
            if (_instance == null) _instance = new PlayerInputChecker();
            return _instance;
        }

        public bool MoveRight() => Input.GetKeyDown(KeyCode.RightArrow);
        public bool MoveLeft() => Input.GetKeyDown(KeyCode.LeftArrow);
        public bool BlockUp() => Input.GetKeyDown(KeyCode.Keypad7);
        public bool BlockMiddle() => Input.GetKeyDown(KeyCode.Keypad4);
        public bool BlockBottom() => Input.GetKeyDown(KeyCode.Keypad1);
        public bool AttackUp() => Input.GetKeyDown(KeyCode.Keypad9);
        public bool AttackMiddle() => Input.GetKeyDown(KeyCode.Keypad6);
        public bool AttackBottom() => Input.GetKeyDown(KeyCode.Keypad3);
    }
}