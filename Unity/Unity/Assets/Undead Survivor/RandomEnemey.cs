using UnityEngine;



public class RandomEnemey : MonoBehaviour
{
    private float currTime;
    private Vector3 pos0;
    private Vector3 pos1; // 랜덤한 구 가장자리 좌표 값 
    private Vector2 pos2; // 2차원 ver
    [SerializeField] private GameObject Farmer;
    [SerializeField] private GameObject Enemey;

    public void Update() 
{

    currTime += Time.deltaTime;
    if (currTime >= 3f)
    {
        pos1= Random.onUnitSphere * 10;
        pos0 = new Vector3(pos1.x, pos1.y,0f);
        pos0 += Farmer.transform.position;
        Instantiate( Enemey, pos0, Quaternion.identity);
        currTime =0f;
    }
}

}
