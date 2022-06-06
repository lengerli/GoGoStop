public abstract class GameAbstractState
{
    public bool isStateInitiated;
    public abstract void EnterState(GameManager gameManager);
    public abstract void UpdateState(GameManager gameManager);
    public abstract void ExitState(GameManager gameManager);

}
