namespace stazAPI.Service
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string error)
        {
            this.Data.Add("error", error);
        }
    }
}
