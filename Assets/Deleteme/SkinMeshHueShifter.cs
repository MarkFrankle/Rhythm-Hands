using UnityEngine;

public class SkinMeshHueShifter : MonoBehaviour
{
    public float Speed = 1;
    private SkinnedMeshRenderer rend;

    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
    }
}