using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class StartActivated : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objectsToStartActivated;

        private void Awake()
        {
            foreach (var go in objectsToStartActivated)
            {
                go.SetActive(true);
            }
        }
    }
}