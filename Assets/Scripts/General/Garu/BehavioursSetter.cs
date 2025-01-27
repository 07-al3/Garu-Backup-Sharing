using UnityEngine;

public class BehavioursSetter : MonoBehaviour
{
    [SerializeField] private Behaviour[] scripts;

    public void setActive(bool status)
    {
        foreach (Behaviour script in scripts)
            script.enabled = status;
    }
}
