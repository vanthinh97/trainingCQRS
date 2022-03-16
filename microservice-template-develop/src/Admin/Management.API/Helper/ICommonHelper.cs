namespace Management.API.Helper
{
    public interface ICommonHelper
    {
        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string HashSha256(string data);
    }
}
