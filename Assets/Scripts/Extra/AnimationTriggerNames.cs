using System.Collections.Generic;
using UnityEngine;

namespace Game.Extra
{
    [System.Serializable]
    public class AnimationTriggerNames
    {
        [SerializeField] public PlayerAnimation AnimationName;
        [SerializeField] public List<string> TriggerNames;
    }
}