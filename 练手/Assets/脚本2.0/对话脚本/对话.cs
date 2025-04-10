using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas;
using UnityEngine.UI;
using NodeCanvas.DialogueTrees;
using NodeCanvas.Tasks.Actions;
public class 对话 : MonoBehaviour
{
    DialogueTreeController 对话脚本;
    public GameObject 对话泡;
    // Start is called before the first frame update
    void Start()
    {
        对话脚本= GetComponent<DialogueTreeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            对话泡.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& Input.GetKeyDown(KeyCode.E))
        {
                
                对话脚本.StartDialogue();
                
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag("Player"))
        {
            对话泡.SetActive(false);
            对话脚本.StopDialogue();
        }
    }
}
