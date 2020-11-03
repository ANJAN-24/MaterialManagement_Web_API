using Microsoft.EntityFrameworkCore;

namespace MaterialManagement_Web_DLL.infra
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {
            
        }
    }
}