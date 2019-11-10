namespace ORM
{
    public interface IHumanRepository
    {
        Human GetById(int id);
        void Update(Human human);
        void Delete(Human human);
        void Create(Human human);
    }
}
