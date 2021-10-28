using UnityEngine;

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

        public bool MoveRight() => Input.GetKeyDown(KeyCode.RightArrow);
        public bool MoveLeft() => Input.GetKeyDown(KeyCode.LeftArrow);
        public bool BlockUp() => Input.GetKeyDown(KeyCode.Keypad7);
        public bool BlockMiddle() => Input.GetKeyDown(KeyCode.Keypad4);
        public bool BlockBottom() => Input.GetKeyDown(KeyCode.Keypad1);
        public bool AttackUp() => Input.GetKeyDown(KeyCode.Keypad9);
        public bool AttackMiddle() => Input.GetKeyDown(KeyCode.Keypad6);
        public bool AttackBottom() => Input.GetKeyDown(KeyCode.Keypad3);
        public bool Pause() => Input.GetKeyDown(KeyCode.Escape);
        public bool Start() => Input.GetKeyDown(KeyCode.Space);
    }
}