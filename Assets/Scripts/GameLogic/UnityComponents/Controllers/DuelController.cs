using Game.Extra;
using Game.Inputs;
using UnityEngine;

namespace Game
{
    public class DuelController : MonoBehaviour
    {
        [Header("Duelists")]
        [Header("Player")]
        [SerializeField] private SwordsmanStateHandler playerPrefab;
        [SerializeField] private float playerStartPositionX;
        [Header("AI")]
        [SerializeField] private SwordsmanStateHandler aiPrefab;
        [SerializeField] private float aiStartPositionX;
        [Header("Post-Effects")]
        [SerializeField] private DuelEndEffect deathEffect;
        [Header("UI")]
        [SerializeField] private UI retryUI;
        [SerializeField] private UI winUI;

        private SwordsmanStateHandler _player;
        private SwordsmanStateHandler _ai;
        
        private void Awake()
        {
            _player = Instantiate(playerPrefab);
            _ai = Instantiate(aiPrefab);
            
            AttackHandler attackHandler = new AttackHandler(_player, _ai, HandleDuelEnd);

            InjectionsForPlayer(attackHandler);
            InjectionsForAI(attackHandler);
            
            PlaceDuelists();
        }

        private void InjectionsForPlayer(AttackHandler attackHandler)
        {
            _player.GetComponent<AttackHandlerInstance>().AttackHandler = attackHandler;
            _player.Init(PlayerInput.GetInstance());
        }

        private void InjectionsForAI(AttackHandler attackHandler)
        {
            AIInput aiInput = new AIInput();
            
            _ai.GetComponent<AttackHandlerInstance>().AttackHandler = attackHandler;
            _ai.Init(aiInput);
            _ai.GetComponent<AIStateHandler>().Init(aiInput, new AIDuelLooker(_player, _ai));
        }

        private void PlaceDuelists()
        {
            if (playerStartPositionX < aiStartPositionX)
                aiPrefab.transform.eulerAngles = new Vector3(0, 180f, 0);
            else
                playerPrefab.transform.eulerAngles = new Vector3(0, 180f, 0);
            playerPrefab.transform.position = new Vector3(playerStartPositionX, 0, 0);
            aiPrefab.transform.position = new Vector3(aiStartPositionX,0,0);
        }
        
        private void HandleDuelEnd(SwordsmanStateHandler defeated)
        {
            playerPrefab.enabled = false;
            aiPrefab.enabled = false;
            deathEffect.EnableEffect(() =>
            {
                //if (defeated == player) retryUI.Enable();  TODO: turn on when UI will be done
                //else if (defeated == ai) winUI.Enable();
                Destroy(defeated);
            });
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(new Vector3(playerStartPositionX,0,0), 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(new Vector3(aiStartPositionX,0,0), 0.5f);
        }
    }
}