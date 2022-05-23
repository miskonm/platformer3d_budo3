using System;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class UniqueId : MonoBehaviour
    {
        public string Id;

        public void GenerateId() =>
            Id = $"{gameObject.name}_{Guid.NewGuid()}";
    }
}