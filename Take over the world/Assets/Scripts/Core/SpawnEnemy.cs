using System.Collections;
using Character;
using UnityEngine;
namespace Core
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField]
        private Enemy _enemy; 
        [SerializeField]
        private GameObject _target;
        private bool win;
        private IEnumerator Start()
        {
           // while (!win)
          //  { 
                yield return new WaitForSeconds(2);
               var enemy =  Instantiate(_enemy.gameObject,transform.position,_enemy.gameObject.transform.rotation);
               enemy.GetComponent<Enemy>().Move(_target.transform);
          //  }
        }
    }
}
