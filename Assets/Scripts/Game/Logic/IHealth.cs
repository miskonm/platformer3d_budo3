using System;

namespace Platformer.Game.Logic
{
    internal interface IHealth
    {
        event Action OnChanged;
        
        float Current { get; }
        float Max { get;  }

        void Setup(float current, float max);
        void ApplyDamage(float damage);
    }
}