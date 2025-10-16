using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Animator storytellerAnimator;

    public void StartScene()
    {
        storytellerAnimator.SetTrigger("StartIntro");
    }
}
