using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Pursuit
    {
        float timePrediction;
        Vector2 position;
        Vector2 targetPosition;
        Vector2 targetSpeed;

        public Pursuit(Vector2 _position, Vector2 _targetPosition, Vector2 _targetSpeed, float _timePrediction)
        {

            position = _position;
            targetPosition = _targetPosition;
            targetSpeed = _targetSpeed;
            timePrediction = _timePrediction;

        }

        public Vector2 GetDir()
        {

            float vel = Vector2.Magnitude(targetSpeed.X, targetSpeed.Y);
            Vector2 positionPrediction = targetPosition + Vector2.Right() * timePrediction * vel;
            Vector2 dir = Vector2.NormalizedVector(positionPrediction.X + position.X, positionPrediction.Y + position.Y);

            return dir;

        }
    }
}
