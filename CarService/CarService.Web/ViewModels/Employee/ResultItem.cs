﻿namespace CarService.Web.ViewModels.Employee
{
    public class ResultItem
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public int CountOfTasks { get; set; }
    }
}