using System;
using System.Collections.Generic;

namespace StudentRegistrationApp.Models;

public partial class Registration
{
    public int RegistrationId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
