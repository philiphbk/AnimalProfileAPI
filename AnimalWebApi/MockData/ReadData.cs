using System.Data;
using AnimalWebApi.Entities;
using IronXL;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;



namespace AnimalWebApi.MockData
{
    public class ReadData
    {
        public static IList<Animal> Data()
        {
            using (var streamReader = new StreamReader(@"C:\Users\damif\source\repos\AnimalWebApi\AnimalWebApi\MockData\MOCK_DATA.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<AnimalClassMap>();
                    var records = csvReader.GetRecords<Animal>().ToList();
                    return records;
                }
            }
        }

        public class AnimalClassMap : ClassMap<Animal>
        {
            public AnimalClassMap()
            {
                Map(m => m.Id).Name("ID");
                Map(m => m.PetName).Name("PetName");
                Map(m => m.Age).Name("Age");
                Map(m => m.Breed).Name("Breed");
                Map(m => m.Description).Name("Description");
            }
        }







       /* private DataTable ReadExcel(string fileName)
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
        }*/

       
    }

}
