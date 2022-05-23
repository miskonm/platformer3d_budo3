using Platformer.Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Objects
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        private bool _isSaved;

        [Inject]
        public void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isSaved)
                return;
            
            _isSaved = true;
            _saveLoadService.Save();
            Debug.Log("Saved!");
        }
    }
}