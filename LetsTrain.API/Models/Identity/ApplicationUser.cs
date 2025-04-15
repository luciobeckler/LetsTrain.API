using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace LetsTrain.API.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public Aluno? Aluno { get; set; }
    }
}
