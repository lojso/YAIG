using UnityEngine;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBoostraper _bootstrappersPrefab;
    
        private void Awake()
        {
            if (FindObjectOfType<GameBoostraper>() == null)
                Instantiate(_bootstrappersPrefab);
        }
    }
}
