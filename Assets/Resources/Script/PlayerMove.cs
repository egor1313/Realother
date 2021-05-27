using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMove : MonoBehaviour
{
    
    public Rigidbody2D rb1;
    public float speed = 10f;
    public Transform tr1;

    private PostProcessVolume _PostProcessVolume;
    private ChromaticAberration _ChromaticAberration;
    
    public GameObject gm1;

    public float forceJump;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public float radius = 0.1f;

    public float xInput;

    

    private Animator _Animator;


    void Start() {
        
        _Animator = GetComponent<Animator>();

        _PostProcessVolume = gm1.GetComponent<PostProcessVolume>();
        
        _PostProcessVolume.profile.TryGetSettings(out _ChromaticAberration);
        

    }

    void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

    if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        
        Jump();

    }
    if (isGrounded){
        _Animator.SetBool("PostEffect", false);
    }
    else{
        _Animator.SetBool("PostEffect", true);
    }
    }

    private void Jump() {
        rb1.AddForce(new Vector2(0, forceJump));
        
    }
        
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float dirx = Input.GetAxis("Horizontal") * speed;

        tr1.Translate(dirx ,0, 0);

        

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundlayer);

        /*if(_boolUp){
        xInput = 0.6f;
        //Mathf.Lerp(_ChromaticAberration.intensity.value, 0.6f, t);
        //t += Time.deltaTime/Chromatic_speed;
        if(Chromatic_speed > 0){
            Chromatic_speed -= Time.deltaTime;
        }

        else{
            _boolUp = false;
            Chromatic_speed = 1;
            xInput = 0f;

        }
        }*/
        

        _ChromaticAberration.intensity.value = xInput;
        

    }
}
