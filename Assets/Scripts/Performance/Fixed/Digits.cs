

using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Performance.Fixed
{
    public class Digits : MonoBehaviour
    {
        public GameObject digitsBox;

        public static readonly List<Vector3> Positions = new List<Vector3>();

        private void Start()
        {
            var i = 0;
            foreach ( Transform digit in digitsBox.transform )
            {
                digit.localScale = new Vector3( 3, 3, 3 );
                digit.position += new Vector3( i++ * 3f, 0, -3f );
                digit.GetComponent<MeshRenderer>().material.color = Color.Lerp( Color.cyan, Color.blue, i / 10.0f );
                Positions.Add( digit.transform.position );
            }
        }

        
        private void Update()
        {
            digitsBox.SetActive( Sort.className == "Radix" );
        }
    }
}