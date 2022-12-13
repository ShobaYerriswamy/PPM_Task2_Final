using System;
using System.Text.RegularExpressions;

using ProlificsProjectManager.PPM.MAIN.PPM.MODEL;
using ProlificsProjectManager.PPM.MAIN.PPM.DOMAIN;


namespace ProlificsProjectManager.PPM.MAIN.PPM.UI
{
    public class viewing
    {
        public void view()
        {
            Console.WriteLine(" ======= HELLO PROLIFICS EMPLOYEE ======= ");
            Console.WriteLine("Enter 1 to Adding Project");
            Console.WriteLine("Enter 2 to View all Projects");
            Console.WriteLine("Enter 3 to Adding Employee");
            Console.WriteLine("Enter 4 to View all Employees");
            Console.WriteLine("Enter 5 to Adding Role");
            Console.WriteLine("Enter 6 to View all Roles");
            Console.WriteLine("Enter 7 for searching Project");
            Console.WriteLine("Enter 8 for searching Project through ID");
            Console.WriteLine("Enter 9 for Adding Employees to Project");
            Console.WriteLine("Enter 10 for view all Employees who added to Projects");
            Console.WriteLine("Enter 11 to Delete employee from Project");
            Console.WriteLine("Enter 'S' to QUIT the application");
       
            ProjectManager PM =  new ProjectManager();
            EmployeeManager EM = new EmployeeManager();
            RoleManager RM = new RoleManager();
            Project project = new Project();
            Employee employee = new Employee();
            Role role = new Role();

            RM.RoleList.Add(new Role(1, "Software Engineer"));
            RM.RoleList.Add(new Role(2, "Associate Software Engineer"));
            RM.RoleList.Add(new Role(3, "Trainee Software Engineer"));
            RM.RoleList.Add(new Role(4, "Technical Lead"));

            Boolean error = false;

            Regex phnumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
            Regex Email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex date = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            var UserInput = Console.ReadLine();

            while (true)
            {
                repeat:

                switch (UserInput)
                {
                    case "1":
                        do
                        {
                            try
                            {
                                inputprojectid:
                                Console.WriteLine("Enter the Project Id");
                                int projectid = Convert.ToInt32(Console.ReadLine());
                                for (int i=0; i<PM.Projects.Count; i++)
                                {
                                    if (PM.Projects[i].id == projectid)
                                    {
                                        Console.WriteLine("The id already exists try new id");
                                        Console.WriteLine("Enter any key to try again");
                                        Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                                        string idTry=Console.ReadLine();

                                        if (idTry == "x")
                                        {
                                            goto breakage;
                                        }
                                        else
                                        {
                                            goto inputprojectid;
                                        }
                                    }
                                }
                                Console.WriteLine("Enter the name of Project");
                                string name = Console.ReadLine();
                                
                                StartDate:
                                Console.WriteLine("Enter the Start Date of Project DD/MM/YYYY format");
                                string start = Console.ReadLine();
                                if(!date.IsMatch(start))
                                {
                                    Console.WriteLine("Invalid date format");
                                    Console.WriteLine("Enter any key to retry again");
                                    Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                                    var sDateread=Console.ReadLine();

                                    if(sDateread == "x")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto StartDate;
                                    }
                                }
                                
                                EndDate:
                                Console.WriteLine("Enter end date of project in DD/MM/YYYY format");
                                string end = Console.ReadLine();
                                if (!date.IsMatch(end))
                                {
                                    Console.WriteLine("Invalid date format");
                                    Console.WriteLine("Enter any key to retry again");
                                    Console.WriteLine("Enter \"x\" to exit to  Main Menu");
                                    var eDateread = Console.ReadLine();

                                    if (eDateread == "x")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto EndDate;
                                    }

                                }

                                Project proj1 = new Project(name, start, end, projectid);
                                PM.AddingProjects(proj1);
                                project = proj1;
                                
                                Console.WriteLine("Added Successfully");
                                Console.WriteLine("Enter any key to get Main Menu");
                                Console.ReadLine();
                            }

                            catch(FormatException e)
                            {
                                Console.WriteLine("\nError : only use Numbers for Id");
                                Console.WriteLine("Enter any key to try again");
                                Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                            
                                UserInput= Console.ReadLine();
                                if(UserInput == "x")
                                {
                                    break;
                                }
                                error = true;
                            }
                        
                            catch (Exception e)
                            {
                                Console.WriteLine("\nError : Only use numbers for id");
                                Console.WriteLine("Enter any key to try again");
                                Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                            
                                
                                UserInput = Console.ReadLine();
                                if(UserInput == "x")
                                {
                                    
                                    break;
                                }
                                error = true;
                            }
                        }

                        while(error);
                        breakage:
                        break;
                        

                    case "2":
                        PM.displayAllProjects();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "3":

                        inputempid:
                        Console.WriteLine("Enter the Id of Employee");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        for(int i =0;i<EM.empList.Count;i++)
                        {
                            if (empId == EM.empList[i].EmployeeID)
                            {
                                Console.WriteLine("The id already exists try new id");
                                Console.WriteLine("Enter any key to try again");
                                Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                                string empidTry = Console.ReadLine();

                                if (empidTry == "x") 
                                {
                                    goto breakage;
                                }
                                else
                                {
                                    goto inputempid;
                                }
                            }
                        }

                        Console.WriteLine("Enter Employee fist name");
                        var fname = Console.ReadLine();
                        Console.WriteLine("Enter Employee last name");
                        var lname = Console.ReadLine();

                        Email:
                        Console.WriteLine("Enter Employee Email id");
                        var EMAIL= Console.ReadLine();
                        if(!Email.IsMatch(EMAIL))
                        {
                            Console.WriteLine("Invalid Email Format");
                            Console.WriteLine("Enter any key to retry again");
                            Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                            var emailread=Console.ReadLine();

                            if(emailread=="x")
                            {
                                break;
                            }
                            else
                            {
                                goto Email;
                            }
                        }

                        mobile:
                        Console.WriteLine("Enter Employee mobile number");
                        var mobile = Console.ReadLine();
                        if(!phnumber.IsMatch(mobile))
                        {
                            Console.WriteLine("Invalid mobile number format");
                            Console.WriteLine("Enter any key to retry again");
                            Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                            var mobread=Console.ReadLine();
                            if(mobread=="x")
                            {
                                break;
                            }
                            else
                            {
                                goto mobile;
                            }
                                
                        }
                            
                        Console.WriteLine("Enter Employee address");
                        var address = Console.ReadLine();

                        Option:
                        Console.WriteLine("Select 1 for assinging employee with new role name and new role id");
                        Console.WriteLine("Select 2 for assinging existing role to the employee");
                        int selection = Convert.ToInt32(Console.ReadLine());

                        if(selection == 1)
                        {
                            try
                            {
                                Console.WriteLine("Enter the Role Id");
                                int roleID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the name of Role");
                                string rolename = Console.ReadLine();
                                Console.WriteLine(rolename);

                                Role role1 = new Role(roleID, rolename);
                                RM.RoleAdd(role1);

                                Employee emp1 = new Employee(empId, fname, lname, EMAIL, mobile, address, roleID,  rolename);
                                EM.AddEmp(emp1);
                                employee = emp1;
                                Console.WriteLine("Added Successfully");
                            }

                            catch(Exception e)
                            {
                                Console.WriteLine("Role id should be in numbers only");
                            }
                        }

                        else if (selection == 2)
                        {
                            try
                            {
                                Selectrole:
                                RM.dispalyRole();
                                Console.WriteLine("Select Role id from above list to assign role to employee");
                                int role1 = Convert.ToInt32(Console.ReadLine());
                                string? roleNAME1 = null;
                                switch (role1)
                                {
                                    case 1:
                                        roleNAME1 = "Software Engineer";
                                        break;
                                    case 2:
                                        roleNAME1 = "Associate Software Engineer";
                                        break;
                                    case 3:
                                        roleNAME1 = "Trainee Software Engineer";
                                        break;
                                    case 4:
                                        roleNAME1 = "Technical Lead";
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Entry");
                                        Console.WriteLine("Enter any key to try again");
                                        Console.WriteLine("Enter  \"x\" to exit to  Main Menu");
                                        string tryemprole = Console.ReadLine();

                                        if(tryemprole == "x")   
                                        {
                                            goto repeat;
                                        }
                                        else
                                        {
                                            goto Selectrole;
                                        }
                                }
                                
                                Employee emp1 = new Employee(empId, fname, lname, EMAIL, mobile, address, role1, roleNAME1);
                                EM.AddEmp(emp1);
                                employee = emp1;
                                Console.WriteLine("Added Successfully!");
                            }
                                
                            catch (Exception e)
                            {
                                Console.WriteLine("Emp id can only be in numbers");
                            }
                        }
                            
                        else
                        {
                            Console.WriteLine("Invalid entry");
                            Console.WriteLine("Try again");
                            goto Option;
                        }
                            
                            Console.WriteLine("Enter any key to get to Main Menu");
                            Console.ReadLine();
                            break;
                    
                    case "4":
                        EM.ShowEmp();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "5":
                        try
                        {
                            inputroleid:
                            Console.WriteLine("Enter the Role Id");
                            int roleIDD = Convert.ToInt32(Console.ReadLine());
                            for(int i = 0;i<RM.RoleList.Count;i++)
                            {
                                if(roleIDD == RM.RoleList[i].RoleId)
                                {
                                    Console.WriteLine("The id already exists try new id");
                                    Console.WriteLine("Enter any key to try again");
                                    Console.WriteLine("Enter \"x\" to get to Main Menu");
                                    string roleidTry = Console.ReadLine();

                                    if (roleidTry == "x") 
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto inputroleid;
                                    }
                                }
                            }

                            Console.WriteLine("Enter the name of Role");
                            string role_name = Console.ReadLine();
                            Role newRole = new Role(roleIDD, role_name);
                            RM.RoleAdd(newRole);
                            Console.WriteLine("Added Successfully!");

                            Console.WriteLine("Enter any key to get to Main Menu");
                            Console.ReadLine();
                        }
                        
