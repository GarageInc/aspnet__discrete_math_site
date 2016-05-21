namespace WebApplication.Service.auto_generating_mathtasks
{
    // Класс, для возвращения ответов на решения

    public class ReturnResult
    {
        public bool isRight { get; set; }

        public string Data { get; set; }

        public ReturnResult(bool b, string d)
        {
            this.isRight = b;
            this.Data = d;
        }
    }
}