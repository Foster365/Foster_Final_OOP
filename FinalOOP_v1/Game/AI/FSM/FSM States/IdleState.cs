using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class IdleState<T> : FSMState<T>
    {
        //BossEnemy bossEnemy;

        FSM<T> fsm;
        T seekState;

        public IdleState(/*BossEnemy _bossEnemy, */FSM<T> _fsm, T _seekState)
        {
            //bossEnemy = _bossEnemy;

            fsm = _fsm;
            seekState = _seekState;
        }

        public override void Awake()
        {

        }

        public override void Execute()
        {
            //Play Animation
            //if (dist <= enemyBoss.seekRange)
                fsm.Transition(seekState);
        }

        public override void Sleep()
        {

        }

    }
}
