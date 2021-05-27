using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class LoadScene : MonoBehaviour


{

    private PostProcessVolume _PostProcessVolume;
    private Vignette _Vignette;
    public float vignetteInput;
    public GameObject gm1;


    // Start is called before the first frame update
    void Start()
    {
        _PostProcessVolume = gm1.GetComponent<PostProcessVolume>();
        _PostProcessVolume.profile.TryGetSettings(out _Vignette);
    }

    // Update is called once per frame
    void Update()
    {
        _Vignette.intensity.value = vignetteInput;
    }
}
