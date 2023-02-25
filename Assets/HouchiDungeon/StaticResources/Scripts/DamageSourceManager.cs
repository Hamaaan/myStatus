using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class DamageSourceManager : MonoBehaviour
    {
        [SerializeField] float Damage;
        [SerializeField] float RandomDamage;
        StaticValueManager _svm;

        // Start is called before the first frame update
        void Start()
        {
            _svm = StaticValueManager.instance;
        }

        // Update is called once per frame
        void Update()
        {
            Damage = _svm.PlayerPower/2;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy)
            {
                RandomDamage = Random.Range(0,_svm.MaxPlayerPower/6) * _svm.PlayerPower/_svm.MaxPlayerPower;

                if (StaticValueManager.instance.isSpecial)
                {
                    enemy.GetDamage(Damage * 2 + RandomDamage);
                }
                else
                {
                    enemy.GetDamage(Damage + RandomDamage);

                }
            }
        }
    }
}

