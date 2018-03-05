namespace VideoStoreManagementSystemConsole
{
    public class VideoRental : Video
    {
        private int rent_days;
        private bool rent_status;

        public VideoRental(int id, string title, string category, int rent_days, bool rent_status)
        {
            this.id = id;
            this.title = title;
            this.category = category;
            this.rent_days = rent_days;
            this.rent_status = rent_status;
        }

        public int getrent_days()
        {
            return rent_days;
        }

        public void setRent_days(int rent_days)
        {
            this.rent_days = rent_days;
        }

        public bool isRent_status()
        {
            return rent_status;
        }

        public void setRent_status(bool rent_status)
        {
            this.rent_status = rent_status;
        }
    }
}