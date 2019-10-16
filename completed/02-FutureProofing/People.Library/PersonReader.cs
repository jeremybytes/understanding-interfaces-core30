using Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace People.Library
{
    public class PersonReader
    {
        WebClient client = new WebClient();
        string baseUri = "http://localhost:9874";

        public List<Person> GetPeople()
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
