using System.Collections;
using UnityEngine;

public class RaisePower : MonoBehaviour
{

    private PlayerController pc;
    private IEnumerator effectExit;
    // Use this for initialization
    void Start()
    {
        pc = GetComponent<PlayerController>();
        effectExit = EffectExit(pc.ReleaseTime);
        Raise();
    }

    void Raise()
    {
        StartCoroutine(effectExit);
    }

    IEnumerator EffectExit(float delay)
    {
        yield return new WaitForSeconds(delay);
        // this.enabled = false; // 現状デストロイの方が分かりやすいが、軽いならこちらに切り替え予定
        Destroy(this);
    }
}
