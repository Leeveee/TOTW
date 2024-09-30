using DG.Tweening;
using UnityEngine;
namespace Character
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private float _moveDuration = 5f;
        
        private Tween _moveTween;
        
        public void Move(Transform target)
        {
            _moveTween = transform.DOMove(target.position, _moveDuration)
                .SetEase(Ease.Linear)
                .SetAutoKill(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Якщо об'єкт зіткнувся з головною будівлею
            if (other.CompareTag("MainHouse"))
            {
                _animator.CrossFade("AttackPork",0);
                _moveTween.Kill();
            }
        }
    }
}
