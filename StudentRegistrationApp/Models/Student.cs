using System;
using System.Collections.Generic;

namespace StudentRegistrationApp.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
