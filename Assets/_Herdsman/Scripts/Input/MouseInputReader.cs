using Herdsman.Player;
using OsirisGames.EventBroker;
using UnityEngine;

namespace Herdsman
{
    public class MouseInputReader : MonoBehaviour, IInputReader
    {
        [SerializeField] private Camera _camera;
        private IEventBus _signalBus;

        public void Init(IEventBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void ReadInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var targerPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(targerPosition);
                _signalBus.Fire(new MoveHeroToTargetSignal(targerPosition));
            }
        }

        private void Update()
        {
            ReadInput();
        }
    }
}