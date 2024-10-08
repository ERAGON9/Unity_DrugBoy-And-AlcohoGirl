

namespace GameLogic
{
    public class ElevatorUp : Elevator
    {
        void FixedUpdate()
        {
            Move();
        }
        
        protected override void Move()
        {
            if (IsActivated())
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
    }
}