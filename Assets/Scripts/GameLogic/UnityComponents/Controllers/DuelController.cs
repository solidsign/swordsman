using Game.Extra;
using Game.Inputs;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class DuelController : MonoBehaviour
    {
        [Header("Duelists")]
        [Header("Player")]
        [SerializeField] private SwordsmanStateHandler player;
        [SerializeField] private Vector2 playerStartPosition;
        [Header("AI")]
        [SerializeField] private SwordsmanStateHandler ai;
        [SerializeField] private Vector2 aiStartPosition;
        [Header("Post-Effects")]
        [SerializeField] private DuelEndEffect deathEffect;
        [Header("UI")]
        [SerializeField] private UI retryUI;
        [SerializeField] private UI winUI;

        private void Awake()
        {
            AttackHandler attackHandler = new AttackHandler(player, ai, this);
            InstantiatePlayer(attackHandler);
            InstantiateAI(attackHandler);
            PlaceDuelists();
        }

        private void InstantiatePlayer(AttackHandler attackHandler)
        {
            Instantiate(player);
            player.gameObject.AddComponent<AttackHandlerInstance>().attackHandler = attackHandler;
            player.Init(PlayerInput.GetInstance());
        }

        private void InstantiateAI(AttackHandler attackHandler)
        {
            AIInput aiInput = new AIInput();
            ai.gameObject.AddComponent<AttackHandlerInstance>().attackHandler = attackHandler;
            ai.Init(aiInput);
            ai.GetComponent<AIStateHandler>().Init(aiInput, new AIDuelLooker(player, ai));
        }

        private void PlaceDuelists()
        {
            if (playerStartPosition.x < aiStartPosition.x)
                ai.transform.eulerAngles = new Vector3(0, 180f, 0);
            else
                player.transform.eulerAngles = new Vector3(0, 180f, 0);
            player.transform.position = playerStartPosition;
            ai.transform.position = aiStartPosition;
        }
        
        public void HandleDuelEnd(SwordsmanStateHandler defeated)
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
    }
}