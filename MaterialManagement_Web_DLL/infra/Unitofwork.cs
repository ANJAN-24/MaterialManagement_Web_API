namespace MaterialManagement_Web_DLL.infra
{
    public class Unitofwork : IUnitofwork
    {
        public readonly ApplicationDbContext _Context ;
        public Unitofwork(ApplicationDbContext context)
        {
            this._Context=context;
        }
        public void commit()
        {
            _Context.SaveChanges();
        }
    }
}