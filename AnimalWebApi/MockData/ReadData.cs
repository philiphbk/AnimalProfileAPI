using System.Data;
using AnimalWebApi.Entities;
using IronXL;

namespace AnimalWebApi.MockData
{
    public class ReadData
    {
        private DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);


            WorkSheet sheet = workbook.DefaultWorkSheet;

            return sheet.ToDataTable(true);
        }

        public async void ReadCSVData(string csvFileName)
        {
            var csvFilereader = new DataTable();
            csvFilereader = ReadExcel(csvFileName);

            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < csvFilereader.Rows.Count; i++)
            {
                animals.Add(new Animal
                {
                    Id = csvFilereader.Rows[i][0].ToString(),
                    PetName = csvFilereader.Rows[i][1].ToString(),
                    Age = csvFilereader.Rows[i][2].ToString(),
                    Breed = csvFilereader.Rows[i][3].ToString(),
                    Description = csvFilereader.Rows[i][4].ToString(),
                });
            }

            foreach (var animal in animals)
            {
                var response = await _CSVManager.GetDataByEntry(
                    animal.Id,
                    animal.PetName,
                    animal.Age,
                    animal.Age,
                    animal.Description);
            }
        }

       
    }

}
