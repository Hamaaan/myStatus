using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        //追記部分
        public float moveSpeed = 0.2f;
        public CharaState charaState = CharaState.IsProgress;


        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        //
        StaticValueManager _svm;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            
            _svm = StaticValueManager.instance;
        }

        private void Start()
        {
            if (StaticValueManager.instance.PreMiniGameScene == "IQ_KigouSagashi 1")
            {
                moveSpeed = 2.0f * _svm.PlayerSpeed / _svm.MaxPlayerSpeed;
            }

            if (StaticValueManager.instance.PreMiniGameScene == "testcoin")
            {
                
            }
        }

        protected override void Update()
        {
            if (StaticValueManager.instance.isDungeonClear)
            {
                moveSpeed = 0;
                animator.SetBool("Clear", true);

            }

            if (controlEnabled)
            {
                //move.x = Input.GetAxis("Horizontal");
                if (isContact)
                {
                    move.x = 0;
                    animator.SetBool("contactEnemy", true);
                }
                else
                {
                    move.x = moveSpeed;
                }
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            UpdateCharaState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }

        //追記部分
        public bool isContact = false;

        public enum CharaState
        {
            IsProgress,
            Attack,
            Damaged
        }
        void UpdateCharaState()
        {
            if (!isContact)
            {
                animator.SetBool("contactEnemy", false);
            }
            switch (charaState)
            {
                case CharaState.Attack:
                    animator.SetBool("attack", true);
                    break;
                case CharaState.IsProgress:
                    //animator.SetBool("contactEnemy", false);

                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                animator.SetBool("contactEnemy", true);
                isContact = true;
            }
            else
            {
                charaState = CharaState.IsProgress;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                animator.SetBool("contactEnemy", true);
                isContact = true;
            }
            else
            {

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isContact = false;
            animator.SetBool("contactEnemy", false);

        }

        public void AttackOnEnemy()
        {
            charaState = CharaState.Attack;
        }
        public void AttackEnd()
        {
            animator.SetBool("attack", false);
        }

    }
}