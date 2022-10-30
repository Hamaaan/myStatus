using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class DamageSourceManager : MonoBehaviour
    {
        [SerializeField] float Damage;
        [SerializeField] float RandomDamage;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy)
            {
                RandomDamage = Random.Range(0,2);
                enemy.GetDamage(Damage + RandomDamage);
            }
        }
    }
}

