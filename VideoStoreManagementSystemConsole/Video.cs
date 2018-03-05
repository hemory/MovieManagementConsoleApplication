namespace VideoStoreManagementSystemConsole
{
    public class Video
    {
        public int id;
        public string title;
        public string category;
        public Video() { }

        public Video(int id, string title, string category)
        {
            this.id = id;
            this.title = title;
            this.category = category;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getCategory()
        {
            return category;
        }

        public void setCategory(string category)
        {
            this.category = category;
        }
    }
}