namespace VideoStoreManagementSystemConsole
{
    public class VideoPlus : Video
    {
        private int numberOfCopies;
        private bool available;

        public VideoPlus(int id, string title, string category, int numberOfCopies, bool available)
        {
            this.id = id;
            this.title = title;
            this.category = category;
            this.numberOfCopies = numberOfCopies;
            this.available = available;
        }

        public int getNumberOfCopies()
        {
            return numberOfCopies;
        }

        public void setNumberOfCopies(int numberOfCopies)
        {
            this.numberOfCopies = numberOfCopies;
        }

        public bool isAvailable()
        {
            return isAvailable();
        }

        public void setAvailable(bool available)
        {
            this.available = available;
        }
    }
}