using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace naichilab
{
    public class GraphEditor : MonoBehaviour
    {
        [SerializeField] List<int> GameResult = new List<int>();

        [SerializeField] RadarChartPolygonUGUI radarChart;

        // Start is called before the first frame update
        void Start()
        {
            radarChart = radarChart.GetComponent<RadarChartPolygonUGUI>();
            for(int i = 0; i < 5; i++)
            {
                //ミニゲーム結果をGameResultに代入
            }
        }

        // Update is called once per frame
        void Update()
        {
            //ミニゲーム結果を反映
            radarChart.Volumes[0] = 5f;
        }
    }

}