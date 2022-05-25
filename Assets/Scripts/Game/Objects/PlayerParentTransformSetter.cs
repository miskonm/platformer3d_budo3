using UnityEngine;

namespace Platformer.Game.Objects
{
    [RequireComponent(typeof(Collider))]
    public class PlayerParentTransformSetter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;
            
            other.transform.SetParent(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;
            
            other.transform.SetParent(null);
        }
    }
}