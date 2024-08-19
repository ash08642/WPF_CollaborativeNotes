namespace CollaborativeNotes.Helpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}