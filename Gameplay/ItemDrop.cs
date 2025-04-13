using UnityEngine;

public class ItemDrop: MonoBehaviour
{
    [SerializeField] ItemDropTableSO _dropTable;
 
    public void DropItem(Vector3 position)
	{
        _dropTable.DropItem(position);
    }
}
