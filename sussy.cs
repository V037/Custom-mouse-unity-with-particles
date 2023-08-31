using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sussy : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject ob1;
    [SerializeField] private GameObject ob2;
    [SerializeField] private GameObject prefab;
    private GameObject[] precount = new GameObject[120];
    private float[] ic = new float[120];

    [SerializeField] private Transform m_RectTransform;
    [SerializeField] private int countt = 0;

    RaycastHit hit;
    Ray ray;
    

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

        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            m_RectTransform.transform.position = hit.point;
        }
    }
}
