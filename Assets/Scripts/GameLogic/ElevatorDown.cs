

namespace GameLogic
{
    public class ElevatorDown : Elevator
    {
        void FixedUpdate()
        {
            Move();
        }

        protected override void Move()
        {
            if (IsActivated())
            {
                MoveDown();
            }
            else
            {
                MoveUp();
            }
        }
    }
}