using System.Collections;
using UnityEngine;
using DNSCoreMechanics.Weapons;
using DNSCoreMechanics.Intefaces;
using DNSCoreMechanics.Utils;
using UnityEngine.EventSystems;


namespace DNSCoreMechanics.Behaviors.Entities
{
    public class EntityBehavior2D<EB, WB> : MonoBehaviour, IEntityBehavior where EB : IEntityBehavior where WB : WeaponBase
    {

        protected EB EBInstance;
        protected WB WBInstance;

        [Header("Health Settings")]
        [SerializeField] protected int health;
        [SerializeField] protected Transform healthBarPrefab;
        protected HealthSystem hs;

        [Header("Behavior Settings (Required)")]
        [SerializeField] protected bool isAIControl;
        [SerializeField] protected int hasShield;
        //protected WeaponBehavior2D weaponBehavior;
        protected Camera cam;

        [Header("Moving Settings TopDown 2D")]
        [SerializeField] public float movementSpeed;
        [SerializeField] public Rigidbody2D rb; //REPETITION
        [SerializeField] public GameObject lookAtDirection;

        [Header("Dash Settings")]
        [SerializeField] public float dashSpeed = 10f; //REPETITION
        [SerializeField] public float dashDuration = 1f; //REPETITION
        [SerializeField] public float dashCooldown = 1f; //REPETITION 
        protected bool isDashing;
        protected bool canDash;

        [Header("Weapon Settings (Required if entity can shoot)")]
        [SerializeField] protected  GameObject bullet;
        [SerializeField] protected Transform bulletTransform;

        [Header("Animation Settings 2D")]
        [SerializeField] protected Animator anim;

        public void Dash(bool isDashing, bool canDash, Rigidbody2D rb, float dashSpeed, float dashDuration, int dashCooldown)
        {
            Vector2 moveDirection = BehaviorsUtils.getNormalizedMoveDirection();
            //Vector2 mousePosition = BehaviorsUtils.getCameraMousePosition();

            if (Input.GetKeyDown(KeyCode.Space) && canDash)
            {
                Debug.Log("dash");
                StartCoroutine(BehaviorsUtils.doDash(canDash, isDashing, rb, moveDirection.x, moveDirection.y, dashSpeed, dashDuration, dashCooldown));
            }
            //EBInstance.Dash( isDashing, canDash,rb, dashSpeed, dashDuration, dashCooldown);
        }

        public void hasCollision()
        {
            EBInstance.hasCollision();
        }

        public void createEntityHealthOnTop()
        {
            hs = new HealthSystem(health);
            Transform hbTransform = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
            hbTransform.transform.parent = transform;
            hbTransform.transform.localPosition = new Vector3(-1, 1.50f, 0);
            HealthBar healthBar = hbTransform.GetComponent<HealthBar>();
            healthBar.Setup(hs, "Bar"); 

        }

        public void InitializeEntityBehaviorRequiredConfigs(float movementSpeed, float jumpPower)
        {
            
        }

        public void Jump()
        {
            EBInstance.Jump();
        }

        public void Move(Transform entityTransform, Animator anim, float movementSpeed, GameObject lookAtDirection)
        {
            EBInstance.Move(entityTransform, anim, movementSpeed, lookAtDirection);
        }

        public void Respawn()
        {
            EBInstance.Respawn();
        }
        public void initTopDown2D(bool canDash, float movementSpeed, Camera cam)
        {
            this.canDash = canDash;
            this.movementSpeed = movementSpeed;
            this.cam = cam;
        }

    }
}

