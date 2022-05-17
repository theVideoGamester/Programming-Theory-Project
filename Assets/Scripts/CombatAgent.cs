using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatAgent : MonoBehaviour
{
    public StateMachine myState;
    public Weapon weapon;
    public float attackSpeed = 1f;
    public AudioClip damageSound;

    [HideInInspector]
    public CombatAgent combatAgent;
    [HideInInspector]
    public CombatAgent targetAgent;

    protected NavMeshAgent agent;
    protected NavMeshObstacle obstacle;
    protected AudioSource audioSource;
    protected HealthBar healthBar;

    [SerializeField]
    protected int maxHP;
    [SerializeField]
    protected int hp;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        combatAgent = GetComponent<CombatAgent>();
        audioSource = GetComponent<AudioSource>();
        healthBar = GetComponentInChildren<HealthBar>();

        if (maxHP == 0) { maxHP = 10; }
        if (hp == 0) { hp = maxHP; }

        healthBar.SetMaxHealth(maxHP, hp);
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(weapon.weaponName);
        }
        myState = myState.Process();
    }

    public virtual void Attack()
    {
        if (targetAgent == null) { return; }
        audioSource.PlayOneShot(damageSound);
        targetAgent.TakeDamage(weapon.damage);
        if (targetAgent.hp <= 0)
        {
            Destroy(targetAgent.gameObject);
            CancelInvoke();
            DestroyTarget();
        }

    }

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        healthBar.SetHealth(hp);
    }

    protected virtual void DestroyTarget()
    {
       
    }
}
