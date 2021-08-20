using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class PowerUpsFactory
    {
        public enum PowerUps { health, speed, damage, random}

        public static PowerUp CreatePowerUp(PowerUps powerUp, Vector2 position)
        {
            Random rnd = new Random();

            switch (powerUp)
            {
                case PowerUps.health:
                    return new HealthPowerUp(position, new Vector2(.5f, .5f), new Vector2(179, 118), new Vector2(10, 10), 10, 0, 10, 10, "Textures/PowerUps/HealthPowerUp.png");
                case PowerUps.speed:
                    return new SpeedPowerUp(position, new Vector2(.3f, .3f), new Vector2(296, 558), new Vector2(10, 10), new Vector2(5, 5), 10, 0, 10, "Textures/PowerUps/SpeedPowerUp.png");
                case PowerUps.damage:
                    return new DamagePowerUp(position, new Vector2(.4f, .4f), new Vector2(206, 205), new Vector2(20, 20), 10, 0, 10, 30, "Textures/PowerUps/DamagePowerUp.png");
                //case PowerUps.random:

                //    return new RandomPowerUp(position, new Vector2(.5f, .5f), new Vector2(666, 666), new Vector2(30, 30), 0, 10 , "Textures/PowerUps/RandomPowerUp.png");
                default:
                    return new HealthPowerUp(position, new Vector2(.5f, .5f), new Vector2(179, 118), new Vector2(10, 10), 10, 0, 10, 10, "Textures/PowerUps/HealthPowerUp.png");
            }
        }
    }
}
