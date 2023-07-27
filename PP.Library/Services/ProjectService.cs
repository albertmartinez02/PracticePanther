using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;
        private static object _lock = new object();
        public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }
                }
                return instance;
            }
        }

        private List<Project> projects;

        public List<Project>? Projects
        {
            get { return projects; }
        }

        public ProjectService()
        {
            projects = new List<Project>();
        }

        public Project? Get(int id)
        {
            return Projects?.FirstOrDefault(p => p.ID == id);
        }

        public void AddProject(Project proj) //Part of Project Menu functionality (create)
        {
            if (proj.ID == 0)
            {
                proj.ID = LastID + 1;
                proj.OpenDate = DateTime.Now; //Possible trouble point , look out
                projects.Add(proj);
            }
        }

        private int LastID
        {
            get
            {
                return projects.Any() ? projects.Select(p => p.ID).Max() : 0;
            }
        }

        public void Delete(Project proj)
        {
            Projects?.Remove(proj);
            return;
        }



    }
}
