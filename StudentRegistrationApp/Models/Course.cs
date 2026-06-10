using System;
using System.Collections.Generic;

namespace StudentRegistrationApp.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseCode { get; set; } = null!;

    public int Credits { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
