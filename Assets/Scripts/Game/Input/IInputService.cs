using UnityEngine;

namespace Platformer.Game.Input
{
    public interface IInputService
    {
        Vector2 MoveAxis { get; }
        bool IsJump { get; }
        bool IsAttackUp { get; }

        void SetLocked(bool isLocked);
    }
}