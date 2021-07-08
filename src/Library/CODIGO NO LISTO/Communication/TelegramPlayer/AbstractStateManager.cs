using System;

namespace Library
{
    public enum PlayerState 
    {
        waitingForStart,
        waitingForJoin,
        waitingForStartGame,
        positioningVessel,
        positioningItem,
        attacking,
    }
    public abstract class AbstractPlayerStateManager : AbstractCommunicationManager
    {        
        public PlayerState State {get; set;}

        public AbstractPlayerStateManager(long id, IPrinter clientP)
        :base(id, clientP)
        {
            this.State = PlayerState.waitingForStart;
        }
        public bool IsWaitingStart()
        {
            return this.State == PlayerState.waitingForStart;
        }
        public bool IsWaitingForJoin()
        {
            return this.State == PlayerState.waitingForJoin;
        }
        public bool IsWaitingForStartGame()
        {
            return this.State == PlayerState.waitingForStartGame;
        }
        public bool IsPositioningVessel()
        {
            return this.State == PlayerState.positioningVessel;
        }
        public bool IsPositioningItem()
        {
            return this.State == PlayerState.positioningItem;
        }
        public bool IsAttacking()
        {
            return this.State == PlayerState.attacking;
        }
        public void NextState()
        {
            this.State = (PlayerState)(((int)this.State + 1) % 7);
        }
        public void PreviousState()
        {
            this.State = (PlayerState)((int)this.State - 1);
        }

    }    

}