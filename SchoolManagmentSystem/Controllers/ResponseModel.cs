namespace SchoolManagmentSystem.Controllers
{
    internal class ResponseModel<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<T> data { get; set; }
    }
}