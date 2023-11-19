namespace _22Percent_BE.Helpers.Jwt
{
    public class JwtMiddlerware
    {
        private readonly RequestDelegate _request;

        public JwtMiddlerware(RequestDelegate  request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            // Get token from request
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            // Add key "Bearer" to token
            context.Request.Headers.Add("Authorization", $"Bearer {token}");

            await _request(context);

        }
    }
}
