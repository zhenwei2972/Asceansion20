using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImgInstantiate : MonoBehaviour
{
    public List<GameObject> Easy;
    private bool spawn;
    public void SpawnImage(string level)
    {
        switch (level)
        {
            case "Easy":
                int index = Random.Range(0, Easy.Count - 1);
                GameObject Image = Instantiate(Easy[index], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                Image.transform.SetParent(GameObject.Find("Img").transform);
                Image.transform.localScale = new Vector3(1, 1, 1);
                Image.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case "Medium":
                break;
            case "Hard:":
                break;
            default:
                Debug.Log("no difficulty selected");
                break;
        }
        setspawned();
    }
    public void setspawned()
    {
        this.spawn = !this.spawn;
    }
    public bool isspawned()
    {
        return this.spawn;
    }
}
