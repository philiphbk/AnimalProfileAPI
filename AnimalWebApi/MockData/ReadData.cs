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





       
    }

}
