using System.Collections;
using UnityEngine;

namespace Game.States.Player
{
    public abstract class Attacked : BaseState
    {
        private float _responseTime;
        private StateHandler _stateHandler;
        public override void Init(StateHandler stateHandler)
        {
            _stateHandler = stateHandler;
            _responseTime = stateHandler.GetComponent<ResponseTime>().Value;
        }

        public override void Enter()
        {
            _stateHandler.StopAllCoroutines();
            _stateHandler.StartCoroutine(WaitForResponse());
        }

        public override void Exit()
        {
            _stateHandler.StopAllCoroutines();
        }

        private IEnumerator WaitForResponse()
        {
            yield return new WaitForSeconds(_responseTime);
            _stateHandler.SetState(nameof(Dead));
        }
    }
}