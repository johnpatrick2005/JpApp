using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JpApp.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<Person> People { get; set; }

        [BindProperty]
        public SearchParameters? SearchParams { get; set; }

        public void OnGet(string? keyword = "", string? searchBy = "", string? sortBy = null, string? sortAsc = "true")
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword
                };
            }

            List<Person> people = new List<Person>()
            {
                new Person {
                    Name = "Alice Johnson",
                    Age = 30,
                    Gender = "Female",
                    EmailAddress = "alice.johnson@example.com"
                },
                new Person {
                    Name = "Bob Smith",
                    Age = 25,
                    Gender = "Male",
                    EmailAddress = "bob.smith@example.com"
                },
                new Person {
                    Name = "Carol Williams",
                    Age = 28,
                    Gender = "Female",
                    EmailAddress = "carol.williams@example.com"
                },
                new Person {
                    Name = "David Brown",
                    Age = 35,
                    Gender = "Male",
                    EmailAddress = "david.brown@example.com"
                },
                new Person {
                    Name = "Eva Green",
                    Age = 40,
                    Gender = "Female",
                    EmailAddress = "eva.green@example.com"
                },
                new Person {
                    Name = "Frank White",
                    Age = 45,
                    Gender = "Male",
                    EmailAddress = "frank.white@example.com"
                },
                new Person {
                    Name = "Grace Black",
                    Age = 50,
                    Gender = "Female",
                    EmailAddress = "grace.black@example.com"
                },
                new Person {
                    Name = "Henry Blue",
                    Age = 55,
                    Gender = "Male",
                    EmailAddress = "henry.blue@example.com"
                },
                new Person {
                    Name = "Isla Brown",
                    Age = 60,
                    Gender = "Female",
                    EmailAddress = "isla.brown@example.com"
                },
                new Person {
                    Name = "Jack Grey",
                    Age = 65,
                    Gender = "Male",
                    EmailAddress = "jack.grey@example.com"
                },
                new Person {
                    Name = "Karen White",
                    Age = 70,
                    Gender = "Female",
                    EmailAddress = "karen.white@example.com"
                },
                new Person {
                    Name = "Larry Green",
                    Age = 75,
                    Gender = "Male",
                    EmailAddress = "larry.green@example.com"
                },
                new Person {
                    Name = "Mona Black",
                    Age = 80,
                    Gender = "Female",
                    EmailAddress = "mona.black@example.com"
                },
                new Person {
                    Name = "Nina Blue",
                    Age = 85,
                    Gender = "Female",
                    EmailAddress = "nina.blue@example.com"
                },
                new Person {
                    Name = "Oscar Red",
                    Age = 90,
                    Gender = "Male",
                    EmailAddress = "oscar.red@example.com"
                }
            };

            if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                if (SearchParams.SearchBy.ToLower() == "name")
                {
                    people = people.Where(p => p.Name != null && p.Name.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "age")
                {                 
                    people = people.Where(p => p.Age.ToString().Contains(SearchParams.Keyword)).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "gender")
                {
                    people = people.Where(p => p.Gender != null && p.Gender.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "emailaddress")
                {
                    people = people.Where(p => p.EmailAddress != null && p.EmailAddress.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
            }

            if (SearchParams.SortBy == null || SearchParams.SortAsc == null)
            {
                this.People = people;
                return;
            }

            bool ascending = SearchParams.SortAsc == true;

            this.People = SearchParams.SortBy.ToLower() switch
            {
                "name" => ascending ? people.OrderBy(p => p.Name).ToList() : people.OrderByDescending(p => p.Name).ToList(),
                "age" => ascending ? people.OrderBy(p => p.Age).ToList() : people.OrderByDescending(p => p.Age).ToList(),
                "gender" => ascending ? people.OrderBy(p => p.Gender).ToList() : people.OrderByDescending(p => p.Gender).ToList(),
                "emailaddress" => ascending ? people.OrderBy(p => p.EmailAddress).ToList() : people.OrderByDescending(p => p.EmailAddress).ToList(),
                _ => people
            };
        }

        public class Person
        {
            public string? Name { get; set; }
            public int Age { get; set; }
            public string? Gender { get; set; }
            public string? EmailAddress { get; set; }
        }

        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; }
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; }
        }
    }
}
