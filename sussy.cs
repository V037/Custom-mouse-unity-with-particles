using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sussy : MonoBehaviour
{
    [SerializeField] private GameObject ob1;
    [SerializeField] private GameObject ob2;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform m_RectTransform;

    [SerializeField] private int countt = 0;
    [SerializeField] private GameObject[] precount = new GameObject[60];
    [SerializeField] private float[] ic = new float[60];
    

    void Start()
    {   
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            while(precount[countt])
            {
                countt++;
            }
            precount[countt] = Instantiate(prefab, m_RectTransform.position, Quaternion.identity);
            ic[countt] = Time.time;
            //StartCoroutine(exxe(countt));
            countt = 0;
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.visible = false;
            ob1.SetActive(false);
            ob2.SetActive(true);
        }else
        {
            ob2.SetActive(false);
            ob1.SetActive(true);
        }

        for(int i = 0; i<precount.Length; i++)
        {
            if(ic[i] != 0)
            {
                if(ic[i]-Time.time <= -5)
                {
                    Destroy(precount[i]);
                }  
            }
        }

        m_RectTransform.position = Input.mousePosition;  
    }

    void exxeee(int i, float drool)
    {
        precount[i] = Instantiate(prefab, m_RectTransform.position, Quaternion.identity);
        
    }

    IEnumerator exxe(int i)
    {
        precount[i] = Instantiate(prefab, m_RectTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        Destroy(precount[i]);
        yield return 0;
    }
}
