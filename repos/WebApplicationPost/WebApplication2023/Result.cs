namespace WebApplicationPost
{
    public class Result
    {
        public double Res { get; set; }
        public string Description { get; set; }

        public Result(double res, string disc)
        {
            Res = res;
            Description = disc;
        }
    }
}
