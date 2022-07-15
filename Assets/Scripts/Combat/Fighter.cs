using RPG.core;
using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {
        [SerializeField] float weaponRage=2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        float timeSinceLastAttack = 0;

        Animator animator;
        Transform target;
        private void Awake()
        {
            animator = GetComponent<Animator>();    
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastAttack+=Time.deltaTime;
            if (!target)
            {
                return;
            }
            if(!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
            }

        }
        void AttackBehavior()
        {
            if (timeSinceLastAttack>=timeBetweenAttacks)
            {
                animator.SetTrigger(MyTags.Animator.attack);
                timeSinceLastAttack = 0;
            }
            
        }
        bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRage;
        }
        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionSchedular>().StartAction(this);
            target=combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
        // animation
        void Hit()
        {

        }

    }
}