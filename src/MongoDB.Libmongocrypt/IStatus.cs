namespace MongoDB.Libmongocrypt
{
    internal interface IStatus
    {
        void Check(Status status);
    }
}
