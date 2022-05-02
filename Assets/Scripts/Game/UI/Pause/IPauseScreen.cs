using System;
using System.Threading.Tasks;

namespace Platformer.Game.UI.Pause
{
    public interface IPauseScreen
    {
        bool IsAnimating { get; }
        event Action OnContinueButtonClicked;
        
        void Show();
        void Hide();
    }
}