using Newtonsoft.Json;
using PersonReader.Interface;
using System.Collections.Generic;
using System.Net;

namespace PersonReader.Service
{
    public class ServiceReader : IPersonReader
    {
        WebClient client = new WebClient();
        string baseUri = "http://localhost:9874";

        public IReadOnlyCollection<Person> GetPeople()
        {
            var address = $"{baseUri}/people";
            string reply = client.DownloadString(address);
            return JsonConvert.DeserializeObject<List<Person>>(reply);
        }

        public Person GetPerson(int id)
        {
            var address = $"{baseUri}/people/{id}";
            string reply = client.DownloadString(address);
            return JsonConvert.DeserializeObject<Person>(reply);
        }
    }
}
