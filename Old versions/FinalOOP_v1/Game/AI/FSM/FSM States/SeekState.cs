using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SeekState<T> : FSMState<T>
    {
        //BossEnemy bossEnemy;
        FSM<T> fsm;
        T idleState;
        T attackState;

        public SeekState()
        {

        }

        public override void Awake()
        {

        }

    }
}
