using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : KinematicObject
    {
        public PatrolPath path;
        public AudioClip ouch;
        public AudioClip destroyed;


        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        [SerializeField]SpriteRenderer spriteRenderer;
        
        //追記部分
        public float EnemyHP;
        public float MinHP = 2f;
        public float MaxHP = 4f;
        public int EXP = 4;
        public int EXP_RandomRange = 4;

        Rigidbody2D rb;
        [SerializeField] bool isFly = false;

        [SerializeField] GameObject DamageEffectPrefab;
        [SerializeField] GameObject DamageEffectPoint;

        [SerializeField] Slider slider;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = spriteRenderer.GetComponent<SpriteRenderer>();

            EnemyHP = Random.Range(MinHP, MaxHP);
            slider = slider.GetComponent<Slider>();
            slider.maxValue = EnemyHP;

            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                /*
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
                */
            }
        }

        protected override void Update()
        {
            if (path != null)
            {
                if (mover == null) mover = path.CreateMover(control.maxSpeed * 0.5f);
                control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
            }

            if (EnemyHP < 0)
            {
                EnemyHP = 0;
                Destroy(this.gameObject, 0.5f);
            }
            

            slider.value = EnemyHP;
            if (getDamage)
            {
                targetVelocity = Vector2.right * 1f + Vector2.up * 0.2f;
                Color color = spriteRenderer.color;
                spriteRenderer.color = new Color(color.r, color.g, color.b,Random.Range(0.3f,0.8f));
            }

        }

        private void OnDestroy()
        {
            StaticValueManager.instance.NumberOfKills++;
            StaticValueManager.instance.PlayerExp += (EXP+ Random.Range(0,EXP_RandomRange));
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            
        }

        bool getDamage = false;
        public void GetDamage(float DamagePoint)
        {
            EnemyHP -= DamagePoint;
            getDamage = true;

            Invoke("GetDamageFalse", 0.5f);
            DamageSound();

            GameObject instance = Instantiate(DamageEffectPrefab);
            instance.transform.localScale = transform.GetChild(0).transform.localScale;
            instance.transform.SetParent(transform.GetChild(0));
            instance.GetComponent<Text>().text = ((int)DamagePoint).ToString();
        }

        void GetDamageFalse()
        {
            getDamage = false;
            targetVelocity = Vector2.right * 0f;
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        void DamageSound()
        {
            if (EnemyHP < 0)
            {
                _audio.PlayOneShot(destroyed);
            }
            else
            {
                _audio.PlayOneShot(ouch);
            }
        }
    }
}