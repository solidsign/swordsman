using Game.Extra;
using Game.Inputs;
using UnityEngine;

namespace Game
{
    public class DuelController : MonoBehaviour
    {
        [Header("Duelists")]
        [Header("Player")]
        [SerializeField] private SwordsmanStateHandler player;
        [SerializeField] private float playerStartPositionX;
        [Header("AI")]
        [SerializeField] private SwordsmanStateHandler ai;
        [SerializeField] private float aiStartPositionX;
        [Header("Post-Effects")]
        [SerializeField] private DuelEndEffect deathEffect;
        [Header("UI")]
        [SerializeField] private UI retryUI;
        [SerializeField] private UI winUI;

        private void Awake()
        {
            AttackHandler attackHandler = new AttackHandler(player, ai, HandleDuelEnd);
            InstantiatePlayer(attackHandler);
            InstantiateAI(attackHandler);
            PlaceDuelists();
        }

        private void InstantiatePlayer(AttackHandler attackHandler)
        {
            Instantiate(player);
            player.gameObject.AddComponent<AttackHandlerInstance>().AttackHandler = attackHandler;
            player.Init(PlayerInput.GetInstance());
        }

        private void InstantiateAI(AttackHandler attackHandler)
        {
            AIInput aiInput = new AIInput();
            ai.gameObject.AddComponent<AttackHandlerInstance>().AttackHandler = attackHandler;
            ai.Init(aiInput);
            ai.GetComponent<AIStateHandler>().Init(aiInput, new AIDuelLooker(player, ai));
        }

        private void PlaceDuelists()
        {
            if (playerStartPositionX < aiStartPositionX)
                ai.transform.eulerAngles = new Vector3(0, 180f, 0);
            else
                player.transform.eulerAngles = new Vector3(0, 180f, 0);
            player.transform.position = new Vector3(playerStartPositionX, 0, 0);
            ai.transform.position = new Vector3(aiStartPositionX,0,0);
        }
        
        private void HandleDuelEnd(SwordsmanStateHandler defeated)
        {
            player.enabled = false;
            ai.enabled = false;
            deathEffect.EnableEffect(() =>
            {
                if (defeated == player) retryUI.Enable();
                else if (defeated == ai) winUI.Enable();
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