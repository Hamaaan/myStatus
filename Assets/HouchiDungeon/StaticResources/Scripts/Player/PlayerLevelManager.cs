using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class PlayerLevelManager : MonoBehaviour
    {
        StaticValueManager _svm;

        //最大値との比率
        private float RatioHP;
        private float RatioSpeed;
        private float RatioRange;
        private float RatioDefence;
        private float RatioPower;

        //増加分
        private int PlusHP;
        private int PlusSpeed;
        private int PlusRange;
        private int PlusDefence;
        private int PlusPower;


        // Start is called before the first frame update
        void Start()
        {
            _svm = StaticValueManager.instance;

            RatioHP = _svm.PlayerHP / _svm.MaxPlayerHP;
            RatioSpeed = _svm.PlayerSpeed / _svm.MaxPlayerSpeed;
            RatioRange = _svm.PlayerRange / _svm.MaxPlayerRange;
            RatioDefence = _svm.PlayerDefence / _svm.MaxPlayerDefence;
            RatioPower = _svm.PlayerPower / _svm.MaxPlayerPower;
        }

        // Update is called once per frame
        void Update()
        {
            CaliculateExp();
        }

        void CaliculateExp()
        {
            float TransExp = _svm.PlayerExp - _svm.StockExp;

            if (TransExp >= _svm.NextExp)
            {
                LevelUp();

            }
        }


        public void LevelUp()
        {
            _svm.StockExp = _svm.BeforeExp + _svm.NextExp;
            _svm.BeforeExp = _svm.NextExp;
            _svm.NextExp = (_svm.BeforeExp * 1.1f + (float)(_svm.PlayerLevel * 15)) / 2f;
            _svm.PlayerLevel++;
            StatusUp();
        }

        public void StatusUp()
        {
            //増加分計算
            PlusHP = (int)(RatioHP / 0.2f) + 1;
            PlusSpeed = (int)(RatioSpeed / 0.2f) + 1;
            PlusRange = (int)(RatioRange / 0.2f) + 1;
            PlusDefence = (int)(RatioDefence / 0.2f) + 1;
            PlusPower = (int)(RatioPower / 0.2f) + 1;

            //ステータスに反映
            _svm.PlayerHP += (float)PlusHP;
            _svm.PlayerSpeed += (float)PlusSpeed;
            _svm.PlayerRange += (float)PlusRange;
            _svm.PlayerDefence += (float)PlusDefence;
            _svm.PlayerPower += (float)PlusPower;

            //比率を維持
            _svm.MaxPlayerHP = _svm.PlayerHP / RatioHP;
            _svm.MaxPlayerSpeed = _svm.PlayerSpeed / RatioSpeed;
            _svm.MaxPlayerRange = _svm.PlayerRange / RatioRange;
            _svm.MaxPlayerDefence = _svm.PlayerDefence / RatioDefence;
            _svm.MaxPlayerPower = _svm.PlayerPower / RatioPower;
        }

    }


