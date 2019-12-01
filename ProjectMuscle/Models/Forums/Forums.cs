using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMuscle.Models.Forums
{
    /// <summary>
    /// Represents a single web forum.
    /// Contains a list of ForumBoard.
    /// E.g. 'MMA Forum'
    /// </summary>
    public class Forum
    {
        [Key]
        public int ForumID { get; set; }

        public string ForumName { get; set; }

        public string ForumDescription { get; set; }

        public List<ForumBoard> BoardList { get; set; }
    }

    /// <summary>
    /// Represents a forum board.
    /// Contains a list of ForumThread.
    /// E.g. 'Muay-Thai Board'
    /// </summary>
    public class ForumBoard
    {
        [Key]
        public int BoardID { get; set; }

        public string BoardName { get; set; }

        public string BoardDescription { get; set; }

        public List<ForumThread> ThreadList { get; set; }
    }

    /// <summary>
    /// Represents a single forum thread.
    /// Contains a list of ForumPost.
    /// E.g. 'UFC 245 Fight Night Megathread'
    /// </summary>
    public class ForumThread
    {
        [Key]
        public int ThreadID { get; set; }

        public string ThreadTitle { get; set; }

        public List<ForumPost> PostList { get; set; }
    }

    /// <summary>
    /// Represents a single forum post.
    /// Holds information on the user who posted it,
    /// and the DateTime it was posted.
    /// E.g. 'The Korean Zombie will win!'
    /// </summary>
    public class ForumPost
    {
        [Key]
        public int PostID { get; set; }

        public int AuthorID { get; set; }

        public DateTime PostDate { get; set; }

        public string PostContent { get; set; }

    }
}
