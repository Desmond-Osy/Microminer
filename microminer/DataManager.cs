using microminer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microminer
{
    public class DataManager
    {
        private DataDBContext dbContext;


        public DataManager(DataDBContext dataDBContext)
        {
            this.dbContext = dataDBContext;
        }

        public void saveToFile(string input, string des)
        {
            if (des.Equals("input")) {

                var todo = dbContext.InputDataModels.SingleOrDefault();
                dbContext.InputDataModels.Remove(todo);
                dbContext.SaveChanges();

                InputDataModel data = new InputDataModel();
                data.Input = input;

                dbContext.InputDataModels.Add(data);
                dbContext.SaveChanges();
            }
            else
            {
                var todo = dbContext.AlphabetizedDataModels.SingleOrDefault();
                dbContext.AlphabetizedDataModels.Remove(todo);
                dbContext.SaveChanges();

                AlphabetizedDataModel data = new AlphabetizedDataModel();
                data.Alphabetized = input;

                dbContext.AlphabetizedDataModels.Add(data);
                dbContext.SaveChanges();
            }
        }


        public string GetAllData()
        {
            
            
            AlphabetizedDataModel res = dbContext.AlphabetizedDataModels.SingleOrDefault();
            return res.Alphabetized;
        }

        public List<string> GetContainingLines(String input)
        {
            var results = new List<string>();
            string [] lines;
            InputDataModel res = dbContext.InputDataModels.SingleOrDefault();
            lines = res.Input.Split('\n');

            foreach(string line in lines)
            {
                if (line.ToUpper().Contains(input.ToUpper()))
                {
                    results.Add(line);
                }
            }
            return results;
        }

    }
}
