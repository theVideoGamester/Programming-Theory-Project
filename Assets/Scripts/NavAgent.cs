using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Parent class of Player and Enemy. Controls Combat and Movement capabilities
public abstract class NavAgent : MonoBehaviour
{
    /*
    protected NavMeshAgent agent;
    
    protected states myState;
    
    protected GameObject target;
    
    protected NavAgent targetAgent;
    protected int hp;
    protected int maxHP;
    protected Weapon myWeapon;
    protected float attackSpeed = 2f;
    protected HealthBar healthBar;
    protected AudioSource audioSource;
    public AudioClip hurtSound;

    

    protected void setAgent()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        myState = states.idle;
        hp = maxHP;
        healthBar = gameObject.GetComponentInChildren<HealthBar>();

        //Abstraction
        healthBar.SetMaxHealth(maxHP);

        audioSource = GetComponent<AudioSource>();
    }

    protected bool endMovement()
    {
        if (!agent.hasPath && agent.enabled)
        {
            agent.enabled = false;
            obstacle.enabled = true;
            myState = states.idle;
            return true;
        }
        return false;
    }

    protected void startMovement(Vector3 destination)
    {
        obstacle.enabled = false;
        agent.enabled = true;
        agent.destination = destination;
    }

    protected void Attack()
    {
        //Abstraction
        targetAgent.TakeDamage(myWeapon.damage);
    }

    protected bool CheckTargetDistance()
    {
        if (target != null && Vector3.Distance(transform.position, target.transform.position) < myWeapon.range)
        {
            return true;
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        //Abstraction
        healthBar.SetHealth(hp);
        PlayHurtSound();

        if (hp <=0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtSound,1);
    }
    */

    /*
    #region detection
    private bool Detection()
    {
        float distance = visionDistance;

        if (player.noisy)
        {
            distance = hearingDistance;
        }

        if (Vector3.Distance(transform.position, playerTransform.position) <= distance)
        {
            //Abstraction
            if (CanSeePlayer() && IsLineOfSite(distance))
            {
                return true;
            }
        }
        return false;
    }
    

   
    #endregion
    */
}
