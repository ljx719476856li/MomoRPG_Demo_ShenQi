using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{

    //TODO 此处绑定共有的脚本组件
    [RequireComponent(typeof(NPCAttribute))]
    [RequireComponent(typeof(MyAnimationEvent))]
    public class AIBase : MonoBehaviour
    {
        [Header("Animator")] [SerializeField] RuntimeAnimatorController animatorController;
        [SerializeField] protected AnimatorOverrideController animatorOverrideController;
        [SerializeField] protected Avatar characterAvatar;
        [SerializeField] [Range(.1f, 1f)] protected float animatorForwardCap = 1f;

        [Header("Audio")]
        [SerializeField] protected float audioSourceSpatialBlend = 0.5f;

        [Header("Capsule Collider")]
        [SerializeField] protected Vector3 colliderCenter = new Vector3(0, 1.03f, 0);
        [SerializeField] protected float colliderRadius = 0.2f;
        [SerializeField] protected float colliderHeight = 2.03f;

        [Header("Movement")]
        [SerializeField] protected float moveSpeedMultiplier = .7f;
        [SerializeField] protected float animationSpeedMultiplier = 1.5f;
        [SerializeField] protected float movingTurnSpeed = 360;
        [SerializeField] protected float stationaryTurnSpeed = 180;
        [SerializeField] protected float moveThreshold = 1f;

        //[Header("'Character Controller'")]
        protected float characterControllerCenterY = 1.44f;
        protected float characterControllerRadius = 1.40f;
        //[SerializeField] float navmeshagentstoppingdistance = 1.3f;

        //NavMeshAgent navMeshAgent;
        protected CharacterController characterController;
        protected Animator animator;
        protected Rigidbody ridigBody;
        protected float turnAmount;
        protected float forwardAmount;
        protected bool isAlive = true;

        public bool ignoreFallCheck = false;
        protected NPCAttribute attribute;
        protected AICharacter ai;
        public AICharacter GetAI()
        {
            return ai;
        }

        void Awake()
        {
            AddRequiredComponents();
            ResourcesLoadAnimationClips();
        }

        private void AddRequiredComponents()
        {
            Debug.Log("1");

            var capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
            capsuleCollider.center = colliderCenter;
            capsuleCollider.radius = colliderRadius;
            capsuleCollider.height = colliderHeight;

            ridigBody = gameObject.AddComponent<Rigidbody>();
            ridigBody.constraints = RigidbodyConstraints.FreezeRotation;

            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = audioSourceSpatialBlend;


            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = animatorController;
            animator.avatar = characterAvatar;

            characterController = gameObject.AddComponent<CharacterController>();
            characterController.center = new Vector3(0.0f, characterControllerCenterY, 0.0f);
            characterController.radius = characterControllerRadius;
            characterController.height = 0.0f;

            //navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
            //navMeshAgent.speed = navMeshAgentSteeringSpeed;
            //navMeshAgent.stoppingDistance = navMeshAgentStoppingDistance;
            //navMeshAgent.autoBraking = false;
            //navMeshAgent.updateRotation = false;
            //navMeshAgent.updatePosition = true;
        }


        private readonly string PrePath = "Prefabs/AnimationClip/";
        private readonly string[] ActionList = { "Idle", "Walk" };

        public readonly string m_modelName = "YangJian";

        public string AnimationPrePath
        {
            get
            {
                return PrePath + m_modelName + "/";
            }
        }

        private void  ResourcesLoadAnimationClips()
        {
            if (animator != null)
            {
                AnimatorOverrideController overrideController = new AnimatorOverrideController();
                overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
                foreach (var actionName in ActionList)
                {
                    overrideController[actionName] = Resources.Load<AnimationClip> (AnimationPrePath + m_modelName + "@" + actionName) ;
                    Debug.Log(overrideController[actionName].name);
                }



                animator.runtimeAnimatorController = overrideController;
            }
        }
    }
}


