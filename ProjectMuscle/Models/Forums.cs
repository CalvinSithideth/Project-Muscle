using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMuscle.Models
{
    public class Forum
    {
        [Key]
        public int ForumID { get; set; }

        public string ForumTitle { get; set; }

        public string ForumDescription { get; set; }

        // Collection Nav Property
        public List<ForumBoard> BoardList { get; set; }
    }


    public class ForumBoard
    {
        [Key]
        public int BoardID { get; set; }

        public string BoardTitle { get; set; }
        public string BoardDescription { get; set; }

        // Reference Nav Property
        [ForeignKey("Forum")]
        public int ForumID { get; set; }

        // Reference Nav Property
        public virtual Forum ParentForum { get; set; }

        // Collection Nav Property
        public virtual ICollection<ForumThread> ThreadList { get; set; }
    }

    public class ForumThread
    {
        [Key]
        public int ThreadID { get; set; }

        public string ThreadTitle { get; set; }

        // Reference Nav Property
        [ForeignKey("ForumBoard")]
        public int BoardID { get; set; }

        // Reference Nav Property
        public virtual ForumBoard ParentBoard { get; set; }

        // Collection Nav Property
        public virtual ICollection<ForumPost> PostList { get; set; }
    }

    public class ForumPost
    {
        [Key]
        public int PostID { get; set; }

        public string PostContent { get; set; }

        public DateTime DatePosted { get; set; }

        // Reference Nav Property
        [ForeignKey("ForumThread")]
        public int ThreadID { get; set; }

        // Reference Nav Property
        public virtual ForumThread ParentThread { get; set; }
    }
}
