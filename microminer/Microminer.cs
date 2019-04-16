using microminer.KwicPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace microminer
{
    public class Microminer
    {
        private readonly DataManager dataManager;
        private readonly MasterControl masterControl;

        public Microminer()
        {
            dataManager = new DataManager();
            masterControl = new MasterControl();
        }

        public void SetInput(string input)
        {
            dataManager.saveToFile(input, "input.txt");
            masterControl.SetInput(input);

            dataManager.saveToFile(masterControl.GetAlphabetized(), "alphabetized.txt");
        }

        public List<string> GetMatches(string input)
        {
            return dataManager.GetContainingLines(input, "input.txt");
        }

        public string GetAlphabetized()
        {
            return dataManager.GetAllData("alphabetized.txt");
        }

    }
}
