using UnityEngine;

public abstract class SpecialTile : MonoBehaviour
{
    [SerializeField] protected int[] steps;
    protected int state = 0;
    protected int currentStep;
    public bool isActive = false;
    [HideInInspector] public MazeGenerator generator;
    [HideInInspector] public BeatManager manager;
    public void Action()
    {
        currentStep++;
        if (currentStep >= steps[state])
        {
            currentStep = 0;
            state++;
            if (state >= steps.Length)
            {
                state = 0;
            }
            if (isActive)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }
        }
        if(isActive)
        {
            DoAction();
        }
        else
        {
            DoOther();
        }
    }
    public abstract void DoAction();
    public abstract void DoOther();
}