                        catch (Exception e)
                        {
                            Console.WriteLine("Role Id should be in Numbers only");
                        }

                        break;

                    case "6":
                        RM.dispalyRole();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "7":
                        Console.WriteLine("Type to Search for Project");
                        UserInput = Console.ReadLine();
                        PM.SearchProject(UserInput);
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;
                    
                    case "8":
                        try
                        {
                            Console.WriteLine("Search via Project id");
                            Console.WriteLine("Enter the id of project");
                            int eid = Convert.ToInt32(Console.ReadLine());
                            PM.ShowProject(eid);
                            Console.WriteLine("Enter any key to get Main Menu");
                            Console.ReadLine();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Id should be in Numbers only");
                        }
                        break;

                    case "9":
                        PM.displayAllProjects();
                        Console.WriteLine("Above are the available projects");
                        Console.WriteLine();
                        EM.ShowEmp();
                        Console.WriteLine("Above are the available employees");
                        Console.WriteLine("Enter the Project ID from above list exactly");
                        int PROJId =Convert.ToInt32(Console.ReadLine());
                        if(PM.exist(PROJId))
                        {
                            Console.WriteLine("Enter the Id of Employee to add into project");
                            int EmpId = Convert.ToInt32(Console.ReadLine());
                        
                            if(EM.exist(EmpId))
                            {
                                employee = EM.eDetails(EmpId);
                                PM.emptopro(PROJId,employee);
                                Console.WriteLine("Added Successfully");
                                Console.WriteLine("Enter any key to get to Main Menu");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Employee does not exist");
                            }
                        }

