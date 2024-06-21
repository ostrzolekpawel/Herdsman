using UnityEngine;
using Herdsman.Animals;
using System;

namespace Herdsman.Player
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class HeroView : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _collider;

        private IHero _hero;

        public void Init(IHero hero)
        {
            _hero = hero ?? throw new ArgumentNullException(nameof(hero));

            if (_collider == null)
            {
                _collider = GetComponent<CircleCollider2D>();
            }

            _collider.radius = _hero.CollectRange;
            _hero.OnchangePosition += ChangePosition;
        }

        private void ChangePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<IAnimalView>() is IAnimalView animal)
            {
                animal.TryFollow();
            }
        }

        public void Tick()
        {
            _hero.Move(transform.position);
        }

        private void OnDestroy()
        {
            _hero.OnchangePosition -= ChangePosition;
            _hero.Dispose();
        }
    }
}