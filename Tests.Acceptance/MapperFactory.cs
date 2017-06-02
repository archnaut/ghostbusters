namespace Tests.Acceptance
{
    internal class MapperFactory
    {
        public IEntityMapper Create(string entityName)
        {
            IEntityMapper mapper;

            switch (entityName)
            {
                case "Events":
                    mapper = new EventMapper();
                    break;
                default:
                    mapper = new DefaultMapper(entityName);
                    break;
            }

            return mapper;
        }
    }
}