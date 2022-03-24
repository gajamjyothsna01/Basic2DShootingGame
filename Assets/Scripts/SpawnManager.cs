using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject enemyprefab;
    public Vector3 offset;
    public float time;
    Stack<GameObject> stackOfBullet = new Stack<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            stackOfBullet.Push(Instantiate(bulletPrefab));
            bulletPrefab.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateBullet();
            //Instantiate(bulletPrefab, transform.position+offset, Quaternion.identity);
        }
        time = time + Time.deltaTime;
        if(time >= 3.0f)
        {
            float x = Random.Range(-13.0f, 13.0f);
            float y = Random.Range(0.0f, 4.0f);
            Instantiate(enemyprefab, new Vector3(x, y, 0), Quaternion.identity);
            time = 0.0f;
        }
    }
   
    private void CreateBullet() //This method is for to Pop out the bullet for resusing purposes.
    {
        GameObject tempBullet = stackOfBullet.Pop();
        tempBullet.SetActive(true);
        tempBullet.transform.position = transform.position + offset;
    }
    public void BackToPool(GameObject obj) // Here, the bullet goes into the pool.
    {
        obj.SetActive(false);
        stackOfBullet.Push(obj);

    }

}
