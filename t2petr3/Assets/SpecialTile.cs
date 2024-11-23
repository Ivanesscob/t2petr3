using UnityEngine;

public abstract class SpecialTile : MonoBehaviour
{
    [SerializeField] protected int[] steps;
    protected int state = 0;
    protected int currentStep;
    protected bool isActive = false;
    public void Action()
    {
        currentStep++;
        if (currentStep > steps[state])
        {
            currentStep = 0;
            state++;
            if (isActive)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }
            if (state >= steps.Length)
            {
                state = 0;
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
