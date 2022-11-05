using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Testing
{
    public class CSVReader : MonoBehaviour
    {
        [SerializeField] private TextAsset textAssetData;

        [Serializable]
        public class CityData
        {
            public int year;
            public string name;
            public int totalHomicides;
            public int totalHarrassments;
            public int totalKidnappings;
            public int totalRobberies;
            public int totalDomesticBurglaries;
            public int totalShoplifting;
            public int totalTheft;
            public int totalArson;
            public int totalCriminalDamageOffences;
            public int totalDrugOffences;
            public int totalWeaponPossession;
            public int totalOffences;
        }

        [Serializable]
        public class CityList
        {
            public List<CityData> cityData;
        }
        public CityList myCityList = new CityList();

        //private Dictionary<City, CityData> cityDictionary = new Dictionary<City, CityData>();


        private void Start()
        { 
            ReadCSV();   
        }

        private void ReadCSV()
        {
            string[] dataset = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

            const int NUM_OF_COLUMNS = 14;
            int tableSize = dataset.Length / NUM_OF_COLUMNS - 1; // ignore first row
            //myCityList.cityData = new CityData[tableSize];
            myCityList.cityData = new List<CityData>(new CityData[tableSize]);

            for (int i = 0; i < tableSize; i++) // Reads column by column for each row
            {
                myCityList.cityData[i] = new CityData
                {
                    year = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1)]),
                    name = dataset[NUM_OF_COLUMNS * (i + 1) + 1],
                    totalHomicides = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 2]),
                    totalHarrassments = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 3]),
                    totalKidnappings = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 4]),
                    totalRobberies = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 5]),
                    totalDomesticBurglaries = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 6]),
                    totalShoplifting = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 7]),
                    totalTheft = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 8]),
                    totalArson = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 9]),
                    totalCriminalDamageOffences = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 10]),
                    totalDrugOffences = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 11]),
                    totalWeaponPossession = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 12]),
                    totalOffences = int.Parse(dataset[NUM_OF_COLUMNS * (i + 1) + 13])
                };
            }

            int row = 1;
            int column = 2;
            Debug.Log("ROW: " + row + ", COLUMN: " + column + ": "+ dataset[NUM_OF_COLUMNS * (row-1 + 1) + column-1]);
            
            /*if (dataset.Contains("Avon"))
            {
                Debug.Log("hello");
            }*/

            /*if (myCityList.cityData.Contains("year"))
            {
                
            }*/

            /*Dictionary<string, CityData> cityDict = new Dictionary<string, CityData>();
            CityData cityData = new CityData();
            if (myCityList.cityData.Contains(cityDict["j"]))
            {
                
            }*/
        }
    }
}
