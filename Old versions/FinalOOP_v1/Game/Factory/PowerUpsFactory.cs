using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class PowerUpsFactory
    {
        public enum PowerUps { life, speed, damage, random}

        public static Item CreatePowerUp(PowerUps powerUp)
        {
            Random rnd = new Random();

            switch (powerUp)
            {
                case PowerUps.life:
                    return new HealthPowerUp(new Vector2(rnd.Next(100, 500), rnd.Next(100, 300)), new Vector2(.5f, .5f), new Vector2(320, 270), new Vector2(10, 10), 0, 10, 10, "Textures/PowerUps/HealthPowerUp.png");
                case PowerUps.speed:
                    return new SpeedPowerUp(new Vector2(rnd.Next(150, 200), rnd.Next(200, 400)), new Vector2(.3f, .3f), new Vector2(296, 558), new Vector2(5, 5), 0, 10, 50, "Textures/PowerUps/SpeedPowerUp.png");
                case PowerUps.damage:
                    return new DamagePowerUp(new Vector2(rnd.Next(200, 300), rnd.Next(300, 500)), new Vector2(.4f, .4f), new Vector2(233, 266), new Vector2(20, 20), 0, 10, 30, "Textures/PowerUps/DamagePowerUp.png");
                case PowerUps.random:

                    return new RandomPowerUp(new Vector2(rnd.Next(400, 450), rnd.Next(450, 500)), new Vector2(.5f, .5f), new Vector2(666, 666), new Vector2(30, 30), 0, 10 , "Textures/PowerUps/RandomPowerUp.png");
                default:
                    return new HealthPowerUp(new Vector2(rnd.Next(100, 500), rnd.Next(100, 300)), new Vector2(.5f, .5f), new Vector2(320, 270), new Vector2(10, 10), 0, 10, 10, "Textures/PowerUps/HealthPowerUp.png");
            }
        }
    }
}
