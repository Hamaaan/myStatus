using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace naichilab
{
    public class UIManager : MonoBehaviour
    {
        StaticValueManager _svm;


        public Text LevelText;
        public Text ExpText;
        public Text PlayerName;
        public RadarChartPolygonUGUI RadarPolygon;

        public Image ExpFillImage;
        [SerializeField] float value = 0;

        // Start is called before the first frame update
        void Start()
        {
            _svm = StaticValueManager.instance;

            RadarPolygon.Volumes[0] = _svm.PlayerHP/_svm.MaxPlayerHP;
            RadarPolygon.Volumes[1] = _svm.PlayerSpeed/_svm.MaxPlayerSpeed;
            RadarPolygon.Volumes[2] = _svm.PlayerRange/_svm.MaxPlayerRange;
            RadarPolygon.Volumes[3] = _svm.PlayerDefence/_svm.MaxPlayerDefence;
            RadarPolygon.Volumes[4] = _svm.PlayerPower/_svm.MaxPlayerPower;

            ExpFillImage = ExpFillImage.GetComponent<Image>();

            PlayerName = PlayerName.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            LevelText.text = _svm.PlayerLevel.ToString();
            ExpText.text = _svm.PlayerExp.ToString();
            TransitionExp();
            PlayerName.text = OpeningSceneManager.GetUserName();
        }

        void TransitionExp()
        {
            float TransExp = _svm.PlayerExp - _svm.StockExp;
            ExpFillImage.fillAmount = TransExp / _svm.NextExp;
        }
    }
}