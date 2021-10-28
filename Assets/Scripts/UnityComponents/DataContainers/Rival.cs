using UnityEngine;
namespace Game
{
    public class Rival : MonoBehaviour
    {
        [SerializeField] private GameObject rival;
        public GameObject RivalGameObject => rival;
    }
}