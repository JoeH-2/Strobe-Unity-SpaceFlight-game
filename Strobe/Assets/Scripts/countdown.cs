using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdown : MonoBehaviour
{ 
    public Movement movement;
    public Text CountText;
    public ParticleSystem Ps;
    public ParticleSystem Hyper;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(e321());
    }
    
    IEnumerator e321()
    {
        movement.enabled = false;
        Ps.Stop();
        Hyper.Stop();
        yield return new WaitForSeconds(3);
        CountText.text = "3";
        yield return new WaitForSeconds(0.5f);
        CountText.text = "2";
        yield return new WaitForSeconds(0.5f);
        CountText.text = "1";
        yield return new WaitForSeconds(0.5f);
        CountText.text = "";
        movement.enabled = true;
        Ps.Play();
        yield return new WaitForSeconds(0.2f);
        Hyper.Play();
    }
}