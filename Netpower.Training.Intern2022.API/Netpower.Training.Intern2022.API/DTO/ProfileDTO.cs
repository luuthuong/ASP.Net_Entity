using System;

namespace Netpower.Training.Intern2022.API.DTO
{
    public class ProfileDTO:DTOBase
    {
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Sex { get; set; }
        public Guid? UserID { get; set; }
    }
}
