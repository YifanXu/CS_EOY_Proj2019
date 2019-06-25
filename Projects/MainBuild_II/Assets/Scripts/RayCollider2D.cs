using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class RayCollider2D
    {
        public RaycastHit2D groundUp { get; set; }
        public RaycastHit2D groundDown { get; set; }
        public RaycastHit2D groundLeft { get; set; }
        public RaycastHit2D groundRight { get; set; }

        /// <summary>
        /// Make generic RayCastHit2D objects for game object.
        /// </summary>
        public RayCollider2D(Vector2 origin, float distance)
        {
            groundUp = Physics2D.Raycast(origin, Vector2.up, distance);
            groundDown = Physics2D.Raycast(origin, Vector2.down, distance);
            groundLeft = Physics2D.Raycast(origin, Vector2.left, distance);
            groundRight = Physics2D.Raycast(origin, Vector2.right, distance);
        }
    }
}
