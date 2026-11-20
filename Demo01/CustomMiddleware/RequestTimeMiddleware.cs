namespace Demo01.CustomMiddleware
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            await _next.Invoke(context);
            watch.Stop();
            Console.WriteLine($"{context.Request.Path} {watch.ElapsedMilliseconds} ms");
        }
    }
}
