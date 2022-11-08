using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataReaders
{
    /// <summary>
    /// Responsible for reading the data from a given CSV file and writing it's contents
    /// to the statically accessible "CrimeData" variable;
    /// </summary>
    public class CSVReader : MonoBehaviour
    {
        [SerializeField] private TextAsset textAssetData;
        
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
        
        public class CityList
        {
            public List<CityData> cityDataList;
        }
        public static CityList CrimeDataset = new CityList();

        //private Dictionary<City, CityData> cityDictionary = new Dictionary<City, CityData>();

        private void Start() => ReadCSV();

        private void ReadCSV()
        {
            string[] dataset = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

            const int NUM_OF_COLUMNS = 14;
            int tableSize = dataset.Length / NUM_OF_COLUMNS - 1; // ignore first row
            CrimeDataset.cityDataList = new List<CityData>(new CityData[tableSize]);

            for (int i = 0; i < tableSize; i++) // Reads column by column before moving to next row
            {
                CrimeDataset.cityDataList[i] = new CityData
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
        }
    }
}
