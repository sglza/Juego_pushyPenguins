using System;
using Source.Components;
using UnityEngine;

namespace Source.Systems
{
    /**
     * This is a template
     */

    public class CollisionResolverSystem : MonoBehaviour
    {

        public Transform move;

        private void OnCollisionEnter(Collision other)
        {
            switch (other.collider.tag)
            {
                case "Item":
                    handleItem(other);
                    break;
                case "Enemy":
                    handleEnemy(other);
                    break;
                case "death":
                    handleDeath(other);
                    break;
            }
        }

        private void handleEnemy(Collision collider)
        {
            
        }

        private void handleItem(Collision other)
        {
            other.gameObject.SetActive(false);
        }

        private void handleDeath(Collision col) {
            
        }

    }
}