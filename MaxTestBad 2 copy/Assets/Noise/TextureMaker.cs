using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMaker : MonoBehaviour {

    public int resolution = 256;

    int _currentResolution = -1;

    public float scale = 4;

    float _currentScale = -1;

    public bool animate = true;

    public enum EMode {
        NOISEMODE_err = -1,
        NOISEMODE_FLAT,
        NOISEMODE_STATIC,
        NOISEMODE_PERLIN,
    }

    public EMode _mode = EMode.NOISEMODE_FLAT;
    EMode _eCurrentMode = EMode.NOISEMODE_err;

    private Texture2D texture;

    private void Awake()
    {
        MakeTexture();
        //FillTexture();

    }

    private void MakeTexture() 
    {
        if (texture != null)
            Destroy(texture);



        texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
        texture.name = "Procedural Texture";
        GetComponent<MeshRenderer>().material.mainTexture = texture;
    }

    private void FillTexture()
    {
        Vector3 point00 = transform.TransformPoint(new Vector3(-0.5f, -0.5f));
        Vector3 point10 = transform.TransformPoint(new Vector3(0.5f, -0.5f));
        Vector3 point01 = transform.TransformPoint(new Vector3(-0.5f, 0.5f));
        Vector3 point11 = transform.TransformPoint(new Vector3(0.5f, 0.5f));
        float stepSize = 1f / resolution;

        switch (_mode)
        {
            case EMode.NOISEMODE_FLAT:
                for (int y = 0; y < resolution; y++)
                {
                    for (int x = 0; x < resolution; x++)
                    {
                        texture.SetPixel(x, y, Color.red);
                    }
                }
                break;
            case EMode.NOISEMODE_STATIC:
                for (int y = 0; y < resolution; y++)
                {
                    Vector3 point0 = Vector3.Lerp(point00, point01, (y + 0.5f) * stepSize);
                    Vector3 point1 = Vector3.Lerp(point10, point11, (y + 0.5f) * stepSize);
                    for (int x = 0; x < resolution; x++)
                    {
                        Vector3 point = Vector3.Lerp(point0, point1, (x + 0.5f) * stepSize);
                        texture.SetPixel(x, y, Color.white * Random.value);
                    }
                }
                break;

            case EMode.NOISEMODE_PERLIN:

                float newNoise = Random.Range(0.0F, 10000.0F);

                for (int y = 0; y < resolution; y++)
                {
                    for (int x = 0; x < resolution; x++)
                    {
                        float localscale = resolution / scale;
                        texture.SetPixel(x, y, Color.white * Mathf.PerlinNoise(newNoise + (x / localscale), newNoise + (y / localscale)));
                    }
                }

                break;
        }
        texture.Apply();

    }

    // Use this for initialization
    void Start () {
		
	}


    float fAnimationTime = 0.0F;
    const float kfAnimationDuration = 1.0F / 10.0F; //x fps
	// Update is called once per frame
	void Update () {
        fAnimationTime += Time.deltaTime;

        bool bDoAnimation = false;
        if (animate && fAnimationTime >= kfAnimationDuration)
        {
            fAnimationTime = 0.0F;
            bDoAnimation = true;
        }
        resolution = Mathf.ClosestPowerOfTwo(resolution);
		if (_eCurrentMode!=_mode || _currentResolution != resolution || _currentScale != scale || bDoAnimation)
        {
            MakeTexture();
            FillTexture();
            _eCurrentMode = _mode;
            _currentResolution = resolution;
            _currentScale = scale;
        }
	}
}
