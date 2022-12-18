using System;
using System.Collections.Generic;

namespace TPlex.Models.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public string? Type { get; set; }

    public int? Salary { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
