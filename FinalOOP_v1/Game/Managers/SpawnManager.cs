using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{
    public class SpawnManager
    {
        #region Singleton
        public static SpawnManager instance;

        public static SpawnManager Instance
        {
            get
            {

                if (instance == null)
                    instance = new SpawnManager();

                return instance;

            }
        }
        #endregion

        void SpawnPowerUp()
        {

            foreach (PowerUpsFactory.PowerUps actualPowerUp in Enum.GetValues(typeof(PowerUpsFactory.PowerUps)))
            {

                Program.Environment.Add(PowerUpsFactory.CreatePowerUp(actualPowerUp));


            }

        }

    }
}
