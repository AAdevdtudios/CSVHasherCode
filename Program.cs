using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CSVHasherCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teamname:- ");
            string teamName = Console.ReadLine();

            Console.WriteLine("CSV File Path eg 'C:\\Users\\Usersname\\Desktop\\CustomData.csv':- ");
            string fileName = Console.ReadLine();


            try
            {
                string[] csvFiles = System.IO.File.ReadAllLines(fileName);
                Console.WriteLine("Loading CSV File ......");
                List<CSVModal> sVModals = new List<CSVModal>();
                List<AttributeType> attributeTypes = new List<AttributeType>();
                List<string> hash = new List<string>();
                for (int i = 1; i < csvFiles.Length; i++)
                {
                    string[] rawData = csvFiles[i].Split(',');
                    string[] attributes = rawData[5].Split(';');
                    for (int q = 1; q < attributes.Length - 1; q++)
                    {
                        string[] ary = attributes[q].Split(':');
                        AttributeType attribute = new AttributeType()
                        {
                            typeDa = ary[0],
                            value = ary[1],
                        };
                        attributeTypes.Add(attribute);
                    }
                    CSVModal cSV = new CSVModal()
                    {
                        SeriesName = i,
                        Filename = rawData[1],
                        attribute = attributeTypes,
                        Description = rawData[3],
                        Name = rawData[2],
                        Gender = rawData[4],
                        UUID = rawData[6],
                    };
                    string json = JsonConvert.SerializeObject(cSV);
                    string hashData = DecodeAndHash.GetHash(json);
                    hash.Add(hashData);
                    sVModals.Add(cSV);
                }
                var file = fileName.TrimEnd('\\').Remove(fileName.LastIndexOf('\\') + 1) + teamName+ ".csv";
                StringBuilder output = new StringBuilder();
                Console.WriteLine("Creating CSV ......");
                string csvHead = string.Format("Serries Name,Filename,Name,Description,Gender,UUID,Hash");
                output.AppendLine(csvHead);

                for (int i = 1; i < sVModals.Count(); i++)
                {
                    var data = sVModals[i-1];
                    string csvRow = string.Format("{0},{1},{2},{3},{4},{5},{6}", data.SeriesName, data.Filename, data.Name, data.Description, data.Gender, data.UUID, hash[i]);

                    output.AppendLine(csvRow);
                }
                File.AppendAllText(file, output.ToString());

                Console.WriteLine("CSV created");

                Console.WriteLine("Outpath location :{0}",fileName);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
