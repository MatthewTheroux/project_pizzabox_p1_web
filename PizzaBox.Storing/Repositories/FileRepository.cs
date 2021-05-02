
using System.IO;
using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace PizzaBox.Storing.Repositories
{
public class FileRepository
{

public List<AStore> ReadFromFile(string path)
{
  var reader = new StreamReader(path);

  if(reader == null)
  {
    System.Console.WriteLine("file does not exist.");
    return null;
  }

  var xml = new XmlSerializer(typeof(List<AStore>));

  if(xml == null)
  {
    System.Console.WriteLine("file is empty.");
    return null;
  }

  var result = (List<AStore>)xml.Deserialize(reader);

  return result;
}
 private void WriteToFile(string path, List<AStore> stores)
        {
            //need file access
            //open file
            var writer = new StreamWriter(path);
            //convert object to text
            var xml = new XmlSerializer(typeof(List<AStore>));
            //write text to file
            xml.Serialize(writer, stores);
            //close file
            writer.Close();
        } 
}
}