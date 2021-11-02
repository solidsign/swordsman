using Game.Inputs;
using UnityEngine;

namespace Game
{
    public class AIInputInstance : MonoBehaviour
    {
        public AIInput AIInput { get; private set; }

        public void Init(AIInput aiInput)
        {
            AIInput = aiInput;
        }
    }
}