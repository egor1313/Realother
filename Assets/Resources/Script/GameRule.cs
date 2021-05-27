using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "dead"){
            SceneLoad(1);
        }

    }
    public void SceneLoad(int SceneNum){
        SceneManager.LoadScene(1);
    }
    public void quit(){
        Application.Quit();
    }
    
    public void playSound(AudioClip din){
        //AudioSource audio;

        //audio = GetComponent<AudioSource>();

        GetComponent<AudioSource>().PlayOneShot(din);

    }
}
