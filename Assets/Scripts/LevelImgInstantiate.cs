using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImgInstantiate : MonoBehaviour
{
    public GameObject imgparentpos; 
    public List<GameObject> Easy,Medium,Hard;
    private int index;
    private bool spawn;
    public void SpawnImage(string level)
    {
        switch (level)
        {
            case "Easy":
                spawner(Easy);
                break;
            case "Medium":
                spawner(Medium);
                break;
            case "Hard":
                spawner(Hard);
                break;
            default:
                Debug.Log("no difficulty selected");
                break;
        }
        setspawned();
    }
    private void spawner(List<GameObject> imgs)
    {
        index = Random.Range(0, imgs.Count - 1);
        Instantiateimg(imgs[index],imgparentpos);
    }
    public void Instantiateimg(GameObject img,GameObject pos)
    {
        GameObject Image = Instantiate(img, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Image.transform.SetParent(pos.transform);
        Image.transform.localScale = new Vector3(1, 1, 1);
        Image.transform.localPosition = new Vector3(0, 0, 0);
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
