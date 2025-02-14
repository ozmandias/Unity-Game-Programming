using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMaker : MonoBehaviour {
        [SerializeField] float period = 1f;
        [SerializeField] float magnitude = 5f;

        void Start () {
            StartCoroutine (Wave());
        }
       
        IEnumerator Wave (){
            WaterMaker water = GetComponent<WaterMaker>();
            while (true){
                yield return new WaitForSeconds(period);
                int x = Random.Range(2,98);
                int z = Random.Range(2,98);
                water.MoveVertex (x,z,magnitude);
                water.MoveVertex (x-1,z,magnitude);
                water.MoveVertex (x+1,z,magnitude);
                water.MoveVertex (x,z-1,magnitude);
                water.MoveVertex (x,z+1,magnitude);
            }
        }
    }