using UnityEngine;

namespace Managers
{
    public class CameraPos : MonoBehaviour
    {
        public Transform player;

        // Update is called once per frame
        private void Update()
        {
            var position = player.position;
            transform.position = new Vector3(position.x, position.y, -10);
        }
    }
}