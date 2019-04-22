using microminer.KwicPlus;
using microminer.Models;
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

        public Microminer(DataDBContext dbContext)
        {
            dataManager = new DataManager(dbContext);
            masterControl = new MasterControl();
        }

        public void SetInput(string input)
        {
            dataManager.saveToFile(input, "input");
            masterControl.SetInput(input);

            dataManager.saveToFile(masterControl.GetAlphabetized(), "alphabetized");
        }

        public List<string> GetMatches(string input)
        {
            return dataManager.GetContainingLines(input);
        }

        public string GetAlphabetized()
        {
            return dataManager.GetAllData();
        }

    }
}
