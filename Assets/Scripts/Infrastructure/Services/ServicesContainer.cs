namespace Infrastructure.Services
{
    public class ServicesContainer
    {
        private static ServicesContainer _instance;
        public static ServicesContainer Instance => _instance ?? (_instance = new ServicesContainer());

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}