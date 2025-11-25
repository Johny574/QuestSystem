using UnityEngine;

public class CollectItemQueststep : Queststep {
    public ItemStack Items;

    public CollectItemQueststep(QueststepSO data, PlayerJournalComponent parttaker, Quest quest) : base(data, parttaker, quest) {
        Items = ((CollectItemQuestStepSO)data).Items;
        // parttaker.Behaviour.GetComponent<InventoryBehaviour>().Inventory.Added +=  OnItemCollected;
    }

    private void OnItemCollected(ItemStack stack, ItemStack[] inventory)
    {
        Items.Count -= stack.Count;
        if (Items.Count <= 0)
            Complete();
    }

    public override Vector2 Closestpoint(Vector2 origin) {
        // var currentScene = SceneManager.GetActiveScene().name;
        // if (SO.Scene != currentScene) {
        //     var path = LocationManager.Instance.BFS(currentScene, SO.Scene);
        //     return SceneTracker.Instance.Objects[typeof(TravelPoint)].Find(x => x.GetComponent<TravelPoint>().Destination.Equals(path[1])).transform.position;
        // }
        
        // if (SceneTracker.Instance.Objects.ContainsKey(typeof(ItemBehaviour))) {
        //     var items = SceneTracker.Instance.Objects[typeof(ItemBehaviour)].Where(x => x.GetComponent<ItemBehaviour>().Item.Stack.Item == Items.Item).ToList();
        //     var target = SceneTracker.Instance.GetClosestObject(items, origin);
        //     if (target != null) {
        //         return target.transform.position;
        //     }
        // }

        return Vector2.zero;
    }
}

