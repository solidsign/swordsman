using System.Collections;
using System.Collections.Generic;
using Game.Extra;
using Game.Inputs;
using Game.States;
using Game.States.AI;
using UnityEngine;

namespace Game
{
    [AddComponentMenu("AI Controllers/SimpleAI")]
    public class SimpleAI : AIStateHandler
    {
        [Min(0.1f)] [SerializeField] private float behaviourSwitchTime;
        [Range(0f, 200f)] [Tooltip("In percents")] [SerializeField] private float relativeTimeDispersion;
        private float _minBehaviourSwitchTime;
        private float _maxBehaviourSwitchTime;
        private AIInput _input;
        private AIDuelLooker _looker;

        protected override void Start()
        {
            base.Start();
            StartCoroutine(ChangeStates());
        }
        protected override void InitializeDictionary()
        {
            States = new Dictionary<string, BaseState>()
            {
                {nameof(Attacking), new Attacking(_input, _looker)},
                {nameof(Defencing), new Defencing(_input, _looker)}
            };
        }

        protected override void SetStartState()
        {
            SetState(nameof(Attacking));
        }

        protected override void CheckIfStateTransitionNeeded() {}

        private void RandomiseState()
        {
            switch (Random.Range(0, 2))
            {
                case 0: SetState(nameof(Attacking));
                    break;
                case 1: SetState(nameof(Defencing));
                    break;
            }
        }

        private IEnumerator ChangeStates()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(Random.Range(_minBehaviourSwitchTime, _maxBehaviourSwitchTime));
                RandomiseState();
            }
        }

        public override void Init(AIInput input, AIDuelLooker aiDuelLooker)
        {
            _input = input;
            _looker = aiDuelLooker;
            _minBehaviourSwitchTime = behaviourSwitchTime - behaviourSwitchTime * relativeTimeDispersion;
            _maxBehaviourSwitchTime = behaviourSwitchTime + behaviourSwitchTime * relativeTimeDispersion;
        }
    }
}