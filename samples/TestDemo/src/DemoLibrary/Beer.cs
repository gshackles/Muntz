namespace DemoLibrary
{
    public class Beer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Beer()
        {
        }

        public Beer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}