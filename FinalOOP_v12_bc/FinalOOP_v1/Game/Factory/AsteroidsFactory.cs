using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class AsteroidsFactory
    {
        public enum AsteroidFactory { asteroid1, asteroid2, asteroid3, asteroid4, asteroid5}

        public static Entity CreateAsteroid(AsteroidFactory asteroid, Vector2 position)
        {
            //Nave1 = new Nave("Ship.png", 150, 400, (float)Math.Cos(0));
            //Nave2 = new Nave("ship.png", 250, 500, (float)Math.Sin(0)*200*250);
            //Nave3 = new Nave("ship.png", 50, 300, (float)Math.Cos(0)*50*250);
            switch (asteroid)
            {
                //Agrego opcion para agregar posicion random
                case AsteroidFactory.asteroid1:
                    return new Asteroid(position, new Vector2(0.5f, 0.5f), new Vector2(70, 61), 0, "Textures/Entities/Asteroids/Asteroid1.png", 5, 10, 5, new Vector2(60, 60));
                case AsteroidFactory.asteroid2:
                    return new Asteroid(position, new Vector2(0.5f, 0.5f), new Vector2(76, 63), 0, "Textures/Entities/Asteroids/Asteroid2.png", 10, 10, 3, new Vector2(30, 30));
                case AsteroidFactory.asteroid3:
                    return new Asteroid(position, new Vector2(0.5f, 0.5f), new Vector2(150, 112), 0, "Textures/Entities/Asteroids/Asteroid3.png", 10, 10, 8, new Vector2(30, 30));
                case AsteroidFactory.asteroid4:
                    return new Asteroid(position, new Vector2(0.5f, 0.5f), new Vector2(199, 165), 0, "Textures/Entities/Asteroids/Asteroid4.png", 5, 10, 5, new Vector2(50, 50));
                case AsteroidFactory.asteroid5:
                    return new Asteroid(position, new Vector2(0.5f, 0.5f), new Vector2(106, 96), 0, "Textures/Entities/Asteroids/Asteroid5.png", 30, 10, 10, new Vector2(10, 10));
                default:
                    return new Asteroid(position, new Vector2(0.5f, 0.5f), new Vector2(70, 61), 0, "Textures/Entities/Asteroids/Asteroid1.png", 5, 10, 50, new Vector2(30, 30));
            }
        }
    }
}
