using UnityEngine;

public class PhotoTransitions : MonoBehaviour
{
    public int spriteCount = 14;
    public float tickTimer = 1.0f;
    public float crossfadeTimer = 0.5f;
    public GameObject photo1 = null;
    public GameObject photo2 = null;
    public Texture2DArray texArray;
    private float _currentTick = 0.0f;
    private int _currentIndexPhoto1 = 0;
    private int _currentIndexPhoto2 = 1;
    private bool _isTickEven = true;

    void Start()
    {
        var material1 = photo1.GetComponent<Renderer>().material;
        material1.SetFloat("_Alpha", 1f);
        material1.SetTexture("_Tex_Array", texArray);
        var material2 = photo2.GetComponent<Renderer>().material;
        material2.SetFloat("_Alpha", 0f);
        material2.SetFloat("_Index", _currentIndexPhoto2);
        material2.SetTexture("_Tex_Array", texArray);
    }

    void Update()
    {
        _currentTick += Time.deltaTime;
        if (_currentTick > tickTimer)
        {
            _currentTick = 0f;

            if (_isTickEven)
                IncrementPhoto(ref _currentIndexPhoto1, ref photo1);
            else
                IncrementPhoto(ref _currentIndexPhoto2, ref photo2);
            LeanTween.value(gameObject, 1f, 0f, crossfadeTimer)
                .setOnUpdate((float val) =>
                {
                    if (_isTickEven)
                        Crossfade(ref photo1, ref photo2, val);
                    else
                        Crossfade(ref photo2, ref photo1, val);
                });
            _isTickEven = _isTickEven ? false : true;
        }
    }

    private void IncrementPhoto(ref int index, ref GameObject gameobj)
    {
        index += 2;
        index = index % spriteCount;

        var material = gameobj.GetComponent<Renderer>().material;
        material.SetFloat("_Index", index);
    }

    private void Crossfade(ref GameObject gameobj1, ref GameObject gameobj2, float val)
    {
        var material1 = gameobj1.GetComponent<Renderer>().material;
        material1.SetFloat("_Alpha", val);

        var material2 = gameobj2.GetComponent<Renderer>().material;
        material2.SetFloat("_Alpha", 1.0f - val);
    }
}
