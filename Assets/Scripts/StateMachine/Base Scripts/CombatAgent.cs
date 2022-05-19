using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatAgent : MonoBehaviour
{
    public StateMachine myState;
    
 
    [HideInInspector]
    public CombatAgent combatAgent;
    [HideInInspector]
    public CombatAgent targetAgent;

    protected NavMeshAgent agent;
    protected NavMeshObstacle obstacle;

    
    protected HealthBar healthBar;
    protected int ac;
    protected Dice d20 = new Dice(1,DICE.D20);

    [SerializeField]
    protected int maxHP;
    [SerializeField]
    protected int hp;
    public float attackSpeed = 1f;

    public Equipment equipment;
    public StatBlock stats;
    [SerializeField]
    protected SoundAgent soundAgent;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        combatAgent = GetComponent<CombatAgent>();
        soundAgent = new SoundAgent(GetComponent<AudioSource>(),soundAgent.damageSound,soundAgent.missSound);
        healthBar = GetComponentInChildren<HealthBar>();

        stats.initializeValues();
        equipment.InitArmor(gameObject);
        ac = equipment.GetAC();

        if (maxHP == 0) { maxHP = 10; }
        maxHP += stats.hardinessBonus;
        if (hp == 0) { hp = maxHP; }

        healthBar.SetMaxHealth(maxHP, hp);
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
        }
        myState = myState.Process();
    }

    public virtual void Attack()
    {
        targetAgent.TakeDamage(equipment.weapon.Damage(),d20.RollDice(), stats.athleticismBonus);
        if (targetAgent.hp <= 0)
        {
            Destroy(targetAgent.gameObject);
            CancelInvoke();
            DestroyTarget();
        }

    }

    public virtual void TakeDamage(int damage, int roll, int bonus)
    {
        if (roll + bonus >= ac) 
        {
            soundAgent.Damaged();
            hp -= damage;
            healthBar.SetHealth(hp);
        }
        else
        {
            soundAgent.Missed();
            Debug.Log("Miss: " + ac + " - (" + roll + " + " + bonus + ") = " + (ac - (roll + bonus)));
        }
    }

    protected virtual void DestroyTarget()
    {
       
    }
}
