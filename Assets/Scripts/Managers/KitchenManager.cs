using UnityEngine;

public class KitchenManager : MonoBehaviour, IGameManager{

    [SerializeField] private GameObject first;
    [SerializeField] private GameObject second;
    [SerializeField] private GameObject recipe;


    public void GenerateRecipe() {
        throw new System.NotImplementedException();
    }
    
    
    public ManagerStatus Status { get; set; }
    public void Startup() {
        Status = ManagerStatus.Started;
    }
    

  
}