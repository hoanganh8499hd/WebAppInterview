namespace WebAppViews.Models
{
    public class CommentService
    {
        public static async Task<List<Comment>> GetRecentCommentsAsync()
        {
            // Simulate asynchronous data fetching by waiting for a short time
            await Task.Delay(500); // Wait for half a second
            // Return some hardcoded comments
            return new List<Comment>
            {
                new Comment(){Text = "This is a great post!", User= "Alice"},
                new Comment(){Text = "Very informative, thanks for sharing.", User= "Bob"},
                new Comment(){Text = "I had a similar experience.", User= "Charlie"}
            };
        }
    }
}
