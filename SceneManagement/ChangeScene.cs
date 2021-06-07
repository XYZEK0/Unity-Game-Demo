using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string toScene;
    private SceneController sceneController;
    private SceneItems1 item1;
    private SceneItems2 item2;
    private SceneItems3 item3;
    private bool isInstance1 = false;
    private bool isInstance2 = false;
    private bool isInstance3 = false;

    public PlayerController playerController = null;
    public Animator levelAnim = null;
    public float transitionTime;
    

    private void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        if (SceneItems1.instance != null)
        { 
            item1 = SceneItems1.instance;
            isInstance1 = true;
        }
        if (SceneItems2.instance != null)
        {
            item2 = SceneItems2.instance;
            isInstance2 = true;
        }
        if (SceneItems3.instance != null)
        {
            item3 = SceneItems3.instance;
            isInstance3 = true;
        }
}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerController.playerRB.Sleep();
            playerController.gameObject.GetComponent<PlayerMovement>().enabled = false;
            playerController.gameObject.GetComponent<PlayerController>().enabled = false;
            playerController.gameObject.GetComponent<Animator>().enabled = false;
            LoadScene();
        }

    }

    private void LoadScene()
    {
        StartCoroutine(LoadDelay());
    }

    public IEnumerator LoadDelay()
    {
        levelAnim.SetTrigger("Fading");

        yield return new WaitForSeconds(transitionTime);



        switch (toScene)
        {
            case "Scene1":
            {
                Debug.Log("Scena1");
                if (isInstance1)
                    item1.gameObject.SetActive(true);
                if (isInstance2)
                    item2.gameObject.SetActive(false);
                if (isInstance3)
                    item3.gameObject.SetActive(false);
                break;
            }
            case "Scene2":
            {
                Debug.Log("Scena2");
                if (isInstance1)
                    item1.gameObject.SetActive(false);
                if (isInstance2)
                    item2.gameObject.SetActive(true);
                if (isInstance3)
                    item3.gameObject.SetActive(false);
                break;
            }
            case "Scene3":
            {
                Debug.Log("Scena3");
                if (isInstance1)
                    item1.gameObject.SetActive(false);
                if (isInstance2)
                    item2.gameObject.SetActive(false);
                if (isInstance3)
                    item3.gameObject.SetActive(true);
                break;
            }
            default:
            {
                Debug.Log("brak sceny");
                break;
            }
        }

        playerController.playerRB.WakeUp();
        playerController.gameObject.GetComponent<PlayerMovement>().enabled = true;
        playerController.gameObject.GetComponent<PlayerController>().enabled = true;
        playerController.gameObject.GetComponent<Animator>().enabled = true;
        sceneController.ChangeScene(toScene);
    }
}
