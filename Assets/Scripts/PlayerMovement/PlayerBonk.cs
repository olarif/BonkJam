using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonk : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Animator bonkAnim;

    public Transform attackPos;
    public float attackRange;
    public LayerMask enemy;
    public int damage;

    private void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //FindObjectOfType<AudioManager>().Play("Bonk");

                Collider2D[] enemiesToBonk = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);

                for(int i = 0; i < enemiesToBonk.Length; i++)
                {
                    //enemiesToBonk[i].GetComponent<Enemy>().TakeDamage(damage);

                    if (!DialogueManager.GetInstance().isPlaying) {
                        enemiesToBonk[i].GetComponent<DialogueTrigger>().StartDialogue();
                    }
                    
                }

                bonkAnim.SetTrigger("Bonk");

                timeBetweenAttack = startTimeBetweenAttack;
            }

            
        } else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
