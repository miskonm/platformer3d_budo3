using Cinemachine;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook _freeLook;

        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            transform.localRotation = Quaternion.Euler(0f, _freeLook.m_XAxis.Value, 0f);
        }
    }
}