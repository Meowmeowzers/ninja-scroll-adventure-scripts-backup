using UnityEngine;


[CreateAssetMenu(menuName = "ItemDropTable")]
public class ItemDropTableSO : ScriptableObject
{
    [SerializeField] GameObject[] _items;

    public void DropItem(Vector3 position)
	{
        int i = Random.Range(0, _items.Length);
        
        if(_items[i] != null){
            Instantiate(_items[i], position, Quaternion.identity);
        }
    }
}
