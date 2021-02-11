﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : Entity, /* EnemyAbs, */ICharacter //Clase abstracta de la cual heredan los enemigos. overraid en update (Aplico las trayectorias como en los métodos)
    {
        //Variables

        //

        //float rotation;
        //Vector2 scale;

        Vector2 position;

        //Vector2 size;
        //string texture;
        //float radius;

        //int life;

        //bool destroyed;

        //float lifeTime;
        //float lifeTimer;

        //float angle;

        //ObjectsPool<EnemyBullet> bulletsPool;

        float timerShoot;
        float timetoShoot;

        ////

        ////Encapsuladas
        //public Vector2 EnemyPosition { get => enemyPosition; set => enemyPosition = value; }
        //public Vector2 EnemySpeed { get => enemySpeed; set => enemySpeed = value; }

        //public Vector2 Scale { get => scale; set => scale = value; }
        //public float Rotation { get => rotation; set => rotation = value; }

        //public Vector2 Size { get => size; set => size = value; }
        //public string Texture { get => texture; set => texture = value; }
        //public float Radius { get => radius; set => radius = value; }

        //public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        //public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }
        //public float Angle { get => angle; set => angle = value; }
        //public Renderer Renderer { get => renderer; set => renderer = value; }


        //

        public Enemy(Vector2 _position, float _rotation, Vector2 _scale, Vector2 _size, Vector2 _enemySpeed, string _texture, int _life, float _angle, float _colliderRadius) : base(_position, _scale, _size, _rotation, _texture, _colliderRadius)/*(position, rotation, scale, size, enemySpeed, texture, life)*/
        {

            //Transform = new Transform(_position, _scale, _rotation);
            //Renderer = new Renderer(_size, _texture, Transform);

            //CircleCollider = new CircleCollider(Transform, Renderer, _colliderRadius);
            //BoxCollider = new BoxCollider(Transform, Renderer, _colliderRadius);

            Angle = _angle - 90;

            //circleCollider = new CircleCollider(enemyPosition, _scale, _rotation, _size, _colliderRadius);

            //life = life;

            position = new Vector2(Transform.Position.X, Transform.Position.Y);
            LifeTime = 5;
            Speed = _enemySpeed;
            timetoShoot = 0.8f;


        }

        public override void Update()//Ver bien esto
        {
            if (!Destroyed)
            {

                Move();

                LifeTime += Time.DeltaTime;
                if (LifeTimer >= LifeTime)
                    Level1Screen.RenderizableObjects.Remove(this);


            }

        }

        public void Shoot()
        {
            //var enemyBullet = bulletsPool.Get();
            //enemyBullet.Init(enemyPosition, new Vector2(1, 1), new Vector2(24, 27), 0, "Textures/BulletEnemy1.png", 3);
            //Console.WriteLine("PlayerPos.X"+ playerPos.X + "PlayerPos.Y" + playerPos.Y, "bulletScale.X" + bullet.BulletScale.X + "bulletScale.Y" + bullet.BulletScale.Y + "bulletSize.X" + bullet.BulletSize.X + "bulletSize.Y" + bullet.BulletSize.Y, "bulletRotation" + bullet.BulletRotation + "bulletTexture" + bullet.BulletTexture);

        }

        public override void Move()
        {
            position.X -= Speed.X * Time.DeltaTime;
        }

        public void CheckforCollisions()
        {

        }

        public override void TakeDamage(float damage)
        {
            if(Damaged)
            {
                CurrentHealth -= damage;
                if (CurrentHealth <= 0)
                    Die();
            }
        }

        public override void Die()
        {
            Level1Screen.Enemies.Remove(this);
        }

        public override void Render()
        {
            if (!Destroyed)
            {

                Engine.Draw(Renderer.Texture, position.X, position.Y, Transform.Scale.X, Transform.Scale.Y, Angle, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

            }
        }
    }
}
