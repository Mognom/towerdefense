using UnityEngine;
using System.Collections.Generic;

public class SpawningPools : MonoBehaviour {
	
	
	private int lol;
	private static Dictionary<GameObject, List<GameObject>> pools;
	private static Dictionary<GameObject,GameObject> activeObjects;	
	
	/*
	 * Otorga una instancia del prefab pedido, y la coloca en la posicion y rotacion elegidas.
	 * En caso de no haber ninguna instancia libre crea una mas para la pool
	 * En caso de no haber ninguna pool del objeto crea una pool nueva
	 */
	
	public static GameObject spawn (GameObject prefab, Vector3 position, Quaternion rotation){
		if (pools == null) {
			pools = new Dictionary<GameObject, List<GameObject>> ();
			activeObjects = new Dictionary<GameObject, GameObject>();
		}
		
		List<GameObject> prefabPool;
		GameObject result;
		//Si ya existia la pool previamente
		if (pools.ContainsKey (prefab)) {
			print ("existia");
			prefabPool = pools [prefab];
			//Hay objetos disponibles en la pool
			if (prefabPool.Count > 0) {
				//Obtiene el objeto y lo saca de la pool
				result = prefabPool [0];
				prefabPool.RemoveAt (0);
				
				result.SetActive (true);
				result.transform.position = position;
				result.transform.rotation = rotation;
			}
			//No hay objetos disponibles en la pool
			else {
				result = (GameObject) Instantiate (prefab, position, rotation);
			}
		}
		//No existe la pool -> la crea
		else {
			pools.Add(prefab, new List<GameObject>());
			result = (GameObject) Instantiate ((Object)prefab, position, rotation);
		}
		activeObjects.Add(result, prefab);
		return result;
	}
	
	
	//Desactiva el objeto para que este disponible en la pool de nuevo.
	public static void recycle (GameObject gObject){
		GameObject key;
		
		//Si ya existia la pool
		if (activeObjects.ContainsKey (gObject)) {
			print ("desactiva");
			gObject.SetActive (false);
			
			key = activeObjects[gObject];
			pools[key].Add (gObject);
			print(activeObjects.Remove(gObject));
		}
	}
}