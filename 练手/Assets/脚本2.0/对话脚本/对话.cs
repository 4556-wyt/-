using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas;
using UnityEngine.UI;
using NodeCanvas.DialogueTrees;
using NodeCanvas.Tasks.Actions;
public class �Ի� : MonoBehaviour
{
    DialogueTreeController �Ի��ű�;
    public GameObject �Ի���;
    // Start is called before the first frame update
    void Start()
    {
        �Ի��ű�= GetComponent<DialogueTreeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            �Ի���.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& Input.GetKeyDown(KeyCode.E))
        {
                
                �Ի��ű�.StartDialogue();
                
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag("Player"))
        {
            �Ի���.SetActive(false);
            �Ի��ű�.StopDialogue();
        }
    }
}
