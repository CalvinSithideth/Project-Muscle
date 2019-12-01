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

        /// <summary>
        /// Creates a new forum.
        /// </summary>
        /// <param name="forumName"></param>
        /// <param name="forumDescription"></param>
        public Forum(string forumName, string forumDescription)
        {
            ForumName = forumName;
            ForumDescription = forumDescription;
        }
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

        /// <summary>
        /// Creates a new board.
        /// </summary>
        /// <param name="boardName">Name of the board. E.g. "Muay-Thai Board"</param>
        /// <param name="boardDescription">Description of the board. E.g. "Southeast Asian Kickboxing"</param>
        public ForumBoard(string boardName, string boardDescription)
        {
            BoardName = boardName;
            BoardDescription = boardDescription;
        }

        public void AddThread(ForumThread newThread)
        {
            ThreadList.Add(newThread);
        }
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

        /// <summary>
        /// Creates a new thread from a thread title and a ForumPost.
        /// </summary>
        /// <param name="threadTitle">The title of the forum thread.</param>
        /// <param name="InitialPost">The first post of the thread (original post).</param>
        public ForumThread(string threadTitle, ForumPost InitialPost)
        {
            ThreadTitle = threadTitle;
            PostList.Add(InitialPost);
        }

        /// <summary>
        /// Adds a new post to the thread.
        /// </summary>
        /// <param name="newPost">The post to add to the thread.</param>
        public void AddPost(ForumPost newPost)
        {
            PostList.Add(newPost);
        }
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

        /// <summary>
        /// Creates a new forum post.
        /// </summary>
        /// <param name="authorID">The ID of the user posting.</param>
        /// <param name="postContent">The entire content string of the post.</param>
        public ForumPost(int authorID, string postContent)
        {
            AuthorID = authorID;
            PostDate = DateTime.Now;
            PostContent = postContent;
        }

    }
}
