using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VideoStoreManagementSystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoStore videoStore = new VideoStore();
            LoanPolicy loanPolicy = new LoanPolicy();
            loanPolicy.set_perday_rental_charge(20);

            while (true)
            {
                Console.WriteLine("BGK Video store");
                Console.WriteLine("1. Add video");
                Console.WriteLine("2. Add customer");
                Console.WriteLine("3. Rent video");
                Console.WriteLine("4. View due amount");
                Console.WriteLine("5. Pay due amount");
                Console.WriteLine("6. View videos");
                Console.WriteLine("7. Set rent per day amount");
                Console.WriteLine("0 to Exit");
                Console.WriteLine("Enter the choice as number(1 to 7)");

                int choice = Convert.ToInt32(Console.ReadLine());
                int membershipId;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the title");
                        string videoTitle = Console.ReadLine();
                        Console.WriteLine("Enter the category");
                        string videoCategory = Console.ReadLine();
                        Console.WriteLine("Enter number of copies");
                        int videoCopies = Convert.ToInt32(Console.ReadLine());
                        videoStore.addVideo(videoTitle,videoCategory,videoCopies);
                        Console.WriteLine("The video was added successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter customer name");
                        string customerName = Console.ReadLine();
                        Console.WriteLine("Enter customer phone number");
                        string customerPhoneNumber = Console.ReadLine();
                        videoStore.addMember(customerName, customerPhoneNumber);
                        Console.WriteLine("The customer was added successfully");
                        break;

                    case 3:
                        Console.WriteLine("Enter the membership id");

                        membershipId = Convert.ToInt32(Console.ReadLine());
                        if (!videoStore.isMemberAvailable(membershipId))
                        {
                            Console.WriteLine("Membership id is not available");
                        }
                        else
                        {
                            videoStore.displayVideos();
                            while (true)
                            {
                                Console.WriteLine("Enter the video id(0 to exit)");
                                int videoId = Convert.ToInt32(Console.ReadLine());
                                if (videoId == 0)
                                {
                                    break;
                                }

                                Console.WriteLine("Enter the rent days");
                                int rentDays = Convert.ToInt32(Console.ReadLine());

                                if (videoStore.isVideoAvailable(videoId))
                                {
                                    videoStore.addRentVideoList(membershipId, videoId, rentDays);
                                    videoStore.decreaseAvailableCount(videoId);
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, video is not available");
                                }
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the membership id");
                        membershipId = Convert.ToInt32(Console.ReadLine());
                        if (!videoStore.isMemberAvailable(membershipId))
                        {
                            Console.WriteLine("Membership Id is not available");
                        }
                        else
                        {
                            videoStore.viewRentDue(membershipId, loanPolicy);
                            Console.WriteLine("--End--");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter the membership id");
                        membershipId = Convert.ToInt32(Console.ReadLine());
                        if (!videoStore.isMemberAvailable(membershipId))
                        {
                            Console.WriteLine("Membership Id is not available");
                        }
                        else
                        {
                            videoStore.paymentRentDue(membershipId);
                            Console.WriteLine("--End--");
                        }
                        break;
                    case 6:
                        videoStore.displayVideos();
                        break;

                    case 7:
                        Console.WriteLine("Enter the rental charge");
                        double perday_rental_charge = Convert.ToInt32(Console.ReadLine());
                        loanPolicy.set_perday_rental_charge(perday_rental_charge);
                        break;
                }
                if (choice == 0)
                {
                    break;
                }
            }
        }
    }

    class Customer
    {
        private int membershipId;
        private string name;
        private string phoneNumber;

        public Customer(int membershipId, string name, string phoneNumber)
        {
            this.membershipId = membershipId;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public int getMembershipId()
        {
            return membershipId;
        }

        public void setMembershipId(int membershipId)
        {
            this.membershipId = membershipId;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setphoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public string tostring()
        {
            return this.getMembershipId() + " - " + this.getName() + " - " + this.getPhoneNumber();
        }
    }

    class LoanPolicy
    {
        private double perday_rental_charge;

        public double getPerday_rental_charge()
        {
            return perday_rental_charge;
        }

        public void set_perday_rental_charge(double perday_rental_charge)
        {
            this.perday_rental_charge = perday_rental_charge;
        }
    }

    class Video
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

    class VideoPlus : Video
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

    class VideoRental : Video
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

    class VideoStore
    {
        private Dictionary<int, Customer> customerList = new Dictionary<int, Customer>();
        private Dictionary<int, VideoPlus> videoList = new Dictionary<int, VideoPlus>();
        private Dictionary<int, List<VideoRental>> rentVideoList = new Dictionary<int, List<VideoRental>>();

        public void addVideo(string title, string category, int numberOfCopies)
        {
            VideoPlus video = new VideoPlus(videoList.Count() + 1, title, category, numberOfCopies, true);
            videoList.Add(videoList.Count() +1, video);
        }

        public void addMember(string name, string phoneNumber)
        {
            Customer customer = new Customer(customerList.Count() + 1, name, phoneNumber);
            customerList.Add(customerList.Count() + 1, customer);
            Console.WriteLine("Member id is : {0}", customerList.Count());
        }

        public void addRentVideoList(int membershipId, int videoId, int rentDays)
        {
            VideoRental videoRental = new VideoRental(videoId, videoList[videoId].getTitle(),videoList[videoId].getCategory(), rentDays, true );
            if (rentVideoList.ContainsKey(membershipId) == false)
            {
                rentVideoList.Add(membershipId,new List<VideoRental>());
                rentVideoList[membershipId].Add(videoRental);
            }
        }

        public void viewRentDue(int membershipId, LoanPolicy loanPolicy)
        {
            if (rentVideoList.ContainsKey(membershipId)==false)
            {
                Console.WriteLine("Nothing due!");
            }
            else
            {
                double duePayment = 0.0;
                Console.WriteLine("Id\t|\tTitle\t||\tCategory\t||\tRent Days");
                foreach (VideoRental videoRental in rentVideoList[membershipId])
                {
                    if (videoRental.isRent_status())
                    {
                        duePayment += videoRental.getrent_days() * loanPolicy.getPerday_rental_charge();
                        Console.WriteLine(videoRental.getId() + "\t|\t" + videoRental.getTitle() + "\t|\t" + videoRental.getCategory() + "\t|\t" + videoRental.getrent_days());
                    }
                    Console.WriteLine("Total Rent Due: {0}", duePayment);
                }
            }
        }

        public void paymentRentDue(int membershipId)
        {
            bool hasDueAmount = false;
            if (rentVideoList.ContainsKey(membershipId)==true)
            {
                foreach (VideoRental videoRental in rentVideoList[membershipId])
                {
                    if (videoRental.isRent_status())
                    {
                        hasDueAmount = true;
                        break;
                    }
                }
            }
            if (rentVideoList.ContainsKey(membershipId) == false || hasDueAmount == false)
            {
                Console.WriteLine("Nothing due");
            }
            else
            {
                foreach (VideoRental videoRental in rentVideoList[membershipId])
                {
                    videoRental.setRent_status(false);
                    videoList[videoRental.getId()].setNumberOfCopies(videoList[videoRental.getId()].getNumberOfCopies() + 1);
                }
                Console.WriteLine(customerList[membershipId].tostring());
                Console.WriteLine("Paid rent due payment successfully");
            }
        }

        public void displayVideos()
        {
            if (videoList.Count()== 0)
            {
                Console.WriteLine("No videos!");  
            }
            else
            {
                Console.WriteLine("Id\t|\tTitle\t|\tCategory\t|\tAvailable");
                foreach (KeyValuePair<int, VideoPlus> videoKeyindex in videoList )
                {
                    VideoPlus video = videoKeyindex.Value;
                    if (video.getNumberOfCopies() != 0)
                    {
                        Console.WriteLine(video.getId() + "|" + video.getTitle() + "|" + video.getCategory() + "|" + video.getNumberOfCopies());
                    }
                }
                Console.WriteLine("--End--");
            }
        }

        public bool isMemberAvailable(int membershipId)
        {
            if (customerList.ContainsKey(membershipId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void decreaseAvailableCount(int video_id)
        {
            videoList[video_id].setNumberOfCopies(videoList[video_id].getNumberOfCopies() - 1);
        }

        public bool isVideoAvailable(int video_id)
        {
            if (videoList[video_id].getNumberOfCopies() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
