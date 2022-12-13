using System;
using ProlificsProjectManager.PPM.MAIN.PPM.MODEL;

namespace ProlificsProjectManager.PPM.MAIN.PPM.DOMAIN
{
    public class ProjectManager
    {
        public List<Project>Projects = new List<Project>();

        public void AddingProjects(Project project)
        {
            Projects.Add(project);
        }

        public void displayProject(Project project)
        {
            Console.WriteLine("Name of the project - " + project.ProjectName + "\n project Id - " + project.id + "\n Start date of project -" + project.Startdate + "\n End date of project -" + project.Enddate);
        }

        public void displayAllProjects()
        {
            if(Projects.Count == 0)
            {
                Console.WriteLine("The List is Empty !!!");
            }
            else
            {
                foreach (var i in Projects)
                {
                    displayProject(i);
                }
            }
        }

        public void display()
        {
            for (int j=0; j<Projects.Count; j++)
            {
                if(Projects[j].AddingEmplist.Count == 0)
                {
                    Console.WriteLine("No employee in the project");
                }
                else
                {
                    Console.WriteLine("Project Name - "+ Projects[j].ProjectName);
                    Console.WriteLine("Names of the employees in the project");
                    for(int i=0; i<Projects[j].AddingEmplist.Count; i++)
                    {
                        Console.WriteLine(Projects[j].AddingEmplist[i].EmpFirstName);
                    }
                   
                }
            }
        }

        public void emptopro(int pid, Employee ename)
        {
            for(int i=0; i<Projects.Count; i++)
            {
                if(Projects[i].id==pid)
                {
                    Projects[i].AddingEmplist.Add(ename);
                }
            }
        }

        public void empfrompro(int pid, Employee ename)
        {
            for(int i=0; i<Projects.Count; i++)
            {
                if(Projects[i].id==pid)
                {
                    Projects[i].AddingEmplist.Remove(ename);
                }
            }
        }

        public Boolean exist(int pid)
        {
            for(int i=0; i<Projects.Count; i++)
            {
                if(pid== Projects[i].id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ShowProject(int eid)
        {
            foreach (Project e in Projects)
            {
                if (e.id == eid)
                {
                    Console.WriteLine(" Name of the project - " + e.ProjectName + " \n project Id - " + e.id + " \n Start date of project -" + e.Startdate + "\n End date of project -" + e.Enddate);
                }
                else
                {
                    Console.WriteLine("Id not found");
                }
            }
        }
        
        public void SearchProject(string search)
        {
            var match = Projects.Where(c => c.ProjectName.Contains(search));
            foreach(var i in match)
            {
                Console.WriteLine("Name of the project - " + i.ProjectName + "\n project Id - " + i.id + "\n Start date of project -" + i.Startdate + "\n End date of project -" + i.Enddate);
            }
        }
    }

    public class EmployeeManager
    {
        public List<Employee> empList = new List<Employee>();

        public void AddEmp(Employee employee)
        {
            empList.Add(employee);
        }

        public void displayEmp(Employee employee)
        {
            Console.WriteLine("Employee Id -" + employee.EmployeeID + "\n Employee first name -" + employee.firstName + "\n Employee last name -" + employee.lastName + "\n Employee email id -" + employee.email + "\n Employee mobile number  -" + employee.mobile + "\n Employee address -" + employee.address + "\n  Role ID -" + employee.roleid + "\n Role Name -" + employee.roleName);
        }

        public Employee eDetails(int eid)
        {
            Employee employee = new Employee();
            for(int i=0; i<empList.Count; i++)
            {
                if(eid==empList[i].EmployeeID)
                {
                    employee=empList[i];
                    return employee;
                }
            }
            return employee;
        }

        public void ShowEmp() 
        {
            if(empList.Count == 0)
            {
                Console.WriteLine("No employees available");
            }
            else
            {
                foreach (var i in empList)
                {
                    displayEmp(i);
                }
            }
        }

        public void ShowEmployee(int eid)
        {
            foreach (Employee i in empList)
            {

                if (i.EmployeeID == eid)
                {
                    Console.WriteLine(" Name of the Employee - " + i.EmpFirstName + " " + i.lastName + "\n Employee Id - " + i.EmployeeID);
                }
                else
                {
                    Console.WriteLine("Id not found");
                }
            }
        }

        public Boolean exist(int eid)
        {
            for(int i=0; i<empList.Count; i++)
            {
                if(eid==empList[i].EmployeeID)
                {
                    return true;
                }       
            }
            return false;
        }
    }
    public class RoleManager
    {
        public List<Role> RoleList = new List<Role>();

        public void RoleAdd(Role role)
        {
            RoleList.Add(role);
        } 

        public void dispalyRole()
        {
            foreach (var i in RoleList)
            {
                Console.WriteLine("Name of the Role -" + i.RoleName+ "\n Role Id - " + i.RoleId);
            }
        }
    }
}
