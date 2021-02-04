﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Collider
    {

        //Vector2 position;
        //Vector2 scale;
        //float rotation;
        float radius;

        Transform transform;
        Renderer renderer;

        public float Radius { get => radius; set => radius = value; }

        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public List<Collider> Colliders = new List<Collider>();

        //public List<Collider> Colliders = new List<Collider>();

        public Collider(Transform transform, Renderer renderer, float radius)
        {
            transform = new Transform(transform.Position, transform.Scale, transform.Rotation);
            renderer = new Renderer(renderer.Size, null, transform);
        }

        public abstract bool CheckforCollisions(Entity target);


        
    }
}
