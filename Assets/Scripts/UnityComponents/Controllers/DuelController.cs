using Game.Extra;
using Game.Inputs;
using Game.States.Player;
using UnityEngine;

namespace Game
{
    public class DuelController : MonoBehaviour
    {
        [SerializeField] private Vector2 playerStartPosition;
        [SerializeField] private Vector2 aiStartPosition;
        [SerializeField] private DuelEndEffect duelEndEffect;

        private SwordsmanStateHandler _player;
        private SwordsmanStateHandler _ai;
        private SwordsmanStateHandler _defeated = null;

        private DuelLooker _looker;

        public void Init(SwordsmanStateHandler player, SwordsmanStateHandler ai)
        {
            _player = player;

            Instantiate(_player);
            _player.transform.position = playerStartPosition;
            _player.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            _player.Init(PlayerInput.GetInstance());
            
            _ai = ai;
            AIInput aiInput = new AIInput(this);
            _looker = new DuelLooker(this);
            
            Instantiate(_ai);
            _ai.transform.position = aiStartPosition;
            _ai.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            _ai.gameObject.AddComponent<AIInputInstance>().Init(aiInput); 
            _ai.Init(aiInput);
            _ai.GetComponent<AIStateHandler>().Init(aiInput, _looker);
        }

        public void InstantiateNewAI(SwordsmanStateHandler ai)
        {
            _player.transform.position = playerStartPosition;
            Instantiate(_ai);
            _ai.transform.position = aiStartPosition;
            _ai.gameObject.AddComponent<DuelControllerInstance>().DuelController = this;
            _ai.Init(new AIInput(this));
        }
        public string GetPlayerState() => _player.GetCurrentState();

        public void Attack(SwordsmanStateHandler attacker, Direction direction, float attackDistance)
        {
            SwordsmanStateHandler attacked;
            if (attacker == _player) attacked = _ai;
            else if (attacker == _ai) attacked = _player;
            else return;

            var distance = Vector2.Distance(attacker.Weapon.AttackPointPosition, attacked.BodyPosition.Value);
            if (distance > attacker.Weapon.AttackDistance) return;
            
            attacked.SetState(nameof(Attacked) + direction.ToString());
            
            if (!attacked.GetCurrentState().Contains(nameof(Attacked))) return;
            duelEndEffect.EnableEffect();
            _defeated = attacked;
            Invoke(nameof(DisableEffect), PlayerAnimationConfiguration.DeathTime);
        }

        private void DisableEffect()
        {
            duelEndEffect.DisableEffect();
            Destroy(_defeated.gameObject);
        }
    }
}