using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRage=2f;
        Transform target;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
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
                GetComponent<Mover>().Stop();
            }

        }
        bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRage;
        }
        public void Attack(CombatTarget combatTarget)
        {
            target=combatTarget.transform;
        }
        public void Cancel()
        {
            target=null;
        }

    }
}