using System.Xml.Serialization;
public class Program
{
    [Serializable]
    public class Continent
    {
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
    }
    [Serializable]
    public class Country
    {
        public string CountryName { get; set; }
        public int CountryId { get; set; }
    }
    private static void Main(string[] args)
    {
        List<Continent> continents = new List<Continent>();

        continents.Add(new Continent
        {
            Name = "Europe",
            Countries = new List<Country>
            {
                new Country
                {
                    CountryId = 1,
                    CountryName = "France"
                },
                new Country
                {
                    CountryId = 2,
                    CountryName = "Hungary"
                }
            }
        });

        continents.Add(new Continent
        {
            Name = "North America",
            Countries = new List<Country>()
            {
                new Country
                {
                    CountryId = 3,
                    CountryName = "Canada"
                },
                new Country
                {
                    CountryId = 4,
                    CountryName = "Mexico"
                }
            }
        });
        
        string filePath = @"c:\FileTest\Continents.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(List<Continent>));

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            serializer.Serialize(fileStream, continents);
        };

        Console.WriteLine("Continents.xml created.");
        List<Continent> continentsFromXml;

        using (FileStream fileStream1 = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            continentsFromXml = serializer.Deserialize(fileStream1) as List<Continent>;
        }

        Console.WriteLine("Data loaded from Continents.xml: \n");
        foreach (Continent continent in continentsFromXml)
        {
            Console.WriteLine("\n" + continent.Name);
            foreach (Country country in continent.Countries)
            {
                Console.Write(country.CountryId + " - " + country.CountryName);
                Console.Write(" / ");
            }
        }


        
    }
}