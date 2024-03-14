namespace BackendAPI.Models.EntityFrameworkModel.Common
{
    public interface IEntityModelBase<ConcreteClass> where ConcreteClass : class
    {
        public void updateEntity(ConcreteClass entity);
    }
}
