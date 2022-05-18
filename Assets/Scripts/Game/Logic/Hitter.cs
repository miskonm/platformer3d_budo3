using System;
using UnityEngine;

namespace Platformer.Game.Logic
{
    public class Hitter : MonoBehaviour
    {
        public event Action<Collider> OnHit;

        private void OnTriggerEnter(Collider other)
        {
            OnHit?.Invoke(other);
        }
    }
}