                        else
                        {
                            Console.WriteLine("Project does not exist");
                        }
                        var Read = Console.ReadLine();
                        break;

                    case "10": 
                        Console.WriteLine("Enter Project Id");
                        int pid =Convert.ToInt32(Console.ReadLine());
                        PM.display();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "11":
                        try
                        {
                            Console.WriteLine("Enter the Id of the project for which you want to delete employees");
                            int PROJId1 = Convert.ToInt32(Console.ReadLine());
                            if(PM.exist(PROJId1))
                            {
                                Console.WriteLine("Enter the id of employee to add into project");
                                int EmpId1 = Convert.ToInt32(Console.ReadLine());
                                employee = EM.eDetails(EmpId1);
                                PM.empfrompro(PROJId1,employee);
                                Console.WriteLine("\nSuccessfully deleted");
                            }

                            else
                            {
                                Console.WriteLine("The project do not exist");
                            }
                        }

                        catch(FormatException e)
                        {
                            Console.WriteLine("Id can only be integer");
                        }

                        Console.WriteLine("Enter any key to get to Main Menu");
                        Console.ReadLine();
                        break;

                    case "S":
                        return;

                    default:
                        Console.WriteLine("Invalid Entry");
                        break; 
                }

                    Console.WriteLine(" ======= LIST ======= ");
                    Console.WriteLine("Enter 1 for Adding Project");
                    Console.WriteLine("Enter 2 to Show all projects");
                    Console.WriteLine("Enter 3 for Adding Employee");
                    Console.WriteLine("Enter 4 for Viewing all Employees");
                    Console.WriteLine("Enter 5 for Adding Role");
                    Console.WriteLine("Enter 6 for Viewing all Roles");
                    Console.WriteLine("Enter 7 for searching Project");
                    Console.WriteLine("Enter 8 for searching Project through ID");
                    Console.WriteLine("Enter 9 for Adding Employees to Project");
                    Console.WriteLine("Enter 10 for view all Employees who added to Projects");
                     Console.WriteLine("Enter 11 to Delete employee from Project");
                    Console.WriteLine("Enter 'S' to QUIT the application");
                
                    UserInput = Console.ReadLine();
            }    
        }
    }
}