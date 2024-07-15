using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //สร้างประเภทของ Player
	public enum PlayerType
	{
		Player1,Player2
	};
	
	public static float MAX_HEALTH = 1000f;
	public float health = MAX_HEALTH;
    public string fighterName;
    public Fighter oponent;
    public bool enable;
    public PlayerType player;
    public FighterStates currentState = FighterStates.IDLE;

    public Rigidbody mybody;
    protected Animator animator;
    private AudioSource audio;
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        animator.SetFloat("HEALTH",healthPercent);

            if(oponent !=null)
            {
                animator.SetFloat("OPPONENT",oponent.healthPercent);
            }
            else
            {
                animator.SetFloat("OPPONENT",1);
            }

            if(health <= 0 && currentState != FighterStates.DEAD)
            {
                animator.SetTrigger("DEAD");
            }


        if(enable)
        {
            if (player == PlayerType.Player1)
            {
                ControlPlayer1();
            }
            else
            {
                ControlPlayer2();
            }
        }      
    }

    public void ControlPlayer1()
    {
        if(Input.GetAxis("Horizontal1") > 0.1)
        {
            animator.SetBool("WALK", true);
        }
        else
        {
            animator.SetBool("WALK", false);
        }
		if(Input.GetAxis("Horizontal1") < -0.1)
        {
            animator.SetBool("WALK_BACK", true);
        }
        else
        {
            animator.SetBool("WALK_BACK", false);
        }
		if(Input.GetAxis("Vertical1") < -0.1)
        {
            animator.SetBool("SIT", true);
        }
        else
        {
            animator.SetBool("SIT", false);
        }
		if(Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("JUMP");
        }
		if(Input.GetKeyDown(KeyCode.N))
        {
            animator.SetTrigger("PUNCH");
        }
		if(Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("KICK");
        }
    }
     public void ControlPlayer2()
    {
        if(Input.GetAxis("Horizontal2") > 0.1)
        {
            animator.SetBool("WALK", true);
        }
        else
        {
            animator.SetBool("WALK", false);
        }
		if(Input.GetAxis("Horizontal2") < -0.1)
        {
            animator.SetBool("WALK_BACK", true);
        }
        else
        {
            animator.SetBool("WALK_BACK", false);
        }
		if(Input.GetAxis("Vertical2") < -0.1)
        {
            animator.SetBool("SIT", true);
        }
        else
        {
            animator.SetBool("SIT", false);
        }
        
		if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("JUMP");
        }
		if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("PUNCH");
        }
		if(Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("KICK");
        }
    }
    public void playsound(AudioClip sound)
    {
        SoundManager.playsound(sound,audio);
    }

    public bool defending
    {
        get 
        {
            return currentState == FighterStates.DEFEND
                || currentState == FighterStates.TAKE_HIT_DEFEND;
        }
    }

    public bool attacking
    {
        get
        {
            return currentState == FighterStates.ATTACK;
        }
    }

    public float healthPercent
    {
        get 
        {
            return health / MAX_HEALTH;
        }
    }

    public Rigidbody body
    {
        get
        {
            return this.mybody;
        }
    }
    //decreased HP
    public virtual void takeDamage(float damage)
    {
        if(defending)
        {
            damage *=0.2f;
        }
        if(health >= damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
    //GET HIT AND ANIMATION TRIGGER
        if (health > 0)
        {
            animator.SetTrigger("TAKE_HIT");
        }
    }
}
