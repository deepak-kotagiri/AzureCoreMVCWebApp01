using AzureCoreWebMVC.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureCoreWebMVC.Services
{
    public class CourseStore
    {
        private DocumentClient _courseDB;
        private Uri courseLinks;
        public CourseStore()
        {
            var uri = new Uri("https://deepak-azurecosmodb.documents.azure.com:443/");
            var key = "scQ1RL75NMYFajGb3PaBGJTVETVXZF6vMIrnsYqnqAUOLydKGxpanSfkxIB1qaDzD6BIrDf30Ilda8YgRL3xhw==";            
            _courseDB = new DocumentClient(uri, key);
           
            courseLinks = UriFactory.CreateDocumentCollectionUri("cosmodb01", "courses");
        }

        public async Task InsertCourses(IEnumerable<Course> courses)
        {
            var options = new FeedOptions { PartitionKey = new PartitionKey("course") };
            var reqOption = new RequestOptions {                
                PartitionKey = new PartitionKey("course")
            };
            // In CosmoDB data is stored as links 
            // create links
            foreach (var item in courses)
            {
              await  _courseDB.CreateDocumentAsync(courseLinks, item ,null);
            }
        }

        public IEnumerable<Course> GetCourses()
        {
            var options = new FeedOptions {
               // PartitionKey = new PartitionKey("course"),
                EnableCrossPartitionQuery = true,
            };
            var courses = _courseDB.CreateDocumentQuery<Course>(courseLinks, options)
                                                .OrderBy(c => c.Title).AsEnumerable();

            return courses;

        }
    }
}
