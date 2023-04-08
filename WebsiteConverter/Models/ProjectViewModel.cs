using static System.Net.WebRequestMethods;

namespace WebsiteConverter.Models
{
    public class ProjectViewModel
    {
        public int ID { get; set; }
        public string Thumbnail { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        //public string Filter { get; set; } = null!;
        public string? URL { get; set; }
        public string GitHub { get; set; } = null!;
        public string Image1 { get; set; } = null!;

        public DateTime ProjectDate { get; set; }
        //public string? Image2 { get; set; }
        //public string? Image3 { get; set; }

        public static List<ProjectViewModel> GetProjects()
        {
            var project1 = new ProjectViewModel()
            {
                Name = " Dungeon Crawler ",
                ProjectDate = new DateTime(2023, 3, 10),
                Description = " During my time at Centriq, we were assigned a project to program a dungeon crawler game using C#. The Dungeon Application is intended to showcase my C# skills. It allows me to demonstrate my ability to break down multi-stage processes into steps and to design complex logical structures.  Please check it out on my GitHub! ",
                ID = 1,
                Thumbnail = "newDungeonApp.png",
                URL = null,
                GitHub = "https://github.com/SteveRogers1215/DungeonApplication",
                Image1 = "newDungeonApp.png",
                //Image2 = "newDungeonApp.png",
                //Image3 = "newDungeonApp.png",
                //Filter = "app"

            };
            var project2 = new ProjectViewModel()
            {
                Name = " Storefront Application ",
                ProjectDate = new DateTime(2023, 5, 19),
                Description = " While at Centriq, I was tasked with building a mock e-commerce site. I've already designed the database that will be used for the application. Currently, I'm working on expanding the functionality of the application using MVC classes. Once that is complete GitHut link will be posted! ",
                ID = 2,
                Thumbnail = "storefront.jpg",
                URL = null,
                GitHub = "",
                Image1 = "storefront.jpg",
                //Image2 = "",
                //Image3 = "",
                //Filter = "web"
            };
            var project3 = new ProjectViewModel()
            {
                Name = "ReactToDo ",
                ProjectDate = new DateTime(2023, 5, 19),
                Description = " Under Construction ",
                ID = 3,
                Thumbnail = "React-icon.svg.png",
                URL = null,
                GitHub = "",
                Image1 = "React-icon.svg.png",
                //Image2 = "",
                //Image3 = "",
                //Filter = "app"

            };
            var project4 = new ProjectViewModel()
            {
                Name = " ToDo API ",
                ProjectDate = new DateTime(2023, 5, 19),
                Description = " Under Construction ",
                ID = 4,
                Thumbnail = "ToDoAPI.webp",
                URL = null,
                GitHub = "",
                Image1 = "ToDoAPI.webp",
                //Image2 = "",
                //Image3 = "",
                //Filter = "card"
            };
            var project5 = new ProjectViewModel()
            {
                Name = " SAT ",
                ProjectDate = new DateTime(2023, 5, 19),
                Description = " Under Construction ",
                ID = 5,
                Thumbnail = "RestfulAPI.png",
                URL = null,
                GitHub = "",
                Image1 = "RestfulAPI.png",
                //Image2 = "",
                //Image3 = "",
                //Filter = "web"

            };
            var project6 = new ProjectViewModel()
            {
                Name = " Personal Projects ",
                Description = " Various projects I get into on my own time. Be sure to keep a look out for updates! ",
                ID = 6,
                Thumbnail = "codescript.jpg",
                URL = null,
                GitHub = "https://github.com/SteveRogers1215/",
                Image1 = " codescript.jpg ",
                //Image2 = "",
                //Image3 = "",
                //Filter = "app"
            };
            return new List<ProjectViewModel> { project1, project2, project3, project4, project5, project6 };
        }
    }
}
